using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// The math category functor 
    /// </summary>
    public interface IFunctor : IAdvancedCategoryArrow, ICategoryObject
    {

        /// <summary>
        /// Calculates arrow 
        /// </summary>
        /// <param name="arrow">The source arrow</param>
        /// <returns>The target arrow</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryArrow arrow);

        /// <summary>
        /// Calculates an arrow
        /// </summary>
        /// <param name="source">The source of the source arrow</param>
        /// <param name="target">The target of the source arrow</param>
        /// <param name="arrow">The source arrow</param>
        /// <returns>The target arrow</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryObject source,
            IAdvancedCategoryObject target, IAdvancedCategoryArrow arrow);

        /// <summary>
        /// Calculates an object
        /// </summary>
        /// <param name="obj">The source object</param>
        /// <returns>The target object</returns>
        IAdvancedCategoryObject CalculateObject(IAdvancedCategoryObject obj);

        /// <summary>
        /// The "is covariant" sign
        /// </summary>
        bool IsCovariant
        {
            get;
        }
    }
}
