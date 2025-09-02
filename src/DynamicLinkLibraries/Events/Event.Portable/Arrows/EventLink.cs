using System;

using CategoryTheory;

using Event.Interfaces;
using NamedTree;

namespace Event.Portable.Arrows
{
    /// <summary>
    /// Link between event and its event handler
    /// </summary>
    public class EventLink : ICategoryArrow,  IDisposable
    {
        #region Fields

        /// <summary>
        /// Target
        /// </summary>
        IEvent target;

        /// <summary>
        /// Source
        /// </summary>
        IEventHandler source;

        /// <summary>
        /// Associated object
        /// </summary>
        object obj;

        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Source
        {
            get => source as ICategoryObject;
            set
            {
                // Checks whether the source
                // implements the legal interface
                source = value.GetSource<IEventHandler>();
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Target
        {
            get =>  target as ICategoryObject;
            set
            {   // Checks whether the target
                // implements the legal interface
                target = value.GetTarget<IEvent>();
                source.AddChild(target);
            }
        }

        /// <summary>
        /// The associated object
        /// </summary>
        object IAssociatedObject.Object { get => obj; set => obj = value; }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if ((source == null) | (target == null))
            {
                return;
            }
            source.RemoveChild(target);
            source = null;
            target = null;
            GC.Collect();
        }


        #endregion

        #region Public

        /// <summary>
        /// Event handler (source)
        /// </summary>
        public IEventHandler Source { get => source; }

        /// <summary>
        /// The event (target)
        /// </summary>
        public IEvent Target { get => target; }

        #endregion

    }
}
