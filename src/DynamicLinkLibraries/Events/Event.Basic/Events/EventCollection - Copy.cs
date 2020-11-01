using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Event.Interfaces;

namespace Event.Basic.Events
{
    /// <summary>
    /// Collection of events
    /// </summary>
    [Serializable()]
    public class EventCollection : Event.Portable.Events.EventCollection, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventCollection()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected EventCollection(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

    }
}