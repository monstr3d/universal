using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;


using CategoryTheory;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Wrapper of library arrow
    /// </summary>
    [Serializable()]
    public class LibraryArrowWrapper : CategoryArrowWrapper, ISerializable
    {
        #region Fields
        /// <summary>
        /// The name
        /// </summary>
        private string name;


        /// <summary>
        /// The properties
        /// </summary>
        protected object properties;

        /// <summary>
        /// bytes of assembly
        /// </summary>
        protected byte[] bytes;

        /// <summary>
        /// Assemblies
        /// </summary>
        static private Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="name">Name</param>
        private LibraryArrowWrapper(string filename, string name)
        {
            Load(filename);
            this.name = name;
            Load();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected LibraryArrowWrapper(SerializationInfo info, StreamingContext context)
        {
            bytes = info.GetValue("Bytes", typeof(byte[])) as byte[];
            name = info.GetValue("Name", typeof(string)) as string;
            try
            {
                properties = info.GetValue("Properties", typeof(object));
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            Load();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bytes", bytes, typeof(byte[]));
            info.AddValue("Name", name, typeof(string));
            if (theArrow != null)
            {
                IPropertiesEditor pe = theArrow.GetLabelObject <IPropertiesEditor>();
                if (pe != null)
                {
                    object prop = pe.Properties;
                    info.AddValue("Properties", prop, typeof(object));
                }
            }
        }

        #endregion

        #region Specific Membes

        /// <summary>
        /// Creates object from string
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>The object</returns>
        static public LibraryArrowWrapper Create(string str)
        {
            int n = str.IndexOf("::");
            string fn = str.Substring(0, n);
            string na = str.Substring(n + 2);
            return new LibraryArrowWrapper(fn, na);
        }

        /// <summary>
        /// Gets factory from assembly
        /// </summary>
        /// <param name="ass">The assembly</param>
        /// <returns>The factory</returns>
        static public IArrowFactory GetFactory(Assembly ass)
        {
            Type[] types = ass.GetTypes();

            foreach (Type type in types)
            {
                if (type.GetInterface("IArrowFactory") != null)
                {
                    FieldInfo fi = type.GetField("Object");
                    if (fi != null)
                    {
                        return fi.GetValue("Object") as IArrowFactory;
                    }
                    else
                    {
                        return type.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IArrowFactory;
                    }
                }
            }
            return null;
        }


        void Load()
        {
            byte[] bytesOut;
            Assembly ass = LibraryObjectWrapper.Load(bytes, out bytesOut);
            IArrowFactory f = GetFactory(ass);
            theArrow = f[name];
            ICategoryArrow arr = this;
            theArrow.SetAssociatedObject(arr.Object);
        }

        void Load(string filename)
        {
            Stream stream = File.OpenRead(filename);
            bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
        }


        #endregion
    }
}
