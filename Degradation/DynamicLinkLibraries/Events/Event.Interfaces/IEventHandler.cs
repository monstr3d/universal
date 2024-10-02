using System;
using System.Collections.Generic;

namespace Event.Interfaces
{
    /// <summary>
    /// Event handler
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Adds event
        /// </summary>
        /// <param name="ev">The event to add</param>
        void Add(IEvent ev);

        /// <summary>
        /// Removes event
        /// </summary>
        /// <param name="ev">The event to remove</param>
        void Remove(IEvent ev);

        /// <summary>
        /// Events
        /// </summary>
        IEnumerable<IEvent> Events
        {
            get;
        }

        /// <summary>
        /// The On Add event
        /// </summary>
        event Action<IEvent> OnAdd;

        /// <summary>
        /// The On Remove event
        /// </summary>
        event Action<IEvent> OnRemove;

     }
}
