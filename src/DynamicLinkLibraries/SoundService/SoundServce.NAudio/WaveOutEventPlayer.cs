using NAudio.Wave.SampleProviders;
using NAudio.Wave;

namespace SoundServce.NAudio
{
    class WaveOutEventPlayer : SoundPlayer
    {
        WaveOutEvent waveOut;
        ISampleProvider sampleProvider;
        string directory;


        public WaveOutEventPlayer(string directory) : base(directory)
        {
            try
            {
                waveOut = new WaveOutEvent();
                Player = waveOut;
            }
            catch (Exception ex)
            {

            }
        }


    }
}