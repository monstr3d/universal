namespace   CategoryTheory.Math
{
    /// <summary>
    /// Bifunctor
    /// </summary>
    public interface IBifunctor : IAdvancedCategoryArrow, IAdvancedCategoryObject
    {
        /// <summary>
        /// Calculates arrow
        /// </summary>
        /// <param name="arrow1">Arrow 1</param>
        /// <param name="arrow2">Arrow 2</param>
        /// <returns>Result arrow</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2);

        /// <summary>
        /// Calculates arrow
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="target">Target object</param>
        /// <param name="arrow1">Arrow 1</param>
        /// <param name="arrow2">Arrow 2</param>
        /// <returns>Result arrou</returns>
        IAdvancedCategoryArrow CalculateArrow(IAdvancedCategoryObject source,
            IAdvancedCategoryObject target,
            IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2);

        /// <summary>
        /// Calculates object
        /// </summary>
        /// <param name="obj1">Object 1</param>
        /// <param name="obj2">Object 2</param>
        /// <returns>Result object</returns>
        IAdvancedCategoryObject CalculateObject(IAdvancedCategoryObject obj1, IAdvancedCategoryObject obj2);

        /// <summary>
        /// The "is covariant" sign
        /// </summary>
        /// <param name="n">Number of argument</param>
        /// <returns>Thue if it is covariant by n - th argument and false othewise</returns>
        bool IsCovariant(int n);

    }
}
