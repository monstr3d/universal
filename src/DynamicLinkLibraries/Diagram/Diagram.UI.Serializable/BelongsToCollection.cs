using System;
using System.Runtime.Serialization;

namespace Diagram.UI
{
    /// <summary>
    /// The belongs to collection link
    /// </summary>
    [Serializable()]
    public class BelongsToCollection : Portable.BelongsToCollection, ISerializable
    {
 
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BelongsToCollection()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BelongsToCollection(SerializationInfo info, StreamingContext context)
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
