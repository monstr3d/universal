using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using PhysicalField;
using Motion6D.Interfaces;

namespace Motion6D
{

    /// <summary>
    /// 3D physical field
    /// </summary>
    [Serializable()]
    public class PhysicalField3D : PhysicalFieldBase
    {
        #region Fields

   
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PhysicalField3D()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization Information</param>
        /// <param name="context">Streaming Context</param>
        protected PhysicalField3D(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

    }
}
