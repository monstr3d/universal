using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Factory of arrow
    /// </summary>
    public interface IArrowFactory
    {
        /// <summary>
        /// Creates arrow
        /// </summary>
        /// <param name="name">name of arrow</param>
        /// <returns>Created arrow</returns>
        ICategoryArrow this[string name]
        {
            get;
        }
    }
}
