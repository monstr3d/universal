using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange.Interfaces
{
    /// <summary>
    /// Client
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerInfo">Registration info</param>
        /// <returns>Information</returns>
        string[] Register(string registerInfo);

        /// <summary>
        /// Unregister
        /// </summary>
        void Unregister();

        /// <summary>
        /// Read action
        /// </summary>
        event Action<byte[]> Read;

        /// <summary>
        /// Sets bytes
        /// </summary>
        byte[] Write
        { set; }

        /// <summary>
        /// Url
        /// </summary>
        string Url
        {
            get;
        }

        /// <summary>
        /// Type
        /// </summary>
        Bytes.Exchange.RemoteType Type
        {
            get;
        }
    }
}
