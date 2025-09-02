namespace CategoryTheory.Math
{
    public static class StaticExtensionCategoryTheoryMath
    {
        /// <summary>
        /// Composition with identical arrow
        /// </summary>
        /// <param name="first">First arrow</param>
        /// <param name="next">Next arrow</param>
        /// <returns>Composition if one arrow is identical and null otherwise</returns>
        public static IAdvancedCategoryArrow IdenticalComposition(this IAdvancedCategoryArrow first,
            IAdvancedCategoryArrow next)
        {
            IAdvancedCategoryArrow[] arr = new IAdvancedCategoryArrow[] { first, next };
            for (int i = 0; i < arr.Length; i++)
            {
                IAdvancedCategoryArrow a = arr[i];
                if (!a.HasAttribute<IdenticalAtrribute>())
                {
                    continue;
                }
                return arr[1 - i];
            }
            return null;
        }

    }
}
