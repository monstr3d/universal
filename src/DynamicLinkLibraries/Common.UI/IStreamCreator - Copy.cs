using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Common.UI
{
    /// <summary>
    /// Creator of stream
    /// </summary>
    public interface IStreamCreator
    {
        /// <summary>
        /// Stream
        /// </summary>
        Stream Stream
        {
            get;
        }
    }
}
