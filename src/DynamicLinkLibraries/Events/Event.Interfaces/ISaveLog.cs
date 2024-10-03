using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Saving 
    /// </summary>
    public interface ISaveLog
    {
        /// <summary>
        /// Bytes of the log
        /// </summary>
        byte[] Bytes
        { get; set; }

        /// <summary>
        /// Extension which says about file
        /// </summary>
        string Extension
        {
            get;
        }

    }
}
