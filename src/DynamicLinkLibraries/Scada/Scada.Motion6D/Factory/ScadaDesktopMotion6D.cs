using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


using CategoryTheory;

using BaseTypes.Attributes;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Event.Portable;
using Event.Interfaces;

using Motion6D;

using Scada.Interfaces;

using Scada.Desktop;
using Scada.Motion6D.Interfaces;

using Web.Interfaces;

using Animation.Interfaces;

using Scada.Desktop.Serializable;
using AssemblyService;
using Event.Portable.Interfaces;

namespace Scada.Motion6D.Factory
{
    /// <summary>
    /// Scada desktop for 6D motion
    /// </summary>
    public class ScadaDesktopMotion6D : Desktop.Serializable.ScadaDesktop, ICameraProvider
    {

        #region Fields

        public const string Cameras = "Cameras";

        /// <summary>
        /// Singleton
        /// </summary>
        new public static readonly ScadaDesktopMotion6D Singleton = new ScadaDesktopMotion6D(null, null, TimeType.Second, true, null);

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
        protected ScadaDesktopMotion6D(IDesktop desktop, string dataConsumer,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep)
            : base(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep, null)
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
            bool isAbsoluteTime, IAsynchronousCalculation realtimeStep)
        {
            IScadaInterface scada = new ScadaDesktopMotion6D(desktop, dataConsumer, timeUnit, isAbsoluteTime, realtimeStep);
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
                        var realtime = StartRealtime();
                        if (realtime == null)
                        {
                            throw new Exception("No runtime");
                        }
                        onStart();
                    }
                    else
                    {
                        StaticExtensionEventPortable.StopRealTime();
                        onStop();
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
                return AppDomain.CurrentDomain.BaseDirectory.GetSubclassObject<IScadaFactory>();
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


        IRealtime StartRealtime()
        {
            IAsynchronousCalculation animation =
               collection.StartAnimation(new string[] {StaticExtensionEventInterfaces.Realtime,
             AnimationType.GetReason()}, AnimationType, new TimeSpan(0), 1, true, isAbsoluteTime);
            if (animation != null)
            {
                StaticExtensionEventPortable.OnceStop(animation.Interrupt);
            }
           return  StaticExtensionEventPortable.StartRealtime(collection, timeUnit, isAbsoluteTime, animation,
                dataConsumer, StaticExtensionEventInterfaces.NewLog,
                StaticExtensionEventInterfaces.Realtime);
        }

        #endregion

    }
}
