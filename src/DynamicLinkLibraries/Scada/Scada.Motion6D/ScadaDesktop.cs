using System;
using System.Collections.Generic;
using System.Xml.Linq;


using CategoryTheory;

using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Portable;
using Event.Interfaces;

using Motion6D.Portable;

using Scada.Interfaces;

using Scada.Desktop;
using Scada.Motion6D.Interfaces;


using Animation.Interfaces;

using Event.Portable.Interfaces;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable;

namespace Scada.Motion6D
{
    /// <summary>
    /// Scada desktop for 6D motion
    /// </summary>
    public class ScadaDesktop : Desktop.ScadaDesktop, ICameraProvider
    {

        #region Fields

        public const string Cameras = "Cameras";

        /// <summary>
        /// Singleton
        /// </summary>
        new public static readonly ScadaDesktop Singleton = new ScadaDesktop(null, null, TimeType.Second, true, null, null);

        Dictionary<string, Camera> cameras = new Dictionary<string, Camera>();

        object enabledlock = new object();

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
        protected ScadaDesktop(IDesktop desktop, string dataConsumer,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory)
            : base(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep, null, 
                  timeMeasurementProviderFactory)
        {

        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Creates SCADA
        /// </summary>
        protected override void CreateScada()
        {
            base.CreateScada();
            if (desktop == null)
            {
                return;
            }
            desktop.ForEach((Camera camera) =>
            {
                cameras[(camera as IAssociatedObject).GetRootName()] = camera;
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
            IScadaInterface scada = new ScadaDesktop(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep, 
                timeMeasurementProviderFactory);
            scada.OnCreateXml += (XElement document) =>
            {
                onCreateXmlFactory(desktop, document);
            };
            return scada;
        }

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        public override bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                lock (enabledlock)
                {
                    if (isEnabled == value)
                    {
                        return;
                    }
                    if (value)
                    {
                        realtime = StartRealtime(timeMeasurementProviderFactory, true);
                        if (realtime == null)
                        {
                            throw new Exception("No runtime");
                        }
                        onStart?.Invoke();
                    }
                    else
                    {
                        realtime.Stop();
                        realtime = null;
                        onStop?.Invoke();
                    }
                    isEnabled = value;
                }
            }
        }



        /// <summary>
        /// Factory from base directory
        /// </summary>
        public IScadaFactory BaseFactory
        {
            get
            {
                return null;
            }
            set
            {
                XElement document = StaticExtensionScadaInterfaces.CreateXML(this);
                StaticExtensionScadaInterfaces.AddItems(document, Cameras, cameras.Keys);
                //   document.AddItems(UrlConsumers, urlConsumers.Keys);
                onCreateXml(document);
            }
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Type of animation
        /// </summary>
        public Animation.Interfaces.Enums.AnimationType AnimationType
        {
            get;
            set;
        }

        Dictionary<string, Camera> ICameraProvider.Cameras
        {
            get
            {
                return cameras;
            }
        }

        #endregion

        #region Private Members

        IRealtime StartRealtime(ITimeMeasurementProviderFactory timeMeasurementProviderFactory,
            bool multiThread)
        {
            IAsynchronousCalculation animation =
               collection.StartAnimation(


               new string[]    { StaticExtensionEventInterfaces.Realtime,
             AnimationType.GetReason() }, AnimationType, new TimeSpan(0), 1, true, isAbsoluteTime);
            if (animation != null)
            {
                StaticExtensionEventPortable.OnceStop(animation.Interrupt);
            }
           return  StaticExtensionEventPortable.StartRealtime(collection, timeUnit, isAbsoluteTime, animation,
                dataConsumer, StaticExtensionEventInterfaces.NewLog,
                StaticExtensionEventInterfaces.Realtime, 
                timeMeasurementProviderFactory, multiThread);
        }

        #endregion

    }
}
