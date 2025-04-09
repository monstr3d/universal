
using CategoryTheory;
using ErrorHandler;


namespace MathGraph
{
    /// <summary>
    /// Path of digraph
    /// </summary>
    public class DigraphPath
    {
        /// <summary>
        /// Edges of path
        /// </summary>
        private List<DigraphEdge> edges = new List<DigraphEdge>();

        /// <summary>
        /// Auxiliary edge
        /// </summary>
        private DigraphEdge prev = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="edges">Array of edges</param>
        /// <param name="inverse">The "inverse" sign</param>
        public DigraphPath(List<DigraphEdge> edges, bool inverse)
        {
            if (inverse)
            {
                for (int i = edges.Count - 1; i >= 0; i--)
                {
                    object o = edges[i];
                    if (!(o is DigraphEdge))
                    {
                        throw new OwnException("Path should contains digraph edges only");
                    }
                    DigraphEdge e = o as DigraphEdge;
                    if (prev != null)
                    {
                        if (prev.Target != e.Source)
                        {
                            throw new OwnException("Path edges are not connected");
                        }
                    }
                    prev = e;
                    this.edges.Add(e);
                }
            }
            else
            {
                for (int i = 0; i < edges.Count; i++)
                {
                    object o = edges[i];
                    if (!(o is DigraphEdge))
                    {
                        throw new OwnException("Path should contains digraph edges only");
                    }
                    DigraphEdge e = o as DigraphEdge;
                    if (prev != null)
                    {
                        if (prev.Target != e.Source)
                        {
                            throw new OwnException("Path edges are not connected");
                        }
                    }
                    prev = e;
                    this.edges.Add(e);
                }
            }
        }

        /// <summary>
        /// Count of edges
        /// </summary>
        public int Count
        {
            get
            {
                return edges.Count;
            }
        }


        /// <summary>
        /// Access to i - th edge
        /// </summary>
        public DigraphEdge this[int i]
        {
            get
            {
                return edges[i] as DigraphEdge;
            }
        }

        /// <summary>
        /// Overriden "GetHashCode" function
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return edges.Count;
        }


        /// <summary>
        /// Checks whether this path contains the edge
        /// </summary>
        /// <param name="edge">The edge to check</param>
        /// <returns>True if path contains edge and false otherwise</returns>
        public bool Contains(DigraphEdge edge)
        {
            return edges.Contains(edge);
        }

        /// <summary>
        /// Checks wheter path contains associated object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>True if path contains object and false otherwise</returns>
        public bool ContainsObject(object o)
        {
            foreach (DigraphEdge edge in edges)
            {
                if (edge.Object == o)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Overriden "Equals" function
        /// </summary>
        /// <param name="o">Object to compare</param>
        /// <returns>True if o equals this object and false otherwise</returns>
        public override bool Equals(object o)
        {
            if (!(o is DigraphPath))
            {
                throw new OwnException("You cannot compare digraph with another type object");
            }
            DigraphPath p = o as DigraphPath;
            if (p.edges.Count != edges.Count)
            {
                return false;
            }
            for (int i = 0; i < edges.Count; i++)
            {
                if (p.edges[i] != edges[i])
                {
                    return false;
                }
            }
            return true;
        }
/*
        /// <summary>
        /// Arrow of path
        /// </summary>
        public IAdvancedCategoryArrow Arrow
        {
            get
            {
                int n = Count;
                IAdvancedCategoryArrow arrow = this[n - 1].Object as IAdvancedCategoryArrow;
                for (int i = n - 2; i >= 0; i++)
                {
                    IAdvancedCategoryArrow a = this[i].Object as IAdvancedCategoryArrow;
                    arrow = a.Compose(null, arrow);
                }
                return arrow;
            }
        }

        /// <summary>
        /// Gets arrow of this path
        /// </summary>
        /// <param name="category">Arrow category</param>
        /// <returns>The arrow</returns>
        public ICategoryArrow GetArrow(ICategory category)
        {
            int n = Count;
            IAdvancedCategoryArrow arrow = this[n - 1].Object as IAdvancedCategoryArrow;
            for (int i = n - 2; i >= 0; i++)
            {
                IAdvancedCategoryArrow a = this[i].Object as IAdvancedCategoryArrow;
                arrow = a.Compose(category, arrow);
            }
            return arrow;
        }
*/

        /// <summary>
        /// Path source
        /// </summary>
        public DigraphVertex Source
        {
            get
            {
                DigraphEdge e = edges[0] as DigraphEdge;
                return e.Source;
            }
        }

        /// <summary>
        /// Path target
        /// </summary>
        public DigraphVertex Target
        {
            get
            {
                DigraphEdge e = edges[edges.Count - 1] as DigraphEdge;
                return e.Target;
            }
        }
    }
}
