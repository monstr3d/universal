using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;

using CategoryTheory;

using Diagram.UI.Interfaces;



using Scada.Interfaces;
using DataPerformer.Interfaces;
using Event.Interfaces;
using System.Reflection;
using DataPerformer.Portable.Interfaces;
using System.Runtime.CompilerServices;

namespace Scada.Desktop
{
    /// <summary>
    /// Static Extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionScadaDesktop
    {

        #region Fields

        static Dictionary<string, IScadaInterface> scadas =
            new Dictionary<string, IScadaInterface>();

        static Dictionary<string, IDesktop> desktops = new Dictionary<string, IDesktop>();

        static Dictionary<string, PropertyInfo> desktopD = new Dictionary<string, PropertyInfo>();

        #endregion

        #region Constructor

        static StaticExtensionScadaDesktop()
        {
            ScadaDesktop.Singleton.SetBase();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// String to existed SCADA
        /// </summary>
        /// <param name="name">The name of scada</param>
        /// <returns>The SCADA</returns>
        public static IScadaInterface ToExistedScada(this string name)
        {
            if (!scadas.ContainsKey(name))
            {
                return null;
            }
            return scadas[name];
        }

        /// <summary>
        /// Clears scadas
        /// </summary>
        public static void Clear()
        {
            foreach (var scada in scadas.Values)
            {
                if (scada.IsEnabled)
                {
                    scada.IsEnabled = false;
                }
            }
            scadas.Clear();
        }

        /// <summary>
        /// Sets assembly
        /// </summary>
        /// <param name="ass">The assembly</param>
        /// <param name="action">The action</param>
        static public void SetScadaAssembly(this Assembly ass, Action<Type> action = null)
        {
            Type[] types = ass.GetTypes();
            foreach (Type type in types)
            {
                PropertyInfo pi = type.GetProperty("Desktop");
                if (pi != null)
                {
                    Type tt = pi.PropertyType;
                    if (tt == typeof(IDesktop))
                    {
                        desktopD[type.Name] = pi;
                    }
                }
                if (type.HasAttribute<InitAssemblyAttribute>())
                {
                    MethodInfo mi = type.GetMethod("Init");
                    mi.Invoke(null, null);
                }
                action?.Invoke(type);
            }

        }

        /// <summary>
        /// Gets Desktop from SCADA
        /// </summary>
        /// <param name="scada">The Scada</param>
        /// <returns>The desktop</returns>
        public static IDesktop GetDesktop(this IScadaInterface scada)
        {
            return (scada as ScadaDesktop).Desktop;
        }

        /// <summary>
        /// Existence of scada
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The sign of the existence</returns>
        public static  bool ScadaExists(this string name)
        {
            return scadas.ContainsKey(name);
        }


        /// <summary>
        /// String to SCADA
        /// </summary>
        /// <param name="name">Name of class</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timerEventFactory">Timer Event Factory</param>
        /// <param name="timerEvent">Timer Factory</param>
        /// <param name="timeMeasurementProviderFactory">Tim eMeasurement Provider Factory</param>
        /// <param name="timeType">Type of time</param>
        /// <param name="isAbsoluteTime">Is absolute time sigh</param>
        /// <param name="realtimeStep">Asynchronous Calculation</param>
        /// <param name="unique">Unique sign</param>
        /// <returns>The SCADA</returns>
        public static IScadaInterface ToScada(this string name,
                string dataConsumer,
                ITimerEventFactory timerEventFactory,
                ITimerFactory timerEvent,
                ITimeMeasurementProviderFactory timeMeasurementProviderFactory,
                TimeType timeType, bool isAbsoluteTime,
                IAsynchronousCalculation realtimeStep, bool unique)
        {
            if (unique)
            {
                if (scadas.ContainsKey(name))
                {
                    return scadas[name];
                }
            }
            var temp = StaticExtensionEventInterfaces.TimerEventFactory;
            var temp1 = StaticExtensionEventInterfaces.TimerFactory;
            StaticExtensionEventInterfaces.TimerEventFactory = timerEventFactory;
            StaticExtensionEventInterfaces.TimerFactory = timerEvent;
            IDesktop desktop = desktopD[name].GetValue(null) as IDesktop;
            IScadaInterface scada =
                desktop.ScadaFromDesktop(dataConsumer, timeType, isAbsoluteTime, 
                realtimeStep, timeMeasurementProviderFactory);
            StaticExtensionEventInterfaces.TimerEventFactory = temp;
            StaticExtensionEventInterfaces.TimerFactory = temp1;
            if (unique)
            {
                scadas[name] = scada;
            }
            return scada;
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        /// <summary>
        /// Scada factory
        /// </summary>
        static public IScadaFactory ScadaFactory
        { get; set; }


        /// <summary>
        /// Sets base factory
        /// </summary>
        /// <param name="replace">Factory for replacement</param>
        public static void SetBase(this IScadaFactory replace)
        {
            if (replace == null)
            {
                throw new Exception();
            }
            if (ScadaFactory == null)
            {
                ScadaFactory = replace;
                return;
            }
            if (ScadaFactory.IsBase(replace))
            {
                ScadaFactory = replace;
            }
        }


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
            string dataConsumer, TimeType timeType, bool isAbsoluteTime, 
            IAsynchronousCalculation realtimeStep, ITimeMeasurementProviderFactory timeMeasurementProviderFactory)
        {
            if (desktop == null)
            {
                return null;
            }
            return ScadaFactory.Create(desktop, dataConsumer, timeType, 
                isAbsoluteTime, realtimeStep, timeMeasurementProviderFactory);
        }

        /// <summary>
        /// Creates Scada from desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="time">Time measure provider</param>
        /// <param name="timerEvent">Time event privider</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="realtimeStep">Realtime Step</param>
        /// <returns>Scada</returns>
        public static IScadaInterface ScadaFromDesktop(this IDesktop desktop,
            string dataConsumer, ITimerFactory time, ITimerEventFactory timerEvent, 
            ITimeMeasurementProviderFactory timeMeasurementProviderFactory,
            TimeType timeType, bool isAbsoluteTime, 
            IAsynchronousCalculation realtimeStep)
        {
            var temp = StaticExtensionEventInterfaces.TimerEventFactory;
            var temp1 = StaticExtensionEventInterfaces.TimerFactory;
            StaticExtensionEventInterfaces.TimerEventFactory = timerEvent;
            StaticExtensionEventInterfaces.TimerFactory = time;
            if (desktop == null)
            {
                return null;
            }
            IScadaInterface scada = 
                desktop.ScadaFromDesktop(dataConsumer, timeType, 
                isAbsoluteTime, realtimeStep, timeMeasurementProviderFactory);
            StaticExtensionEventInterfaces.TimerEventFactory = temp;
            StaticExtensionEventInterfaces.TimerFactory = temp1;
            return scada;
        }


        #endregion
    }
}
