using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Object with images
    /// </summary>
    public interface IImageArrow
    {
        /// <summary>
        /// Arrow to image
        /// </summary>
        ICategoryArrow ToImage
        {
            get;
        }

        /// <summary>
        /// Arrow from image
        /// </summary>
        ICategoryArrow FromImage
        {
            get;
        }
    }

}
