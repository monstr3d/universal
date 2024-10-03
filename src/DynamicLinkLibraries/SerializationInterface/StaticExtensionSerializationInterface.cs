using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationInterface
{
    /// <summary>
    /// Serialization operations
    /// </summary>
    public static class StaticExtensionSerializationInterface
    {
        /// <summary>
        /// Serialization binder
        /// </summary>
        private static SerializationBinder binder;

        private static BinaryFormatter binaryFormatter
        {
            get => new BinaryFormatter();
        }


        private static List<SerializationBinder> binders = new List<SerializationBinder>();

        /// <summary>
        /// Serialization
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="info">Serialization info</param>
        /// <param name="name">Name of object</param>
        /// <param name="obj">Object for serialization</param>
        public static void Serialize<T>(this SerializationInfo info, string name, T obj) where T : class
        {
            byte[] b = new byte[0];
            if (obj != null)
            {
                MemoryStream s = new MemoryStream();
                binaryFormatter.Serialize(s, obj);
                b = new byte[s.Length];
                Array.Copy(s.GetBuffer(), b, b.Length);
            }
            info.AddValue(name, b, typeof(byte[]));
        }

        /// <summary>
        /// Object serialization to bytes
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The bytes</returns>
        public static byte[] Serialize(this object obj)
        {
            MemoryStream ms = new MemoryStream();
            binaryFormatter.Serialize(ms, obj);
            byte[] buffer = new byte[ms.Position];
            Array.Copy(ms.GetBuffer(), buffer, buffer.Length);
            return buffer;
        }


        /// <summary>
        /// Deserialization
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="info">Serialization info</param>
        /// <param name="name">Name of object</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize<T>(this SerializationInfo info, string name) where T : class
        {
            byte[] b = info.GetValue(name, typeof(byte[])) as byte[];
            if (b == null)
            {
                return null;
            }
            if (b.Length == 0)
            {
                return null;
            }
            using (var stream = new MemoryStream(b))
            {
                return stream.Deserialize<T>();
            }
        }

        /// <summary>
        /// Deserialzes object from bytes
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="b">Bytes</param>
        /// <returns>The object</returns>
        public static T Deserialize<T>(this byte[] b) where T : class
        {
            if (b == null)
            {
                return null;
            }
            if (b.Length == 0)
            {
                return null;
            }
            MemoryStream s = new MemoryStream(b);
            return s.Deserialize<T>();
        }

        /// <summary>
        /// Deserialzes object from stream
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="stream">Stream</param>
        /// <returns>The object</returns>
        public static T Deserialize<T>(this Stream stream) where T : class
        {
            var bf = binaryFormatter;
            if (binder != null)
            {
                bf.Binder = binder;
            }
            var obj = bf.Deserialize(stream);
            return (T)obj;
        }

        /// <summary>
        /// Clones object by serialization
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">The prototype object</param>
        /// <returns>A clone</returns>
        public static T Clone<T>(this T obj) where T : class
        {
            MemoryStream ms = new MemoryStream();
            binaryFormatter.Serialize(ms, obj);
            ms.Position = 0;
            return binaryFormatter.Deserialize(ms) as T;
        }

        /// <summary>
        /// Serialization Binder
        /// </summary>
        public static SerializationBinder Binder
        {
            get
            {
                return binder;
            }
            set
            {
                if (binders.Contains(value))
                {
                    return;
                }
                binders.Add(value);
                if (binder == null)
                {
                    binder = value;
                    return;
                }
                if (binder is BinderCollection)
                {
                    BinderCollection bc = binder as BinderCollection;
                    bc.Add(value);
                    return;
                }
                binder = new BinderCollection(new SerializationBinder[] { binder, value });
            }
        }

        /// <summary>
        /// Gets bytes of file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Bytes</returns>
        public static byte[] GetFileBytes(this string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            using (Stream stream = File.OpenRead(fileName))
            {
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
                return b;
            }
        }

    }
}
