using SoundService;
using SoundService.Interfaces;

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
            get => new WaveOutEventPlayer(directory);
        }

        string ISoundFactory.Directory { get => directory; set => directory = value; }
    }
}
