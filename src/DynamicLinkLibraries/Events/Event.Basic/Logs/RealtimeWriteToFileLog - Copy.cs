using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Diagram.UI;

using Event.Interfaces;

namespace Event.Basic.Logs
{
    /// <summary>
    /// Log with realtime writing
    /// </summary>
    public class RealtimeWriteToFileLog : IEventLog, IDisposable
    {
        #region Fields

        /// <summary>
        /// The singleton
        /// </summary>
        public static readonly RealtimeWriteToFileLog Singleton = new RealtimeWriteToFileLog(false);

        protected Stream stream;

        BinaryFormatter formatter = new BinaryFormatter();

        static string direrctory;

        string fileName;

        private static event Action<string> postSave = 
            (string fileName) => { };

        volatile Queue<object> queue = new Queue<object>();


        volatile Dictionary<DateTime, object> dictionary = new Dictionary<DateTime, object>();

        AutoResetEvent autoreset = new AutoResetEvent(false);

        AutoResetEvent auto = new AutoResetEvent(false);

        bool stopped;

        #endregion

        #region Ctor

        private RealtimeWriteToFileLog()
        {
            fileName = direrctory + Path.DirectorySeparatorChar + Guid.NewGuid() + "CurrentLog.Log";
            stream = File.OpenWrite(fileName);
            Thread thread = new Thread(Run);
            thread.Start();
        }

        private RealtimeWriteToFileLog(bool b)
        {

        }

        #endregion

        #region IEventLog Members

        IEventLog IEventLog.NewLog
        {
            get
            {
                return new RealtimeWriteToFileLog();
            }
        }

        void IEventLog.Write(Dictionary<string, object> data, DateTime time)
        {
            Tuple<Dictionary<string, object>, DateTime> t = new Tuple<Dictionary<string, object>, DateTime>(data, time);
            t.TransformSave();
            //formatter.Serialize(stream, t);
            Save(t, time);
        }

        void IEventLog.Write(IEvent ev, string name, DateTime time)
        {
           // formatter.Serialize(stream, new Tuple<string, DateTime>(name, time));
            Save(new Tuple<string, DateTime>(name, time), time);
        }

        void IEventLog.Write(IEventReader reader, string name, object[] output, DateTime time)
        {
            Tuple<string, object[], DateTime> t = new Tuple<string, object[], DateTime>(name, output, time);
            t.TransformSave();
            Save(t, time);
           // formatter.Serialize(stream, t);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            DisposeStream();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Post Save enent
        /// </summary>
        public static event Action<string> PostSave
        {
            add { postSave += value; }
            remove { postSave -= value; }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Disposes the stream
        /// </summary>
        protected virtual void DisposeStream()
        {
            stopped = true;
            autoreset.Set();
            auto.WaitOne();
            if (stream != null)
            {
                stream.Flush();
                stream.Dispose();
                stream = null;
                string f = direrctory + Path.DirectorySeparatorChar + (DateTime.Now + 
                    "").Replace("/", "_").Replace(":", "_") + ".filelog";
                File.Move(fileName, f);
                postSave(f);
            }
        }

        #endregion

        #region Private Members

        void Save(object o, DateTime dt)
        {
            Save(o);
            if ((o == null) | stopped)
            {
                return;
            }
            dictionary[dt] = o;
            autoreset.Set();
        }


        void Save(object o)
        {
            if (stopped)
            {
                return;
            }
            queue.Enqueue(o);
            autoreset.Set();
        }

        object locker = new object();

        void Run()
        {
            while (true)
            {
                autoreset.WaitOne();
                /* lock (locker)
                   {
                       List<DateTime> l = new List<DateTime>(dictionary.Keys);
                       l.Sort();
                       foreach (DateTime dt in l)
                       {
                           object o = dictionary[dt];
                           dictionary.Remove(dt);
                           if (o != null)
                           {
                               formatter.Serialize(stream, o);
                           }
                       }
                   }

                   continue;
                   */
                while (queue.Count > 0)
                {
                    object obj = queue.Dequeue();
                    if (obj != null)
                    {
                        formatter.Serialize(stream, obj);
                    }
                }
                if (stopped)
                {
                    auto.Set();
                    return;
                }

            }
        }

        #endregion

        static RealtimeWriteToFileLog()
        {
            direrctory = AppDomain.CurrentDomain.BaseDirectory + "Logs";
            if (!Directory.Exists(direrctory))
            {
                Directory.CreateDirectory(direrctory);
            }
        }
        
    }
}
