using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Wrapper of category object
    /// </summary>
    public class CategoryObjectWrapper : ICategoryObject, IChildrenObject
    {
        #region Fields

        /// <summary>
        /// The internal object
        /// </summary>
        protected ICategoryObject theObject;

        /// <summary>
        /// Children
        /// </summary>
        protected IAssociatedObject[] childern = new IAssociatedObject[1];

        /// <summary>
        /// The associated object;
        /// </summary>
        object obj;


        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// Associated object
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
                if (theObject != null)
                {
                    theObject.SetAssociatedObject(value);
                }
            }
        }

        #endregion 

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return childern; }
        }

        #endregion

    }
}
