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
    public class EventLink : CategoryArrow,  IRemovableObject
    {
        #region Fields

        IEvent target;

        IEventHandler source;

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
        public override ICategoryObject Source
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
        public override ICategoryObject Target
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

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if ((source == null) | (target == null))
            {
                return;
            }
            source.Remove(target);
            source = null;
        }


        #endregion

    

    }
}
