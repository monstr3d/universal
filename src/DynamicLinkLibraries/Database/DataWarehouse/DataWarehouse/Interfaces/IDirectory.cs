using System;

using NamedTree;


namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Directory
    /// </summary>
    public interface IDirectory : INode, IChildren<IDirectory>, IChildren<ILeaf>
    {
        /// <summary>
        /// Adds directory
        /// </summary>
        /// <param name="name">Directory name</param>
        /// <param name="description">Description</param>
        /// <param name="ext">Extension</param>
        /// <returns>Created directory</returns>
        IDirectory Add(IDirectory directory);

        /// <summary>
        /// Adds leaf
        /// </summary>
        /// <param name="name">Leaf name</param>
        /// <param name="description">Description</param>
        /// <param name="data">Data</param>
        /// <param name="ext">Extension</param>
        /// <returns>Created leaf</returns>
        ILeaf Add(ILeaf leaf);

        /// <summary>
        /// Adds child event
        /// </summary>
        event Action<object> OnAddDirectory;

        /// <summary>
        /// Delete itself event
        /// </summary>
        event Action<object> OnDeleteItself;

        /// <summary>
        /// Change itself event
        /// </summary>
        event Action<object> OnChangeItself;

        /// <summary>
        /// Add leaf event
        /// </summary>
        event Action<object> OnAddLeaf;


    }
}
