using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace PhysicalField
{
    /// <summary>
    /// Link between Physical field and irradiated object
    /// </summary>
    [Serializable()]
    public class FieldLink : Interfaces.FieldLink, ISerializable
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FieldLink()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FieldLink(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }


    }
}
