using System.Collections.Generic;
using NamedTree;

namespace CategoryTheory
{
    /// <summary>
    /// Wrapper of category arrow
    /// </summary>
    public class CategoryArrowWrapper : ICategoryArrow, IChildren<IAssociatedObject>
    {
        #region
        /// <summary>
        /// The internal object
        /// </summary>
        protected ICategoryArrow theArrow;

        /// <summary>
        /// The associated object;
        /// </summary>
        object obj;


        /// <summary>
        /// Children
        /// </summary>
        protected IAssociatedObject[] children = new IAssociatedObject[1];


        #endregion

        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return theArrow.Source;
            }
            set
            {
                theArrow.Source = value;
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return theArrow.Target;
            }
            set
            {
                theArrow.Target = value;
            }
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                if (theArrow == null)
                {
                    return obj;
                }
                return theArrow.Object;
            }
            set
            {
                if (theArrow == null)
                {
                    obj = value;
                }
                else
                {
                    theArrow.SetAssociatedObject(value);
                }
            }
        }

        #endregion

        #region IChildrenObject Members


        #endregion

        #region Members
        /// <summary>
        /// Arrow
        /// </summary>
        public ICategoryArrow Arrow
        {
            get
            {
                return theArrow;
            }
            set
            {
                theArrow = value;
                children[0] = value;
                if (theArrow is IParentArrow)
                {
                    (theArrow as IParentArrow).Parent = this;
                }
            }
        }

        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => children;

        #endregion
    }
}
