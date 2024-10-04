using SoundService.Interfaces;

namespace SoundService
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionSoundService
    {
        /// <summary>
        /// Directory of sounds
        /// </summary>
        public static string SoundDirectory
        {
            get
            {
                return SoundCollection.SoundDirectory;
            }
            set
            {
                SoundCollection.SoundDirectory = value;
                if (SoundFactory != null)
                {
                    SoundFactory.Directory = value;
                }
            }
        }

        /// <summary>
        /// Sound Factory
        /// </summary>
        public static ISoundFactory SoundFactory { get; set; }

        /// <summary>
        /// Sets a factory
        /// </summary>
        /// <param name="soundFactory">The factory to set</param>
        public static void Set(this ISoundFactory soundFactory)
        {
            soundFactory.Directory = SoundDirectory;
            SoundFactory = soundFactory;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionSoundService()
        {
            new CodeCreators.CSCodeCreator();
        }

    }
}
