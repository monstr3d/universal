using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

using CategoryTheory;

using SerializationInterface;


namespace DataSetService
{
    /// <summary>
    /// Data provider from xml
    /// </summary>
    [Serializable()]
    public class SavedDataProvider : Pure.SavedDataProvider, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SavedDataProvider()
        {
        
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SavedDataProvider(SerializationInfo info, StreamingContext context)
        {
            dataSet = info.Deserialize<DataSet>("DataSet");
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<DataSet>("DataSet", dataSet);
        }

        #endregion

 
    }
}
