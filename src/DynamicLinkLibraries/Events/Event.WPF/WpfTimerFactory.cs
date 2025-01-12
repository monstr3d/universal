using Event.Interfaces;

namespace Event.WPF
{
    public class WpfTimerFactory : ITimerFactory
    {
        public static readonly ITimerFactory Singleton = new WpfTimerFactory();


        private WpfTimerFactory()
        {

        }

        Interfaces.ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            return new Timer(timeSpan);
        }
    }
}
