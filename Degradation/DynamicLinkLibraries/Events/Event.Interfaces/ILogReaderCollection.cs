using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Collection of log readers
    /// </summary>
    public interface ILogReaderCollection
    {
        /// <summary>
        /// Readers
        /// </summary>
        IEnumerable<ILogReader> Readers
        {
            get;
        }
    }
}
