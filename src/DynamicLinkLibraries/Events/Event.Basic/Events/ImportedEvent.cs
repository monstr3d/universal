using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using SerializationInterface;

using Event.Interfaces;





namespace Event.Basic.Events
{
    /// <summary>
    /// Imported event
    /// </summary>
    [Serializable()]
    public class ImportedEvent : CategoryObject, ISerializable, IEvent
    {
        #region Fields

        /// <summary>
        /// Imported event
        /// </summary>
        protected IEvent ev;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of imported object</param>
        public ImportedEvent(string type)
        {
            Type t = Type.GetType(type);
            ConstructorInfo ci = t.GetConstructor(new Type[0]);
            ev = ci.Invoke(new object[0]) as IEvent;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ImportedEvent(SerializationInfo info, StreamingContext context)
        {
            ev = info.Deserialize<IEvent>("Event");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<IEvent>("Event", ev);
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
                return ev.IsEnabled;
            }
            set
            {
                ev.IsEnabled = value;  
            }
        }
 

        #endregion

        #region Public Members

        /// <summary>
        /// Event
        /// </summary>
        public IEvent Event
        {
            get
            {
                return ev;
            }
        }

        #endregion

    }
}
