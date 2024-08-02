using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using SerializationInterface;
using System;
using System.Runtime.Serialization;

namespace Http.Meteo.Serializable
{
    public class  MeteoService : Wrapper.MeteoService, ISerializable
    {
        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize("Properties", values);
        }

        #endregion

        /// <summary>
        /// Deserilaization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected MeteoService(SerializationInfo info, StreamingContext context)
        {
            values = info.Serialize<object[]>("Properties");
            nBuffer = values.Length - 1;
            CreateMeasurements();
            Update();
        }


        #region Members
        void CreateMeasurements()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            for (int i = 0; i < types.Length; i++)
            {
                int[] k = new int[] { i + 2 };
                Func<object> f = () => { return values[k[0]]; };
                l.Add(new Measurement(types[i], f, names[i]));
            }
            measurements = l.ToArray();
        }


        #endregion


    }
}
