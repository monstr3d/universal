using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.IO;


using CategoryTheory;
using ErrorHandler;

namespace Diagram.UI
{
    /// <summary>
    /// Object of multiple libraries
    /// </summary>
    [Serializable()]
    public class MultiLibraryObject : CategoryObjectWrapper, ISerializable
    {
        #region Fields

        /// <summary>
        /// Auxiliary libraries
        /// </summary>
        List<byte[]> bytes = new List<byte[]>();

        /// <summary>
        /// Names of libraries
        /// </summary>
        List<string> names = new List<string>();

        /// <summary>
        /// Name of object
        /// </summary>
        string name;

        /// <summary>
        /// The properties
        /// </summary>
        protected object properties;

        /// <summary>
        /// Assembly
        /// </summary>
        private Assembly assembly;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MultiLibraryObject()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MultiLibraryObject(SerializationInfo info, StreamingContext context)
        {
            bytes = info.GetValue("Bytes", typeof(List<byte[]>)) as List<byte[]>;
            name = info.GetValue("Name", typeof(string)) as string;
            names = info.GetValue("Names", typeof(List<string>)) as List<string>;
            try
            {
                properties = info.GetValue("Properties", typeof(object));
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            init();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bytes", bytes, typeof(List<byte[]>));
            info.AddValue("Name", name, typeof(string));
            info.AddValue("Names", names, typeof(List<string>));
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

        #region Specific Members
        
        /// <summary>
        /// Adds dynamic link library
        /// </summary>
        /// <param name="filename">Library file</param>
        public void Add(string filename)
        {
            Stream stream = File.OpenRead(filename);
            byte[] b = new byte[stream.Length];
            stream.Read(b, 0, b.Length);
            stream.Close();
            byte[] bytesOut;
            assembly = LibraryObjectWrapper.Load(b, out bytesOut);
            bytes.Add(b);
            names.Add(filename);
        }

        /// <summary>
        /// Name of object
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                theObject = Factory[name];
                children[0] = theObject;
                if (Object != null)
                {
                    theObject.SetAssociatedObject(Object);
                }
            }
        }

        /// <summary>
        /// Libraries
        /// </summary>
        public string[] Libraries
        {
            get
            {
                if (names.Count == 0)
                {
                    return null;
                }
                string[] s = new string[names.Count];
                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = names[i] + "";
                }
                return s;
            }
        }

        /// <summary>
        /// Factory
        /// </summary>
        public IObjectFactory Factory
        {
            get
            {
                if (assembly == null)
                {
                    return null;
                }
                return LibraryObjectWrapper.GetFactory(assembly);
            }
        }

        /// <summary>
        /// Assembly
        /// </summary>
        public Assembly Assembly
        {
            get
            {
                return assembly;
            }

            set
            {
                assembly = value;
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected void init()
        {
            byte[] bytesOut = null;
            int i = 0;
            List<byte[]> lb = new List<byte[]>(bytes);
            foreach (byte[] b in lb)
            {
                assembly = LibraryObjectWrapper.Load(b, out bytesOut);
                if (bytesOut != null)
                {
                    bytes[i] = bytesOut;
                }
                ++i;
            }
            IObjectFactory factory = Factory;
            theObject = factory[name];
            children[0] = theObject;
            IPropertiesEditor pe = theObject.GetObject<IPropertiesEditor>();
            if ((properties != null) & (pe != null))
            {
                pe.Properties = properties;
            }
            if (bytesOut != null)
            {
                 Interfaces.ISeparatedAssemblyEditedObject
                    ine = theObject.GetObject<Interfaces.ISeparatedAssemblyEditedObject>();
                if (ine != null)
                {
                    ine.FirstLoad();
                }
            }
            if (Object != null)
            {
               theObject.SetAssociatedObject(Object);
            }
        }


        #endregion
    }
}
