using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    class Helper
    {
        IRegistration m_Proxy;

        #region ICommunication Members
        /// <summary>
        /// This is used to make an http proxy and to active it.
        /// </summary>
        /// <param name="EndpoindAddress"></param>
        /// <param name="callbackinstance"></param>
        public void MakeClient(string EndpoindAddress, RemoteType type, object callbackinstance)
        {
            EndpointAddress endpointAddress = new EndpointAddress(EndpoindAddress);
            InstanceContext context = new InstanceContext(callbackinstance);
            m_Proxy = new RegistrationProxy(context, type.ToBinding(), endpointAddress);
        }
        /// <summary>
        /// This method is called   to  register  client  with CMS.
        /// </summary>
        /// <param name="EventOperation"></param>
        public string[] Subscribe(string registerInfo)
        {
            return m_Proxy.Register(registerInfo);
        }


        /// <summary>
        /// This method is called   to  unregister  client  with CMS.
        /// </summary>
        /// <param name="EventOperation"></param>
        public void UnSubscribe(string eventOperation)
        {
            m_Proxy.UnRegister();
        }

        /// <summary>
        /// Sets bytes
        /// </summary>
        /// <param name="buffer"></param>
        public void SetBytes(byte[] buffer)
        {
            m_Proxy.SetBytes(buffer);
        }

        #endregion
    }

}