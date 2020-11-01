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

namespace HttpClient
{
    /// <summary>
    /// This is class for http test client form.
    /// </summary>
    public partial class Subscriber : IEvent, Event.Data.Remote.Interfaces.IClient
    {
        #region Fields

        /// <summary>
        /// Helper
        /// </summary>
        HttpHelper communicationObject = null;

        /// <summary>
        /// End point
        /// </summary>
        string Endpoint = string.Empty;


        /// <summary>
        /// Event
        /// </summary>
        Action<object[]> ev;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of the class Subscriber
        /// It retrives the endpoint address of cms  from config file  to connect with that.
        /// alse creates BroadcastReceiver instance.
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="ev">Event</param>
        public Subscriber(string url)
        {
            Endpoint = url;
            communicationObject = new HttpHelper();
            communicationObject.MakeClient(Endpoint, this);
        }

        #endregion

        #region IEvent Members

        void IEvent.OnEvent(AlertData data)
        {
            if (data != null)
            {
                if (data.Data != null)
                {
                    ev(data.Data);
                }
            }
        }

        #endregion

        #region Internal Members

        internal void Subscribe(bool b)
        {
            if (b)
            {
                communicationObject.Subscribe();
                return;
            }
            communicationObject.UnSubscribe("");
        }

        #endregion

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
            get { return Event.Remote.RemoteType.Http; }
        }

  
        #endregion
    }

}