
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.WPF
{
    /// <summary>
    /// WPF timer factory
    /// </summary>
    public class WpfTimerEventFactory : ITimerEventFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static WpfTimerEventFactory Singleton = new WpfTimerEventFactory();

        #endregion

        #region Ctor


        private WpfTimerEventFactory()
        {

        }

        #endregion

        #region ITimerEventFactory Members


        ITimerEvent ITimerEventFactory.NewTimer
        {
            get
            {
                return new TimerEvent();
            }
        }


        /*
                ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
                {
                    return new Timer(timeSpan);
                }
                */

        #endregion
    }
}