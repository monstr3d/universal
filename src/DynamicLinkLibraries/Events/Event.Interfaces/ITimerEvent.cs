using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Event.Interfaces
{
    /// <summary>
    /// Timer event
    /// </summary>
    public interface ITimerEvent  : IEvent
    {
        /// <summary>
        /// Time span
        /// </summary>
        TimeSpan TimeSpan
        {
            get;
            set;
        }

    }
}
