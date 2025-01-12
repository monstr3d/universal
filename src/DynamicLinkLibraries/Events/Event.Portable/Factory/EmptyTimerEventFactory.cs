
namespace Event.Portable.Factory
{
    /// <summary>
    /// Empty timer event factory
    /// </summary>
    public class EmptyTimerEventFactory : Event.Interfaces.ITimerEventFactory,
        Event.Interfaces.ITimerFactory
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
            Event.Interfaces.StaticExtensionEventInterfaces.TimerFactory = Singleton;
            Event.Interfaces.StaticExtensionEventInterfaces.TimerEventFactory = Singleton;
        }

        private EmptyTimerEventFactory()
        {

        }

        Event.Interfaces.ITimerEvent Event.Interfaces.ITimerEventFactory.NewTimer => new EmptyTimerEvent();

        Event.Interfaces.ITimer Event.Interfaces.ITimerFactory.CreateTimer(System.TimeSpan timeSpan)
        {
            return new EmptyTimer(timeSpan);
        }

        class EmptyTimer : Event.Interfaces.ITimer
        {
            System.TimeSpan timeSpan;

            System.Action ev;

            internal EmptyTimer(System.TimeSpan timeSpan)
            {
                this.timeSpan = timeSpan;
            }

            System.TimeSpan Event.Interfaces.ITimer.TimeSpan => timeSpan;

            bool Event.Interfaces.ITimer.IsEnabled { get; set; }

            event System.Action Event.Interfaces.ITimer.Event
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

        class EmptyTimerEvent : Event.Interfaces.ITimerEvent
        {
            System.Action ev;

            System.TimeSpan Event.Interfaces.ITimerEvent.TimeSpan { get; set; }
            
            bool Event.Interfaces.IEvent.IsEnabled { get; set; }

            event System.Action Event.Interfaces.IEvent.Event
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
