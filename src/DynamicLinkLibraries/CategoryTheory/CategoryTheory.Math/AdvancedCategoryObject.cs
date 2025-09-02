using NamedTree;

namespace CategoryTheory.Math
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

        protected virtual string Name { get; set; }

        string INamed.Name { get => Name; set => Name = value; }

        #endregion
    }
}
