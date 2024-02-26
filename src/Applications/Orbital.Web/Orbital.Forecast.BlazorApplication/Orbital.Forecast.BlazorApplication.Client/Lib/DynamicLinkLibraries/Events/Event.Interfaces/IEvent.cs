using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Interfaces
{
    /// <summary>
    /// Event
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Raised event
        /// </summary>
        event Action Event;

        /// <summary>
        /// Is enabled sign
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }
    }
}
