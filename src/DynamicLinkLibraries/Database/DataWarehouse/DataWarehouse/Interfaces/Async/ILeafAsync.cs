using System;
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

        /// <summary>
        /// UpdatesData
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns></returns>
        Task<byte[]> UpdateDataAcync(byte[] data);

        /// <summary>
        /// Update data 
        /// </summary>
        event Action<object> OnUpdateData;

    }
}
