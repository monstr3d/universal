using System;
using System.Collections.Generic;
using System.Text;


using CategoryTheory;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using Motion6D.Interfaces;
using NamedTree;
using RealMatrixProcessor;
using Vector3D;

namespace Motion6D.Portable
{
    /// <summary>
    /// Rigid reference frame
    /// </summary>
    public class RigidReferenceFrame : CategoryObject, IReferenceFrame,
       IPostLoadPosition, IPostSetArrow, IAlias, IStarted
    {

        #region Fields

        protected Vector3DProcessor vp = new();

        protected RealMatrix realMatrix = new();

        protected ReferenceFrame own = new Motion6DAcceleratedFrame();

        private ReferenceFrame relative = new Motion6DAcceleratedFrame();

        /// <summary>
        /// Relative position
        /// </summary>
        protected double[] relativePosition = new double[] { 0, 0, 0 };

        /// <summary>
        /// Relarive quaternion components
        /// </summary>
        protected double[] relativeQuaternion = new double[] { 1, 0, 0, 0 };

        List<IPosition> children = new List<IPosition>();

        /// <summary>
        /// Parent frame
        /// </summary>
        protected IReferenceFrame parent;
   
        /// <summary>
        /// Associated parameters
        /// </summary>
        protected object parameters;

        //protected double[,] relativeMatrix = new double[3, 3];

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] q44 = new double[4, 4];


        /// <summary>
        /// Linear velocity
        /// </summary>
        protected double[] velocity = new double[] { 0, 0, 0 };

        // protected double[] relativeVelocity = new double[] { 0, 0, 0 };

        /// <summary>
        /// Angular velocity
        /// </summary>
        protected double[] omega = new double[] { 0, 0, 0 };

        protected string[] aliasNames = new string[] { "X", "Y", "Z", "Roll", "Pitch", "Yaw" };

        protected Dictionary<string, int> alinames = new Dictionary<string, int>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RigidReferenceFrame()
        {
            for (int i = 0; i < aliasNames.Length; i++)
            {
                alinames[aliasNames[i]] = i;
            }
            Init();
        }


        protected RigidReferenceFrame(object obj)
        {

        }


        #endregion

        #region IReferenceFrame Members

        /// <summary>
        /// Own frame
        /// </summary>
        public ReferenceFrame Own
        {
            get { return own; }
        }

  

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Start(time);
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames => aliasNames;

        object IAlias.this[string name] { get => GetAliasValue(name); set => SetAliasValue(name, value); }

        event Action<IAlias, string> change;

        event Action<IAlias, string> IAlias.OnChange
        {
            add
            {
                change += value;
            }

            remove
            {
                change -= value;
            }
        }

        event Action<IPosition> INode<IPosition>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IPosition> INode<IPosition>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        object IAlias.GetType(string name)
        {
            return GetAliasType(name);
        }

        #endregion

        #region IAlias Support


        EulerAngles angles = new EulerAngles();

        protected virtual object GetAliasValue(string name)
        {
            int i = alinames[name];
            if (i < 3)
            {
                return relative.Position[i];
            }
            vp.Set(angles, relative.Quaternion);
            switch (i - 3)
            {
                case 0: return angles.roll;
                case 1: return angles.pitch;
                case 2: return angles.yaw;
            }
            return 0;
        }


        protected virtual void SetAliasValue(string name, object value)
        {
            double v = (double)value;
            int i = alinames[name];
            if (i < 3)
            {
                relative.Position[i] = v;
            }
            if (i < 9)
            {
                vp.Set(angles, relative.Quaternion);
                switch (i - 6)
                {
                    case 0:
                        angles.roll = v;
                        break;
                    case 1:
                        angles.pitch = v;
                        break;
                    case 2:
                        angles.yaw = v;
                        break;
                }
                vp.ToQuaternion(angles, relative.Quaternion);
            }
        }


        protected virtual object GetAliasType(string name)
        {
            return (double)0;
        }


        #endregion

        #region IPosition Members

