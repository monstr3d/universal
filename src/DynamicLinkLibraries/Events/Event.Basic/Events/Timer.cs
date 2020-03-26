using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using CategoryTheory;

using DataPerformer.Interfaces;

using Event.Interfaces;

namespace Event.Basic.Events
{
    /// <summary>
    /// Timer
    /// </summary>
    [Serializable()]
    public class Timer : CategoryObject, ITimerEvent, ISerializable,
         IRemovableObject, INativeEvent, ICalculationReason
    {
        #region Fields

        ITimerEvent timer;

        TimeSpan timeSpan;

        event Action ev;

        Action locked;

        private string calculationReason = "";

        event Action onPrepare = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Timer()
        {
            timer = StaticExtensionEventInterfaces.TimerEventFactory.NewTimer;
            Action act = Event;
            locked = act.LockedAction();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Timer(SerializationInfo info, StreamingContext context)
            : this()
        {
            (this as ITimerEvent).TimeSpan = (TimeSpan)info.GetValue("TimeSpan", typeof(TimeSpan));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TimeSpan", timeSpan, typeof(TimeSpan));
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            timer.RemoveItself();
        }


        #endregion

        #region ITimerEvent Members

        TimeSpan ITimerEvent.TimeSpan
        {
            get
            {
                return timeSpan;
            }
            set
            {
                if (timeSpan.Equals(value))
                {
                    return;
                }
                timeSpan = value;
                if (timer != null)
                {
                    timer.TimeSpan = value;
                }
            }
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add
            {
                ev += value;
            }
            remove
            {
                ev -= value;
            }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return timer.IsEnabled;
            }
            set
            {
                if (calculationReason.Equals("Realtime"))
                {
                    if (timer.IsEnabled == value)
                    {
                        return;
                    }
                    if (value)
                    {
                        onPrepare();
                        timer.Event += locked;
                    }
                    else
                    {
                        timer.Event -= locked;
                    }
                    timer.IsEnabled = value;
                }
            }
        }

        #endregion

        #region ICalculationReason Members

        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
            }
        }

        #endregion

        #region INativeEvent Members

        /// <summary>
        /// Forces event
        /// </summary>
        void INativeEvent.Force()
        {
            ev();
        }

        #endregion

        #region Public Members

        #endregion

        #region Private Members

        void Event()
        {
            ev();
        }

        #endregion

    }
}
