
using System.Runtime.Serialization;

namespace SoundService.Serializable
{
    /// <summary>
    /// Collection of sounds
    /// </summary>
    [Serializable()]
    public class SoundCollection : SoundService.SoundCollection, ISerializable
    {

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public SoundCollection()
        {

        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SoundCollection(SerializationInfo info, StreamingContext context)
        {
            sounds = info.GetValue("Sounds", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Sounds", sounds, typeof(Dictionary<string, string>));
        }

        #endregion


    }
}
