
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Event.Interfaces;
using Web.Interfaces;



namespace Event.Remote
{
    /// <summary>
    /// Remote event
    /// </summary>
    [Serializable()]
    public class RemoteEvent : ISerializable, IEvent, IUrlProvider, IUrlConsumer
    {

        #region Fields

        string url;

        RemoteType type = RemoteType.Ipc;

        private event Action ev;

        private bool isEnabled = false;

        private Action<bool> register = (bool reg) => {};

        protected Action<string> changeInput = (string s) => { };

        protected Action<string> changeOutput = (string s) => { };


        /// <summary>
        /// Subscription
        /// </summary>
        object subscription;

        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RemoteEvent()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected RemoteEvent(SerializationInfo info, StreamingContext context)
        {
            url = info.GetString("Url");
            type = (RemoteType)info.GetValue("Type", typeof(object));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Url", url);
            info.AddValue("Type", type, typeof(object));
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add { ev += value; }
            remove { ev -= value; }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                if (value & (subscription == null))
                {
                    CreateSubscription();
                }
                register(value);
                isEnabled = value;
            }
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get { return url; }
        }

        event Action<string> IUrlProvider.Change
        {
            add { changeOutput += value; }
            remove { changeOutput -= value; }
        }

        #endregion

        #region IUrlConsumer Members

        string IUrlConsumer.Url
        {
            set
            {
                if (isEnabled)
                {
                    throw new Exception("Stop client please");
                }
                if (value.Equals(url))
                {
                    return;
                }
                url = value;
                CreateSubscription();
            }
        }

        event Action<string> IUrlConsumer.Change
        {
            add { changeInput += value; }
            remove { changeInput -= value; }
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Client type
        /// </summary>
        public RemoteType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (isEnabled)
                {
                    throw new Exception("Stop client please");
                }
                type = value;
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Creates subscription
        /// </summary>
        void CreateSubscription()
        {
            if (type.Equals(Remote.RemoteType.Ipc))
            {
                IPCClient.Subscriber s = new IPCClient.Subscriber(url, ev);
                register = (bool b) => { s.Subscribe(b); };
                subscription = s;
                return;
            }
            if (type.Equals(Remote.RemoteType.Tcp))
            {
                TCPClient.Subscriber s = new TCPClient.Subscriber(url, ev);
                register = (bool b) => { s.Subscribe(b); };
                subscription = s;
                return;
            }
            if (type.Equals(Remote.RemoteType.Http))
            {
                HttpClient.Subscriber s = new HttpClient.Subscriber(url, ev);
                register = (bool b) => { s.Subscribe(b); };
                subscription = s;
                return;
            }
        }

        #endregion

    }
}
