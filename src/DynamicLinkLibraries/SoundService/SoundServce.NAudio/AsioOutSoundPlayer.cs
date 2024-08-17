using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundServce.NAudio
{
    class AsioOutSoundPlayer : SoundPlayer
    {
        AsioOut asioOut;
        ISampleProvider sampleProvider;
        string directory;


        public AsioOutSoundPlayer(string directory)
        {
            asioOut = new AsioOut();
            Player = asioOut;
            this.directory = directory;
        }

        public override string SoundLocation
        {
            get => base.SoundLocation;
            set
            {
                base.SoundLocation = value;
                if (value != null)
                {
                    sampleProvider = CreateInputStream(Path.Combine(directory, value));
                    asioOut.Init(sampleProvider);
                }
            }
        }

        private ISampleProvider CreateInputStream(string fileName)
        {
            var audioFileReader = new AudioFileReader(fileName);
            var sampleChannel = new SampleChannel(audioFileReader, true);
            var postVolumeMeter = new MeteringSampleProvider(sampleChannel);
            return postVolumeMeter;
        }

    }
}