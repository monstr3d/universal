using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Timer factory
    /// </summary>
    public interface ITimerEventFactory
    {
        /// <summary>
        /// New timer
        /// </summary>
        ITimerEvent NewTimer
        {
            get;
        }
    }
}
