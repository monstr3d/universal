using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Interface for arrows with post operation
    /// </summary>
    public interface IPostSetArrow
    {
        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        void PostSetArrow();
    }
}
