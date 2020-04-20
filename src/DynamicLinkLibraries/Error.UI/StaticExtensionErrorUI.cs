using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error.UI
{
    /// <summary>
    /// Static extensions for errors
    /// </summary>
    public static class StaticExtensionErrorUI
    {
        /// <summary>
        /// Plays error
        /// </summary>
        static public void PlayError()
        {
            System.IO.Stream st = Properties.Resources.Error;
            System.Media.SoundPlayer pl = new System.Media.SoundPlayer();
            pl.Stream = st;
            pl.Play();
        }
    }
}
