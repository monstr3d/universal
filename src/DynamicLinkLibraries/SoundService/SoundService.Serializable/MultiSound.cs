using System.Runtime.Serialization;

namespace SoundService.Serializable
{
    /// <summary>
    /// Multiple sound
    /// </summary>
    [Serializable]
    public class MultiSound : SoundService.MultiSound, ISerializable
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MultiSound()
        {
        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private MultiSound(SerializationInfo info, StreamingContext context)
        {
            conditionName = info.GetString("Condition");
            soundName = info.GetString("Sound");
        }


        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Condition", conditionName);
            info.AddValue("Sound", soundName);
        }

        #endregion



    }
}
