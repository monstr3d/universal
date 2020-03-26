using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Remote
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionEventRemote
    {
        /// <summary>
        /// Array of remote types
        /// </summary>
        public static readonly List<RemoteType> Types = 
            new List<RemoteType> { RemoteType.Ipc, RemoteType.Tcp, RemoteType.Http };
    }
}
