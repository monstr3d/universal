using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Event.Interfaces
{
    /// <summary>
    /// Event provider
    /// </summary>
    /// <typeparam name="T">Event object</typeparam>
    public interface IEvent<T> where T : class
    {
        /// <summary>
        /// Event
        /// </summary>
        event Action<T> Event;
    }
}
