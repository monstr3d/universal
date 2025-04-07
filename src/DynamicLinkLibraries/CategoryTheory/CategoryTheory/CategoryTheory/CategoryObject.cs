using System;
using System.Collections.Generic;
using System.Text;
using ErrorHandler;
using NamedTree;

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

        Performer performer = new Performer();

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

        string INamed.Name { get => performer.GetAssociatedName(this); set => throw new IllegalSetPropetryException("WRITE PROHIBITED"); }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return this.ObjectArrowName() + base.ToString() + ")";
        }

        #endregion

    }
}
