using ErrorHandler;
using NamedTree;

namespace CategoryTheory.Math
{
    /// <summary>
    /// Combination of functrors
    /// </summary>
    public abstract class  FunctorCombination: IFunctor
    {
        #region Fields

        private IFunctor[] functors;

        private object obj;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="functors">Functors</param>
        public FunctorCombination(IFunctor[] functors)
        {
            foreach (IFunctor f in functors)
            {
                if (!(f is IFunctorAcceptor))
                {
                    throw new OwnException("Illegal functor combination");
                }
            }
            this.functors = functors;
        }

        #endregion

        #region IFunctor Members

        IAdvancedCategoryArrow IFunctor.CalculateArrow(IAdvancedCategoryArrow arrow)
        {
            Func<IFunctor, IAdvancedCategoryArrow> func = (IFunctor f) =>
                {
                    if ((f as IFunctorAcceptor).Accept(arrow))
                    {
                        return f.CalculateArrow(arrow);
                    }
                    return null;
                };
            return GetObject<IAdvancedCategoryArrow>(func);
        }

        IAdvancedCategoryArrow IFunctor.CalculateArrow(IAdvancedCategoryObject source, IAdvancedCategoryObject target, IAdvancedCategoryArrow arrow)
        {
            Func<IFunctor, IAdvancedCategoryArrow> func = (IFunctor f) =>
            {
                if ((f as IFunctorAcceptor).Accept(arrow))
                {
                    return f.CalculateArrow(source, target, arrow);
                }
                return null;
            };
            return GetObject<IAdvancedCategoryArrow>(func);
        }

        IAdvancedCategoryObject IFunctor.CalculateObject(IAdvancedCategoryObject obj)
        {
            Func<IFunctor, IAdvancedCategoryObject> func = (IFunctor f) =>
            {
                if ((f as IFunctorAcceptor).Accept(obj))
                {
                    return f.CalculateObject(obj);
                }
                return null;
            };
            return GetObject<IAdvancedCategoryObject>(func);
        }

        bool IFunctor.IsCovariant
        {
            get { return functors[0].IsCovariant; }
        }

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


        /// <summary>
        /// The "is monomorphism" sign
        /// </summary>
        public abstract bool IsMonomorphism
        {
            get;
        }

        /// <summary>
        /// The "is epimorphism" sign
        /// </summary>
        public abstract bool IsEpimorphism
        {
            get;
        }

        /// <summary>
        /// The "is isomorphism" sign
        /// </summary>
        public abstract bool IsIsomorphism
        {
            get;
        }

        /// <summary>
        /// Composes this arrow "f" with next arrow "g" 
        /// </summary>
        /// <param name="category"> The category of arrow</param>
        /// <param name="next"> The next arrow "g" </param>
        /// <returns>Composition "fg" </returns>
        public abstract IAdvancedCategoryArrow Compose(ICategory category, IAdvancedCategoryArrow next);

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

        #region ICategoryObject Members

        /// <summary>
        /// Category
        /// </summary>
        public abstract ICategory Category
        {
            get;
        }

        /// <summary>
        /// Id arrow
        /// </summary>
        public abstract IAdvancedCategoryArrow Id
        {
            get;
        }
        string INamed.Name { get => throw new OwnNotImplemented("FunctorCombination"); set => throw new OwnNotImplemented("FunctorCombination"); }

        #endregion

        #region Members

        T GetObject<T>(Func<IFunctor, T> func) where T : class
        {
            foreach (IFunctor f in functors)
            {
                T t = func(f);
                if (t != null)
                {
                    return t;
                }
            }
            throw new OwnException("Illegal function combination");
        }

        #endregion

    }
}
