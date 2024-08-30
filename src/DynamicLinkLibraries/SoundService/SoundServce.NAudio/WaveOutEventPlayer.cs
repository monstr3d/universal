using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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

        public override string SoundLocation
        {
            get => base.SoundLocation;
            set
            {
                base.SoundLocation = value;
                if (value != null)
                {
                    sampleProvider = CreateInputStream(Path.Combine(directory, value));
                    waveOut.Init(sampleProvider);
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