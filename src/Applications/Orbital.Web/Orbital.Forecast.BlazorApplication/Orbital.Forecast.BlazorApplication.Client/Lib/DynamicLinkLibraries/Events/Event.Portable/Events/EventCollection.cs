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
    /// Collection of events
    /// </summary>
    public class EventCollection : CategoryObject,  IEvent, IEventHandler
    {
        #region Fields

        List<IEvent> ev = new List<IEvent>();

        bool isEnabled = false;

        event Action<IEvent> onAdd = (IEvent e) => { };

        event Action<IEvent> onRemove = (IEvent e) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventCollection()
        {

        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add
            {
                foreach (IEvent e in ev)
                {
                    e.Event += value;
                }
            }
            remove
            {
                foreach (IEvent e in ev)
                {
                    e.Event -= value;
                }
            }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                foreach (IEvent e in ev)
                {
                    e.IsEnabled = value;
                }
                isEnabled = value;
            }
        }

        #endregion

        #region IEventHandler Members

        void IEventHandler.Add(IEvent ev)
        {
            this.ev.Add(ev);
            onAdd(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            this.ev.Remove(ev);
        }


        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                foreach (IEvent e in ev)
                {
                    yield return e;
                }
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        #endregion
    }
}
