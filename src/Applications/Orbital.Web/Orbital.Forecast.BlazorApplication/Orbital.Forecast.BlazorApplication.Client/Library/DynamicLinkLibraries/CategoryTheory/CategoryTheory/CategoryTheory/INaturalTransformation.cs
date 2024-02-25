using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Natural transformation
    /// </summary>
    public interface INaturalTransformation : IAdvancedCategoryArrow
    {

        /// <summary>
        /// Calculates arrow of natural transform
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>The arrow of transform</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryArrow obj);

        /// <summary>
        /// Calculates arrow of natural thansform
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="source">Source</param>
        /// <param name="target">Tatget</param>
        /// <returns>The arrow</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryObject obj,
             IAdvancedCategoryObject source, IAdvancedCategoryObject target);

    }
}
