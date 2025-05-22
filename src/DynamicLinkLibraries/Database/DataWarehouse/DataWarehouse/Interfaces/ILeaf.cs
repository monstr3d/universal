using NamedTree;
using System;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Leaf
    /// </summary>
    public interface ILeaf : INode, IData
    {
        /// <summary>
        /// Delete itself event
        /// </summary>
        event Action<ILeaf> OnDeleteItself;

        /// <summary>
        /// Chande itseld evenr
        /// </summary>
        event Action<ILeaf> OnChangeItself;
   }
}
