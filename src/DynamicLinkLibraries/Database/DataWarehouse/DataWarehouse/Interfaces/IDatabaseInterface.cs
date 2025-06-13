using System.Collections.Generic;


namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Interface for working with database
    /// </summary>
    public interface IDatabaseInterface
    {

        /// <summary>
        /// Gets roots nodes
        /// </summary>
        /// <param name="extensions">Extension</param>
        /// <returns>Root nodes</returns>
        IDirectory[] GetRoots(params string[] extensions);


    }
}
