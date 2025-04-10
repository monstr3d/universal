using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

using Motion6D.Interfaces;
using Vector3D;
using ErrorHandler;
using NamedTree;

namespace Motion6D
{
    /// <summary>
    /// Accelerated position
    /// </summary>
    [Serializable()]
    [Leaf<IPosition>]
    public class AcceleratedPosition : CategoryObject, ISerializable, IAlias, IPosition,
        IAcceleration, IExtendedDifferentialEquationSolver, IVelocity,
        IStarted, IChildren<IAssociatedObject>, IDataConsumer, IPostSetArrow
    {
        #region Fields

        protected Vector3DProcessor vp = new();

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Relative accelerations
        /// </summary>
        protected double[] relativeAcc = new double[3];
        
        
        const Double a = 0;


        private double[] position = new double[3];


        private double[] absoluteAcc = new double[3];

        private bool isUpdated = false;

        private double[] absoluteVel = new double[3];

        private double[] relativeVel = new double[3];

        private double[] initialVector = new double[3];

        private double[] buffer = new double[3];

        private double[] buffer1 = new double[3];

        private double[] initial = new double[6];

        private MeasurementDerivation[] measures = new MeasurementDerivation[6];

        private IAssociatedObject[] children = new IAssociatedObject[1];

        private RelativeField field = new RelativeField(true);

        static private readonly string[] names = new string[] { "x", "y", "z", "Vx", "Vy", "Vz" };

        private Dictionary<string, int> dn = new Dictionary<string, int>();

        private List<string> ln = new List<string>();

        private Action<double[]> transform;

        private IReferenceFrame parent;

        private ReferenceFrame frame;

        private IAcceleration acc;

        private IAngularAcceleration angacc;

        private IVelocity vel;

        private IAngularVelocity angvel;

        private IList<IMeasurements> measurements = new List<IMeasurements>();

        private IMeasurement[] measuresAcc = new IMeasurement[3];

        private Dictionary<int, string> meas = new Dictionary<int, string>();

        private IDataConsumer cons;

        private bool isSerialized = false;

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public AcceleratedPosition()
        {
            PostConstruct();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AcceleratedPosition(SerializationInfo info, StreamingContext context)
        {
            initial = info.GetValue("Initial", typeof(double[])) as double[];
            meas = info.GetValue("Measures", typeof(Dictionary<int, string>)) as Dictionary<int, string>;
            field = RelativeField.Load(info, this);
            PostConstruct();
            isSerialized = true;
        }

        #endregion

        #region ISerializable Members


        /// <summary>
        /// Implementation of serialization
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Initial", initial, typeof(double[]));
            info.AddValue("Measures", meas, typeof(Dictionary<int, string>));
            field.Save(info);
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return ln; }
        }

        object IAlias.this[string name]
        {
            get
            {
                return initial[dn[name]];
            }
            set
            {
                initial[dn[name]] = (double)value;
            }
        }

        object IAlias.GetType(string name)
        {
            return a;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IPosition Members

        double[] IPosition.Position
        {
            get { return position; }
        }

        IReferenceFrame IPosition.Parent
        {
            get
            {
                return parent as IReferenceFrame;
            }
            set
            {
                parent = value;
                if (!isSerialized)
                {
                    PostCreateFrame();
                }
            }
        }

        object IPosition.Parameters
        {
            get
            {
                throw new ErrorHandler.OwnException("The method or operation is not implemented.");
            }
            set
            {
                throw new ErrorHandler.OwnException("The method or operation is not implemented.");
            }
        }

        void IPosition.Update()
        {
        }

        #endregion

        #region IVelocity Members

        double[] IVelocity.Velocity
        {
            get { return absoluteVel; }
        }
/*
        double[] IVelocity.RevativeVelocity
        {
            get { return relativeVel; }
        }
*/
        #endregion

        #region IAcceleration Members

        double[] IAcceleration.LinearAcceleration
        {
            get { return absoluteAcc; }
        }

        double[] IAcceleration.RelativeAcceleration
        {
            get { return relativeAcc; }
        }

        #endregion

        #region IDifferentialEquationSolver Members

        void IDifferentialEquationSolver.CalculateDerivations()
        {
        }

        void IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            Array.Copy(position, offset, variables, 0, 3);
            Array.Copy(relativeVel, offset + 3, variables, 3, 3);
        }

        int VariablesCount
        {
            get
            {
                IMeasurements m = this;
                return m.Count;
            }
        }


        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measures.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measures[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            cons.UpdateChildrenData();
            transform(relativeAcc);
            for (int i = 0; i < relativeAcc.Length; i++)
            {
                relativeAcc[i] += (double)measuresAcc[i].Parameter();
            }
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Array.Copy(initial, position, 3);
            Array.Copy(initial, 3, relativeVel, 0, 3);
        }


