using System;
using System.Collections.Generic;

using CategoryTheory;


namespace Event.Interfaces
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionEventInterfaces
    {
        #region Fields

        /// <summary>
        /// Realtime
        /// </summary>
        public const string Realtime = "Realtime";

        /// <summary>
        /// Realtime Log Analysis
        /// </summary>
        public const string RealtimeLogAnalysis = "RealtimeLogAnalysis";

        /// <summary>
        ///  Pure realtime Log Analysis
        /// </summary>
        public const string PureRealtimeLogAnalysis = "PureRealtimeLogAnalysis";

        static List<EventLogLink> links = new ();

        static List<EventReaderLink> readers = new ();

        static IEventLog currentLog;

        static ILogLoader listLoader = new LogListLoaderCollection(new ILogLoader[0]);


        static List<Func<object, object>> loadList = new ();

        static List<Func<object, object>> saveList = new ();


        static event Action<string> postSaveLog;

        /// <summary>
        /// Locker
        /// </summary>
       static public  object Locker
        { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// Action factory creator
        /// </summary>
        public static IActionFactoryCreator ActionFactoryCreator
        { get; set; }

        /// <summary>
        /// Sets base action
        /// </summary>
        /// <param name="creator">Actiom creator</param>
        public static void SetBaseAction(this IActionFactoryCreator creator)
        {
            if (creator == null)
            {
                throw new Exception("SetBaseAction");
            }
            if (ActionFactoryCreator == null)
            {
                ActionFactoryCreator = creator;
                return;
            }
            if (ActionFactoryCreator.IsBase(creator))
            {
                ActionFactoryCreator = creator; 
            }
        }


        /// <summary>
        /// Checks where reason is realtime analysis
        /// </summary>
        /// <param name="reason">Calculation reason</param>
        /// <returns>Check result</returns>
        static public bool IsRealtimeAnalysis(this string reason)
        {
            return reason.Equals(RealtimeLogAnalysis) |
                reason.Equals(PureRealtimeLogAnalysis);
        }

        /// <summary>
        /// Post save log events
        /// </summary>
        static public event Action<string> PostSaveLog
        {
            add { postSaveLog += value; }
            remove { postSaveLog -= value; }
        }

        /// <summary>
        /// Post save log
        /// </summary>
        /// <param name="id">Log id</param>
        static public void LogPostSave(string id)
        {
            postSaveLog?.Invoke(id);
        }

        /// <summary>
        /// LockedAction
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Locked action</returns>
        static public Action LockedAction(this Action action)
        {
            if (Locker == null)
            {
                return action;
            }
             
            return () =>
            {
                lock (Locker)
                {
                    action();
                }
            };
        }

        /// <summary>
        /// Loads log
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>Log reader</returns>
        public static object LoadLog(this string url, uint begin, uint end)
        {
            return listLoader.Load(url, begin, end);
        }

    
        /// <summary>
        /// Adds list loader
        /// </summary>
        /// <param name="loader"></param>
        public static void AddListLoader(this ILogLoader loader)
        {
            LogListLoaderCollection c = listLoader as LogListLoaderCollection;
            c.Add(loader);
        }


        /// <summary>
        /// Transformation of a list for load
        /// </summary>
        /// <param name="list">Transformed list</param>
        public static void TransformLogLoad(this List<object> list)
        {
            Transform(list, loadList);
        }

        /// <summary>
        /// Transformation of a list for load
        /// </summary>
        /// <param name="list">Transformed list</param>
        public static IEnumerable<object> TransformLogLoad(this IEnumerable<object> list)
        {
           return  Transform(list, loadList);
        }


        /// <summary>
        /// Transformation of a list for save
        /// </summary>
        /// <param name="list">Transformed list</param>
        public static void TransformLogSave(this List<object> list)
        {
            Transform(list, saveList);
        }

        /// <summary>
        /// Adds a load function
        /// </summary>
        /// <param name="function">The function</param>
        public static void AddLoadFunction(this Func<object, object> function)
        {
            function.Add(loadList);
        }

        /// <summary>
        /// Adds a load function
        /// </summary>
        /// <param name="function">The function</param>
        public static void AddSaveFunction(this Func<object, object> function)
        {
            function.Add(saveList);
        }

        /// <summary>
        /// Factory of logs
        /// </summary>
        public static IEventLog LogFactory
        {
            get;
            set;
        }

        /// <summary>
        /// The "has log" sign
        /// </summary>
        public static bool HasLog
        {  get; set; } = false;

        /// <summary>
        /// New log
        /// </summary>
        public static IEventLog NewLog
        {
            get
            {
                if (!HasLog)
                {
                    return null;
                }
                if (currentLog == null)
                {
                    if (LogFactory != null)
                    {
                        currentLog = LogFactory.NewLog;
                    }
                }
                return currentLog;
            }
            set
            {
                currentLog = value;
            }
        }

        /// <summary>
        /// Currrent log
        /// </summary>
        public static IEventLog CurrentLog
        {
            get
            {
                return currentLog;
            }
        }


        /// <summary>
        /// Connects log
        /// </summary>
        /// <param name="ev">Event</param>
        /// <param name="log">Log</param>
        /// <param name="name">Name</param>
        public static void ConnectLog(this IEvent ev, IEventLog log, string name)
        {
            links.Add(new EventLogLink(ev, log, name));
        }

        /// <summary>
        /// Connect to Log
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="log">Log</param>
        /// <param name="name">Name of the reader</param>
        public static void ConnectLog(this IEventReader reader, IEventLog log, string name)
        {
            if (reader is INativeReader)
            {
                readers.Add(new EventReaderLink(reader, log, name));
            }
        }

        /// <summary>
        /// Disconnect log
        /// </summary>
        public static void DisconnectLog()
        {
            foreach (EventLogLink l in links)
            {
                l.Dispose();
            }
            foreach (EventReaderLink l in readers)
            {
                l.Dispose();
            }
            links.Clear();
            readers.Clear();
            if (currentLog is IDisposable)
            {
                (currentLog as IDisposable).Dispose();
            }
        }

        /// <summary>
        /// Facotory of times
        /// </summary>
        public static ITimerFactory TimerFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Timer factory
        /// </summary>
        static public ITimerEventFactory TimerEventFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Creates timer
        /// </summary>
        /// <param name="timeSpan">Time span</param>
        /// <returns>The timer</returns>
        public static ITimer CreateTimer(this TimeSpan timeSpan)
        {
            return TimerFactory.CreateTimer(timeSpan);
        }

        /// <summary>
        /// Transformation for save
        /// </summary>
        /// <param name="tuple">The tuple</param>
        public static void TransformSave(this Tuple<Dictionary<string, object>, DateTime> tuple)
        {
            tuple.Transform(saveList);
        }

        /// <summary>
        /// Transformation for save
        /// </summary>
        /// <param name="tuple">The tuple</param>
        public static void TransformSave(this Tuple<string, object[], DateTime> tuple)
        {
            tuple.Transform(saveList);
        }

        #endregion

        #region Private Members

        private static void Add(this Func<object, object> f, List<Func<object, object>> list)
        {
            list.Add(f);
        }

        /// <summary>
        /// Transformatiom
        /// </summary>
        /// <param name="ob">Object</param>
        /// <param name="l">Function list</param>
        /// <returns>Transformation result</returns>
        static object Transform(this object ob, List<Func<object, object>> l)
        {
            object o = ob;
            foreach (Func<object, object> f in l)
            {
                o = f(o);
            }
            return o;
        }

        static void Transform(this Tuple<Dictionary<string, object>, DateTime> tuple, List<Func<object, object>> trans)
        {
            Dictionary<string, object> d = tuple.Item1;
            List<string> l = new List<string>(d.Keys);
            foreach (string key in l)
            {
                d[key] = d[key].Transform(trans);
            }
        }

        static void Transform(this Tuple<string, object[], DateTime> tuple, List<Func<object, object>> trans)
        {
            object[] ob = tuple.Item2;
            for (int i = 0; i < ob.Length; i++)
            {
                ob[i] = ob[i].Transform(trans);
            }
        }

        static IEnumerable<object> Transform(IEnumerable<object> list, List<Func<object, object>> trans)
        {
            foreach (object o in list)
            {
                if (o is Tuple<Dictionary<string, object>, DateTime>)
                {
                    Tuple<Dictionary<string, object>, DateTime> t =
                        o as Tuple<Dictionary<string, object>, DateTime>;
                    Dictionary<string, object> d = t.Item1;
                    List<string> l = new List<string>(d.Keys);
                    foreach (string key in l)
                    {
                        d[key] = d[key].Transform(trans);
                    }
                }
                if (o is Tuple<string, object[], DateTime>)
                {
                    Tuple<string, object[], DateTime> t = o as Tuple<string, object[], DateTime>;
                    object[] ob = t.Item2;
                    for (int i = 0; i < ob.Length; i++)
                    {
                        ob[i] = ob[i].Transform(trans);
                    }
                }
                yield return o;
            }
        }

        static void Transform(List<object> list, List<Func<object, object>> trans)
        {
            object[] obj = null;
            foreach (object o in list)
            {
                if (o is Tuple<Dictionary<string, object>, DateTime> t)
                {
                    Dictionary<string, object> d = t.Item1;
                    List<string> l = new List<string>(d.Keys);
                    foreach (string key in l)
                    {
                        d[key] = d[key].Transform(trans);
                    }
                }
                if (o is Tuple<string, object[], DateTime> tt)
                {
                    object[] ob = tt.Item2;
                    obj = ob;
                    for (int i = 0; i < ob.Length; i++)
                    {
                        ob[i] = ob[i].Transform(trans);
                    }
                }
            }
        }

        #endregion
    }
}