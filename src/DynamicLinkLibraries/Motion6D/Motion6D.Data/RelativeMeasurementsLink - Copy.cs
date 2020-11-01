using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Link for relative measurements
    /// </summary>
    [Serializable()]
    public class RelativeMeasurementsLink : Motion6D.Portable.RelativeMeasurementsLink, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelativeMeasurementsLink()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private RelativeMeasurementsLink(SerializationInfo info, StreamingContext context)
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
