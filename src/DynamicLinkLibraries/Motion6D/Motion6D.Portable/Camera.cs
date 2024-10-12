using System;
using System.Collections.Generic;

using CategoryTheory;


using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using DataPerformer.Interfaces;

using Event.Interfaces;

using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Basic camera
    /// </summary>
    public abstract class Camera : Position, ICategoryObject, IVisibleConsumer, IEventHandler, 
        ICalculationReason, IAllowCodeCreation
    {

        #region Fields

        object obj;

   
        /// <summary>
        /// Width
        /// </summary>
        protected int width;

        /// <summary>
        /// Heght
        /// </summary>
        protected int height;

        /// <summary>
        /// Visualization angle
        /// </summary>
        protected double fieldOfView = 40;


        protected IPosition cameraPositon;


   
        /// <summary>
        /// Perspective matrix
        /// </summary>
        protected double[,] matr4 = new double[4, 4];

        /// <summary>
        /// Helper frame
        /// </summary>
        protected ReferenceFrame helperFrame = new ReferenceFrame();

        /// <summary>
        /// Vector
        /// </summary>
        protected double[] vector16 = new double[16];

        /// <summary>
        /// Shift
        /// </summary>
        protected double[] shift = new double[3];

        protected double near = 1;

        protected double far = 200;

    
        /// <summary>
        /// List of visible by camera objects
        /// </summary>
        protected List<IPosition> visible = new List<IPosition>();


        event Action<IVisible> onAdd;

        event Action<IVisible> onRemove;

        event Action<IVisible> onPost;


        protected string calculationReason = "";

        protected bool allowCodeCreation = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Camera()
        {

        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IVisibleConsumer Members

        void IVisibleConsumer.Add(IVisible visible)
        {
            AddVisible(visible.Position);
            onAdd?.Invoke(visible);
        }

        void IVisibleConsumer.Remove(IVisible visible)
        {
            if (visible != null)
            {
                RemoveVisible(visible.Position);
                onRemove?.Invoke(visible);
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        /// <param name="visible">Visible object</param>
        void IVisibleConsumer.Post(IVisible visible)
        {
            if (visible is ICameraConsumer)
            {
                (visible as ICameraConsumer).Add(this);
                onPost?.Invoke(visible);
            }
        }

        event Action<IVisible> IVisibleConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        event Action<IVisible> IVisibleConsumer.OnPost
        {
            add { onPost += value; }
            remove { onPost -= value; }
        }

        #endregion

        #region IEventHandler Members

        protected List<IEvent> events = new();

        protected event Action<IEvent> onAddEvent;
        
        protected event Action<IEvent> onRemoveEvent;

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
            onAddEvent?.Invoke(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
            onRemoveEvent?.Invoke(ev);
        }

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                foreach (IEvent ev in events)
                {
                    yield return ev;
                }
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }

        #endregion

        #region ICalculationReason Members
        string ICalculationReason.CalculationReason
        {
            get => calculationReason;
            set { calculationReason = value; SetCalculationReason(); }
        }

        #endregion

        #region IAllowCodeCreation Members

        bool IAllowCodeCreation.AllowCodeCreation => allowCodeCreation;

        #endregion

        #region Overriden Members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return this.ObjectArrowName() + base.ToString() + ")";
        }

        #endregion

        #region Abstract Members

        /// <summary>
        /// Sets a calculation reason
        /// </summary>
        protected abstract void SetCalculationReason();

        /// <summary>
        /// Updates realtime
        /// </summary>
        // !!! DELETE       protected abstract void RealtimeUpdate();

        #endregion

   
        #region Virtual Members

        // Scale
        public virtual double Scale
        {
            get;
            set;
        }


        public virtual double NearPlaneDistance
        {
            get => near;
            set => near = value;
        }

        public virtual double FarPlaneDistance
        {
            get => far;
            set => far = value;
        }

        public virtual double FieldOfView
        {
            get => fieldOfView;
            set
            {
                fieldOfView = value;
                sin = Math.Sin(Math.PI * fieldOfView / 360.0);
            }
        }

        public virtual int Width
        {
            get => width;
            set => width = value;
        }

        public virtual int Height
        {
            get => height;
            set => height = value;
        }

        public virtual bool Perspective
        { get; set; } = true;

        public virtual double Aspect
        {
            get => ((double)Height) / (double)Width;
        }


        #endregion

        #region Specific Members

        /// <summary>
        /// Adds visible object to itself
        /// </summary>
        /// <param name="p">The visible object for adding</param>
        public virtual void AddVisible(IPosition p)
        {
            if (p == null)
            {
                return;
            }
            if (visible.Contains(p))
            {
                return;
            }
            object o = p.Parameters;
            if (!(o is IVisibleCollection))
            {
                visible.Add(p);
            }
            else
            {
                IVisibleCollection vc = o as IVisibleCollection;
                int count = vc.Count;
                for (int i = 0; i < count; i++)
                {
                    visible.Add(vc[i]);
                }
            }
        }

        /// <summary>
        /// Removes visible object
        /// </summary>
        /// <param name="p">The visible object for removing</param>
        public virtual void RemoveVisible(IPosition p)
        {
            if (p == null)
            {
                return;
            }
            object obj = p.Parameters;
            if (obj is IVisibleCollection)
            {
                IVisibleCollection vc = obj as IVisibleCollection;
                int n = vc.Count;
                for (int i = 0; i < n; i++)
                {
                    IPosition pp = vc[i];
                    if (visible.Contains(pp))
                    {
                        visible.Remove(pp);
                        object par = pp.Parameters;
                        if (par is ICameraConsumer)
                        {
                            (par as ICameraConsumer).Remove(this);
                        }
                    }
                }
            }
            if (!visible.Contains(p))
            {
                return;
            }
            visible.Remove(p);
            if (obj is ICameraConsumer)
            {
                ICameraConsumer cc = obj as ICameraConsumer;
                cc.Remove(this);
            }
        }

        /// <summary>
        /// Updates image
        /// </summary>
        public abstract void UpdateImage();

        /// <summary>
        /// Children count
        /// </summary>
        public int Count
        {
            get
            {
                return visible.Count;
            }
        }

        /// <summary>
        /// The position of n - th visible object
        /// </summary>
        /// <param name="n">visible objectd number</param>
        /// <returns>The position of n - th visible object</returns>
        public IPosition this[int n]
        {
            get
            {
                return visible[n];
            }
        }

        protected  Action<object, Action> updateImage;


        protected double sin = 2 * Math.Asin((20 * Math.PI) / 180.0);


        public event Action<object, Action> OnUpdate
        {
            add { updateImage += value; }
            remove { updateImage -= value; }
        }

        /// <summary>
        /// Updates all frames on desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        static public void UpdateAll(IDesktop desktop)
        {
            IEnumerable<IObjectLabel> objs = desktop.Objects;
            foreach (IAssociatedObject obj in objs)
            {
                object o = obj.Object;
                if (o is Camera c)
                {
                    c.UpdateImage();
                }
            }
        }

        protected event Action<IEvent> OnAddEvent;

 

        #endregion

    }
}
