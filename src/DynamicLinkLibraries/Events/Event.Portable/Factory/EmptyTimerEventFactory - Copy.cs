using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Portable.Factory
{
    /// <summary>
    /// Empty timer event factory
    /// </summary>
    public class EmptyTimerEventFactory : ITimerEventFactory, ITimerFactory
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static EmptyTimerEventFactory Singleton = new EmptyTimerEventFactory();


        /// <summary>
        /// Sets itself
        /// </summary>
        public static void Set()
        {
            StaticExtensionEventInterfaces.TimerFactory = Singleton;
            StaticExtensionEventInterfaces.TimerEventFactory = Singleton;
        }

        private EmptyTimerEventFactory()
        {

        }

        ITimerEvent ITimerEventFactory.NewTimer => new EmptyTimerEvent();

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            return new EmptyTimer(timeSpan);
        }

        class EmptyTimer : ITimer
        {
            TimeSpan timeSpan;

            Action ev;

            internal EmptyTimer(TimeSpan timeSpan)
            {
                this.timeSpan = timeSpan;
            }

            TimeSpan ITimer.TimeSpan => timeSpan;

            bool ITimer.IsEnabled { get; set; }

            event Action ITimer.Event
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
        }

        class EmptyTimerEvent : ITimerEvent
        {
            Action ev;

            TimeSpan ITimerEvent.TimeSpan { get; set; }
            bool IEvent.IsEnabled { get; set; }

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
        }

    }
}
