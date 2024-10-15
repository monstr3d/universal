using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Event.Interfaces;

namespace Event.Portable.Arrows
{
    /// <summary>
    /// Link between event and its handler
    /// </summary>
    public class EventLink : ICategoryArrow,  IDisposable
    {
        #region Fields

        IEvent target;

        IEventHandler source;

        object obj;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventLink()
        {

        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetSource<IEventHandler>();
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IEvent>();
                source.Add(target);
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
            source.Remove(target);
            source = null;
        }


        #endregion

        #region Public

        public IEvent Source { get => source; }

        #endregion


    }
}
