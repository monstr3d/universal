using System;
using System.Runtime.Serialization;

namespace DataPerformer
{
    /// <summary>
    /// The link between data provider and data consumer
    /// </summary>
    [Serializable()]
    public class DataLink : Portable.DataLink, ISerializable
    {

        #region Fields

   
  

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataLink(SerializationInfo info, StreamingContext context)
        {
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
        }


        #endregion

    }
}
