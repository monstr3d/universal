using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Action factory
    /// </summary>
    public interface IActionFactory
    {
        /// <summary>
        /// Creates action
        /// </summary>
        /// <param name="ev">Event</param>
        /// <returns>Action</returns>
        Action this[IEvent ev]
        {
            get;
        }

     }
}
