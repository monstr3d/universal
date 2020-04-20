using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using BaseTypes.Attributes;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Scada.Interfaces;
using System.Xml.Linq;

namespace Scada.Desktop
{
    /// <summary>
    /// Creator of scada
    /// </summary>
    public interface IScadaFactory
    {
        /// <summary>
        /// Creates scada from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sing</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>The scada</returns>
        IScadaInterface Create(IDesktop desktop, string dataConsumer,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep);

        /// <summary>
        /// Create Xml documet
        /// </summary>
        event Action<IDesktop, XElement> OnCreateXml;

      }
}
