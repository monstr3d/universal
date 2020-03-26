using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Base category object
    /// </summary>
    public class CategoryObject : ICategoryObject
    {

        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected CategoryObject()
        {
        }

        #endregion

        #region ICategoryObject Members

        /// <summary>
        /// Category
        /// </summary>
        public virtual ICategory Category
        {
            get { return null; }
        }


        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// Associated object
        /// </summary>
        public  object Object
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
