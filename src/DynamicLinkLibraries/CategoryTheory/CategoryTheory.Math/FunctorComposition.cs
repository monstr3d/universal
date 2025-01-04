namespace CategoryTheory.Math
{
    /// <summary>
    /// Composition of two functors
    /// </summary>
    public class FunctorComposition : IFunctor
    {
        /// <summary>
        /// First functor
        /// </summary>
        protected IFunctor first;

        /// <summary>
        /// Next functor
        /// </summary>
        protected IFunctor next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="first">First functor</param>
        /// <param name="next">Next functor</param>
        public FunctorComposition(IFunctor first, IFunctor next)
        {
            this.first = first;
            this.next = next;
        }

        /// <summary>
        /// Calculates arrow 
        /// </summary>
        /// <param name="arrow">The source arrow</param>
        /// <returns>The target arrow</returns>
        public IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryArrow arrow)
        {
            return first.CalculateArrow(next.CalculateArrow(arrow));
        }

        /// <summary>
        /// Calculates an arrow
        /// </summary>
        /// <param name="source">The source of the source arrow</param>
        /// <param name="target">The target of the source arrow</param>
        /// <param name="arrow">The source arrow</param>
        /// <returns>The target arrow</returns>
        public IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryObject source,
            IAdvancedCategoryObject target, IAdvancedCategoryArrow arrow)
        {
            IAdvancedCategoryObject s = next.CalculateObject(arrow.Source as IAdvancedCategoryObject);
            IAdvancedCategoryObject t = next.CalculateObject(arrow.Target as IAdvancedCategoryObject);
            IAdvancedCategoryArrow n = next.CalculateArrow(s, t, arrow);
            IAdvancedCategoryArrow ar = first.CalculateArrow(source, target, n);
            return ar;
        }

        /// <summary>
        /// Calculates an object
        /// </summary>
        /// <param name="obj">The source object</param>
        /// <returns>The target object</returns>
        public IAdvancedCategoryObject CalculateObject(IAdvancedCategoryObject obj)
        {
            return first.CalculateObject(next.CalculateObject(obj));
        }

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public ICategoryObject Source
        {
            get
            {
                return next.Source;
            }
            set
            {

            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public ICategoryObject Target
        {
            get
            {
                return first.Target;
            }
            set
            {
            }
        }

        /// <summary>
        /// Composes this arrow "f" with next arrow "g" 
        /// </summary>
        /// <param name="category"> The category of arrow</param>
        /// <param name="next"> The next arrow "g" </param>
        /// <returns>Composition "fg" </returns>
        public IAdvancedCategoryArrow Compose(ICategory category, IAdvancedCategoryArrow next)
        {
            IFunctor f = next as IFunctor;
            return new FunctorComposition(this, f);
        }

        /// <summary>
        /// Is isomorphism sign
        /// </summary>
        public bool IsMonomorphism
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Is epimorphism sign
        /// </summary>
        public bool IsEpimorphism
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Is isomorphism sign
        /// </summary>
        public bool IsIsomorphism
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The category of this object
        /// </summary>
        public ICategory Category
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// The identical arrow of this object
        /// </summary>
        public IAdvancedCategoryArrow Id
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Objects comparation
        /// </summary>
        /// <param name="o">The object to compare</param>
        /// <returns>1</returns>
        public int CompareTo(object o)
        {
            return 1;
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public object Object
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        /// <summary>
        /// The "is covariant" sign
        /// </summary>
        public bool IsCovariant
        {
            get
            {
                if (first.IsCovariant)
                {
                    return next.IsCovariant;
                }
                return !next.IsCovariant;
            }
        }
    }

}
