using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Record.Interfaces
{

    /// <summary>
    /// The factory of audio commands
    /// </summary>
    public interface IAudioCommandFactory
    {
       /// <summary>
       /// Gets default command
       /// </summary>
       /// <returns>The command</returns>
        IAudioCommand GetDefault();
    }
}
