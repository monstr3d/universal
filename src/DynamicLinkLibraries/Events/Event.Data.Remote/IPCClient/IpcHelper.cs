using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

using IPCClient.AthenaEventClient;


namespace IPCClient
{
    /// <summary>
    /// This is the helper class to make http proxy and it implements ICommunication interface for factory method design pattern.
    /// </summary>

    class IpcHelper  
    {
        IRegistration m_Proxy;
        
        #region ICommunication Members
        /// <summary>
        /// This is used to make an http proxy and to active it.
        /// </summary>
        /// <param name="EndpoindAddress"></param>
        /// <param name="callbackinstance"></param>
        public void MakeClient(string EndpoindAddress, object callbackinstance)
        {
            NetNamedPipeBinding namedpipebinding = new NetNamedPipeBinding();
            EndpointAddress endpointAddress = new EndpointAddress(EndpoindAddress);
            InstanceContext context = new InstanceContext(callbackinstance);
            m_Proxy = new RegistrationProxy(context, namedpipebinding, endpointAddress);
        }
        /// <summary>
        /// This method is called   to  register  client  with CMS.
        /// </summary>
        /// <param name="EventOperation"></param>
        public string[] Subscribe()
        {
            return m_Proxy.Register();
        }


        /// <summary>
        /// This method is called   to  unregister  client  with CMS.
        /// </summary>
        /// <param name="EventOperation"></param>
        public void UnSubscribe(string eventOperation)
        {
            m_Proxy.UnRegister();
        }

        #endregion
    }

}
