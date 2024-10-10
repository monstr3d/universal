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
    
        static public void Init(InitAssemblyAttribute attr)
        { 
        
        }



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
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
