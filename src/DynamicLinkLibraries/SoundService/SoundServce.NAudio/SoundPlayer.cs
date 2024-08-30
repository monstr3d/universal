using NAudio.Wave;
using SoundService.Interfaces;


namespace SoundServce.NAudio
{
    internal  class SoundPlayer : ISoundPlayer, IDisposable
    {

        protected IWavePlayer player;

        protected AutoResetEvent ev;

        string soundLocation;


        public IWavePlayer Player
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
        }

        public virtual string SoundLocation
        {
            get => soundLocation;
            set => soundLocation = value;
        }

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

        void ISoundPlayer.Play()
        {
            
            player.Play();
        }

        void ISoundPlayer.PlaySync()
        {
            ev = new AutoResetEvent(false);
            player.Play();
            ev.WaitOne();
            ev = null;
        }

        protected virtual void DisposeInrernal()
        {

        }
    }
}
