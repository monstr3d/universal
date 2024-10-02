using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Object for restoring by arrows
    /// </summary>
    public interface IDiagramRestoredObject
    {

        /// <summary>
        /// Restoring of arrow by arrows from this and target arrows
        /// </summary>
        /// <param name="target">Arrow target</param>
        /// <param name="arrows">Array of arrows</param>
        /// <param name="result">Result of finding</param>
        /// <returns>The arrow</returns>
        IAdvancedCategoryArrow RestoreArrow(IAdvancedCategoryObject target, 
            IAdvancedCategoryArrow[,] arrows, out FindResults result);
    }

}
