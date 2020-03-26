using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.ServiceModel;
using System.Diagnostics;
using System.Configuration;

using Diagram.UI;

using Event.Remote;

namespace TCPClient
{
    /// </summary>
    public partial class Subscriber : IEvent, Event.Data.Remote.Interfaces.IClient
    {
        // BroadcastReceiver receiver = null;
        public void OnEvent(AlertData data)
        {
            if (data != null)
            {
                ev(data.Data);
            }
        }

        #region IClient Members

        string[] Event.Data.Remote.Interfaces.IClient.Register()
        {
            try
            {
                return communicationObject.Subscribe();
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
            return null;
        }

        void Event.Data.Remote.Interfaces.IClient.Unregister()
        {
            try
            {
                communicationObject.UnSubscribe("");
            }
            catch (Exception exception)
            {
                exception.ShowError();
            }
        }

        event Action<object[]> Event.Data.Remote.Interfaces.IClient.Read
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        string Event.Data.Remote.Interfaces.IClient.Url
        {
            get { return Endpoint; }
        }

        Event.Remote.RemoteType Event.Data.Remote.Interfaces.IClient.Type
        {
            get { return Event.Remote.RemoteType.Tcp; }
        }


        #endregion


        TcpHelper communicationObject = null;
        string Endpoint = string.Empty;

        /// <summary>
        /// Event
        /// </summary>
        event Action<object[]> ev = (object[] o) => { };

  


        /// <summary>
  
        public Subscriber(string url)
        {
            Endpoint = url;// ConfigurationManager.AppSettings["EndpointAddress"];
            communicationObject = new TcpHelper();
            communicationObject.MakeClient(Endpoint, this);
         }

        public void Subscribe()
        {
            communicationObject.Subscribe();
        }

        /// <summary>
        /// This return the topic name.
        /// </summary>
        /// <returns></returns>
        string GetSelectedMethod()
        {
            return "";
        }
 
 


 
    }

}