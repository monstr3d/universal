using System;

namespace Event.Interfaces
{
    /// <summary>
    /// Timer event
    /// </summary>
    public interface ITimerEvent  : IEvent, IEventProxy
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
