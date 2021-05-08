using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }

    }
}
