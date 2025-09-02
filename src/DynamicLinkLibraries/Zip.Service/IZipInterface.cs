using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.Service
{
    /// <summary>
    /// Get, set zip bytes
    /// </summary>
    public interface IZipInterface
    {
        /// <summary>
        /// Gets/sets bytes from/to zip file
        /// </summary>
        /// <param name="filename">File mame</param>
        /// <returns>Bytes</returns>
        byte[] this[string filename] { get; set; }
    }
}
