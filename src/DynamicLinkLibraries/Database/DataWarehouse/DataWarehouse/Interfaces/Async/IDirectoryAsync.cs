using System.Collections.Generic;

using System.Threading.Tasks;

namespace DataWarehouse.Interfaces.Async
{
    /// <summary>
    /// Async directory
    /// </summary>
    public interface IDirectoryAsync
    {
        /// <summary>
        /// Loads children
        /// </summary>
        /// <returns>Task</returns>
        Task LoadChildren();

        /// <summary>
        /// Loads leaves
        /// </summary>
        /// <returns></returns>
        Task LoadLeaves();
        
        /// <summary>
        /// Removes itself 
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> RemoveItselfAsync();

        /// <summary>
        /// Adds directory
        /// </summary>
        /// <param name="name">Directory name</param>
        /// <param name="description">Description</param>
        /// <param name="ext">Extension</param>
        /// <returns>Created directory</returns>
        Task<IDirectoryAsync> Add(IDirectory directory);

    }
}
