using System.Runtime.Serialization;

using SerializationInterface;

namespace Http.Meteo.Serializable
{
    /// <summary>
    /// Meteorological service
    /// </summary>
    [Serializable]
    public class  MeteoService : Wrapper.MeteoService, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeteoService() 
        { 
        
        }

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


        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object[]>("Properties", values);
        }

        #endregion


    }
}
