using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using NamedTree;
using SerializationInterface;

namespace DataSetService
{
    /// <summary>
    /// External data set provider
    /// </summary>
    [Serializable()]
    public class ExternalDataSetProvider : Pure.ExternalDataSetProvider, ISerializable
    {

        #region Ctor

  

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ExternalDataSetProvider(SerializationInfo info, StreamingContext context)
          
        {
            dataSet = info.Deserialize<DataSet>("DataSet");

            factoryType = info.GetString("Factory");
            url = info.GetString("Url");
            CreateFactory();
        }


        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<DataSet>("DataSet", dataSet);
            info.AddValue("Factory", factoryType);
            info.AddValue("Url", url);
        }

        #endregion
    }
}
