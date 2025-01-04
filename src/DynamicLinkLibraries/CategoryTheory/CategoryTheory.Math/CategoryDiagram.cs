using System.Collections;

using MathGraph;

namespace CategoryTheory.Math
{
    /// <summary>
    /// DiagramLimit
    /// </summary>
    public class CategoryDiagram
    {

        /// <summary>
        /// Out of diagram test
        /// </summary>
        static public readonly string ObjectOutOfDiagram = "Diagram does not contains object";

        /// <summary>
        /// Extra object in diagram text
        /// </summary>
        static public readonly string ExtraArrow = "Extra object";

        /// <summary>
        /// Shortage of in diagram text
        /// </summary>
        static public readonly string ArrowsShortage = "Shortage of arrows in diagram";

        /// <summary>
        /// Graph
        /// </summary>
        private Digraph graph;

        /// <summary>
        /// Arrows hash table
        /// </summary>
        private Dictionary<CategoryObjectPair, IAdvancedCategoryArrow > arrows = new Dictionary<CategoryObjectPair, IAdvancedCategoryArrow >();

        /// <summary>
        /// Objects
        /// </summary>
        private IList<IAdvancedCategoryObject> objects = new List<IAdvancedCategoryObject>();

        /// <summary>
        /// Sources
        /// </summary>
        private Dictionary<IAdvancedCategoryObject, IList<IAdvancedCategoryArrow >> sources = new Dictionary<IAdvancedCategoryObject, IList<IAdvancedCategoryArrow >>();

        /// <summary>
        /// Targets
        /// </summary>
        private Dictionary<IAdvancedCategoryObject, IList<IAdvancedCategoryArrow >> targets = new Dictionary<IAdvancedCategoryObject, IList<IAdvancedCategoryArrow >>();

        /// <summary>
        /// Category
        /// </summary>
        private ICategory category;

        /// <summary>
        /// Limit
        /// </summary>
        private IAdvancedCategoryObject lim;

        /// <summary>
        /// Limit arrow
        /// </summary>
        private IAdvancedCategoryArrow limArrow;

        /// <summary>
        /// Limit id arrows
        /// </summary>
        private IList<IAdvancedCategoryArrow > limIdArrows;

        /// <summary>
        /// Limit function arrowa
        /// </summary>
        private List<IAdvancedCategoryArrow > limFuncArrows;

        /// <summary>
        /// Lim id arrow
        /// </summary>
        private IAdvancedCategoryArrow limIdArrow;

        /// <summary>
        /// Limit fuctional arrow
        /// </summary>
        private IAdvancedCategoryArrow limFuncArrow;

        /// <summary>
        /// Limit arrows
        /// </summary>
        private Dictionary<IAdvancedCategoryObject, IAdvancedCategoryArrow > limArrows;

        /// <summary>
        /// Colimit
        /// </summary>
        private IAdvancedCategoryObject colim;

        /// <summary>
        /// Colimit arrow
        /// </summary>
        private IAdvancedCategoryArrow colimArrow;

        /// <summary>
        /// Colimit id arrows
        /// </summary>
        private Dictionary<IAdvancedCategoryObject, IAdvancedCategoryArrow > colimArrows;

        /// <summary>
        /// Colimit function arrowa
        /// </summary>
        private IList<IAdvancedCategoryArrow > colimFuncArrows;

        /// <summary>
        /// Colim id arrow
        /// </summary>
        private IAdvancedCategoryArrow colimIdArrow;

        /// <summary>
        /// Colimit fuctional arrow
        /// </summary>
        private IAdvancedCategoryArrow colimFuncArrow;

        /// <summary>
        /// Coimit arrows
        /// </summary>
        private IList<IAdvancedCategoryArrow > colimIdArrows;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="graph">Graph</param>
        /// <param name="category">Category</param>
        public CategoryDiagram(Digraph graph, ICategory category)
        {
            this.graph = graph;
            this.category = category;
            for (int i = 0; i < graph.Count; i++)
            {
                IAdvancedCategoryObject o = graph[i].Object as IAdvancedCategoryObject;
                CategoryObjectPair idPair = new CategoryObjectPair(o, o);
                IAdvancedCategoryArrow id = o.Id;
                arrows[idPair] = id;
                objects.Add(o);
                IList<IAdvancedCategoryArrow > s = new List<IAdvancedCategoryArrow >();
                s.Add(id);
                sources[o] = s;
                IList<IAdvancedCategoryArrow > t = new List<IAdvancedCategoryArrow >();
                t.Add(id);
                targets[o] = t;
            }
            for (int i = 0; i < graph.Count; i++)
            {
                DigraphVertex o = graph[i];
                GetPaths(o, o);
            }
        }

