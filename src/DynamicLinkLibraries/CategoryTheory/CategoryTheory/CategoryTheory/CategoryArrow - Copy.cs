using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CategoryTheory
{
    /// <summary>
    /// Category arrow
    /// </summary>
    public abstract class CategoryArrow : ICategoryArrow
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        private object obj;

        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public abstract ICategoryObject Source
        {
            get;
            set;
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public abstract ICategoryObject Target
        {
            get;
            set;
        }


        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// Object
        /// </summary>
        public object Object
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