        double[] IPosition.Position
        {
            get { return own.Position; }
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        public virtual IReferenceFrame Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value != null & parent != null)
                {
                    throw new ErrorHandler.OwnException("Parent");
                }
                parent = value;
                if (value == null)
                {
                    owp = Motion6DFrame.Base;
                    return;
                }
                if (IsSerialized)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        public virtual object Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }


        /// <summary>
        /// Updates itself
        /// </summary>
        public virtual void Update()
        {
            ReferenceFrame b = BaseFrame;
            own.Set(b, relative);
        }

        #endregion

        #region IPostLoadPosition Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public virtual void PostLoadPosition()
        {
            CreateFrame();
            CopyPositionToRelativeFrame();
            CopyQuaternionToRelativeFrame();
            Init();
            relative.SetMatrix();
        }


        #endregion

        #region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public virtual void PostSetArrow()
        {
            PostSetParameters();
            CreateFrame();
        }

        #endregion

        #region Specific Members

        #region Public Members


        /// <summary>
        /// Copies position to relative reference frame
        /// </summary>
        public void CopyPositionToRelativeFrame()
        {
            if (IsSerialized)
            {
                return;
            }
            Array.Copy(relativePosition, relative.Position, 3);
        }


        /// <summary>
        /// Copies quaternion to relative reference frame
        /// </summary>
        public virtual void CopyQuaternionToRelativeFrame()
        {
            if (IsSerialized)
            {
                return;
            }
            Array.Copy(relativeQuaternion, relative.Quaternion, 4);
            relative.SetMatrix();
        }

        /// <summary>
        /// Copies whole 6D position to relative reference frame
        /// </summary>
        public void Copy6DPosition()
        {
            CopyPositionToRelativeFrame();
            CopyQuaternionToRelativeFrame();
        }

        /// <summary>
        /// Relative position
        /// </summary>
        public double[] RelativePosition
        {
            get { return relativePosition; }
        }

        /// <summary>
        /// Relative matrix
        /// </summary>
        public virtual double[,] RelativeMatrix
        {
            get
            {
                return relative.Matrix;
            }
            set
            {
                vp.MatrixToQuaternion(value, relativeQuaternion);
                CopyQuaternionToRelativeFrame();
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        public void Init()
        {
            if (relative == null)
            {
                return;
            }
            double[] q = relative.Quaternion;
            for (int i = 0; i < q.Length; i++)
            {
                q[i] = relativeQuaternion[i];
            }
            double[] p = relative.Position;
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = relativePosition[i];
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// The "is serialized" sign
        /// </summary>
        protected bool IsSerialized
        {
            get;
            set;
        } = false;


        /// <summary>
        /// Post set parameteres operation
        /// </summary>
        protected virtual void PostSetParameters()
        {
            Parameters = parameters;
        }



        /// <summary>
        /// Base frame
        /// </summary>
        protected ReferenceFrame BaseFrame
        {
            get
            {
                if (parent != null)
                {
                    return parent.Own;
                }
                return Motion6DFrame.Base;
            }
        }

        /// <summary>
        /// Creates frame
        /// </summary>
        protected virtual void CreateFrame()
        {
            if (IsAcceleration)
            {
                relative = new Motion6DAcceleratedFrame();
                owp = new Motion6DAcceleratedFrame();
            }
            else if (IsVelocity & IsAngularVelocity)
            {
                relative = new Motion6DFrame();
                owp = new Motion6DFrame();
            }
            else if (IsAngularVelocity)
            {
                relative = new RotatedFrame();
                owp = new RotatedFrame();
            }
            else if (IsVelocity)
            {
                relative = new MovedFrame();
                owp = new MovedFrame();
            }
            else
            {
                relative = new ReferenceFrame();
                owp = new ReferenceFrame();
            }
        }

        /// <summary>
        /// Relative reference frame
        /// </summary>
        protected ReferenceFrame Relative
        {
            get
            {
                return relative;
            }
            set
            {
                relative = value;
            }
        }

        protected void ClearAliases()
        {
            aliasNames = new string[0];
            alinames.Clear();
        }
       
        /// <summary>
        /// Start
        /// </summary>
        /// <param name="time">Time</param>
        protected virtual void Start(double time)
        {
            Update();
        }

        void INode<IPosition>.Add(INode<IPosition> node)
        {
            var position = node as IPosition;
            children.Add(position);
        }

        void INode<IPosition>.Remove(INode<IPosition> node)
        {
            var position = node as IPosition;
            children.Remove(position);
        }

        /// <summary>
        /// Own frame
        /// </summary>
        protected ReferenceFrame owp
        {
            set
            {
                own = value;
            }
        }

        /// <summary>
        /// The "is acceleration" sign
        /// </summary>
        protected virtual bool IsAcceleration
        {
            get
            {
                if (parent == null)
                {
                    return true;
                }
                return parent.Own is IAcceleration;
            }
        }

        /// <summary>
        /// Detects velocity support of ReferenceFrame class
        /// </summary>
        protected virtual bool IsVelocity
        {
            get
            {
                if (parent == null) // If parent frame is null
                {
                    return true;
                }
                return parent.Own is IVelocity; // Parent frame implements IVelocity interface
            }
        }

        /// <summary>
        /// The "is angular velocity" sign
        /// </summary>
        protected virtual bool IsAngularVelocity
        {
            get
            {
                if (parent == null)
                {
                    return true;
                }
                return parent.Own is IAngularVelocity;
            }
        }

        #endregion

        #region Internal Members

        internal ReferenceFrame RelativeFrame => relative;

        INode<IPosition> INode<IPosition>.Parent { get => this.Parent; set => Parent = value as IReferenceFrame; }
   
        IPosition INode<IPosition>.Value => this;

        /// <summary>
        /// Children objects
        /// </summary>
        IEnumerable<INode<IPosition>> INode<IPosition>.Nodes { get => children; set { } }

    
        #endregion

        #endregion

    }
}
