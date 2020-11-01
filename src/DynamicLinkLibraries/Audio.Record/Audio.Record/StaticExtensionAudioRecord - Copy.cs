using Audio.Record.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Record
{

    /// <summary>
    /// Extensions methods
    /// </summary>
    public static class StaticExtensionAudioRecord
    {

        #region Public Members

        /// <summary>
        /// Factory of recoders
        /// </summary>
        static public IAudioRecordFactory RecorderFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Factory of recoders
        /// </summary>
        static public IAudioCommandFactory AudioCommandFactory
        {
            get;
            set;
        }

        #endregion

    }
}
