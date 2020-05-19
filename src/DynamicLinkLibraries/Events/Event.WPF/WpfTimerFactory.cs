using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Interfaces;

namespace Event.WPF
{
    public class WpfTimerFactory : ITimerFactory
    {
        public static readonly ITimerFactory Singleton = new WpfTimerFactory();


        private WpfTimerFactory()
        {

        }

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            return new Timer(timeSpan);
        }
    }
}
