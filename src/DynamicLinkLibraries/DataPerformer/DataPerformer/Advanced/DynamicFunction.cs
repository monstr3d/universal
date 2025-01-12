using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


using DataPerformer.Interfaces;

namespace DataPerformer.Advanced
{
    /// <summary>
    /// Dynamic function
    /// </summary>
    [Serializable()]
    public class DynamicFunction : Portable.Advanced.DynamicFunction, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DynamicFunction()
        {
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DynamicFunction(SerializationInfo info, StreamingContext context)
            : this()
        {
            x = info.GetString("X");
            size = info.GetInt32("Size");
            degree = info.GetInt32("Degree");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x);
            info.AddValue("Size", size);
            info.AddValue("Degree", degree);
        }

        #endregion
    }
}