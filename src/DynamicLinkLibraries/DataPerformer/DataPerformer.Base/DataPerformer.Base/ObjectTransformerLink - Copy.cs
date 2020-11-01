using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DataPerformer
{
    /// <summary>
    /// Link to object transformer
    /// </summary>
    [Serializable()]
    public class ObjectTransformerLink : Portable.ObjectTransformerLink, ISerializable
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectTransformerLink()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ObjectTransformerLink(SerializationInfo info, StreamingContext context)
        {
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

    }
}
