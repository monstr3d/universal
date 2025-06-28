using System.Collections.Generic;

using DataWarehouse.Interfaces;


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

        /// <summary>
        /// Data
        /// </summary>
        IDatabaseInterface data;

        public DatabaseInterface(IDatabaseInterface data)
        {
            this.data = data;
        }

        /// <summary>
        /// Get root nodes
        /// </summary>
        /// <param name="ext">Extensions</param>
        /// <returns>Root nodes</returns>
        public IDirectory[] GetRoots(string[] ext)
        {
            return data.GetRoots( ext);
        }

    }
}