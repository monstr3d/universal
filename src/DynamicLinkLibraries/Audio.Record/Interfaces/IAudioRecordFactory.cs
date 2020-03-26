using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Record.Interfaces
{
    /// <summary>
    /// Factory
    /// </summary>
    public interface IAudioRecordFactory
    {

        /// <summary>
        /// Gets default audio
        /// </summary>
        /// <param name="autoSave"></param>
        /// <returns>Default audio</returns>
        IAudioRecorder GetDefault(bool autoSave);
 
    }
}
