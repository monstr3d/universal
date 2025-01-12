using System;
using System.Collections.Generic;
using System.Reflection;

using BaseTypes.Attributes;

using CategoryTheory;

using Diagram.UI.Interfaces;

using AssemblyService.Attributes;


using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

using Event.Interfaces;

using Scada.Interfaces;

namespace Scada.Desktop
{
    /// <summary>
    /// Static Extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionScadaDesktop
    {

        #region Fields

        static readonly Type[] inputTypes = new Type[] { typeof(InitAssemblyAttribute) };


        static Dictionary<string, IScadaInterface> scadas =
            new Dictionary<string, IScadaInterface>();

        static Dictionary<string, IDesktop> desktops = new Dictionary<string, IDesktop>();

        static Dictionary<string, PropertyInfo> desktopD = new Dictionary<string, PropertyInfo>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionScadaDesktop()
        {
            ScadaDesktop.Singleton.SetBase();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets name of SCADA
        /// </summary>
        /// <param name="scada">The scada</param>
        /// <returns>The name</returns>
        public static string GetScadaName(this IScadaInterface scada)
        {
            foreach (var key in scadas.Keys)
            {
                if (scadas[key] == scada)
                {
                    return key;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds SACDA Event
        /// </summary>
        /// <param name="tuple">Input</param>
        /// <returns>The event</returns>
        public static Interfaces.IEvent ToScadaEvent(this 
            Tuple<IScadaInterface, string> tuple)
        {
            var s = tuple.Item1;
            var e = tuple.Item2;
            if (s.Events.Contains(e))
            {
                return s[e];
            }
            return null;
        }

        /// <summary>
        /// Adds action to SCADA events
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="str">Events</param>
        public static void AddToScadaEvent(this Action action, 
            IEnumerable<string> str)
        {
            var t = str.ToScadaEvent();
            foreach (var i in t)
            {
                i.Event += action;
            }
        }

        /// <summary>
        /// Finds Scada events
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns>Events</returns>

        public static IEnumerable<Interfaces.IEvent> 
            ToScadaEvent(this IEnumerable<string> str)
        {
            var p = str.ToScadaString();
            foreach (var pp in p)
            {
                var s = pp.ToScadaEvent();
                if (s != null)
                {
                    yield return s;
                }
            }
        }

        /// <summary>
        /// To SCADA and string
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>Scada and string</returns>
        public static IEnumerable<Tuple<IScadaInterface, string>> 
            ToScadaString(this IEnumerable<string> str)
        {
            foreach (var s in str)
            {
                var t = s.ToScadaString();
                if (t != null)
                {
                    yield return t;
                }
            }
        }

        /// <summary>
        /// To SCADA and string
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>Scada and string</returns>
        static public Tuple<IScadaInterface, string> ToScadaString(this string str)
        {
            int k =  str.IndexOf('.');
            if (k < 0 | k == str.Length - 1)
            {
                return null;
            }
            var scada = str.Substring(0, k).ToExistedScada();
            if (scada == null)
            {
                return null;
            }
            return new Tuple<IScadaInterface, string>(scada, str.Substring(k + 1));
        }

        /// <summary>
        ///  Detects function
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns>The function</returns>
        public static Func<object> DetectFunc(this string str)
        {
            var t = str.ToScadaString();
            if (t == null)
            {
                return null;
            }
            if (!t.Item1.Outputs.ContainsKey(t.Item2))
            {
                return null;
            }
            return t.Item1.GetOutput(t.Item2);
        }

        /// <summary>
        /// Detects actions
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns>Action</returns>
        public static Tuple<Func<object>, Action<object>, object> 
            DetectActions(this string[] str)
        {
            var tt = new Tuple<IScadaInterface, string>[2];
            for (int i = 0; i < 2; i++)
            {
                var t = str[i].ToScadaString();
                if (t == null)
                {
                    return null;
                }
                tt[i] = t;
            }
            if (!tt[0].Item1.Outputs.ContainsKey(tt[0].Item2))
            {
                return null;
            }
            var to = tt[0].Item1.Outputs[tt[0].Item2];
            if (!tt[1].Item1.Inputs.ContainsKey(tt[1].Item2))
            {
                return null;
            }
            var ti = tt[1].Item1.Inputs[tt[1].Item2];
            if (ti.Equals(to))
            {
                return new Tuple<Func<object>, Action<object>, object>(
                    tt[0].Item1.GetOutput(tt[0].Item2),
                    tt[1].Item1.GetInput(tt[1].Item2), to);
            }
            return null;
        }

        /// <summary>
        /// Input ouptut action
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        /// <param name="compare">The "Compare" string</param>
        /// <returns>The action</returns>
        public static Action InputToOutput(this string input, string output,
            bool compare = true)
        {
            var ss = new string[]{ input, output };
            var tt = new Tuple<IScadaInterface, string>[2];
            for (int i = 0; i < 2; i++)
            {
                var s = ss[i];
                int k = s.IndexOf('.');
                var scada = s.Substring(0, k).ToExistedScada();
                tt[i] = new Tuple<IScadaInterface, string>(scada, s.Substring(k + 1));
            }
            return tt[0].InputToOutput(tt[1], compare);
        }

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
                    MethodInfo mi = type.GetMethod("Init", inputTypes);
                    if (mi != null)
                    {
                        mi.Invoke(null, new object[1]);
                    }
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
            var desktop = desktopD[name].GetValue(null) as IDesktop;
            var scada =
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
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
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
            var scada = 
                desktop.ScadaFromDesktop(dataConsumer, timeType, 
                isAbsoluteTime, realtimeStep, timeMeasurementProviderFactory);
            StaticExtensionEventInterfaces.TimerEventFactory = temp;
            StaticExtensionEventInterfaces.TimerFactory = temp1;
            return scada;
        }


        #endregion
    }
}
