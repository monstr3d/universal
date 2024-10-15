using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataPerformer.Arrows
{
    /// <summary>
    /// Data link
    /// </summary>
    /// <summary>
    /// The link with data provider
    /// </summary>
    [Serializable()]
    public class DataLink : Portable.DataLink,
       ISerializable
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
        private DataLink(SerializationInfo info, StreamingContext context)
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


        #region Overriden Members

        #endregion

        #region  Members


        #endregion

    }
}
