using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Pair of category objects
    /// </summary>
    public class CategoryObjectPair
    {
        /// <summary>
        /// Source
        /// </summary>
        private ICategoryObject source;

        /// <summary>
        /// Target
        /// </summary>
        private ICategoryObject target;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        public CategoryObjectPair(ICategoryObject source, ICategoryObject target)
        {
            this.source = source;
            this.target = target;
        }

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return source.GetHashCode() | target.GetHashCode();
        }

        /// <summary>
        /// Equaulity function
        /// </summary>
        /// <param name="o">Object to compare</param>
        /// <returns>True if o equals this object and false otherwise</returns>
        public override bool Equals(object o)
        {
            CategoryObjectPair p = o as CategoryObjectPair;
            return (p.source == source) & (p.target == target);
        }

        /// <summary>
        /// Source
        /// </summary>
        public ICategoryObject Source
        {
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Target
        /// </summary>
        public ICategoryObject Target
        {
            get
            {
                return target;
            }
        }
    }
}
