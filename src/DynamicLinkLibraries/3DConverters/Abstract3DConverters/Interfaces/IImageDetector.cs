using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Detector of image
    /// </summary>
    public interface IImageDetector
    {
        /// <summary>
        /// Detection
        /// </summary>
        /// <param name="imagePath">Path</param>
        /// <returns>True on success</returns>
        bool Detect(string imagePath);

        /// <summary>
        /// Detection
        /// </summary>
        /// <param name="imageData">Data</param>
        /// <returns>True on success</returns>
        bool Detect(byte[] imageData);
    }
}
