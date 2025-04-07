using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace GeneralNode
{
    /// <summary>
    /// Common interface of all nodes
    /// </summary>
    public interface INode
    {

        /// <summary>
        /// The id
        /// </summary>
        object Id
        {
            get;
        }

        /// <summary>
        /// The parent id
        /// </summary>
        object ParentId
        {
            get;
        }

        /// <summary>
        /// Adds child node
        /// </summary>
        /// <param name="node">Child node</param>
        void Add(INode node);

        /// <summary>
        /// Checks whether this node contais node
        /// </summary>
        /// <param name="node">Node to check</param>
        /// <returns>True if contains and false otherwise</returns>
        bool Contains(INode node);

        /// <summary>
        /// Associated object
        /// </summary>
        object Object
        {
            get;
            set;
        }

        /// <summary>
        /// Parent
        /// </summary>
        INode Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Children count
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// The n - th child
        /// </summary>
        INode this[int n]
        {
            get;
        }

        /// <summary>
        /// Sorts nodes
        /// </summary>
        /// <param name="comparer">Comparer</param>
        void Sort(IComparer<INode> comparer);

        /// <summary>
        /// Sorts all nodes
        /// </summary>
        /// <param name="comparer">Comparer</param>
        void SortAll(IComparer<INode> comparer);

        /// <summary>
        /// This node and all its childdren
        /// </summary>
        ICollection<INode> All
        {
            get;
        }

        /// <summary>
        /// children
        /// </summary>
        ICollection<INode> Children
        {
            get;
        }


        /// <summary>
        /// Gets child order
        /// </summary>
        /// <param name="node">child node</param>
        /// <returns></returns>
        int GetChildOrder(INode node);

        /// <summary>
        /// Order of node
        /// </summary>
        int Order
        {
            get;
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void Remove();

        /// <summary>
        /// Removes node
        /// </summary>
        /// <param name="node">Removed node</param>
        void Remove(INode node);


    }
}
