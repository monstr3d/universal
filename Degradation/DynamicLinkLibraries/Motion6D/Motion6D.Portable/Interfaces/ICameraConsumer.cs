using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Portable.Interfaces
{
    /// <summary>
    /// Consumer of camera
    /// </summary>
    public interface ICameraConsumer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        void Add(Camera camera);

        /// <summary>
        /// Removes camera
        /// </summary>
        /// <param name="camera"></param>
        void Remove(Camera camera);
    }
}
