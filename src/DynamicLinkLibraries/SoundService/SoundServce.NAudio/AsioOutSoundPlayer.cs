using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SoundServce.NAudio
{
    class AsioOutSoundPlayer : SoundPlayer
    {
        AsioOut asioOut;


        public AsioOutSoundPlayer(string directory) : 
            base(directory)
        {
            try
            {
                asioOut = new AsioOut();
                Player = asioOut;
            }
            catch (Exception ex)
            {

            }
        }

 
    }
}