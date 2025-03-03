using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.IO;

using CategoryTheory;

using SerializationInterface;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Wrapper of object loaded from dll
    /// </summary>
    [Serializable()]
    public class LibraryObjectWrapper : CategoryObjectWrapper, ISerializable
    {

        #region Fields

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The dll path
        /// </summary>
        private string filename;

        /// <summary>
        /// The properties
        /// </summary>
        protected object properties;

        /// <summary>
        /// Assemblies
        /// </summary>
        static private Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LibraryObjectWrapper()
        {
        }

        /// <summary>
        /// Deserialisation constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public LibraryObjectWrapper(SerializationInfo info, StreamingContext context)
        {
            filename = info.GetValue("FileName", typeof(string)) + "";
            name = info.GetValue("Name", typeof(string)) + "";
            try
            {
                properties = info.GetValue("Properties", typeof(object));
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            Initialize();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="name">Name</param>
        private LibraryObjectWrapper(string filename, string name)
        {
            this.filename = filename;
            this.name = name;
            Initialize();
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileName", filename);
            info.AddValue("Name", name);
            if (theObject != null)
            {
                IPropertiesEditor pe = theObject.GetObject<IPropertiesEditor>();
                if (pe != null)
                {
                    object prop = pe.Properties;
                    info.AddValue("Properties", prop, typeof(object));
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates object
        /// </summary>
        /// <param name="str">Strinf of filename and nale</param>
        /// <returns>Created object</returns>
        static public LibraryObjectWrapper Create(string str)
        {
            int n = str.IndexOf("::");
            string fn = str.Substring(0, n);
            string na = str.Substring(n + 2);
            return new LibraryObjectWrapper(fn, na);
        }


        /// <summary>
        /// Loads assembly from bytes
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <param name="bytesOut">The bytes</param>
        /// <returns>The assembly</returns>
        public static Assembly Load(byte[] bytes, out byte[] bytesOut)
        {
            bytesOut = null;
            Assembly[] assemb = AppDomain.CurrentDomain.GetAssemblies();
            Assembly ass = Assembly.Load(bytes);
            Assembly asr = ass.Replace();
            if (asr != null)
            {
                ass = asr;
                string f = ass.Location;
                bytesOut = f.GetFileBytes();
            }
            string an = ass.FullName;
            if (assemblies.ContainsKey(an))
            {
                return assemblies[an];
            }
            foreach (Assembly a in assemb)
            {
                if (an.Equals(a.FullName))
                {
                    ass = a;
                    break;
                }
            }
            assemblies[an] = ass;
            return ass;
        }

        /// <summary>
        /// Transformation to bytes for serialization
        /// </summary>
        /// <param name="obj">Object for serialization</param>
        /// <returns>Serialization bytes</returns>
        public static object[] TransformToBytes(object[] obj)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            object[] o = new object[obj.Length];
            for (int i = 0; i < o.Length; i++)
            {
                object ob = obj[i];
                if (ob == null)
                {
                    continue;
                }
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, ob);
                o[i] = stream.GetBuffer();
            }
            return o;
        }

        /// <summary>
        /// Transformation from bytes of deserialization
        /// </summary>
        /// <param name="obj">Object for desserialization</param>
        /// <returns>Deserialized objects</returns>
        public static object[] TransformFromBytes(object[] obj)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter =
                 new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            object[] o = new object[obj.Length];
            for (int i = 0; i < o.Length; i++)
            {
                object ob = obj[i];
                if (ob == null)
                {
                    continue;
                }
                byte[] b = ob as byte[];
                MemoryStream stream = new MemoryStream(b);
                o[i] = formatter.Deserialize(stream);
            }
            return o;
        }

        /// <summary>
        /// Gets names of objects
        /// </summary>
        /// <param name="filename">File name of library object</param>
        /// <returns>The names</returns>
        static public string[] GetNames(string filename)
        {
            Assembly ass = null;
            if (BinaryLoader.Object != null)
            {
                byte[] b = BinaryLoader.Object[filename];
                if (b != null)
                {
                    byte[] bytesOut;
                    ass = Load(b, out bytesOut);
                }
            }
            if (ass == null)
            {
                ass = Assembly.LoadFile(filename);
            }
            IObjectFactory factory = GetFactory(ass);
            return factory.Names;
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="name">Name</param>
        public void Set(string filename, string name)
        {
            this.filename = filename;
            this.name = name;
            Initialize();
        }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName
        {
            get
            {
                return filename;
            }
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected void Initialize()
        {
            Assembly ass = null;
            if (BinaryLoader.Object != null)
            {
                byte[] b = BinaryLoader.Object[filename];
                if (b != null)
                {
                    byte[] bytesOut;
                    ass = Load(b, out bytesOut);
                }
            }
            if (ass == null)
            {
                ass = Assembly.LoadFile(filename);
            }
            IObjectFactory factory = GetFactory(ass);
            theObject = factory[name];
            childern[0] = theObject;
            if (Object != null)
            {
                theObject.SetAssociatedObject(Object);
            }
            IPropertiesEditor pe = theObject.GetObject<IPropertiesEditor>();
            if ((properties != null) & (pe != null))
            {
                pe.Properties = properties;
            }
        }

        /// <summary>
        /// Gets factory from assembly
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <returns>The factory</returns>
        static public IObjectFactory GetFactory(Assembly assembly)
        {
            Type[] types = assembly.GetTypes(); // Types of assembly
            foreach (Type type in types)
            {
                if (type.GetInterface("IObjectFactory") != null)
                {
                    // Looking for singleton
                    FieldInfo fi = type.GetField("Object");
                    if (fi != null)
                    {
                        return fi.GetValue("Object") as IObjectFactory;
                    }
                    else
                    {
                        // Calling of default constructor
                        return type.GetConstructor(new Type[] { }).Invoke(new object[] { }) as IObjectFactory;
                    }
                }
            }
            return null;
        }

 
        #endregion

    }
}
