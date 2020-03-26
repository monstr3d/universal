using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using BaseTypes;

using Event.Interfaces;
using Event.Remote;

using Web.Interfaces;

namespace Event.Data.Remote
{
    /// <summary>
    /// Server
    /// </summary>
    [Serializable()]
    public class Server : IAssociatedObject, ISerializable, IDisposable, 
        IUrlConsumer, IUrlProvider, IEventWriter
    {
        #region Fields

        object obj;

        ServerNet server;

        event Action<string> provider = (string url) => { };

        event Action<string> consumer = (string url) => { };

        List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        RemoteType type = RemoteType.Ipc;

        string url = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Server()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Server(SerializationInfo info, StreamingContext context)
        {
           url = info.GetString("Url");
           type = (RemoteType)info.GetValue("Type", typeof(RemoteType));
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            server.RemoveItself();
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Url", url);
            info.AddValue("Type", type, typeof(RemoteType));
        }

        #endregion

        #region IUrlConsumer Members

        string IUrlConsumer.Url
        {
            set 
            {
                if (url.Equals(value))
                {
                    return;
                }
                url = value;
                Set();
            }
        }

        event Action<string> IUrlConsumer.Change
        {
            add { consumer += value; }
            remove { consumer -= value; }
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get { return url; }
        }

        event Action<string> IUrlProvider.Change
        {
            add {provider += value; }
            remove { provider -= value; }
        }

        #endregion

        #region IEventWrite Members

        List<Tuple<string, object>> IEventWriter.Types
        {
            get
            {
                return types;
            }
            set
            {
                if (types.Equals(value))
                {
                    return;
                }
                types = value;
                Set();
            }
        }

        void IEventWriter.OnEvent(object[] data)
        {
            Publishing publising = new Publishing(url);
            AlertData adata = new AlertData();
            adata.Data = data;
            publising.OnEvent(adata);
        }

        #endregion

        #region Public Members

        public Event.Remote.RemoteType RemoteType
        {
            get
            {
                return type;
            }
            set
            {
                if (type.Equals(value))
                {
                    return;
                }
                type = value;
                Set();
            }
        }

        #endregion

        #region Private Members

        void Set()
        {
            server.RemoveItself();
            server = new ServerNet(url, type, types);
        }

        #endregion

    }
}
