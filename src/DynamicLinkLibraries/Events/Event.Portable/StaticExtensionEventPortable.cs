using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using BaseTypes.Attributes;

using AssemblyService.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Runtime;
using DataPerformer.Portable.Interfaces;

using Event.Interfaces;
using Event.Portable.Arrows;
using Event.Portable.Interfaces;
using Event.Portable.Internal;
using ErrorHandler;

namespace Event.Portable
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventPortable
    {

        #region Fields

        static IRealtime currentRuntime;

  
        static bool relativeTime;

        static private event Action<string> start = (string reason) => { };

        static private event Action stop = () => { };

        static Action<IComponentCollection> onStartRealtime = (IComponentCollection collection)
        => { };

        static int cadr = 0;


        #endregion

        #region Ctor
        static StaticExtensionEventPortable()
        {
            Portable.Runtime.StandardEventRuntime.Singleton.Set();
            new CSCodeCreator();
        }
        #endregion

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Enumerable tranformation
        /// </summary>
        static public Func<IEnumerable<object>, IEnumerable<object>> EnumerableTranformation
        {
            get;
            set;
        }

        /// <summary>
        /// Runtime
        /// </summary>
        public static IRealtime Runtime
        {
            get;
            set;
        }

        /// <summary>
        /// Set base runtime
        /// </summary>
        /// <param name="runtime">The runtime to set</param>
        public static void SetBase(this IRealtime runtime)
        {
            if (runtime == null)
            {
                throw new Exception("SetBase");
            }
            if (Runtime == null)
            {
                Runtime = runtime;
                return;
            }
            if (Runtime.IsBase(runtime))
            {
                Runtime = runtime;
            }
        }

        /// <summary>
        /// Finds event
        /// </summary>
        /// <param name="handler">Event handler</param>
        /// <param name="name">The name of event</param>
        /// <returns>The event</returns>
        public static IEvent FindEvent(this IEventHandler handler, string name)
        {
            if (!(handler is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ao = handler as IAssociatedObject;
            foreach (IEvent ev in handler.Events)
            {
                if (ev is IAssociatedObject)
                {
                    string s = ao.GetRelativeName(ev as IAssociatedObject);
                    if (s == name)
                    {
                        return ev;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Simulation cadr
        /// </summary>
        public static int Cadr
        {
            get
            {
                return cadr;
            }
        }

        /// <summary>
        /// Finds events
        /// </summary>
        /// <param name="handler">Event handler</param>
        /// <param name="names">The names of events</param>
        /// <returns>The events</returns>
        public static IEvent[] FindEvents(this IEventHandler handler, string[] names)
        {
            IEvent[] ev = new IEvent[names.Length];
            for (int i = 0; i < ev.Length; i++)
            {
                ev[i] = handler.FindEvent(names[i]);
            }
            return ev;
        }

        /// <summary>
        /// Gets names of events
        /// </summary>
        /// <param name="handler">Event handler</param>
        /// <returns>Names of events</returns>
        public static IEnumerable<string> GetEventNames(this IEventHandler handler)
        {
            if (handler is IAssociatedObject)
            {
                IAssociatedObject ao = handler as IAssociatedObject;
                foreach (IEvent ev in handler.Events)
                {
                    if (ev is IAssociatedObject)
                    {
                        yield return ao.GetRelativeName(ev as IAssociatedObject);
                    }
                }
            }
        }

        /// <summary>
        /// On start real time
        /// </summary>
        static public event Action<IComponentCollection> OnStartRealtime
        {
            add { onStartRealtime += value; }
            remove { onStartRealtime -= value; }
        }

        /// <summary>
        /// Is running sign
        /// </summary>
        static public bool IsRunning
        {
            get
            {
                return currentRuntime != null;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        static public event Action<string> Start
        {
            add { start += value; }
            remove { start -= value; }
        }

        /// <summary>
        /// Starts real time
        /// </summary>
        /// <param name="collection">Collection</param>
        static public void StartRealtime(IComponentCollection collection)
        {
            onStartRealtime(collection);
        }

        /// <summary>
        /// Once stops
        /// </summary>
        /// <param name="start">Stop action</param>
        public static void OnceStart(Action<IComponentCollection> start)
        {
            if (start == null)
            {
                return;
            }
            new StartHelper(start);
        }

        /// <summary>
        /// Stop
        /// </summary>
        static public event Action Stop
        {
            add { stop += value; }
            remove { stop -= value; }
        }

        /// <summary>
        /// Once stops
        /// </summary>
        /// <param name="stop">Stop action</param>
        public static void OnceStop(Action stop)
        {
            if (stop == null)
            {
                return;
            }
            new StopHelper(stop);
        }

        /// <summary>
        /// Sets runtime
        /// </summary>
        /// <param name="runtime">Runtime</param>
        public static void Set(this IRealtime runtime)
        {
            if (runtime == null)
            {
                throw new Exception("Set real time");
            }
            if (Runtime == null)
            {
                Runtime = runtime;
                return;
            }
            if (Runtime.IsBase(runtime))
            {
                Runtime = runtime;
            }
        }

        public static IRealtime CreateRuntime(
              this IDataConsumer dataConsumer, TimeType timeUnit, bool absoluteTime, string reason, int priority = 0, IEventLog log = null)
        {
            IDesktop desktop = (dataConsumer as ICategoryObject).GetRootDesktop();
            IComponentCollection collection = dataConsumer.CreateCollection(StaticExtensionEventInterfaces.Realtime);
            /* !!!! IAsynchronousCalculation animation =
                 collection.StartAnimation([StaticExtensionEventInterfaces.Realtime,
              AnimationType.GetReason()], AnimationType, Pause, TimeScale, true, checkBoxAbsoluteTime.Checked);
             if (animation != null)
             {
                 StaticExtensionEventPortable.OnceStop(animation.Interrupt);
             }*/
            return collection.StartRealtime(timeUnit,
                absoluteTime, null,
                dataConsumer, log,
                reason, null, false);
        }


        /// <summary>
        /// Start
        /// </summary>
        /// <param name="collection">Components</param>
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">Components</param>
        /// <param name="realtimeStep">Realtime step</param>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="timeMeasurementProviderFactory">Factory of time measurements</param>
        /// <param name="multiThread">The multi thread sign</param>
        /// <returns>The runtime</returns>
        public static IRealtime StartRealtime(this IComponentCollection collection,
            TimeType timeUnit, bool isAbsoluteTime, IAsynchronousCalculation realtimeStep,
           IDataConsumer dataConsumer, IEventLog log, string reason, 
           ITimeMeasurementProviderFactory timeMeasurementProviderFactory, bool multiThread)
        {
            if (reason.Equals(StaticExtensionEventInterfaces.Realtime))
            {
                if (multiThread)
                {
                    IRealtime rt = Runtime.Start(collection, timeUnit, isAbsoluteTime, realtimeStep,
                    dataConsumer, log, reason, timeMeasurementProviderFactory);
                    if (rt == null)
                    {
                        stop();
                    }
                    return rt;
                }
                if (currentRuntime != null)
                {
                    throw new Exception("currentRuntime");
                }
                start(reason);
                currentRuntime = Runtime.Start(collection, timeUnit, isAbsoluteTime, realtimeStep,
                    dataConsumer, log, reason, timeMeasurementProviderFactory);
                if (currentRuntime == null)
                {
                    stop();
                }
            }
            else
            {
                start(reason);
                return Runtime.Start(collection, timeUnit, isAbsoluteTime, realtimeStep,
                     dataConsumer, log, reason, timeMeasurementProviderFactory);
            }
            return currentRuntime;
        }

        /// <summary>
        /// Stops realtime
        /// </summary>
        public static void StopRealTime()
        {
            if (currentRuntime == null)
            {
                return;
               /// !!!! OnError(new Exception(""))
            }
            currentRuntime.Stop();
            currentRuntime = null;
            PostStop();
        }

        /// <summary>
        /// Post stop
        /// </summary>
        public static void PostStop()
        {
            stop();
        }

        /// <summary>
        /// Realtime analysis
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="act">Action</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        public static void RealtimeAnalysis(this IDataConsumer dataConsumer, 
            IEnumerable<object> input, string reason,  Action<object> act,
            TimeType timeType, bool isAbsoluteTime)
        {
            IDesktop desktop = (dataConsumer as IAssociatedObject).GetRootDesktop();
            IComponentCollection collection = dataConsumer.CreateCollection(
               reason);
            StaticExtensionEventInterfaces.NewLog = null;
            using (IDisposable disp = collection.StartRealtime(timeType,
                 isAbsoluteTime, null, dataConsumer, null,
                 reason, null, false) as IDisposable)
            {
                IRealtime r = disp as IRealtime;
                RealtimeProvider p = r.TimeProvider as RealtimeProvider;
                Dictionary<IReplacedMeasurementParameter, string> d;
                IEnumerable<object>   list = dataConsumer.CreateList(input,
                    collection, out d);
                DateTime centuryBegin = new DateTime(2001, 1, 1);
                using (ReplacedMeasurementsBackup backup = new ReplacedMeasurementsBackup(d, r))
                {
                    Dictionary<string, object>[] dm = backup.Output;
                    foreach (object obj in list)
                    {
                        try
                        {
                            if (obj is Tuple<INativeReader, object[], DateTime> t)
                            { 
                                p.DateTime = t.Item3;
                                t.Item1.Read(t.Item2);
                                act(t);
                                continue;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                        Tuple<DateTime, INativeEvent, Dictionary<string, object>> tuple = obj as Tuple<DateTime, INativeEvent, Dictionary<string, object>>;
                        dm[0] = tuple.Item3;
                        DateTime dt = tuple.Item1;
                        p.DateTime = tuple.Item1;
                        tuple.Item2.Force();
                        act(tuple);
                    }
                }
            }
        }


        /// <summary>
        /// Realtime analysis
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        public static bool RealtimeAnalysis(this IDataConsumer dataConsumer,
           ILogReader input, Func<object, bool> stop, string reason,
            TimeType timeType, bool isAbsoluteTime)
        {
            IEnumerable<object> enu = input.Load(0, 0);
            return dataConsumer.RealtimeAnalysis(enu, stop, reason, timeType, isAbsoluteTime);
        }

        /// <summary>
        /// Realtime analysis
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        public static void RealtimeAnalysis(this IDataConsumer dataConsumer,
            object input, Func<object, bool> stop, string reason,
            TimeType timeType, bool isAbsoluteTime)
        {
            cadr = 0;
            IComponentCollection cc = dataConsumer.CreateCollection(reason);
            if (input is ILogReader lr)
            {
                cc.ForEach((ICalculationReason re) => { re.CalculationReason = reason; });
                cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                dataConsumer.RealtimeAnalysis(lr, stop, reason, timeType, isAbsoluteTime);
                cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
                return;
            }
            if (input is ILogReaderCollection lc)
            {
                cc.ForEach((ICalculationReason re) => { re.CalculationReason = reason; });
                cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                IEnumerable<ILogReader> lrc = lc.Readers;
                foreach (ILogReader r in lrc)
                {
                    cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                    bool b = dataConsumer.RealtimeAnalysis(r, stop, reason, timeType, isAbsoluteTime);
                    cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
                    if (b)
                    {
                        return;
                    }
                }
                cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
            }

            if (input is IIterator)
            {
                IIterator it = input as IIterator;
                cc.ForEach((ICalculationReason re) => { re.CalculationReason = reason; });
                cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
                return;
            }
        }

        /// <summary>
        /// Analysis of an iterator, modelled after the realtime analysis of log. Most dummy varibales will perhaps be erased
        /// </summary>
        /// <param name="dataConsumer"></param>
        /// <param name="input"></param>
        /// <param name="stop"></param>
        /// <param name="reason"></param>
        /// <param name="timeType"></param>
        /// <param name="isAbsoluteTime"></param>
        /// <returns></returns>
        public static bool RealTimeAnalysis(this IDataConsumer dataConsumer,
            IIterator input, Func<object,bool> stop, string reason,
            TimeType timeType, bool isAbsoluteTime)
        {
            return false;
            IDesktop desktop = (dataConsumer as IAssociatedObject).GetRootDesktop();
            IComponentCollection collection = dataConsumer.CreateCollection(
                reason);
            StaticExtensionEventInterfaces.NewLog = null;
            using (IDisposable disp = collection.StartRealtime(timeType,
                 isAbsoluteTime, null, dataConsumer, null,
                 reason, null, false) as IDisposable)
            {
                IRealtime r = disp as IRealtime;
                RealtimeProvider p = r.TimeProvider as RealtimeProvider;
   //!!!             Dictionary<IReplacedMeasurementParameter, string> d;

            }
        }


        /// <summary>
        /// Realtime analysis
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        public static bool RealtimeAnalysis(this IDataConsumer dataConsumer, 
            IEnumerable<object> input, Func<object, bool> stop, string reason,
            TimeType timeType, bool isAbsoluteTime)
        {
            IDesktop desktop = (dataConsumer as IAssociatedObject).GetRootDesktop();
            IComponentCollection collection = dataConsumer.CreateCollection(
                reason);
            StaticExtensionEventInterfaces.NewLog = null;
            using (IDisposable disp = collection.StartRealtime(timeType,
                 isAbsoluteTime, null, dataConsumer, null,
                 reason, null, false) as IDisposable)
            {
                IRealtime r = disp as IRealtime;
                RealtimeProvider p = r.TimeProvider as RealtimeProvider;
                Dictionary<IReplacedMeasurementParameter, string> replacedMeasurements;
                IEnumerable<object> list = dataConsumer.CreateList(input,
                    collection, out replacedMeasurements);
                DateTime centuryBegin = new DateTime(2001, 1, 1);
                using (ReplacedMeasurementsBackup backup = new ReplacedMeasurementsBackup(replacedMeasurements, r))
                {
                    Dictionary<string, object>[] output = backup.Output;
                    foreach (object obj in list)
                    {
                        try
                        {
                            if (obj is Tuple<INativeReader, object[], DateTime> t)
                            {
                                p.DateTime = t.Item3;
                                t.Item1.Read(t.Item2);
                                if (stop(t))
                                {
                                    return true;
                                }
                                continue;
                            }
                        }
                        catch (Exception exception)
                        {
                            exception.HandleException(-1);
                            continue;
                        }
                        try
                        {
                            if (obj is Tuple<DateTime, INativeEvent, Dictionary<string, object>> tuple)
                            {
                                Dictionary<string, object> dob = tuple.Item3;
                                output[0] = tuple.Item3;
                                DateTime dt = tuple.Item1;
                                p.DateTime = tuple.Item1;
                                tuple.Item2.Force();
                                if (stop(tuple))
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            exception.HandleException(-1);
                            continue;
                        }
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerableDirectory(this IDataConsumer dataConsumer,
                    object input, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            if (input is ILogReaderCollection)
            {
                ILogReaderCollection lr = input as ILogReaderCollection;
                return dataConsumer.RealtimeAnalysisEnumerableDirectory(lr, stop, reason, timeType, isAbsoluteTime);
            }
            return null;
        }


        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerable(this IDataConsumer dataConsumer,
                    object input, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            if (input is ILogReader lr)
            {
                return dataConsumer.RealtimeAnalysisEnumerable(lr, stop, reason, timeType, isAbsoluteTime);
            }
            if (input is ILogReaderCollection lrc)
            {
                return dataConsumer.RealtimeAnalysisEnumerable(lrc, stop, reason, timeType, isAbsoluteTime);
            }
            if (input is IIterator)
            {

            }
            return null;
        }

        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="reader">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerable(this IDataConsumer dataConsumer,
                    ILogReader reader, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            IEnumerable<object> en = reader.Load(0, 0);
            return dataConsumer.RealtimeAnalysisEnumerable(en, stop, reason, timeType, isAbsoluteTime);
        }

        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="readers">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerable(this IDataConsumer dataConsumer,
                    ILogReaderCollection readers, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            IComponentCollection cc = dataConsumer.CreateCollection(reason);
            cc.ForEach((ICalculationReason re) => { re.CalculationReason = reason; });
            cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
            IEnumerable<ILogReader> r = readers.Readers;
            foreach (ILogReader reader in r)
            {
                cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                IEnumerable<object> en =
                        dataConsumer.RealtimeAnalysisEnumerable(reader, stop, reason, timeType, isAbsoluteTime);
                foreach (object o in en)
                {
                    yield return o;
                }
                cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
            }
            cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
        }

        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="readers">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerableDirectory(this IDataConsumer dataConsumer,
                    ILogReaderCollection readers, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            IComponentCollection cc = dataConsumer.CreateCollection(reason);
            cc.ForEach((ICalculationReason re) => { re.CalculationReason = reason; });
            cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
            IEnumerable<ILogReader> r = readers.Readers;
            foreach (ILogReader reader in r)
            {
                cc.ForEach((IRealTimeStartStop ss) => { ss.Start(); });
                IEnumerable<object> en =
                        dataConsumer.RealtimeAnalysisEnumerable(reader, stop, reason, timeType, isAbsoluteTime);
                object ob = null;
                foreach (object o in en)
                {
                    ob = o;
                }
                yield return ob;
                cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
            }
            cc.ForEach((IRealTimeStartStop ss) => { ss.Stop(); });
        }

        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerable(this IDataConsumer dataConsumer,
                    IEnumerable<object> input, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            IDesktop desktop = (dataConsumer as IAssociatedObject).GetRootDesktop();
            IComponentCollection collection = dataConsumer.CreateCollection(reason);
            StaticExtensionEventInterfaces.NewLog = null;
            using (IDisposable disp = collection.StartRealtime(timeType,
                 isAbsoluteTime, null, dataConsumer, null,
                 reason, null, false) as IDisposable)
            {
                IRealtime r = disp as IRealtime;
                var realtImeProvider = r.TimeProvider as RealtimeProvider;
                Dictionary<IReplacedMeasurementParameter, string> dReplaced;
                IEnumerable<object> list = dataConsumer.CreateList(input,
                    collection, out dReplaced);
                DateTime centuryBegin = new DateTime(2001, 1, 1);
                using (var backup = new ReplacedMeasurementsBackup(dReplaced, r))
                {
                    Dictionary<string, object>[] output = backup.Output;
                    foreach (object obj in list)
                    {
                        if (obj is Tuple<INativeReader, object[], DateTime> t)
                        {
                            try
                            {
                                realtImeProvider.DateTime = t.Item3;
                                t.Item1.Read(t.Item2);
                                if (stop(t))
                                {
                                    break;
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.HandleException(-1);
                                continue;
                            }
                            yield return obj;
                            continue;
                        }
                        try
                        {
                            if (obj is Tuple<DateTime, INativeEvent, Dictionary<string, object>> tuple)
                            {
                                output[0] = tuple.Item3;
                                DateTime dt = tuple.Item1;
                                realtImeProvider.DateTime = tuple.Item1;
                                tuple.Item2.Force();
                                if (stop(tuple))
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            exception.HandleException(-1);
                            continue;
                        }
                        yield return obj;
                    }
                }
            }
        }



        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        public static IEnumerable<object> RealtimeAnalysisEnumerable(this IDataConsumer dataConsumer,
            IEnumerable<IEnumerable<object>> input, Func<object, bool> stop, string reason,
                    TimeType timeType, bool isAbsoluteTime)
        {
            foreach (IEnumerable<object> enu in input)
            {
                IEnumerable<object> item = dataConsumer.RealtimeAnalysisEnumerable(enu, stop, reason, timeType, isAbsoluteTime);
                foreach (object obj in item)
                {
                    yield return obj;
                }
            }
        }


    
        /// <summary>
        /// Relative Time sign
        /// </summary>
        public static bool RelativeTime
        {
            get
            {
                return relativeTime;
            }
            set
            {
                relativeTime = value;
            }
        }

        /// <summary>
        /// Creates Enumerable
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="list">The input list</param>
        /// <param name="components"></param>
        /// <param name="dictionary">The dictionary of parameters</param>
        /// <returns>The list of log objects</returns>
        public static IEnumerable<object> CreateList(this IDataConsumer consumer, IEnumerable<object> list, IComponentCollection components,
                out Dictionary<IReplacedMeasurementParameter, string> dictionary)
        {
            Dictionary<IReplacedMeasurementParameter, string> dict = new Dictionary<IReplacedMeasurementParameter, string>();
            List<object> ll = new List<object>();
            components.ForEach((IMeasurements m) =>
            {
                string name = consumer.GetMeasurementsName(m) + ".";
                for (int i = 0; i < m.Count; i++)
                {
                    IMeasurement me = m[i];
                    if (me is IReplacedMeasurementParameter)
                    {
                        dict[me as IReplacedMeasurementParameter] = name + me.Name;
                    }
                }
            });
            Dictionary<string, INativeReader> dnr = new Dictionary<string, INativeReader>();
            components.ForEach((INativeReader reader) =>
            {
                if (reader is IAssociatedObject ao)
                {
                    string name = (consumer as IAssociatedObject).GetRelativeName(ao);
                    dnr[name] = reader;
                }
            });
            Dictionary<string, INativeEvent> dna = new Dictionary<string, INativeEvent>();
            IAssociatedObject ao = consumer as IAssociatedObject;
            components.ForEach((INativeEvent ne) =>
            {
                dna[ao.GetRelativeName(ne as IAssociatedObject)] = ne;
            });
            dictionary = dict;
            return consumer.CreateListPrivate(list,  components, dictionary, dnr, dna);
        }

        /// <summary>
        /// Modelled after CreateList meotod. Both methods have to be roofed by a single method, with and object of Object class rather than IEnumerable or IITerator
        /// </summary>
        /// <param name="consumer"></param>
        /// <param name="list"></param>
        /// <param name="components"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static IIterator CreateIterator(this IDataConsumer consumer, IEnumerable<object> list, IComponentCollection components,
                out Dictionary<IReplacedMeasurementParameter, string> dictionary)
        {
            Dictionary<IReplacedMeasurementParameter, string> dict = new Dictionary<IReplacedMeasurementParameter, string>();
            List<object> ll = new List<object>();
            components.ForEach((IMeasurements m) =>
            {
                string name = consumer.GetMeasurementsName(m) + ".";
                for (int i = 0; i < m.Count; i++)
                {
                    IMeasurement me = m[i];
                    if (me is IReplacedMeasurementParameter)
                    {
                        dict[me as IReplacedMeasurementParameter] = name + me.Name;
                    }
                }
            });
            Dictionary<string, INativeReader> dnr = new Dictionary<string, INativeReader>();
            components.ForEach((INativeReader reader) =>
            {
                if (reader is IAssociatedObject)
                {
                    string name = (consumer as IAssociatedObject).GetRelativeName(
                        reader as IAssociatedObject);
                    dnr[name] = reader;
                }
            });
            Dictionary<string, INativeEvent> dna = new Dictionary<string, INativeEvent>();
            IAssociatedObject ao = consumer as IAssociatedObject;
            components.ForEach((INativeEvent ne) =>
            {
                dna[ao.GetRelativeName(ne as IAssociatedObject)] = ne;
            });
            dictionary = dict;

            return null;
        }


        /// <summary>
        /// On error event
        /// </summary>
        public static event Action<Exception> OnError
        {
            add { Runtime.OnError += value; }
            remove { Runtime.OnError -= value; }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Realtime analysis enumerable
        /// </summary>
        /// <param name="dataConsumer">Data consumer</param>
        /// <param name="input">Input</param>
        /// <param name="stop">Stop function</param>
        /// <param name="reason">Reason</param>
        /// <param name="timeType">Time type</param>
        /// <param name="isAbsoluteTime">The absolute time "sign"</param>
        /// <returns>The enumerable</returns>
        private static IEnumerable<object>
            RealtimeAnalysisEnumerable(IEnumerable<object> list, ReplacedMeasurementsBackup backup, Func<object, bool> stop,
             RealtimeProvider p)
        {
            Dictionary<string, object>[] dm = backup.Output;
            foreach (object obj in list)
            {
                if (obj is Tuple<INativeReader, object[], DateTime>)
                {
                    try
                    {
                        Tuple<INativeReader, object[], DateTime> t = obj as Tuple<INativeReader, object[], DateTime>;
                        p.DateTime = t.Item3;
                        t.Item1.Read(t.Item2);
                        if (stop(t))
                        {
                            break;
                        }
                    }
                    catch (Exception exception)
                    {
                        exception.HandleException(-1);
                        continue;
                    }
                    yield return obj;
                    continue;
                }
                try
                {

                    Tuple<DateTime, INativeEvent, Dictionary<string, object>> tuple =
                    obj as Tuple<DateTime, INativeEvent, Dictionary<string, object>>;
                    dm[0] = tuple.Item3;
                    DateTime dt = tuple.Item1;
                    p.DateTime = tuple.Item1;
                    tuple.Item2.Force();
                    if (stop(tuple))
                    {
                        break;
                    }
                }
                catch (Exception exception)
                {
                    exception.HandleException(-1);
                    continue;
                }
                yield return obj;
            }
        }

        /// <summary>
        /// Creates 
        /// </summary>
        /// <param name="consumer">The data consumer</param>
        /// <param name="list">The input list</param>
        /// <param name="components"></param>
        /// <param name="dictionary">The dictionary of parameters</param>
        /// <returns>The list of log objects</returns>
        private static IEnumerable<object> CreateListPrivate(this IDataConsumer consumer, IEnumerable<object> list, IComponentCollection components,
                Dictionary<IReplacedMeasurementParameter, string> dictionary, Dictionary<string, INativeReader> dnr,
                 Dictionary<string, INativeEvent> dna)
        {
            Dictionary<string, object> dcurrent = new Dictionary<string, object>();
            List<object> used = new List<object>();
            List<object[]> usedArrays = new List<object[]>();
            var queueReplaced = new Queue<Tuple<DateTime, INativeEvent, Dictionary<string, object>>>();
            Tuple<DateTime, INativeEvent, Dictionary<string, object>> tp = null;
            IEnumerable<object> en = list;
            Tuple<string, DateTime> tsCurrent = null;
            Func<IEnumerable<object>, IEnumerable<object>> f = EnumerableTranformation;
            if (f != null)
            {
                en = f(en);
            }
            foreach (object current in en)
            {
                ++cadr;
                if (current is Tuple<Dictionary<string, object>, DateTime> cc)
                {
                    Dictionary<string, object> dc = cc.Item1;
                    foreach (string key in dc.Keys)
                    {
                        dcurrent[key] = dc[key];
                    }
                    if (tsCurrent != null)
                    {
                        var ret = new Tuple<DateTime, INativeEvent, Dictionary<string, object>>(tsCurrent.Item2,
                             dna[tsCurrent.Item1], dcurrent);
                        tsCurrent = null;
                        yield return ret;
                    }
                }
                else
                {
                    tp = null;
                    while (queueReplaced.Count > 0)
                    {
                        dcurrent = new Dictionary<string, object>();
                        yield return queueReplaced.Dequeue();
                    }
                }
                if (current is Tuple<string, object[], DateTime> t)
                {
                    object[] ob = t.Item2;
                    if (ob.Length > 0)
                    {
                        if (usedArrays.Contains(ob))
                        {
                            throw new Exception();
                        }
                        usedArrays.Add(ob);
                    }
                    yield return new Tuple<INativeReader, object[], DateTime>(dnr[t.Item1], ob, t.Item3);
                }
                if (current is Tuple<string, DateTime> ts)
                {
                    tsCurrent = ts;
                    continue;
                    if (dcurrent.Count > 0)
                    {
                        tp = new Tuple<DateTime, INativeEvent, Dictionary<string, object>>(ts.Item2,
                        dna[ts.Item1], dcurrent);
                        queueReplaced.Enqueue(tp);
                        dcurrent.Clear();
                    }
                }
            }
        }

        #endregion

        #region Helper Classes

        #region StartHelper class

        class StartHelper
        {
            Action<IComponentCollection> start;
            internal StartHelper(Action<IComponentCollection> start)
            {
                this.start = start;
                OnStartRealtime += StartAction;
            }

            void StartAction(IComponentCollection collection)
            {
                start(collection);
                OnStartRealtime -= StartAction;
            }
        }

        #endregion

        #region StopHelper class

        class StopHelper
        {
            Action stop;
            internal StopHelper(Action stop)
            {
                this.stop = stop;
                StaticExtensionEventPortable.Stop += StopAction;
            }

            void StopAction()
            {
                stop();
                StaticExtensionEventPortable.Stop -= StopAction;
            }
        }


        #endregion

        #endregion

    }
}