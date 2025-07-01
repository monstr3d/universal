using System.Threading.Tasks;

namespace DataWarehouse.Interfaces.Async
{
    /// <summary>
    /// Async leaf
    /// </summary>
    public interface ILeafAsync
    {
        /// <summary>
        /// Removes itself 
        /// </summary>
        /// <returns>Task</returns>
        Task<bool> RemoveItselfAsync();

    }
}
