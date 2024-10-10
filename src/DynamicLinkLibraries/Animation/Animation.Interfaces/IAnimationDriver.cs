using System;

using Diagram.UI.Interfaces;


namespace Animation.Interfaces
{
    /// <summary>
    /// Driver of animation
    /// </summary>
    public interface IAnimationDriver
    {
        /// <summary>
        /// Starts animation
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <param name="reasons">Reasons</param>
        /// <param name="animationType">Type of animation</param>
        /// <param name="pause">Pause</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="realTime">The "real time" sign</param>
        /// <param name="absoluteTime">The "absolute time" sign</param>
        /// <returns>Animation asynchronous calculation</returns>
        object StartAnimation(IComponentCollection collection, string[] reasons,
          Enums.AnimationType animationType,
          TimeSpan pause, double timeScale, bool realTime, bool absoluteTime);

        /// <summary>
        /// Supports asynchronous 
        /// </summary>
        bool SuppotrsAsynchronous
        {
            get;
        }

    }
}
