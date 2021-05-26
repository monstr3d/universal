using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyService.Attributes;
using CategoryTheory;

using Event.Interfaces;

namespace Event.Windows.Forms
{
    /// <summary>
    /// Factory of windows timers
    /// </summary>
    [InitAssembly]
    public class WindowsTimerFactory : ITimerEventFactory, ITimerFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly WindowsTimerFactory Singleton = new WindowsTimerFactory();
    
        [InitAssembly]
        public static void Init()
        { }



        #endregion

        #region Ctor

        static WindowsTimerFactory()
        {
            WindowsTimerFactory f = Singleton;
            StaticExtensionEventInterfaces.TimerFactory = f;
            StaticExtensionEventInterfaces.TimerEventFactory = f;
        }
    
        private WindowsTimerFactory()
        {
        }

        #endregion

        #region ITimerFactory Members

        ITimerEvent ITimerEventFactory.NewTimer
        {
            get { return new Timer(); }
        }

        ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
        {
            return new TimeTimer(timeSpan);
        }

        #endregion
    }
}
