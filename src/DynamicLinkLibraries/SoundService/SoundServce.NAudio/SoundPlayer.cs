using SoundService.Interfaces;


namespace SoundServce.NAudio
{
    internal class SoundPlayer : ISoundPlayer
    {
        string ISoundPlayer.SoundLocation { get; set; }

        void ISoundPlayer.Play()
        {
            throw new NotImplementedException();
        }

        void ISoundPlayer.PlaySync()
        {
            throw new NotImplementedException();
        }
    }
}
