using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using HttpClient.AthenaEventClient;
using System.Net;
 

namespace HttpClient
{
    /// <summary>
    /// This is the helper class to make http proxy and it implements ICommunication interface for factory method design pattern.
    /// </summary>

    class HttpHelper  
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
            WSDualHttpBinding namedpipebinding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
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
