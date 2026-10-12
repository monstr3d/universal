using System;

namespace Event.Interfaces
{
    /// <summary>
    /// Factory of timers
    /// </summary>
    public interface ITimerFactory
    {
        /// <summary>
        /// Facrory of timers
        /// </summary>
        /// <param name="timeSpan">Time span</param>
        /// <returns>The timer</returns>
        ITimer CreateTimer(TimeSpan timeSpan);
    }
}
