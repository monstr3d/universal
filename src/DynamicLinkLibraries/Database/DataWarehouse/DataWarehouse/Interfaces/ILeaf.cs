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
        event Action OnDeleteItself;

        /// <summary>
        /// Change itself event
        /// </summary>
        event Action<ILeaf> OnChangeItself;
   }
}
