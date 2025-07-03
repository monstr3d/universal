using System.Collections.Generic;
using System.Threading.Tasks;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;


namespace DataWarehouse
{

    /// <summary>
    /// Wrapper for database interface
    /// </summary>
    public class DatabaseInterface
    {
        /// <summary>
        /// User
        /// </summary>
        IUser user;

        IDirectory[] roots;
        public bool SupportsAsync { get; init; }

        /// <summary>
        /// Data
        /// </summary>
        IDatabaseInterface data;

        IDatabaseInterfaceAsync data_async;

        public DatabaseInterface(IDatabaseInterface data)
        {
            this.data = data;
            data_async = data as IDatabaseInterfaceAsync;
            SupportsAsync = data_async != null;
        }

        async public Task<IDirectoryAsync[]> GetRootsAsync(string[] ext)
        {
            var t = data_async.GetRoots(ext);
            await t;
            return t.Result;
        }

        /// <summary>
        /// Get root nodes
        /// </summary>
        /// <param name="ext">Extensions</param>
        /// <returns>Root nodes</returns>
        public IDirectory[] GetRoots(string[] ext)
        {
            if (roots == null)
            {
                roots = data.GetRoots(ext);
            }
            return roots;
        }

    }
}