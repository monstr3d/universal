using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Record.Interfaces
{
    /// <summary>
    /// Audio command 
    /// </summary>
    public interface IAudioCommand
    {
        /// <summary>
        /// The command event
        /// </summary>
        event Action<string> Command;
    }
}
