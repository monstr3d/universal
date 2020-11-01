using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Remote
{
    /// <summary>
    /// Type of remote object
    /// </summary>
    public enum RemoteType
    {
        Ipc,    // Ipc event
        Tcp,    // Tcp event
        Http    // Http event
    }
}
