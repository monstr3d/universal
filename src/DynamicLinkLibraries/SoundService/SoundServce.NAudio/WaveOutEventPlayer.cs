using NAudio.Wave.SampleProviders;
using NAudio.Wave;

namespace SoundServce.NAudio
{
    class WaveOutEventPlayer : SoundPlayer
    {
        WaveOutEvent waveOut;
        ISampleProvider sampleProvider;
        string directory;


        public WaveOutEventPlayer(string directory)
        {
            try
            {
                waveOut = new WaveOutEvent();
                Player = waveOut;
                this.directory = directory;
            }
            catch (Exception ex)
            {

            }
        }


    }
}