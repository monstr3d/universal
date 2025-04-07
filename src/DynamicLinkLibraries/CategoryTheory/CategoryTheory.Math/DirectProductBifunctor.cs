using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using NamedTree;

namespace CategoryTheory.Math
{
    /// <summary>
    /// Bifunctor of direct product
    /// </summary>
    public class DirectProductBifunctor : IBifunctor
    {

        #region Fields

        IDirectProductCategory category;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="category">Category</param>
        public DirectProductBifunctor(IDirectProductCategory category)
        {
            this.category = category;
        }

        #region IBifunctor Members

        IAdvancedCategoryArrow IBifunctor.CalculateArrow(IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2)
        {
           return null;
        }

        IAdvancedCategoryArrow IBifunctor.CalculateArrow(IAdvancedCategoryObject source, IAdvancedCategoryObject target,
            IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        IAdvancedCategoryObject IBifunctor.CalculateObject(IAdvancedCategoryObject obj1, IAdvancedCategoryObject obj2)
        {
            IList<IAdvancedCategoryArrow> l = new List<IAdvancedCategoryArrow>();
            IList<IAdvancedCategoryObject> o = new List<IAdvancedCategoryObject>();
            o.Add(obj1);
            o.Add(obj2);
            return category.GetDirectProduct(o, l);
        }

        bool IBifunctor.IsCovariant(int n)
        {
            return true;
        }

        #endregion

        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IAdvancedCategoryArrow.IsMonomorphism
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        bool IAdvancedCategoryArrow.IsEpimorphism
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        bool IAdvancedCategoryArrow.IsIsomorphism
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        IAdvancedCategoryArrow IAdvancedCategoryArrow.Compose(ICategory category, IAdvancedCategoryArrow next)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region IAdvancedCategoryObject Members

        ICategory IAdvancedCategoryObject.Category
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        IAdvancedCategoryArrow IAdvancedCategoryObject.Id
        {
            get { throw new NotImplementedException(); }
        }

        string INamed.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion


    }
}
