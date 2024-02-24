using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Addition to associated object
    /// </summary>
    public class AssociatedAddition
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected IAssociatedObject associatedObject;

        /// <summary>
        /// Additional object
        /// </summary>
        protected object additional;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="associatedObject">Associated object</param>
        /// <param name="additional">additional</param>
        public AssociatedAddition(IAssociatedObject associatedObject,
            object additional)
        {
            this.associatedObject = associatedObject;
            this.additional = additional;

        }

        #endregion

        #region Members

        /// <summary>
        /// Associated object
        /// </summary>
        public IAssociatedObject AssociatedObject
        {
            get
            {
                return associatedObject;
            }
        }

        /// <summary>
        /// Additional object
        /// </summary>
        public object Additional
        {
            get
            {
                return additional;
            }
        }

        #endregion
    }
}
