using System;
using System.Collections.Generic;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Creator of children
    /// </summary>
    public interface IChildrenCreator
    {
        /// <summary>
        /// Gets children of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>The children</returns>
        object[] GetChildren(object o);

        /// <summary>
        /// Gets image index
        /// </summary>
        /// <param name="o">Object of image</param>
        /// <returns>Image index</returns>
        int GetImageIndex(object o);


        /// <summary>
        /// Gets selected image index
        /// </summary>
        /// <param name="o">Object of image</param>
        /// <returns>Selected image index</returns>
        int GetSelectedImageIndex(object o);

        /// <summary>
        /// Gets name of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>The name</returns>
        string GetObjectName(object o);
        
    }
}
