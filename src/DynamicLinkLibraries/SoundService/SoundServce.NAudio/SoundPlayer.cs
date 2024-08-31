using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using SoundService.Interfaces;
using System.IO;
using System.Numerics;


namespace SoundServce.NAudio
{
    /// <summary>
    /// Base class for NAudio players
    /// </summary>
    internal class SoundPlayer : ISoundPlayer, IDisposable
    {

        #region Fields

        protected IWavePlayer player;

        protected AutoResetEvent ev;

        string soundLocation;

        ISampleProvider sampleProvider;

        protected string directory;

        #endregion

        #region ISoundPlayer Members

        /// <summary>
        /// Sound location
        /// </summary>
        string ISoundPlayer.SoundLocation
        {
            get => soundLocation;
            set
            {
                soundLocation = value;
                if (value != null)
                {
                    sampleProvider = CreateInputStream(Path.Combine(directory, value));
                    player.Init(sampleProvider);
                }
            }
        }

        /// <summary>
        /// Plays itself
        /// </summary>
        void ISoundPlayer.Play()
        {
            player.Play();
        }

        /// <summary>
        /// Sinchronous playing
        /// </summary>
        void ISoundPlayer.PlaySync()
        {
            ev = new AutoResetEvent(false);
            player.Play();
            ev.WaitOne();
            ev = null;
        }

        #endregion

        #region IDisopsable Members

        void IDisposable.Dispose()
        {
            if (player != null)
            {
                player.PlaybackStopped -= Player_PlaybackStopped;
            }
            if (player is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
   
        #endregion

        protected IWavePlayer Player
        {
            get => player;
            set
            {
                if (player != null)
                {
                    player.PlaybackStopped -= Player_PlaybackStopped;
                }
                player = value;
                player.PlaybackStopped += Player_PlaybackStopped;
            }
        }

        private void Player_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (ev == null)
            {
                return;
            }
            ev.Set();
            ev = null;
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
