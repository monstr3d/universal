using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;


using Event.Interfaces;
using Event.Portable;
using Event.Log.Database;
using Event.Log.Database.Interfaces;
using Event.Basic.Logs;
using AssemblyService.Attributes;

namespace Event.Basic
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventBasic
    {
        #region Fields

        private static event Action<Stream> postSaveLog = (Stream stream) => { };

        private static event Action<Stream> postLoadLog = (Stream stream) => { };

        static BinaryFormatter formatter = new BinaryFormatter();

        #endregion

        #region Ctor


        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionEventBasic()
        {
            FileLogListLoader.Singleton.AddListLoader();
            RealtimeReadFromFileLog.Singleton.AddListLoader();
            (new DatabaseLogLoader()).AddListLoader();
            DataPerformer.Interfaces.StaticExtensionDataPerformerInterfaces.BytesToObject =
                TransformDeserialize;
            DataPerformer.Interfaces.StaticExtensionDataPerformerInterfaces.ObjectToBytes =
                  TransformSerialize;
        }

        #endregion

        #region Members

        /// <summary>
        /// Serialization Binder
        /// </summary>
        static public SerializationBinder Binder
        {
            get
            {
                return formatter.Binder;
            }
            set
            {
                formatter.Binder = value;
            }
        }

        /// <summary>
        /// Gets length of log item
        /// </summary>
        /// <param name="item">The intem</param>
        /// <returns>The length</returns>
        public static int GetLength(this ILogItem item)
        {
            if (item is ILogData)
            {
                return (item as ILogData).Length;
            }
            object r = item.LogFromItem();
            if (r is ILogReaderCollection)
            {
                int n = 0;
                ILogReaderCollection collection = r as ILogReaderCollection;
                foreach (ILogReader reader in collection.Readers)
                {
                    n += reader.FullLength;
                }
                return n;
            }
            return 0;
        }       


        /// <summary>
        /// Data from item
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Log reader</returns>
        static public object LogFromItem(this ILogItem item)
        {
            if (item is ILogData)
            {
                return new DatabaseLogReader(item as ILogData);
            }
            if (item is ILogDirectory)
            {
                return new DatabaseDirectoryLogReader(item as ILogDirectory);
            }
            return null;
        }

        /// <summary>
        /// Data from url
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Log reader</returns>
        static public object LogFromUrl(this string url)
        {
            ILogItem item = url.ItemFromUrl();
            if (item is ILogData)
            {
                return new DatabaseLogReader(item as ILogData);
            }
            if (item is ILogDirectory)
            {
                return new DatabaseDirectoryLogReader(item as ILogDirectory);
            }
            return null;
        }

        /// <summary>
        /// Post save log event
        /// </summary>
        public static event Action<Stream> PostSaveLog
        {
            add { postSaveLog += value; }
            remove { postSaveLog -= value; }
        }

        /// <summary>
        /// Post load log event
        /// </summary>
        public static event Action<Stream> PostLoadLog
        {
            add { postLoadLog += value; }
            remove { postLoadLog -= value; }
        }

        /// <summary>
        /// Transorms object from bytes by deserialization
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>ob</returns>
        public static object TransformDeserialize(this byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Transorms bytes from object by serialization
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>ob</returns>
        public static byte[] TransformSerialize(this object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                byte[] b = stream.GetBuffer();
                byte[] outp = new byte[stream.Length];
                Array.Copy(b, outp, outp.Length);
                return outp;
            }
        }

        /// <summary>
        /// Deseriaization of enumerable
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Enumerable</returns>
        public static IEnumerable<object> FromBytes(this IEnumerable<byte[]> bytes)
        {
            foreach (byte[] b in bytes)
            {
                using (MemoryStream stream = new MemoryStream(b))
                {
                    stream.Position = 0;
                    yield return formatter.Deserialize(stream);
                }

            }
        }

        /// <summary>
        /// Transfrmation to bytes
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>Transformation result</returns>
        public static IEnumerable<byte[]> ToBytes(this ILogReader reader, uint begin, uint end)
        {
            IEnumerable<object> en = reader.Load(begin, end);
            foreach (object o in en)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, o);
                    byte[] b = stream.GetBuffer();
                    byte[] outp = new byte[stream.Length];
                    Array.Copy(b, outp, outp.Length);
                    yield return outp;
                }
            }
        }

        /// <summary>
        /// Transfrmation to stream
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>Transformation result</returns>
        public static void ToStream(this ILogReader reader, Stream stream, uint begin, uint end)
        {
            IEnumerable<object> en = reader.Load(begin, end);
            foreach (object o in en)
            {
                formatter.Serialize(stream, o);
            }
        }

        /// <summary>
        /// To object enumerable
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>The enumerable</returns>
        static public IEnumerable<object> ToObjectEnumerable(this Stream stream)
        {
            long length = stream.Length;
            while (stream.Position < length)
            {
                object o = null;
                try
                {
                    o = formatter.Deserialize(stream);
                }
                catch
                {
                    break;
                }
                yield return o;
            }
        }

   /*     /// <summary>
        /// To object enumerable
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>The enumerable</returns>
        static public IEnumerable<object> ToObjectEnumerable(this string fileName)
        {
            using (Stream stream = File.OpenRead(fileName))
            {
                return stream.ToObjectEnumerable();
            }
        }

    */

        /// <summary>
        /// To byte enumerable
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <returns>Bytes</returns>
        static public IEnumerable<byte[]> ToByteEnumerable(this IEnumerable<object> objects)
        {
            foreach (object o in objects)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, o);
                    byte[] b = stream.GetBuffer();
                    byte[] outp = new byte[stream.Length];
                    Array.Copy(b, outp, outp.Length);
                    yield return outp;
                }
            }
        }

        /// <summary>
        /// Post load log
        /// </summary>
        /// <param name="stream"></param>
        public static void LogPostLoad(this Stream stream)
        {
            postLoadLog(stream);
        }
        /// <summary>
        /// Post save log
        /// </summary>
        /// <param name="stream"></param>
        public static void LogSaveLoad(this Stream stream)
        {
            postSaveLog(stream);
        }

        /// <summary>
        /// Transforms list to bytes
        /// </summary>
        /// <param name="list">List of objects</param>
        /// <returns></returns>
        public static byte[] LogListToBytes(this List<object> list)
        {
            MemoryStream stream = new MemoryStream();
            list.TransformLogSave();
            formatter.Serialize(stream, list);
            postSaveLog(stream);
            byte[] b = stream.GetBuffer();
            byte[] outp = new byte[stream.Length];
            Array.Copy(b, outp, outp.Length);
            return outp;
        }

        /// <summary>
        /// Transforms bytes to list 
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>List</returns>
        public static List<object> LogListFromBytes(this byte[] bytes)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(bytes, 0, bytes.Length);
            List<object> list = formatter.Deserialize(stream) as List<object>;
            postLoadLog(stream);
            list.TransformLogLoad();
            return list;
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        /// <summary>
        /// Saves log to file
        /// </summary>
        /// <param name="log">Log</param>
        /// <param name="filename">File name</param>
        public static void SaveToFile(this ISaveLog log, string filename)
        {
            using (Stream stream = File.OpenWrite(filename + "." + log.Extension))
            {
                byte[] b = log.Bytes;
                stream.Write(b, 0, b.Length);
            }
        }

        #endregion

    }
}