        /// <summary>
        /// Count of objects
        /// </summary>
        public int Count
        {
            get
            {
                return objects.Count;
            }
        }

        /// <summary>
        /// Digraph
        /// </summary>
        public Digraph Graph
        {
            get
            {
                return graph;
            }
        }

        /// <summary>
        /// Access to i th object
        /// </summary>
        public IAdvancedCategoryObject this[int i]
        {
            get
            {
                return objects[i] as IAdvancedCategoryObject;
            }
        }

        /// <summary>
        /// Access to arrow by pair
        /// </summary>
        public IAdvancedCategoryArrow this[CategoryObjectPair p]
        {
            get
            {
                return arrows[p] as IAdvancedCategoryArrow ;
            }
        }

        /// <summary>
        /// Gets outcoming arrows
        /// </summary>
        /// <param name="o">The soutrce</param>
        /// <returns>List of outcoming arrows</returns>
        public IList<IAdvancedCategoryArrow > GetOutcomingArrows(IAdvancedCategoryObject o)
        {
            return sources[o];
        }

        /// <summary>
        /// Gets incoming arrows
        /// </summary>
        /// <param name="o">The target</param>
        /// <returns>List of outcoming arrows</returns>
        public IList<IAdvancedCategoryArrow > GetIncomingArrows(IAdvancedCategoryObject o)
        {
            return targets[o];
        }

        /// <summary>
        /// Keys of arrows table
        /// </summary>
        public ICollection Keys
        {
            get
            {
                return arrows.Keys;
            }
        }

        /// <summary>
        /// Gets arrow from limit to diagram object
        /// </summary>
        /// <param name="o">The diagram object</param>
        /// <returns>The arrow</returns>
        public IAdvancedCategoryArrow GetLimArrow(IAdvancedCategoryObject o)
        {
            return limArrows[o] as IAdvancedCategoryArrow ;
        }

        /// <summary>
        /// Limit
        /// </summary>
        public IAdvancedCategoryObject Lim
        {
            get
            {
                if (lim == null)
                {
                    CreateLim();
                }
                return lim;
            }
        }

        /// <summary>
        /// Gets arrow to lim
        /// </summary>
        /// <param name="arrows">Arrows to objects</param>
        /// <returns>The arrow to lim</returns>
        public IAdvancedCategoryArrow GetArrowToLim(List<IAdvancedCategoryArrow> arrows)
        {
            Dictionary<ICategoryObject, ICategoryArrow> dictionary = new Dictionary<ICategoryObject, ICategoryArrow>();
            IAdvancedCategoryObject source = null;
            foreach (IAdvancedCategoryArrow arrow in arrows)
            {
                if (source == null)
                {
                    source = arrow.Source as IAdvancedCategoryObject;
                }
                if (source != arrow.Source)
                {
                    throw new CategoryException(CategoryException.DifferentSources,
                        new IAdvancedCategoryObject[] { source, arrow.Source as IAdvancedCategoryObject });
                }
                if (!objects.Contains(arrow.Target as IAdvancedCategoryObject))
                {
                    throw new CategoryException(ObjectOutOfDiagram, arrow.Target);
                }
                if (dictionary.ContainsKey(arrow.Target))
                {
                    throw new CategoryException(ExtraArrow, arrow);
                }
                dictionary[arrow.Target] = arrow;
            }
            foreach (object o in objects)
            {
                if (!dictionary.ContainsKey(o as ICategoryObject))
                {
                    throw new CategoryException(ArrowsShortage, o);
                }
            }
            foreach (CategoryObjectPair pair in Keys)
            {
                IAdvancedCategoryArrow ar = this[pair];
                IAdvancedCategoryArrow first = dictionary[pair.Source] as IAdvancedCategoryArrow ;
                IAdvancedCategoryArrow second = dictionary[pair.Target] as IAdvancedCategoryArrow ;
                IAdvancedCategoryArrow composition = ar.Compose(category, first);
                if (!composition.Equals(second))
                {
                    throw new CategoryException(CategoryException.NonCommutativePath, ar);
                }
            }
            Dictionary<int, IAdvancedCategoryArrow > sortedTable = new Dictionary<int, IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow ar in arrows)
            {
                int i = objects.IndexOf(ar.Target as IAdvancedCategoryObject);
                sortedTable[i] = ar;
            }
            IList<IAdvancedCategoryArrow > sortedArrows = new List<IAdvancedCategoryArrow >();
            for (int i = 0; i < sortedTable.Count; i++)
            {
                sortedArrows.Add(sortedTable[i]);
            }
            IDirectProductCategory productCategory = category as IDirectProductCategory;
            IAdvancedCategoryArrow arrowToProduct =
                productCategory.GetArrowToDirectProduct(source, limIdArrow.Source as IAdvancedCategoryObject, sortedArrows);
            IEqualizerCategory equalizerCategory = category as IEqualizerCategory;
            IAdvancedCategoryArrow res = equalizerCategory.GetArrowToEqualizer(limArrow,
                arrowToProduct, limIdArrow, limFuncArrow);
            return res;
        }

