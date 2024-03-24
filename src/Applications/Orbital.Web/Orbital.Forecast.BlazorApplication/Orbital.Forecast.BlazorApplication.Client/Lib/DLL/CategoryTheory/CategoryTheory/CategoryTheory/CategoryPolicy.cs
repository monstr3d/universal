using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{

    /// <summary>
    /// Policy of category
    /// </summary>
    public abstract class CategoryPolicy
    {
        /// <summary>
        /// Policy
        /// </summary>
        static private CategoryPolicy policy;

        /// <summary>
        /// Policy
        /// </summary>
        static public CategoryPolicy Object
        {
            set
            {
                policy = value;
            }
            get
            {
                return policy;
            }
        }


        /// <summary>
        /// Gets category
        /// </summary>
        /// <param name="category">String category representation</param>
        /// <returns>Category</returns>
        public abstract ICategory GetCategory(string category);
    }

}
