namespace CategoryTheory.Math
{
    /// <summary>
    /// Category with equalizer
    /// </summary>
    public interface ICoequalizerCategory : ICategory
    {
        /// <summary>
        /// Gets coequalizer of two arrows 
        /// </summary>
        /// <param name="arrow1">First arrow</param>
        /// <param name="arrow2">Second arrow</param>
        /// <returns>The coequalizer</returns>
        IAdvancedCategoryArrow GetCoequalizer(IAdvancedCategoryArrow arrow1, IAdvancedCategoryArrow arrow2);

        /// <summary>
        /// Gets arrow from coequalizer
        /// </summary>
        /// <param name="coequalizer">The coqualizer</param>
        /// <param name="arrow">Arrow to object</param>
        /// <param name="arrowToObject1">First arrow to object</param>
        /// <param name="arrowToObject2">Second arrow to object</param>
        /// <returns>Arrow from equalizer</returns>
        IAdvancedCategoryArrow GetArrowFromCoequalizer(IAdvancedCategoryArrow coequalizer, IAdvancedCategoryArrow arrow,
            IAdvancedCategoryArrow arrowToObject1, IAdvancedCategoryArrow arrowToObject2);
    }

}
