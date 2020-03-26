using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

using Event.Interfaces;


namespace Event.Basic.Events
{
    /// <summary>
    /// External event
    /// </summary>
    public class ExternalEvent : ISerializable, IPropertiesEditor,
       ISeparatedAssemblyEditedObject, IEvent
    {
        #region Fields

        /// <summary>
        /// Events
        /// </summary>
        static List<string> events = new List<string>();

        /// <summary>
        /// Event
        /// </summary>
        IEvent ev;

        /// <summary>
        /// Editor of properties
        /// </summary>
        ISeparatedPropertyEditor editor;

        /// <summary>
        /// Type of event
        /// </summary>
        string eventType;

        /// <summary>
        /// Bytes
        /// </summary>
        byte[][] bytes = new byte[3][];

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public ExternalEvent(string types)
        {
            string[] s = types.Split(";".ToCharArray());
            eventType = s[0];
            Type t = Type.GetType(eventType);
            ev = t.GetConstructor(new Type[0]).Invoke(new object[0]) as IEvent;
            using (System.IO.Stream stream = System.IO.File.OpenRead(t.Assembly.Location))
            {
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
                bytes[0] = b;
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get { return this.GetEditor(); }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                bytes[1] = ev.Serialize();
                return new Tuple<string, byte[][]>(eventType, bytes);
            }
            set
            {
                Tuple<string, byte[][]> t = value as Tuple<string, byte[][]>;
                eventType = t.Item1;
                bytes = t.Item2;
                string ass = eventType.Substring(eventType.IndexOf(',') + 1);
                Assembly[] assemb = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in assemb)
                {
                    if (a.FullName.Equals(ass))
                    {
                        goto m;
                    }
                }
               AppDomain.CurrentDomain.Load(bytes[0]);
           m:
               ev = bytes[1].Deserialize<IEvent>();
            }
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return bytes[2];
            }
            set
            {
                bytes[2] = value;
            }
        }

        ISeparatedPropertyEditor ISeparatedAssemblyEditedObject.Editor
        {
            get
            {
                return editor;
            }
            set
            {
                editor = value;
            }
        }

        void ISeparatedAssemblyEditedObject.FirstLoad()
        {
            this.LoadAssembly();
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add { ev.Event += value; }
            remove { ev.Event -= value; }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return true;
            }
            set
            {
                
            }
        }

        #endregion
    }
}
