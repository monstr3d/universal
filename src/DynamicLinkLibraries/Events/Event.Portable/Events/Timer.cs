using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using DataPerformer.Interfaces;
using Event.Interfaces;


namespace Event.Portable.Events
{
    public class Timer : CategoryObject, ITimerEvent, 
          IRemovableObject, INativeEvent, ICalculationReason
    {
        #region Fields

        protected ITimerEvent timer;

        protected TimeSpan timeSpan;

        protected event Action ev;

        protected Action locked;

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

 
        #region Private Members

        void Event()
        {
            ev();
        }

        #endregion

    }
}
