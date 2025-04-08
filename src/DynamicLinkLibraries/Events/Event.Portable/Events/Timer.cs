using System;
using System.Collections.Generic;
using CategoryTheory;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

using Event.Interfaces;
using NamedTree;


namespace Event.Portable.Events
{
    /// <summary>
    /// Timer
    /// </summary>
    public class Timer : CategoryObject, ITimerEvent,
          IDisposable, INativeEvent, ICalculationReason, IMeasurements
    {
        #region Fields

        protected ITimerEvent timer;

        protected TimeSpan timeSpan;

        protected event Action ev;

        protected Action locked;

        private string calculationReason = "";

        IMeasurement measurement;

        event Action onPrepare = () => { };

        DateTime start;


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
            double a = 0;
            measurement = new ReplacedParameterMeasurement(a, GetTime, "Time", this);
        }


        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            timer.DisdposeItself();
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

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
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
                    start = DateTime.Now;
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
            ev?.Invoke();
        }

        #endregion

        #region Private Members

        void Event()
        {
            ev?.Invoke();
        }

        #endregion

        object GetTime()
        {
            var dt = DateTime.Now - start;
            var a = dt.TotalSeconds;
            if (a > 100)
            {

            }
            return a;
        }

        #region IMeasurement Members


        IMeasurement IMeasurements.this[int number] => measurement;

        int IMeasurements.Count => 1;

        bool IMeasurements.IsUpdated { get; set; } = false;

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [measurement];

        void IMeasurements.UpdateMeasurements()
        {

        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion
    }
}