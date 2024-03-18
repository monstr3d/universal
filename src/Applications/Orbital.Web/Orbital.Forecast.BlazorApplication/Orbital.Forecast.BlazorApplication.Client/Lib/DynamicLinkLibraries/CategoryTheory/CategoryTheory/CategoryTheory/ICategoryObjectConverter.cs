using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Creator of category object
    /// </summary>
    public interface ICategoryObjectConverter
    {
        /// <summary>
        /// Accepts conversion
        /// </summary>
        /// <param name="o">The converted object</param>
        /// <returns>True is object can be converted and false otherwize</returns>
        bool Accept(object o);

        /// <summary>
        /// Converts object to ICategoryObject
        /// </summary>
        /// <param name="o">The converted object</param>
        /// <returns>Conversion result</returns>
        ICategoryObject Convert(object o);

    }
}
