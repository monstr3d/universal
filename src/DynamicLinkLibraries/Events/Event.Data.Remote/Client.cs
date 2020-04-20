using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;

using Event.Interfaces;
using Event.Remote;

using Web.Interfaces;

namespace Event.Data.Remote
{
    [Serializable()]
    public class Client : ISerializable,
        IEventReader, IUrlConsumer, IUrlProvider, IDisposable
    {
        #region Fields

        Interfaces.IClient client;

        RemoteType type = RemoteType.Ipc;

        string url = "";

        event Action change = () => { };

        event Action<string> changeUrl = (string url) => { };

        event Action<string> changeUrlProvider = (string url) => { };


        List<Tuple<string, object>> types = null;

        List<Action<object[]>> reads = new List<Action<object[]>>();

        AutoResetEvent reset;

        bool isEnanled = false;

        string[] str;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Client(SerializationInfo info, StreamingContext context)
        {
            type = (RemoteType)info.GetValue("Type", typeof(RemoteType));
            url = info.GetString("Url");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", type, typeof(RemoteType));
            info.AddValue("Url", url);
        }

        #endregion

        #region IEventReader Members

        List<Tuple<string, object>> IEventReader.Types
        {
            get { return types; }
        }


        event Action<object[]> IEventReader.EventData
        {
            add
            {
                reads.Add(value);
                if (client != null)
                {
                    client.Read += value;
                }
            }
            remove
            {
                reads.Remove(value);
                if (client != null)
                {
                    client.Read -= value;
                }
            }
        }

        bool IEventReader.IsEnabled
        {
            get
            {
                return isEnanled;
            }
            set
            {
                if (isEnanled == value)
                {
                    return;
                }
                isEnanled = false;
                bool b = client == null;
                if (client == null)
                {
                    CreateClient();
                }
                if (client == null)
                {
                    isEnanled = false;
                    return;
                }
                if (value)
                {
                    if (client != null)
                    {
                        if (!b)
                        {
                            client.Register();
                        }
                        isEnanled = true;
                    }
                }
                else
                {
                    if (client != null)
                    {
                        client.Unregister();
                    }
                }
            }
        }

        string[] IEventReader.EventNames
        {
            get
            {
                return new string[0];
            }
        }

        IEventReader IEventReader.this[string name]
        {
            get
            {
                return this;
            }
        }

        event Action IEventReader.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            Disconnect();
        }

        #endregion

        #region IUrlConsumer Members

        string IUrlConsumer.Url
        {
            set
            {
                if (!url.Equals(value))
                {
                    client = null;
                }
                url = value;
                changeUrl(value);
            }
        }

        event Action<string> IUrlConsumer.Change
        {
            add { changeUrl += value; }
            remove { changeUrl -= value; }
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get { return url; }
        }

        event Action<string> IUrlProvider.Change
        {
            add { changeUrlProvider += value; }
            remove { changeUrlProvider -= value; }
        }

        #endregion

        #region Public Members

        public RemoteType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value.Equals(type))
                {
                    return;
                }
                type = value;
                client = null;
            }
        }

        #endregion

        #region Private Members

        void CreateClient()
        {
            try
            {
                if (client != null)
                {
                    if (client.Url.Equals(url) & client.Type.Equals(type))
                    {
                        return;
                    }
                }
                Disconnect();
                if (type.Equals(RemoteType.Ipc))
                {
                    client = new IPCClient.Subscriber(url);
                }
                else if (type.Equals(RemoteType.Tcp))
                {
                    client = new TCPClient.Subscriber(url);
                }
                else
                {
                    client = new HttpClient.Subscriber(url);
                }
                foreach (Action<object[]> read in reads)
                {
                    client.Read += read;
                }
                str = client.Register();
                if (str != null)
                {
                    types = str.StringToTypes();
                }
             }
            catch (Exception exception)
            {
                isEnanled = false;
                exception.ShowError();
                Disconnect();
                client = null;
            }
         }

        private void Disconnect()
        {
            if (client == null)
            {
                return;
            }
            foreach (Action<object[]> act in reads)
            {
                client.Read -= act;
            }
            client.RemoveItself();
            client = null;
        }

        #endregion
    }
}
