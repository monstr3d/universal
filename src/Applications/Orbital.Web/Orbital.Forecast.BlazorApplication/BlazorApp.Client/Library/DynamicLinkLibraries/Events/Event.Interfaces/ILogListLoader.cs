using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{

    /// <summary>
    /// Loader of log list
    /// </summary>
    public interface ILogLoader
    {
        /// <summary>
        /// Loads log reader
        /// </summary>
        /// <param name="url">Log url</param>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>Log reader</returns>
        object Load(string url);

    }
}
