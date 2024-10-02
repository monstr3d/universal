using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Event block
    /// </summary>
    public interface IEventBlock
    {
        /// <summary>
        /// Blocked event
        /// </summary>
        /// <param name="ev">Event</param>
        /// <returns>True if blocked</returns>
        bool this[IEvent ev]
        {
            get;
        }

        /// <summary>
        /// Names of blocked events
        /// </summary>
        string[] Names
        {
            get;
            set;
        }
    }
}
