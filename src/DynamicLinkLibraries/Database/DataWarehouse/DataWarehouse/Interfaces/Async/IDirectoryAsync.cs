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
        /// Adds a directory
        /// </summary>
        /// <param name="directory">Prototype</param>
        /// <returns>THe added directory</returns>
         Task<IDirectoryAsync> AddAsync(IDirectory directory);

        /// <summary>
        /// Adds a leaf
        /// </summary>
        /// <param name="leaf">Prototype</param>
        /// <returns>THe added leaf</returns>
        Task<ILeafAsync> AddAsync(ILeaf leaf);

        /// <summary>
        /// Updates Name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The name</returns>
        Task<string> UpdateNameAsync(string name);

        /// <summary>
        /// Updates Description
        /// </summary>
        /// <param name="name">The description</param>
        /// <returns>The description</returns>
        Task<string> UpdateDescriptionAsync(string description);

    }
}
