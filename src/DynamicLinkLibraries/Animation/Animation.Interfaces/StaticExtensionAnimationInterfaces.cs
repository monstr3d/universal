using System;


using Animation.Interfaces.Enums;
using Diagram.UI.Interfaces;

namespace Animation.Interfaces
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionAnimationInterfaces
    {

        #region Private Members

        static public IAnimationDriver Driver
        { get; set; }


        #endregion

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        }

        /// <summary>
        /// Suppotrs animation
        /// </summary>
        static public bool SupportsAnimation
        {
            get
            {
                return Driver != null;
            }
        }

        /// <summary>
        /// Supports asynchronous animation
        /// </summary>
        static public bool SuppotrsAsynchronous
        {
            get
            {
                if (Driver == null)
                {
                    return false;
                }
                return Driver.SuppotrsAsynchronous;
            }
        }

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
        public static object StartAnimation(IComponentCollection collection, string[] reasons,
         AnimationType animationType,
          TimeSpan pause, double timeScale, bool realTime, bool absoluteTime)
        {
            if (Driver == null)
            {
                return null;
            }
            return Driver.StartAnimation(collection, reasons,
                animationType, pause, timeScale, realTime, absoluteTime);
        }



        /// <summary>
        /// Reason
        /// </summary>
        /// <param name="type">Animation type</param>
        public static string GetReason(this AnimationType type)
        {
            if (type == AnimationType.Synchronous)
            {
                return "Animation";
            }
            return "AsynchronousAnimation";
        }

        #endregion

    }
}
