using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DimAtm.Serializable
{
    /// <summary>
    /// Atmosphere
    /// </summary>
    [Serializable]
    public class Atmosphere : DinAtm.Portable.Atmosphere, ISerializable
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Atmosphere()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private Atmosphere(SerializationInfo info, StreamingContext context)
        {
            ifa = info.GetValue("ifa", typeof(int[])) as int[];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ifa", ifa, typeof(int[]));
        }

        #endregion
    }
}
