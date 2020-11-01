using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;



namespace Motion6D
{
    /// <summary>
    /// Link of relative frame
    /// </summary>
    [Serializable()]
    public class ReferenceFrameArrow : Portable.ReferenceFrameArrow, ISerializable
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameArrow()
        {
   
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ReferenceFrameArrow(SerializationInfo info, StreamingContext context)
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
