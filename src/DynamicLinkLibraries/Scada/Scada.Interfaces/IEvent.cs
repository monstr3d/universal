using System;

namespace Scada.Interfaces
{
    /// <summary>
    /// IEvent
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Event
        /// </summary>
        event Action Event;
    }
}
