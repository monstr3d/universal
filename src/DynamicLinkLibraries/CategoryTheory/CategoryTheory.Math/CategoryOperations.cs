

namespace CategoryTheory.Math
{
    /// <summary>
    /// Standard category operations
    /// </summary>
    public class CategoryOperations
    {

        /// <summary>
        /// Gets arrow to equalizer
        /// </summary>
        /// <param name="equalizer">The qualizer</param>
        /// <param name="arrow">Arrow to object</param>
        /// <returns>Arrow to equalizer</returns>
        public static IAdvancedCategoryArrow GetArrowToEqualizer(IAdvancedCategoryArrow equalizer, 
            IAdvancedCategoryArrow arrow)
        {
            IAdvancedCategoryObject s = arrow.Source as IAdvancedCategoryObject;
            IAdvancedCategoryObject t = equalizer.Source as IAdvancedCategoryObject;
            IAdvancedCategoryArrow[,] arrows = new IAdvancedCategoryArrow[1, 3];
            arrows[0, 0] = arrow;
            arrows[0, 1] = (arrow.Source as IAdvancedCategoryObject).Id;
            arrows[0, 2] = equalizer;
            IDiagramRestoredObject r = s as IDiagramRestoredObject;
            FindResults res;
            return r.RestoreArrow(t, arrows, out res);
        }

        /// <summary>
        /// Gets arrow to coequalizer
        /// </summary>
        /// <param name="coequalizer">The qualizer</param>
        /// <param name="arrow">Arrow to object</param>
        /// <returns>Arrow from equalizer</returns>
        public static IAdvancedCategoryArrow GetArrowFromCoequalizer(IAdvancedCategoryArrow coequalizer, 
            IAdvancedCategoryArrow arrow)
        {
            IAdvancedCategoryObject s = arrow.Target as IAdvancedCategoryObject;
            IAdvancedCategoryObject t = coequalizer.Source as IAdvancedCategoryObject;
            IAdvancedCategoryArrow[,] arrows = new IAdvancedCategoryArrow[1, 3];
            arrows[0, 0] = arrow;
            arrows[0, 1] = coequalizer;
            arrows[0, 2] = (arrow.Source as IAdvancedCategoryObject).Id;
            IDiagramRestoredObject r = s as IDiagramRestoredObject;
            FindResults res;
            return r.RestoreArrow(s, arrows, out res);
        }


        /// <summary>
        /// Gets colimit
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="arrows">Diagram arrows</param>
        /// <param name="coequalizer">Coequalizer</param>
        /// <param name="objectArrows">Arrows to colimit</param>
        /// <param name="productArrows">Sum arrows</param>
        /// <returns>The colimit</returns>
        public static IAdvancedCategoryObject GetColim(ICategory category, IList<IAdvancedCategoryArrow> arrows,
            ref IAdvancedCategoryArrow coequalizer, ref IList<IAdvancedCategoryArrow> objectArrows, ref IList<IAdvancedCategoryArrow> productArrows)
        {
            IList<IAdvancedCategoryObject> objects = new List<IAdvancedCategoryObject>();
            IList<IAdvancedCategoryObject> sources = new List<IAdvancedCategoryObject>();
            IDirectSumCategory direct = category as IDirectSumCategory;
            ICoequalizerCategory coequ = category as ICoequalizerCategory;
            foreach (IAdvancedCategoryArrow arrow in arrows)
            {
                if (!objects.Contains(arrow.Source as IAdvancedCategoryObject))
                {
                    objects.Add(arrow.Source as IAdvancedCategoryObject);
                }
                if (!objects.Contains(arrow.Target as IAdvancedCategoryObject))
                {
                    objects.Add(arrow.Source as IAdvancedCategoryObject);
                }
                sources.Add(arrow.Source as IAdvancedCategoryObject);
            }
            IList<IAdvancedCategoryArrow> productSourceArrows = new List<IAdvancedCategoryArrow>();
            productArrows = new List<IAdvancedCategoryArrow>();
            IAdvancedCategoryObject product = direct.GetDirectSum(objects, productArrows);
            IAdvancedCategoryObject productSource = direct.GetDirectSum(sources, productSourceArrows);
            IList<IAdvancedCategoryArrow> coequList = new List<IAdvancedCategoryArrow>();
            IList<IAdvancedCategoryArrow> arrList = new List<IAdvancedCategoryArrow>();
            foreach (IAdvancedCategoryArrow arr in productArrows)
            {
                IAdvancedCategoryObject target = arr.Target as IAdvancedCategoryObject;
                foreach (IAdvancedCategoryObject t in sources)
                {
                    if (t == target)
                    {
                        arrList.Add(arr);
                    }
                }
            }
            IAdvancedCategoryArrow first = direct.GetArrowFromDirectSum(product, productSource, arrList);
            foreach (IAdvancedCategoryArrow arr in arrows)
            {
                int num = objects.IndexOf(arr.Target as IAdvancedCategoryObject);
                IAdvancedCategoryArrow pr = productArrows[num] as IAdvancedCategoryArrow;
                IAdvancedCategoryArrow eq = pr.Compose(category, arr);
                coequList.Add(eq);
            }
            IAdvancedCategoryArrow second = direct.GetArrowFromDirectSum(product, productSource, coequList);
            coequalizer = coequ.GetCoequalizer(first, second);
            objectArrows = new List<IAdvancedCategoryArrow>();
            foreach (IAdvancedCategoryArrow arrow in productArrows)
            {
                IAdvancedCategoryArrow arr = coequalizer.Compose(category, arrow);
                objectArrows.Add(arr);
            }
            return coequalizer.Target as IAdvancedCategoryObject;
        }

        /// <summary>
        /// Composition with identical morphism
        /// </summary>
        /// <param name="first">First morphism</param>
        /// <param name="second">Second morphism</param>
        /// <returns>The composition</returns>
        static public IAdvancedCategoryArrow CompositionWithId(IAdvancedCategoryArrow first, IAdvancedCategoryArrow second)
        {
            if (first == (first.Target as IAdvancedCategoryObject).Id)
            {
                return second;
            }
            if (second == (second.Source as IAdvancedCategoryObject).Id)
            {
                return first;
            }
            return null;
        }




    }
}
