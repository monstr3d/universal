using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using CategoryTheory;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Scada.Interfaces;
using Scada.Desktop;

namespace Scada.Motion6D
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionScadaMotion6D 
    {
        #region Fields

        private static IScadaInterface scada = ScadaDesktop.Singleton;

        static IAsynchronousCalculation currentCalculation;


        #endregion

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        /// <summary>
        /// List of cameras
        /// </summary>
        /// <param name="scada">SCADA</param>
        /// <returns>The list</returns>
        public static List<string> GetCameraList(this IScadaInterface scada)
        {
            XElement document = scada.XmlDocument;
            return new List<string>();// document.GetItems(ScadaDesktop.Cameras);
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
        public static IAsynchronousCalculation StartAnimation(this IComponentCollection collection, string[] reasons,
         global::Animation.Interfaces.Enums.AnimationType animationType,
          TimeSpan pause, double timeScale, bool realTime, bool absoluteTime)
        {

            currentCalculation = global::Animation.Interfaces.StaticExtensionAnimationInterfaces.StartAnimation
                (collection, reasons, animationType, pause, timeScale, realTime, absoluteTime)
                as IAsynchronousCalculation;
            return currentCalculation;
        }



        #endregion

        #region Private Members

        static StaticExtensionScadaMotion6D()
        {
            ScadaDesktop.Singleton.SetBase();
        }

        #endregion
    }
}
