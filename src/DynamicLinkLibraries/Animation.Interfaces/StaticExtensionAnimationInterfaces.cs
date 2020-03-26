using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;

namespace Animation.Interfaces
{
    /// <summary>
    /// Static extension
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionAnimationInterfaces
    {

        #region Private Members

        static IAnimationDriver driver;

 
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
                return driver != null;
            }
        }

        /// <summary>
        /// Supports asynchronous animation
        /// </summary>
        static public bool SuppotrsAsynchronous
        {
            get
            {
                if (driver == null)
                {
                    return false;
                }
                return driver.SuppotrsAsynchronous;
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
          Enums.AnimationType animationType,
          TimeSpan pause, double timeScale, bool realTime, bool absoluteTime)
        {
            if (driver == null)
            {
                return null;
            }
            return driver.StartAnimation(collection, reasons,
                animationType, pause, timeScale, realTime, absoluteTime);
        }
  
    
    
        /// <summary>
        /// Reason
        /// </summary>
        /// <param name="type">Animation type</param>
        public static string GetReason(this Enums.AnimationType type)
        {
            if (type == Enums.AnimationType.Synchronous)
            {
                return "Animation";
            }
            return "AsynchronousAnimation";
        }

        #endregion

        #region Private

        static StaticExtensionAnimationInterfaces()
        {
            driver = AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IAnimationDriver>();
        }

        #endregion

    }
}