        /// <summary>
        /// Gets arrow from limit to diagram object
        /// </summary>
        /// <param name="o">The diagram object</param>
        /// <returns>The arrow</returns>
        public IAdvancedCategoryArrow GetColimArrow(IAdvancedCategoryObject o)
        {
            return colimArrows[o] as IAdvancedCategoryArrow ;
        }

        /// <summary>
        /// Limit
        /// </summary>
        public IAdvancedCategoryObject Colim
        {
            get
            {
                if (colim == null)
                {
                    CreateColim();
                }
                return colim;
            }
        }

        /// <summary>
        /// Gets arrow from colim
        /// </summary>
        /// <param name="arrows">Arrows from objects</param>
        /// <returns>Arrow from colim</returns>
        public IAdvancedCategoryArrow GetArrowFromColim(IList<IAdvancedCategoryArrow> arrows)
        {
            Dictionary<ICategoryObject, ICategoryArrow> dictionary = new Dictionary<ICategoryObject, ICategoryArrow>();
            IAdvancedCategoryObject target = null;
            foreach (IAdvancedCategoryArrow arrow in arrows)
            {
                if (target == null)
                {
                    target = arrow.Target as IAdvancedCategoryObject;
                }
                if (target != arrow.Target)
                {
                    throw new CategoryException(CategoryException.DifferentTargets,
                        new IAdvancedCategoryObject[] { target, arrow.Target as IAdvancedCategoryObject });
                }
                if (!objects.Contains(arrow.Source as IAdvancedCategoryObject))
                {
                    throw new CategoryException(ObjectOutOfDiagram, arrow.Source);
                }
                if (dictionary.ContainsKey(arrow.Source))
                {
                    throw new CategoryException(ExtraArrow, arrow);
                }
                dictionary[arrow.Source] = arrow;
            }
            foreach (object o in objects)
            {
                if (!dictionary.ContainsKey(o as ICategoryObject))
                {
                    throw new CategoryException(ArrowsShortage, o);
                }
            }
            foreach (CategoryObjectPair pair in Keys)
            {
                IAdvancedCategoryArrow ar = this[pair];
                IAdvancedCategoryArrow first = dictionary[pair.Target] as IAdvancedCategoryArrow ;
                IAdvancedCategoryArrow second = dictionary[pair.Source] as IAdvancedCategoryArrow ;
                IAdvancedCategoryArrow composition = first.Compose(category, ar);
                if (!composition.Equals(second))
                {
                    throw new CategoryException(CategoryException.NonCommutativePath, ar);
                }
            }
            Dictionary<int, IAdvancedCategoryArrow > sortedTable = new Dictionary<int, IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow ar in arrows)
            {
                int i = objects.IndexOf(ar.Source as IAdvancedCategoryObject);
                sortedTable[i] = ar;
            }
            IList<IAdvancedCategoryArrow > sortedArrows = new List<IAdvancedCategoryArrow >();
            for (int i = 0; i < sortedTable.Count; i++)
            {
                sortedArrows.Add(sortedTable[i]);
            }
            IDirectSumCategory sumCategory = category as IDirectSumCategory;
            IAdvancedCategoryArrow arrowFromSum =
                sumCategory.GetArrowFromDirectSum(target, colimIdArrow.Target as IAdvancedCategoryObject, sortedArrows);
            ICoequalizerCategory coequalizerCategory = category as ICoequalizerCategory;
            IAdvancedCategoryArrow res = coequalizerCategory.GetArrowFromCoequalizer(colimArrow,
                arrowFromSum, colimIdArrow, colimFuncArrow);
            return res;
        }


        /// <summary>
        /// Creates limit
        /// </summary>
        private void CreateLim()
        {
            if (!(category is IDirectProductCategory))
            {
                throw new CategoryException(CategoryException.DirectProductNotSupported);
            }
            if (!(category is IEqualizerCategory))
            {
                throw new CategoryException(CategoryException.EqualizerNotSupported);
            }
            IDirectProductCategory productCategory = category as IDirectProductCategory;
            IList<IAdvancedCategoryArrow > firstArrows = new List<IAdvancedCategoryArrow >();
            IAdvancedCategoryObject firstProduct = productCategory.GetDirectProduct(objects, firstArrows);
            IList<IAdvancedCategoryObject> endObjects = new List<IAdvancedCategoryObject>();
            foreach (CategoryObjectPair o in arrows.Keys)
            {
                IAdvancedCategoryArrow a = arrows[o] as IAdvancedCategoryArrow ;
                endObjects.Add(a.Target as IAdvancedCategoryObject);
            }
            IList<IAdvancedCategoryArrow > secondArrows = new List<IAdvancedCategoryArrow >();
            IAdvancedCategoryObject secondProduct = productCategory.GetDirectProduct(endObjects, secondArrows);
            limIdArrows = new List<IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow tar in secondArrows)
            {
                IAdvancedCategoryObject t = tar.Target as IAdvancedCategoryObject;
                foreach (IAdvancedCategoryArrow proj in firstArrows)
                {
                    if (proj.Target == t)
                    {
                        limIdArrows.Add(proj);
                        break;
                    }
                }
            }
            limIdArrow = productCategory.GetArrowToDirectProduct(firstProduct, secondProduct, limIdArrows);
            limFuncArrows = new List<IAdvancedCategoryArrow >();
            foreach (CategoryObjectPair o in arrows.Keys)
            {
                IAdvancedCategoryArrow tar = this[o];
                foreach (IAdvancedCategoryArrow proj in firstArrows)
                {
                    if (proj.Target == tar.Source)
                    {
                        IAdvancedCategoryArrow ar = tar.Compose(category, proj);
                        limFuncArrows.Add(ar);
                        break;
                    }
                }
            }
            limFuncArrow = productCategory.GetArrowToDirectProduct(firstProduct, secondProduct, limFuncArrows);
            IEqualizerCategory equalizerCategory = category as IEqualizerCategory;
            limArrow = equalizerCategory.GetEqualizer(limIdArrow, limFuncArrow);
            lim = limArrow.Source as IAdvancedCategoryObject;
            limArrows = new Dictionary<IAdvancedCategoryObject, IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow proj in firstArrows)
            {
                IAdvancedCategoryObject t = proj.Target as IAdvancedCategoryObject;
                IAdvancedCategoryArrow ar = proj.Compose(category, limArrow);
                limArrows[t] = ar;
            }
        }


        /// <summary>
        /// Creates limit
        /// </summary>
        private void CreateColim()
        {
            if (!(category is IDirectSumCategory))
            {
                throw new CategoryException(CategoryException.DirectSumNotSupported);
            }
            if (!(category is IEqualizerCategory))
            {
                throw new CategoryException(CategoryException.CoequalizerNotSupported);
            }
            IDirectSumCategory sumCategory = category as IDirectSumCategory;
            IList<IAdvancedCategoryArrow > firstArrows = new List<IAdvancedCategoryArrow >();
            IAdvancedCategoryObject firstSum = sumCategory.GetDirectSum(objects, firstArrows);
            IList<IAdvancedCategoryObject> beginObjects = new List<IAdvancedCategoryObject>();
            foreach (CategoryObjectPair o in arrows.Keys)
            {
                IAdvancedCategoryArrow a = arrows[o];
                beginObjects.Add(a.Source as IAdvancedCategoryObject);
            }
            IList<IAdvancedCategoryArrow > secondArrows = new List<IAdvancedCategoryArrow >();
            IAdvancedCategoryObject secondSum = sumCategory.GetDirectSum(beginObjects, secondArrows);
            colimIdArrows = new List<IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow sar in secondArrows)
            {
                IAdvancedCategoryObject s = sar.Source as IAdvancedCategoryObject;
                foreach (IAdvancedCategoryArrow proj in firstArrows)
                {
                    if (proj.Source == s)
                    {
                        colimIdArrows.Add(proj);
                        break;
                    }
                }
            }
            colimIdArrow = sumCategory.GetArrowFromDirectSum(firstSum, secondSum, colimIdArrows);
            colimFuncArrows = new List<IAdvancedCategoryArrow >();
            foreach (CategoryObjectPair o in arrows.Keys)
            {
                IAdvancedCategoryArrow sar = this[o];
                foreach (IAdvancedCategoryArrow proj in firstArrows)
                {
                    if (proj.Source == sar.Target)
                    {
                        IAdvancedCategoryArrow ar = proj.Compose(category, sar);
                        colimFuncArrows.Add(ar);
                        break;
                    }
                }
            }
            colimFuncArrow = sumCategory.GetArrowFromDirectSum(firstSum, secondSum, colimFuncArrows);
            ICoequalizerCategory coequalizerCategory = category as ICoequalizerCategory;
            colimArrow = coequalizerCategory.GetCoequalizer(colimIdArrow, colimFuncArrow);
            colim = colimArrow.Target as IAdvancedCategoryObject;
            colimArrows = new Dictionary<IAdvancedCategoryObject, IAdvancedCategoryArrow >();
            foreach (IAdvancedCategoryArrow proj in firstArrows)
            {
                IAdvancedCategoryObject s = proj.Source as IAdvancedCategoryObject;
                IAdvancedCategoryArrow ar = colimArrow.Compose(category, proj);
                colimArrows[s] = ar;
            }
        }


        /// <summary>
        /// Gets paths
        /// </summary>
        /// <param name="v">Root object</param>
        /// <param name="ob">Current object</param>
        private void GetPaths(DigraphVertex v, DigraphVertex ob)
        {
            CategoryObjectPair pair = new CategoryObjectPair(v.Object as IAdvancedCategoryObject,
                ob.Object as IAdvancedCategoryObject);
            IAdvancedCategoryArrow theArrow = this[pair];
            foreach (DigraphEdge edge in ob.OutcomingEdges)
            {
                DigraphVertex vo = edge.Target;
                IAdvancedCategoryArrow ar = edge.Object as IAdvancedCategoryArrow ;
                CategoryObjectPair p = new CategoryObjectPair(v.Object as IAdvancedCategoryObject, ar.Target);
                IAdvancedCategoryArrow newArrow = ar.Compose(category, theArrow);
                if (arrows.ContainsKey(p))
                {
                    IAdvancedCategoryArrow prev = this[p];
                    IAdvancedCategoryArrow comp = ar.Compose(category, theArrow);
                    if (!prev.Equals(newArrow))
                    {
                        throw new CategoryException(CategoryException.NonCommutativePath);
                    }
                    continue;
                }
                arrows[p] = newArrow;
                IList<IAdvancedCategoryArrow> s = 
                    sources[p.Source as IAdvancedCategoryObject] as IList<IAdvancedCategoryArrow>;
                s.Add(newArrow);
                IList<IAdvancedCategoryArrow> t = 
                    targets[p.Target as IAdvancedCategoryObject] as IList<IAdvancedCategoryArrow>;
                t.Add(newArrow);
                GetPaths(v, vo);
            }
        }
    }
}
