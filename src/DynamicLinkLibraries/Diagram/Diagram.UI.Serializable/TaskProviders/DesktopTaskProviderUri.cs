using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Diagram.UI.TaskProviders
{
    /// <summary>
    /// URL desktop task provider
    /// </summary>
    public class DesktopTaskProviderUri : IDesktopTaskProvider
    {

        #region Fields


        private Dictionary<string, IDesktop> dic = new Dictionary<string, IDesktop>();

        private Uri uri;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uri">Uri</param>
        public DesktopTaskProviderUri(Uri uri)
        {
            this.uri = uri;
        }

        #endregion

        #region IDesktopTaskProvider Members

        async Task<IDesktop> IDesktopTaskProvider.Get(string name)
        {

            var c = new CancellationToken();

            if (dic.ContainsKey(name))
            {
                IDesktop d = dic[name];
                foreach (object o in d.Objects)
                {
                    return d;
                }
            }
            using var stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + name);
            PureDesktopPeer desktop = new PureDesktopPeer();
            var b = await desktop.Load(stream, c);
            dic[name] = desktop;
            return desktop;
        }
 
        string IDesktopTaskProvider.GetTask(string name)
        {
            using (StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + name))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        #region Members

        Uri GetUri(string name)
        {
            try
            {
                return new Uri(uri, name);
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }

        #endregion
    }
}
