using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoundService.Serializable
{
    /// <summary>
    /// Convereter of digit to sound
    /// </summary>
    [Serializable()]
    public class Object2SoundName : SoundService.Object2SoundName, ISerializable
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Object2SoundName()
        {

        }

        /// <summary>
        /// Deserialization construcror
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private Object2SoundName(SerializationInfo info, StreamingContext context)
        {
            inputs = info.GetValue("Inputs", typeof(string[])) as string[];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Inputs", inputs, typeof(string[]));
        }

        #endregion

    }
}
