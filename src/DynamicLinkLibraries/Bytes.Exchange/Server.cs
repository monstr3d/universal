using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Bytes.Exchange.Interfaces;

namespace Bytes.Exchange
{
    /// <summary>
    /// Server
    /// </summary>
    [Serializable()]
    public class Server :  IDisposable, IEventWriter
    {
        #region Fields

        object obj;

        ServerNet server;

        event Action<string> provider = (string url) => { };

        event Action<string> consumer = (string url) => { };

        List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        RemoteType type;

        string url = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Server(string url, RemoteType type)
        {
            this.type = type;
            this.url = url;
            Set();
        }


        #endregion
   
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            server.Dispose();
        }

        #endregion
   
        #region IEventWriter Members

        void IEventWriter.OnEvent(byte[] data)
        {
            Publishing publising = new Publishing(url);
            AlertData adata = new AlertData();
            adata.Data = data;
            publising.OnEvent(adata);
        }

        #endregion

        #region Public Members

        public RemoteType RemoteType
        {
            get
            {
                return type;
            }
        }

        #endregion

        #region Private Members

        void Set()
        {
            server = new ServerNet(url, type);
        }

        #endregion

    }
}
