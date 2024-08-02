using System.Runtime.Serialization;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using Diagram.UI;
using SerializationInterface;

namespace Http.Meteo.Serializable
{
    public class  MeteoService : Wrapper.MeteoService, ISerializable
    {
        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object[]>("Properties", values);
        }

        #endregion

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected MeteoService(SerializationInfo info, StreamingContext context)
        {
            values = info.Deserialize<object[]>("Properties");
            nBuffer = values.Length - 1;
            CreateMeasurements();
            Update();
        }


        #region Members

  

      



        #endregion


    }
}
