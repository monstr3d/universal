using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    /// <summary>
    /// This is class for http test client form.
    /// </summary>
    public class Subscriber : IEvent, Bytes.Exchange.Interfaces.IClient
    {

        #region Fields

        /// <summary>
        /// Helper
        /// </summary>
        Helper communicationObject = null;

        /// <summary>
        /// End point
        /// </summary>
        protected string Endpoint = string.Empty;

        Action<AlertData> eventH = (AlertData data) => {};
 
        protected RemoteType type;

        /// <summary>
        /// Event
        /// </summary>
        protected event Action<byte[]> ev = (byte[] bytes) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of the class Subscriber
        /// It retrives the endpoint address of cms  from config file  to connect with that.
        /// alse creates BroadcastReceiver instance.
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="ev">Event</param>
        public Subscriber(string url, RemoteType type)
        {
            Endpoint = url;
            this.type = type;
            MakeClient();
        }

        /// <summary>
        /// Default comstructor
        /// </summary>
        protected Subscriber()
        {

        }

        #endregion

        #region IEvent Members

        void IEvent.OnEvent(AlertData data)
        {
            eventH(data);
        }

        #endregion

        #region IClient Members

        string[] Bytes.Exchange.Interfaces.IClient.Register(string registerInfo)
        {
            try
            {
                string[] str = communicationObject.Subscribe(registerInfo);
                eventH = (AlertData data) =>
                        {
                            if (data != null)
                            {
                                if (data.Data != null)
                                {
                                    ev(data.Data);
                                }
                            }
                        };
                return str;
            }
            catch (Exception exception)
            {
                this.ShowError(exception);
            }
            return null;
        }

        void Bytes.Exchange.Interfaces.IClient.Unregister()
        {
            try
            {
                communicationObject.UnSubscribe("");
                eventH = (AlertData data) => { };
            }
            catch (Exception exception)
            {
                this.ShowError(exception);
            }
        }

        event Action<byte[]> Bytes.Exchange.Interfaces.IClient.Read
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        byte[] Interfaces.IClient.Write
        {
            set { communicationObject.SetBytes(value); }
        }
        
        string Bytes.Exchange.Interfaces.IClient.Url
        {
            get { return Endpoint; }
        }

        Bytes.Exchange.RemoteType Bytes.Exchange.Interfaces.IClient.Type
        {
            get { return Bytes.Exchange.RemoteType.Ipc; }
        }


        #endregion

        #region Internal Members

        internal void Subscribe(bool b)
        {
            if (b)
            {
                communicationObject.Subscribe("");
                return;
            }
            communicationObject.UnSubscribe("");
        }

        #endregion

        #region Protected Members

        protected void MakeClient()
        {
            communicationObject = new Helper();
            communicationObject.MakeClient(Endpoint, type, this);
        }

        #endregion
    }
}
