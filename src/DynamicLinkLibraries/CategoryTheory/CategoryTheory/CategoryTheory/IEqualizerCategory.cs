using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Category with equalizer
    /// </summary>
    public interface IEqualizerCategory : ICategory
    {

        /// <summary>
        /// Gets equalizer of two arrows 
        /// </summary>
        /// <param name="arrow1">First arrow</param>
        /// <param name="arrow2">Second arrow</param>
        /// <returns>The equalizer</returns>
        IAdvancedCategoryArrow GetEqualizer(IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2);

        /// <summary>
        /// Gets arrow to equalizer
        /// </summary>
        /// <param name="equalizer">The qualizer</param>
        /// <param name="arrow">Arrow to object</param>
        /// <param name="arrowFromObject1">First arrow from object</param>
        /// <param name="arrowFromObject2">Second arrow from object</param>
        /// <returns></returns>
        IAdvancedCategoryArrow GetArrowToEqualizer(IAdvancedCategoryArrow equalizer,
            IAdvancedCategoryArrow arrow, IAdvancedCategoryArrow arrowFromObject1, IAdvancedCategoryArrow arrowFromObject2);

    }
}