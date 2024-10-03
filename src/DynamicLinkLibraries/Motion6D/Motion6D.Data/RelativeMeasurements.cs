using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Motion6D
{
    /// <summary>
    /// Relative measurements
    /// </summary>
    [Serializable()]
    public class RelativeMeasurements : Portable.RelativeMeasurements, ISerializable
    { 
        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public RelativeMeasurements()
        {
         
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private RelativeMeasurements(SerializationInfo info, StreamingContext context)
            : this()
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