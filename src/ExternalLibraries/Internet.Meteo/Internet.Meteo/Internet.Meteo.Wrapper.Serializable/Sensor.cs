using System.Runtime.Serialization;

namespace Internet.Meteo.Wrapper.Serializable
{

    [Serializable]
    public class Sensor : Wrapper.Sensor, ISerializable
    {


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kind">Kind</param>
        public Sensor(string kind) : base(kind)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private  Sensor(SerializationInfo info, StreamingContext context)
        {
            Set(info.GetString("Kind"));
        }

        #endregion

        #region ISerializable implementation

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Kind", kind);
        }

        #endregion
    }
}
