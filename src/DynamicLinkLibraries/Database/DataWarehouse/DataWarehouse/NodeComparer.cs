using System.Collections.Generic;

using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse
{
    /// <summary>
    /// Comparer of nodes
    /// </summary>
    public class NodeComparer : IComparer<INode>, IEqualityComparer<INode>, 
        IComparer<IDirectory>, IComparer<ILeaf>
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly NodeComparer Singleton = new NodeComparer();

        #endregion

        #region Ctor

        private NodeComparer()
        {
        }

        #endregion

        #region IComparer<INode> Members

        int IComparer<INode>.Compare(INode x, INode y)
        {
            var xx = x as INamed;
            var yy = y as INamed;
            return xx.Name.CompareTo(yy.Name); 
        }

        #endregion

        #region IEqualityComparer<INode> Members

        bool IEqualityComparer<INode>.Equals(INode x, INode y)
        {
            return x.Name.Equals(y.Name);
        }

        int IEqualityComparer<INode>.GetHashCode(INode obj)
        {
            return 0;
        }

        #endregion

        #region IComparer<ILeaf> Members

        int IComparer<ILeaf>.Compare(ILeaf x, ILeaf y)
        {
            IComparer<INode> c = this;
            return c.Compare(x, y);
        }

        #endregion

        #region IComparer<IDirectory> Members

        int IComparer<IDirectory>.Compare(IDirectory x, IDirectory y)
        {
            IComparer<INode> c = this;
            return c.Compare(x, y);
        }

        #endregion
    }
}
