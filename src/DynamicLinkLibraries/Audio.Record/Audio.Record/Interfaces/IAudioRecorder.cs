using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audio.Record.Interfaces
{
    /// <summary>
    /// Audio record
    /// </summary>
    public interface IAudioRecorder
    {
        /// <summary>
        /// Statrs
        /// </summary>
        /// <param name="Id">The unique identificator</param>
        void Start(string Id);

        /// <summary>
        /// Stops itself
        /// </summary>
        void Stop();


        /// <summary>
        /// Saves data
        /// </summary>
        /// <param name="url">URL</param>
        void Save(string url);

        /// <summary>
        /// Id of record
        /// </summary>
        string Id
        {
            get;
        }
    }
}
