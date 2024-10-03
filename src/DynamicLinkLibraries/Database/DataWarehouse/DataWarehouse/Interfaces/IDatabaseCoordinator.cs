using System;
using System.Collections.Generic;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Database coordinator
    /// </summary>
    public interface IDatabaseCoordinator
    {
        /// <summary>
        /// Finds database
        /// </summary>
        /// <param name="name">Database name</param>
        /// <returns>Database interface</returns>
        IDatabaseInterface this[string name]
        {
            get;
        }

        /// <summary>
        /// Creates database
        /// </summary>
        /// <param name="name">Database name</param>
        /// <returns>True in success and false otherwise</returns>
        bool Create(string name);
    }
}
