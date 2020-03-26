using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using Event.Interfaces;

namespace Event.Portable.Events
{
    /// <summary>
    /// Forced event
    /// </summary>
    public class ForcedEvent : CategoryObject,  IEvent
    {
        #region Fields

        bool isEnabled = false;

        event Action ev = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ForcedEvent()
        {
        }

 
        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Forces event
        /// </summary>
        public void Force()
        {
            ev();
        }

        #endregion
    }
}
