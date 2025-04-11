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
        IDirectory Add(string name, string description, string ext);

        /// <summary>
        /// Adds leaf
        /// </summary>
        /// <param name="name">Leaf name</param>
        /// <param name="description">Description</param>
        /// <param name="data">Data</param>
        /// <param name="ext">Extension</param>
        /// <returns>Created leaf</returns>
        ILeaf Add(string name, string description, byte[] data, string ext);

    }
}
