using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using CategoryTheory;

using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;

using Scada.Interfaces;

using Web.Interfaces;
using DataPerformer.Portable.Interfaces;
using NamedTree;

namespace Scada.Desktop.Serializable
{
    /// <summary>
    /// Desktop of scada
    /// </summary>
    public class ScadaDesktop : Desktop.ScadaDesktop
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        new public static readonly ScadaDesktop Singleton =
            new ScadaDesktop(null, null, TimeType.Second, true, null, null, null);

        Dictionary<string, IUrlConsumer> urlConsumers = new Dictionary<string, IUrlConsumer>();



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <param name="events">Events</param>
        protected ScadaDesktop(IDesktop desktop, string dataConsumer, TimeType timeUnit, bool isAbsoluteTime,
            IAsynchronousCalculation realtimeStep, Event.Interfaces.IEvent[] events, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory) :
            base(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep, events, timeMeasurementProviderFactory)
        {
             onStop += () =>
             {
                 Event.Interfaces.IEventLog log = Event.Interfaces.StaticExtensionEventInterfaces.CurrentLog;
                 if (log != null)
                 {
                     if (log is IDisposable disp)
                     {
                         disp.Dispose();
                     }
                 }
                 Event.Interfaces.StaticExtensionEventInterfaces.NewLog = null;
            };
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Crerates SCADA
        /// </summary>
        protected override void CreateScada()
        {
            base.CreateScada();
            desktop.ForEach((IUrlConsumer consumer) =>
                {
                    urlConsumers[(consumer as IAssociatedObject).GetRootName()] = consumer;
                });
        }

        /// <summary>
        /// Creates scada from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sing</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>The scada</returns>
        public override IScadaInterface Create(IDesktop desktop, string dataConsumer, TimeType timeUnit,
            bool isAbsoluteTime, IAsynchronousCalculation realtimeStep, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory)
        {

            IScadaInterface scada = 
                new ScadaDesktop(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep, eventsData,
                timeMeasurementProviderFactory);
            scada.OnCreateXml += (XElement document) =>
            {
                onCreateXmlFactory(desktop, document);
            };
            return scada;
        }


        /// <summary>
        /// Refresh
        /// </summary>
        public override void Refresh()
        {
            (desktop as Diagram.UI.PureDesktopPeer).Refresh();
            CreateScada();
            onRefresh();
        }


        #endregion

    }
}
