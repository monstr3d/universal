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

 
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="data">Data</param>
        public DatabaseInterface(IUser user, IDatabaseInterface data)
        {
            this.user = user;
            this.data = data;
        }

 
        /// <summary>
        /// Get root nodes
        /// </summary>
        /// <param name="ext">Extensions</param>
        /// <returns>Root nodes</returns>
        public IDirectory[] GetRoots(string[] ext)
        {
            return data.GetRoots(user.Login, user.Password, user.Key, ext);
        }

        /// <summary>
        /// Refreshes itself
        /// </summary>
        /// <param name="ext">Extensions</param>
        public void Refresh(string[] ext)
        {
            data.Refresh(user.Login, user.Password, user.Key, ext);
        }

        /// <summary>
        /// Gets data
        /// </summary>
        /// <param name="id">Id of data</param>
        /// <param name="ext">Extension of data</param>
        /// <returns>The data</returns>
        public virtual byte[] GetData(string id, ref string ext)
        {
            return data.GetData(user.Login, user.Password, user.Key, id, ref ext);
        }


        /// <summary>
        /// Gets items of database
        /// </summary>
        /// <param name="extension">Extension of items</param>
        /// <returns>Table of items</returns>
        public IDictionary<object, object> GetItems(string extension)
        {
            return data.GetItems(user.Login, user.Password, user.Key, extension);
        }
    }
}