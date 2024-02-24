using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Start of file
    /// </summary>
    public interface IStartFile
    {
        /// <summary>
        /// Start of file
        /// </summary>
        /// <param name="fileName">File name</param>
        void Start(string fileName);

        /// <summary>
        /// Start of buffer
        /// </summary>
        /// <param name="buffer">Buffer</param>
        void Start(byte[] buffer);


        /// <summary>
        /// Stop
        /// </summary>
        void Stop();
    }
}
