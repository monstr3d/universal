using AssemblyService;
using BaseTypes.Attributes;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Scada.Desktop.Serializable
{
    /// <summary>
    /// Static Extension
    /// </summary>
    public static class StaticExtensionScadaDesktopSerializable
    {

        public const string UrlConsumers = "UrlConsumers";

        /// <summary>
        /// List of url providers
        /// </summary>
        /// <param name="scada">SCADA</param>
        /// <returns>The list</returns>
        public static List<string> GetUrlConsumerList(this IScadaInterface scada)
        {
            XElement document = scada.XmlDocument;
            return document.GetItems(UrlConsumers);
        }


        /// <summary>
        /// Creates Scada from bytes
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static async Task<IScadaInterface> ScadaFromBytes(this byte[] buffer,
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, 
            IAsynchronousCalculation realtimeStep)
        {
            var ct = new CancellationToken();
            IDesktop desktop = await buffer.DesktopFromBytes(ct);
            return desktop.ScadaFromDesktop(dataConsumer, timeType, isAbsoluteTime, realtimeStep, null);
        }

        /// <summary>
        /// Creates Scada from stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static async Task<IScadaInterface> ScadaFromBytes(this System.IO.Stream stream,
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, 
            IAsynchronousCalculation realtimeStep)
        {
            CancellationToken ct = new CancellationToken();
            IDesktop desktop = await stream.DesktopFromStream(ct);
            return desktop.ScadaFromDesktop(dataConsumer, timeType, isAbsoluteTime, realtimeStep, null);
        }

        /// <summary>
        /// Creates Scada from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static async Task<IScadaInterface> ScadaFromFile(this string fileName,
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, 
            IAsynchronousCalculation realtimeStep)
        {
  
            IDesktop desktop = await fileName.DesktopFromFile();
            return desktop.ScadaFromDesktop(dataConsumer, timeType, isAbsoluteTime, realtimeStep, null);
        }

        /// <summary>
        /// Creates Scada from string
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static async Task<IScadaInterface> ScadaFromString(this string buffer,
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep)
        {
            var ct = new CancellationToken();
            return await buffer.StringToBytes().ScadaFromBytes(dataConsumer, timeType, isAbsoluteTime, realtimeStep);
        }

        /// <summary>
        /// Conerts SCADA to string
        /// </summary>
        /// <param name="scada">SCADA</param>
        /// <returns>The bytes</returns>
        public static byte[] ToBytes(this IScadaInterface scada)
        {
            if (scada is ScadaDesktop)
            {
                return (scada as ScadaDesktop).Desktop.ToBytes();
            }
            return null;
        }

        /// <summary>
        /// Conerts SCADA to string
        /// </summary>
        /// <param name="scada">SCADA</param>
        /// <returns>The string</returns>
        public static string ToScadaString(this IScadaInterface scada)
        {
            if (scada is ScadaDesktop)
            {
                return (scada as ScadaDesktop).Desktop.DesktopToString();
            }
            return null;
        }


        /// <summary>
        /// Factory from base directory
        /// </summary>
        public static IScadaFactory BaseFactory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory.GetSubclassObject<IScadaFactory>();
            }
        }

    }
}
