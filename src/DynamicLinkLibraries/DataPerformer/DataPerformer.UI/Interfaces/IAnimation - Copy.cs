using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.UI.Interfaces
{
    /// <summary>
    /// Starts animation
    /// </summary>
    public interface IAnimation
    {
        /// <summary>
        /// Starts animation
        /// </summary>
        /// <param name="animation">Animation action</param>
        void Start(Action<Action> animation);

        /// <summary>
        /// Stops animation
        /// </summary>
        void Stop();

        /// <summary>
        /// Pauses animation
        /// </summary>
        void Pause();

    }
}
