
namespace CategoryTheory.Math
{
    /// <summary>
    /// Category with direct product
    /// </summary>
    public interface IDirectProductCategory : ICategory
    {

        /// <summary>
        /// Gets direct product
        /// </summary>
        /// <param name="objects">List of objects</param>
        /// <param name="arrows">List of arrows to objects</param>
        /// <returns>Direct product</returns>
        IAdvancedCategoryObject GetDirectProduct(IList<IAdvancedCategoryObject> objects, IList<IAdvancedCategoryArrow> arrows);

        /// <summary>
        /// Gets arrow to direct product
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="product">Direct product</param>
        /// <param name="arrows">Arrows to product components</param>
        /// <returns>Arrow to product</returns>
        IAdvancedCategoryArrow GetArrowToDirectProduct(IAdvancedCategoryObject source, 
            IAdvancedCategoryObject product, IList<IAdvancedCategoryArrow> arrows);
    }

}
