using System.Collections.Generic;


namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Interface for working with database
    /// </summary>
    public interface IDatabaseInterface
    {
        /// <summary>
        /// Logins
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        void Login(string login, string password, object key);

        /// <summary>
        /// Gets roots nodes
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="extensions">Extension</param>
        /// <returns>Root nodes</returns>
        IDirectory[] GetRoots(string login, string password,  object key, string[] extensions);

        /// <summary>
        /// Refreshes itself
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="extension">Extension</param>
        void Refresh(string login, string password, object key, string[] extension);

        /// <summary>
        /// Gets data
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="id">Data id</param>
        /// <param name="extension">Extension</param>
        /// <returns>Data</returns>
        byte[] GetData(string login, string password, object key, string id,
          ref  string extension);

        /// <summary>
        /// Gets items
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="extension">Extension</param>
        /// <returns>Items dictionary</returns>
        IDictionary<object, object> GetItems(string login, string password, 
            object key, string extension);

        /// <summary>
        /// Gets Leaves
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="extension">Extension</param>
        /// <returns>Items dictionary</returns>
        IDictionary<object, object> GetLeaves(string login, string password,
            object key, string extension);

    }
}
