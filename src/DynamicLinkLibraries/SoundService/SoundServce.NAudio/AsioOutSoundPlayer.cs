using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SoundServce.NAudio
{
    class AsioOutSoundPlayer : SoundPlayer
    {
        AsioOut asioOut;


        public AsioOutSoundPlayer(string directory)
        {
            try
            {
                asioOut = new AsioOut();
                Player = asioOut;
                this.directory = directory;
            }
            catch (Exception ex)
            {

            }
        }

 
    }
}