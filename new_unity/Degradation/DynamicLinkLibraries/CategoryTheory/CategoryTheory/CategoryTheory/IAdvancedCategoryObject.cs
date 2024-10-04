using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryTheory
{
    /// <summary>
    /// Advanced category object
    /// </summary>
    public interface IAdvancedCategoryObject : ICategoryObject
    {
        /// <summary>
        /// The identical arrow of this object
        /// </summary>
        IAdvancedCategoryArrow Id
        {
            get;
        }

        /// <summary>
        /// The category of this object
        /// </summary>
        ICategory Category
        {
            get;
        }
    }
}
