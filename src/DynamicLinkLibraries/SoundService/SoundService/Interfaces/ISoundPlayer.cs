namespace SoundService.Interfaces
{
    /// <summary>
    /// Sound player
    /// </summary>
    public interface ISoundPlayer
    {
        /// <summary>
        /// Sound location
        /// </summary>
        string SoundLocation { get; set; }

        /// <summary>
        /// Plays itself
        /// </summary>
        void Play();

        /// <summary>
        /// Sinchronous playing
        /// </summary>
        void PlaySync();
    }
}
