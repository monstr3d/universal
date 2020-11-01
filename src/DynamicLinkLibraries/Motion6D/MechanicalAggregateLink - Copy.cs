using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Link between aggregates
    /// </summary>
    [Serializable()]
    public class MechanicalAggregateLink : Portable.MechanicalAggregateLink, ISerializable 
      
    {
         #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MechanicalAggregateLink()
        {

        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MechanicalAggregateLink(SerializationInfo info, StreamingContext context)
        {
           connection = info.GetValue("Connection", typeof(int[])) as int[]; 
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Connection", connection, typeof(int[])); 
        }

        #endregion
    }
}
