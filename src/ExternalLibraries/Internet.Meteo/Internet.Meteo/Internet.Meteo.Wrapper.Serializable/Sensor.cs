using System.Runtime.InteropServices;
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
            Key = info.GetString("Key");
            Position = info.GetString("Position");
            Set(info.GetString("Kind"));
            Create();
        }

        #endregion

        #region ISerializable implementation

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Kind", kind);
            info.AddValue("Key", Key);
            info.AddValue("Position", Position);
        }

        #endregion
    }
}
