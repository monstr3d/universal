
namespace CategoryTheory.Math
{
    /// <summary>
    /// Advanced category arrow
    /// </summary>
    public abstract class AdvancedCategoryArrow : IAdvancedCategoryArrow
    {

        #region Fields

        object obj;

        #endregion

        #region IAdvancedCategoryArrow Membres

        /// <summary>
        /// The "is monomorphism" sign
        /// </summary>
        public abstract bool IsMonomorphism
        { get; }

        /// <summary>
        /// The "is epimorphism" sign
        /// </summary>
        public abstract bool IsEpimorphism
        { get; }

        /// <summary>
        /// The "is isomorphism" sign
        /// </summary>
        public abstract bool IsIsomorphism
        { get; }

        /// <summary>
        /// Composes this arrow "f" with next arrow "g" 
        /// </summary>
        /// <param name="category"> The category of arrow</param>
        /// <param name="next"> The next arrow "g" </param>
        /// <returns>Composition "fg" </returns>
        public abstract IAdvancedCategoryArrow Compose(ICategory category, IAdvancedCategoryArrow next);

        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public abstract ICategoryObject Source
        { get; set; }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public abstract ICategoryObject Target
        { get; set; }

        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// The associated object
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