        #endregion

        #region IChildrenObject Members

        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            this.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.ResetAll();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
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

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
            PostCreateFrame();
            isSerialized = false;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Field
        /// </summary>
        public RelativeField Field
        {
            get
            {
                return field;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public void Post()
        {
            cons = this;
            transform = VectorOperations.CreateTransformer(InerialAcceleration, this);
            for (int i = 0; i < measuresAcc.Length; i++)
            {
                string s = meas[i];
                IMeasurement m = this.FindMeasurement(s, false);
                measuresAcc[i] = m;
            }
        }

        /// <summary>
        /// Measurements
        /// </summary>
        public Dictionary<int, string> Measures
        {
            get
            {
                return meas;
            }
        }


        private void PostConstruct()
        {
            children[0] = field;
            IPositionObject p = field;
            p.Position = this;
            for (int i = 0; i < names.Length; i++)
            {
                ln.Add(names[i]);
                dn[names[i]] = i;
            }
            transform = InerialAcceleration;
            Measurement[] ma = [new Measurement(getAx, "", this), new Measurement(getAy, "", this), new Measurement(getAz, "", this)];
            MeasurementDerivation[] md =[
                new MeasurementDerivation(a, getVx, ma[0], "Vx", this),
                new MeasurementDerivation(a, getVy, ma[1], "Vy", this),
                new MeasurementDerivation(a, getVz, ma[2], "Vz", this)];
            MeasurementDerivation[] mc = [
                new MeasurementDerivation(a, getX, md[0], "X", this),
                new MeasurementDerivation(a, getY, md[1], "Y", this),
                new MeasurementDerivation(a, getZ, md[2], "Z", this)];
            for (int i = 0; i < 3; i++)
            {
                measures[i] = mc[i];
                measures[i + 3] = md[i];
            }
        }

        private void InerialAcceleration(double[] x)
        {
           ReferenceFrame frame = this.GetFrame();
            IAngularVelocity av = frame as IAngularVelocity;
            vp.CalculateRelativeAcceleration(absoluteAcc, angvel.Omega, angacc.AngularAcceleration,
                vel.Velocity, position, buffer, buffer1, x);
        }

        private void PostCreateFrame()
        {
            try
            {
                frame = this.GetFrame();
                acc = frame.GetSimpleObject<IAcceleration>("Object should have acceleration");
                angvel = frame.GetSimpleObject<IAngularVelocity>("Object should have angular velocity");
                vel = frame.GetSimpleObject<IVelocity>("Object should have velocity");
                angacc = frame.GetSimpleObject<IAngularAcceleration>("Object should have angular acceleration");

            }
            catch (Exception e)
            {
                e.HandleException(10);
                IPosition p = this;
                p.Parent = null;
                throw e;
            }
 
        }

        object getAx()
        {
            return relativeAcc[0];
        }

        object getAy()
        {
            return relativeAcc[1];
        }
        object getAz()
        {
            return relativeAcc[2];
        }

        object getVx()
        {
            return relativeVel[0];
        }

        object getVy()
        {
            return relativeVel[1];
        }
        object getVz()
        {
            return relativeVel[2];
        }

        object getX()
        {
            return position[0];
        }

        object getY()
        {
            return position[1];
        }
        object getZ()
        {
            return position[2];
        }
        #endregion

        #region IStateDoubleVariables Members

        List<string> IStateDoubleVariables.Variables
        {
            get { throw new ErrorHandler.WriteProhibitedException(); }
        }

        double[] IStateDoubleVariables.Vector
        {
            get
            {
                throw new ErrorHandler.WriteProhibitedException();
            }
            set
            {
                throw new ErrorHandler.WriteProhibitedException();
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => measures;

        INode<IPosition> INode<IPosition>.Parent 
        
        { 
            get
            {
                return parent;
            }

            set
            {
                IPosition p = this;
                p.Parent = value as IReferenceFrame;
            }
        }
        IEnumerable<INode<IPosition>> INode<IPosition>.Nodes { get => []; set { } }

        IPosition INode<IPosition>.Value => this;

        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
           new  ErrorHandler.WriteProhibitedException();
        }

        void IChildren<IAssociatedObject>.AddChild(IAssociatedObject child)
        {
        }

        void IChildren<IAssociatedObject>.RemoveChild(IAssociatedObject child)
        {
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new ErrorHandler.OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        void INode<IPosition>.Add(INode<IPosition> node)
        {
            throw new IllegalSetPropetryException("Position");
        }

        void INode<IPosition>.Remove(INode<IPosition> node)
        {
        }


        #endregion

    }
}
