using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    /// <summary>
    /// Publisher
    /// </summary>
    public class Publisher
    {
        #region Fields

        // Service Proxy...
        PublisherProxy proxy;

        AlertData data = new AlertData();


        #endregion

        #region Ctor

        /// <summary>
        /// Publisher
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="type">Type</param>
        public Publisher(string address, RemoteType type)
        {
            EndpointAddress endpointAddress = new EndpointAddress(address);
            proxy = new PublisherProxy(type.ToBinding(), endpointAddress);
        }

        #endregion

        #region Members

        /// <summary>
        /// Bytes to send
        /// </summary>
        public byte[] Bytes
        {
            set
            {
                data.Data = value;
                proxy.OnEvent(data);
            }
        }

        #endregion

    }
}
