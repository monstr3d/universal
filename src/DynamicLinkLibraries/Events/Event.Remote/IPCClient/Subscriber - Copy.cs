using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.ServiceModel;

using System.Diagnostics;
 
using System.Configuration;

namespace IPCClient
{
    /// <summary>
    /// This is class for http test client form.
    /// </summary>
    public partial class Subscriber :  IEvent
    {
        // BroadcastReceiver receiver = null;
        #region Fields

        /// <summary>
        /// Helper
        /// </summary>
        IpcHelper CommunicationObject = null;
       
        /// <summary>
        /// End point
        /// </summary>
        string Endpoint = string.Empty;

        /// <summary>
        /// Event
        /// </summary>
        Action ev;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of the class Subscriber
        /// It retrives the endpoint address of cms  from config file  to connect with that.
        /// alse creates BroadcastReceiver instance.
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="ev">Event</param>
        public Subscriber(string url, Action ev)
        {

            Endpoint = url;
            this.ev = ev;

            CommunicationObject = new IpcHelper();
            CommunicationObject.MakeClient(Endpoint, this);
        }

        #endregion

        #region IEvent Members

        void IEvent.OnEvent()
        {
            ev();
        }

        #endregion
        
        #region Internal Members

        internal void Subscribe(bool b)
        {
            if (b)
            {
                CommunicationObject.Subscribe();
                return;
            }
            CommunicationObject.UnSubscribe("");
        }

        #endregion

    }
}