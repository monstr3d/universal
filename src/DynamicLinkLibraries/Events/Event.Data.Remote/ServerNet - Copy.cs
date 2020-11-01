using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;

using BaseTypes;

using Event.Data.Remote.Interfaces;
using Event.Remote;

namespace Event.Data.Remote
{
    class ServerNet : IDisposable
    {

        #region Fields

        static System.ServiceModel.Channels.Binding wsDualBindingpublish = 
            new WSDualHttpBinding();
        
        static System.ServiceModel.Channels.Binding tcpBindingpublish = new NetTcpBinding();
       
        static System.ServiceModel.Channels.Binding namedPipeBindingpublish = new NetNamedPipeBinding();

        /// <summary>
        /// This is Servicehost for PublishService.
        /// </summary>
        ServiceHost eventServiceHost = null;
        /// <summary>
        /// This is the ServiceHost for SubscriptionService
        /// </summary>
        ServiceHost subscriptionManagerHost = null;

        static Dictionary<string, string[]> dictionary =
            new Dictionary<string, string[]>();

        string url;

        RemoteType type;

        List<Tuple<string, object>> types;

        System.ServiceModel.Channels.Binding binding = null;
        
        #endregion

        #region CON & DCON
        /// <summary>
        /// This is the constructor of Server class.
        /// </summary>
        public ServerNet(string url, RemoteType type, List<Tuple<string, object>> types)
        {
            this.url = url;
            this.type = type;
            this.types = types;
            dictionary[url] = types.TypesToStrings();
            Initializeoperation();
        }


        ~ServerNet()
        {
            CleanUp(false);
        }

        #endregion

        #region Internal Members

        static internal Dictionary<string, string[]> Dictionary
        {
            get
            {
                return dictionary;
            }
        }

        #endregion

        #region Service Hosting
        /// <summary>
        /// This is the method that is used to take pub and sub service in listen mode.
        /// 
        /// </summary>
        void Initializeoperation()
        {
            try
            {
                eventServiceHost = new ServiceHost(typeof(Publishing));

                ///Here diferent binding is created for different protocol.
                /// For example NetTcpBinding is created for TCP protocol.
                /// For example WSDualHttpBinding is created for  HTTP  protocol.
                /// For example NetNamedPipeBinding is created for Named Pipe protocol.

                if (type.Equals(RemoteType.Ipc))
                {
                    binding = new NetNamedPipeBinding();
                }
                else if (type.Equals(RemoteType.Tcp))
                {
                    NetTcpBinding n = new NetTcpBinding(SecurityMode.None);
                    n.Security.Message.ClientCredentialType = MessageCredentialType.None;
                    binding = n;
                }
                else
                {
                    binding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                }

                ///By the following line i add the address of PublishService to eventServiceHost for differnt protocol
                /*!!!     eventServiceHost.AddServiceEndpoint(typeof(IEvent), wsDualBindingpublish,
                                             "http://localhost:8000/PublishingService/");
                     eventServiceHost.AddServiceEndpoint(typeof(IEvent), tcpBindingpublish,
                                             "net.tcp://localhost:8001/PublishingService");
                     eventServiceHost.AddServiceEndpoint(typeof(IEvent), namedPipeBindingpublish,
                                             "net.pipe://localhost/MyPipe1");

                     //This line is used  to open pub service to listen.
                     eventServiceHost.Open();*/
                subscriptionManagerHost = new ServiceHost(typeof(Subscription));
                /*
                System.ServiceModel.Channels.Binding wsDualBinding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                System.ServiceModel.Channels.Binding tcpBinding = new NetTcpBinding(SecurityMode.None);*/
                // System.ServiceModel.Channels.Binding namedPipeBinding = new NetNamedPipeBinding();
                /*

                ///By the following line i add the address of Subscription Service to subscriptionManagerHost for differnt protocol
                subscriptionManagerHost.AddServiceEndpoint(typeof(IRegistration), wsDualBinding,
                                        "http://localhost:8003/SubscriptionServie/");
                subscriptionManagerHost.AddServiceEndpoint(typeof(IRegistration), tcpBinding,
                                    "net.tcp://localhost:8002/SubscriptionServie");*/
                subscriptionManagerHost.AddServiceEndpoint(typeof(IRegistration), binding, url);



                //This line is used  to open sub service to listen.
                subscriptionManagerHost.Open();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        #endregion

        #region IDisposable Members

        private bool disposed = false;

        public void Dispose()
        {
            dictionary.Remove(url);
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Members

        private void CleanUp(bool disposing)
        {
            if (!disposed)
            {
                if (eventServiceHost != null)
                {
                    eventServiceHost.Close();
                    subscriptionManagerHost.Close();
                }
            }
            disposed = true;
        }

        #endregion

    }
}