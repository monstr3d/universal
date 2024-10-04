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
    public abstract class AdvancedCategoryObject : IAdvancedCategoryObject
    {
        #region Fields

        object obj;

        #endregion

        #region IAdvancedCategoryObject Members

        /// <summary>
        /// The identical arrow of this object
        /// </summary>
        public abstract IAdvancedCategoryArrow Id
        {
            get;
        }

        /// <summary>
        /// The category of this object
        /// </summary>
        public abstract ICategory Category
        {
            get;
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion
    }
}
