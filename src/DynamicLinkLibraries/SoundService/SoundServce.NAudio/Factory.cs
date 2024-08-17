using SoundService;
using SoundService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundServce.NAudio
{
    internal class Factory : ISoundFactory
    {
        string directory;
        internal Factory()
        {
            this.Set();
        }

        ISoundPlayer ISoundFactory.SoundPlayer
        {
            get => new AsioOutSoundPlayer(directory);
        }

        string ISoundFactory.Directory { get => directory; set => directory = value; }
    }
}
