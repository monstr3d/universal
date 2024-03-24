using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryTheory
{
    /// <summary>
    /// Advanced category arrow
    /// </summary>
    public interface IAdvancedCategoryArrow : ICategoryArrow
    {
        /// <summary>
        /// The "is monomorphism" sign
        /// </summary>
        bool IsMonomorphism
        {
            get;
        }

        /// <summary>
        /// The "is epimorphism" sign
        /// </summary>
        bool IsEpimorphism
        {
            get;
        }

        /// <summary>
        /// The "is isomorphism" sign
        /// </summary>
        bool IsIsomorphism
        {
            get;
        }

        /// <summary>
        /// Composes this arrow "f" with next arrow "g" 
        /// </summary>
        /// <param name="category"> The category of arrow</param>
        /// <param name="next"> The next arrow "g" </param>
        /// <returns>Composition "fg" </returns>
        IAdvancedCategoryArrow Compose(ICategory category, IAdvancedCategoryArrow next);

    }
}
