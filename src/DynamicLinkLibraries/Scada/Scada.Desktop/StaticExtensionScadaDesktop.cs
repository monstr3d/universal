using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;



using Scada.Interfaces;
using DataPerformer.Interfaces;


namespace Scada.Desktop
{
    /// <summary>
    /// Static Extension
    /// </summary>
    public static class StaticExtensionScadaDesktop
    {

        #region Fields


        #endregion

        #region Public Members

        /// <summary>
        /// Scada factory
        /// </summary>
        static public IScadaFactory ScadaFactory
        { get; set; }

        /// <summary>
        /// Creates Scada from desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static IScadaInterface ScadaFromDesktop(this IDesktop desktop,
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep)
        {
            if (desktop == null)
            {
                return null;
            }
            return ScadaFactory.Create(desktop, dataConsumer, timeType, isAbsoluteTime, realtimeStep);
        }

        #endregion

        #region Private Members

        static StaticExtensionScadaDesktop()
        {
        }
        #endregion
    }
}
