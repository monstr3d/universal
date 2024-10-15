using System;

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
