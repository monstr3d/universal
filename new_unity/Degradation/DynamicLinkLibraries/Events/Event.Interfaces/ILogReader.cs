using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Reader of log
    /// </summary>
    public interface ILogReader
    {
        /// <summary>
        /// Loads log
        /// </summary>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>Log</returns>
        IEnumerable<object> Load(uint begin, uint end);

        /// <summary>
        /// Full length of log
        /// </summary>
        int FullLength
        {
            get;
        }

        /// <summary>
        /// Name of reader
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Name of initial file
        /// </summary>
        string FileName
        {
            get;
        }

    }
}
