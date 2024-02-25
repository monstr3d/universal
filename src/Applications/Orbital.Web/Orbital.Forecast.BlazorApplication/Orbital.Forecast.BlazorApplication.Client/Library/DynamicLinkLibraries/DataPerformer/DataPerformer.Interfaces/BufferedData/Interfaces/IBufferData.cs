using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    /// <summary>
    /// Log data
    /// </summary>
    public interface IBufferData : IBufferItem
    {
        /// <summary>
        /// File name
        /// </summary>
        string FileName
        {
            get;
        }

        /// <summary>
        /// Buffer
        /// </summary>
        IEnumerable<byte[]> Buffer
        {
            get;
        }

        /// <summary>
        /// Length
        /// </summary>
        int Length
        {
            get;
        }

    }
}
