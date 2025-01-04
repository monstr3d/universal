namespace CategoryTheory.Math
{
    /// <summary>
    /// Category with direct sum
    /// </summary>
    public interface IDirectSumCategory : ICategory
    {
        /// <summary>
        /// Gets direct sum
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows from objects to sum</param>
        /// <returns>The direct sum</returns>
        IAdvancedCategoryObject GetDirectSum(IList<IAdvancedCategoryObject> objects, IList<IAdvancedCategoryArrow> arrows);

        /// <summary>
        /// Gets arrow from direct sum
        /// </summary>
        /// <param name="target">Arrow target</param>
        /// <param name="sum">Direct sum</param>
        /// <param name="arrows">Arrows from objects</param>
        /// <returns>Arrow from direct sum</returns>
        IAdvancedCategoryArrow GetArrowFromDirectSum(IAdvancedCategoryObject target, IAdvancedCategoryObject sum, IList<IAdvancedCategoryArrow> arrows);
    }

}
