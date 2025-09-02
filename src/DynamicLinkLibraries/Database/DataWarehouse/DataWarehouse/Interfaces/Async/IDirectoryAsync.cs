using DataWarehouse.Classes;
using System.Threading;
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
        Task LoadChildren(CancellationToken cancellationToken);

        /// <summary>
        /// Loads leaves
        /// </summary>
        /// <returns></returns>
        Task LoadLeaves(CancellationToken cancellationToken);
        
        /// <summary>
        /// Removes itself 
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> RemoveItselfAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Adds a directory
        /// </summary>
        /// <param name="directory">Prototype</param>
        /// <returns>THe added directory</returns>
         Task<IDirectoryAsync> AddAsync(IDirectory directory, CancellationToken cancellationToken);

        /// <summary>
        /// Adds a leaf
        /// </summary>
        /// <param name="leaf">Prototype</param>
        /// <returns>THe added leaf</returns>
        Task<ILeafAsync> AddAsync(ILeaf leaf, CancellationToken cancellationToken);

        /// <summary>
        /// Updates Name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The name</returns>
        Task<string> UpdateNameAsync(string name, CancellationToken cancellationToken);

        /// <summary>
        /// Updates Description
        /// </summary>
        /// <param name="name">The description</param>
        /// <returns>The description</returns>
        Task<string> UpdateDescriptionAsync(string description, CancellationToken cancellationToken);

        /// <summary>
        /// SyncModde
        /// </summary>
        SyncMode SyncMode { get; }

  
    }
}
