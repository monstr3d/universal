using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using CategoryTheory;

using Event.Interfaces;


namespace Event.Basic.Events
{
    /// <summary>
    /// Transient State Event
    /// </summary>
    [Serializable()]
    public class TransientProcessEvent : CategoryObject, IEvent, IEventHandler, ISerializable
    {
        #region Fields

        TimeSpan[] spans = new TimeSpan[0];

        private Action ev = () => { };

        private List<IEvent> events = new List<IEvent>();

        Action<IEvent> onAdd = (IEvent e) => { };
        
        Action<IEvent> onRemove = (IEvent e) => { };

        int currentStep;

        object loc = new object();

        bool isEnabled = false;

        DateTime previous = DateTime.Now;

        bool isRunning = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TransientProcessEvent()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TransientProcessEvent(SerializationInfo info, StreamingContext context)
        {
            spans = info.GetValue("TimeSpans", typeof(TimeSpan[])) as TimeSpan[];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TimeSpans", spans, typeof(TimeSpan[]));
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
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                Enable();
            }
        }

        #endregion

        #region IEventHandler Members

        void IEventHandler.Add(IEvent ev)
        {
            events.Add(ev);
            onAdd(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            events.Remove(ev);
            onRemove(ev);
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
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Time spans
        /// </summary>
        public TimeSpan[] TimeSpans
        {
            get
            {
                return spans;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception();
                }
                spans = value;
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Enanble/Disable operation
        /// </summary>
        void Enable()
        {
            lock (loc)
            {
                isRunning = false;
                if (isEnabled)
                {
                    previous = DateTime.Now;
                    foreach (IEvent ev in events)
                    {
                        ev.Event += EventHandler; // Adds event handler
                    }
                    return;
                }
                foreach (IEvent ev in events)
                {
                    ev.Event -= EventHandler;    // Removes event handler
                }
            }
        }

        /// <summary>
        /// Event handler
        /// </summary>
        void EventHandler()
        {
            if (isRunning)
            {
                previous = DateTime.Now;
                return;
            }
            lock (loc)
            {
                if (isRunning)
                {
                    return;
                }
                isRunning = true;
                currentStep = 0;
                Action act = AsyncEvent; // Asynchronous event
                act.BeginInvoke(null, null);
            }
        }

        /// <summary>
        /// Asynchronous event
        /// </summary>
        void AsyncEvent()
        {
            for (int i = currentStep; i < spans.Length; i++)
            {
                Thread.Sleep(spans[i]); // Sleep
                ev();                   // Raise event
            }
            DateTime now = DateTime.Now;
            DateTime dt = previous;
            for (int i = 0; i < spans.Length; i++)
            {
                dt += spans[i];
                if (dt > now)
                {
                    currentStep = i;
                    Action act = AsyncEvent;
                    isRunning = true;
                    act.BeginInvoke(null, null);
                    return;
                }

            }
            isRunning = false;
        }

        #endregion

    }
}
