using System;
using System.Runtime.Serialization;


using CategoryTheory;
using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Link between visible object and its consumer
    /// </summary>
    [Serializable()]
    public class VisibleConsumerLink : Portable.VisibleConsumerLink, ISerializable    
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VisibleConsumerLink()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected VisibleConsumerLink(SerializationInfo info, StreamingContext context)
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
