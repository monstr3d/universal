using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Motion6D.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Link to facet
    /// </summary>
    [Serializable()]
    public class FacetConsumerLink : Portable.FacetConsumerLink, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FacetConsumerLink()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FacetConsumerLink(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

    }
}
