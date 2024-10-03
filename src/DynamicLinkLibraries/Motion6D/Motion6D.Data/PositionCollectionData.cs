using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;

using DataPerformer;
using DataPerformer.Interfaces;
using DataPerformer.Portable;


using Motion6D.Interfaces;



namespace Motion6D
{
    /// <summary>
    /// Positions with data
    /// </summary>
    [Serializable()]
    public class PositionCollectionData : Portable.PositionCollectionData, ISerializable
     {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PositionCollectionData()
        {
            
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PositionCollectionData(SerializationInfo info, StreamingContext context)
        {
            measurements = info.GetValue("Measurements", typeof(List<string>)) as List<string>;
            factoryName = info.GetValue("Factory", typeof(string)) + "";
            factory = PositionFactory.Factory[factoryName];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measurements", measurements, typeof(List<string>));
            info.AddValue("Factory", factoryName, typeof(string));
        }

        #endregion

      }
}