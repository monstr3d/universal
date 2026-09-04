using System;

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
