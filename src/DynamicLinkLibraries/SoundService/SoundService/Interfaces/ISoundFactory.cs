using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundService.Interfaces
{
    /// <summary>
    /// Factory of sounds
    /// </summary>
    public interface ISoundFactory
    {
        /// <summary>
        /// Sound Player
        /// </summary>
        ISoundPlayer SoundPlayer {get;}

        string Directory { get; set; }
    }
}
