using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using Motion6D.Interfaces;
using Motion6D;

namespace WpfInterface.Interfaces
{
    /// <summary>
    /// Visible object
    /// </summary>
    public interface IWpfVisible : IVisible
    {
        /// <summary>
        /// Gets visual object for camera
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>Visual object</returns>
        System.Windows.Media.Media3D.Visual3D GetVisual(Camera camera);

        /// <summary>
        /// Textures
        /// </summary>
        Dictionary<string, byte[]> Textures
        {
            get;
        }
    }
}
