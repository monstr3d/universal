using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using SerializationInterface;


namespace Dynamic.Atmosphere.Serializable
{
    /// <summary>
    /// Dynamical atmosphere
    /// </summary>
    [Serializable]
    public class Atmosphere : Portable.Atmosphere, ISerializable
    {

        #region Ctor

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
        protected Atmosphere(SerializationInfo info, StreamingContext context)
        {
            Properties = info.Deserialize<object>("Properties");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize("Properties", Properties);
        }

        #endregion

        #region Private Members

        object Properties
        {
            get
            {
                ob[0] = ifa;
                return ob;
            }
            set
            {
                if (value is int[])
                {
                    If = value as int[];
                    ob[0] = ifa;
                    return;
                }
                ob = value as object[];
                If = ob[0] as int[];
            }
        }

        #endregion

    }
}
