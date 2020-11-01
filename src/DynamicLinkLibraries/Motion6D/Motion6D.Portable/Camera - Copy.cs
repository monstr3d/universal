using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using Motion6D.Interfaces;

using Event.Interfaces;
using Motion6D.Portable.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Basic camera
    /// </summary>
    public abstract class Camera : Position, ICategoryObject, IVisibleConsumer, IEventHandler
    {

        #region Fields

        /// <summary>
        /// List of visible by camera objects
        /// </summary>
        protected List<IPosition> visible = new List<IPosition>();

        #region Add Remove Events

        /// <summary>
        /// Add event
        /// </summary>
        event Action<IVisible> onAdd = (IVisible v) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IVisible> onRemove = (IVisible v) => { };

        /// <summary>
        /// Post event
        /// </summary>
        event Action<IVisible> onPost = (IVisible v) => { };

        /// <summary>
        /// Add event 
        /// </summary>
        event Action<IEvent> onAddEvent = (IEvent e) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IEvent> onRemoveEvent = (IEvent e) => { };

        /// <summary>
        /// Events
        /// </summary>
        List<IEvent> events = new List<IEvent>();

        #endregion

        /// <summary>
        /// Attached oject
        /// </summary>
        private object obj;

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
            onAdd(visible);
        }

        void IVisibleConsumer.Remove(IVisible visible)
        {
            if (visible != null)
            {
                RemoveVisible(visible.Position);
                onRemove(visible);
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
                onPost(visible);
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

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
            onAddEvent(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
            onRemoveEvent(ev);
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

        #region Virtual Members

        /// <summary>
        /// Scale
        /// </summary>
        public virtual double Scale
        {
            get
            {
                return 1;
            }
            set
            {
            }
        }

        /// <summary>
        /// Updates real time
        /// </summary>
        public virtual void UpdateRealTime()
        {
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
                if (o is Camera)
                {
                    Camera c = o as Camera;
                    c.UpdateImage();
                }
            }
        }

        #endregion

    }
}
