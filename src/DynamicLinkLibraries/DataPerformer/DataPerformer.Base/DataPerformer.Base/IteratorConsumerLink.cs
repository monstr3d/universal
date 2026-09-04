using System;
using System.Runtime.Serialization;

namespace DataPerformer
{
    /// <summary>
    /// Link to iterator consumer
    /// </summary>
    [Serializable()]
    public class IteratorConsumerLink : Portable.IteratorConsumerLink, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public IteratorConsumerLink()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private IteratorConsumerLink(SerializationInfo info, StreamingContext context)
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
