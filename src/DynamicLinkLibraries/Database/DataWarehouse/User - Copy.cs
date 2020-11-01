using System;
using System.Collections.Generic;
using System.Text;
using DataWarehouse.Interfaces;

namespace DataWarehouse
{
    /// <summary>
    /// Standard user
    /// </summary>
    public class User : IUser
    {
        #region Fields

        string login;
        string password;

        object key;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        public User(string login, string password, object key)
        {
            this.login = login;
            this.password = password;
            this.key = key;
        }

        #endregion

        #region IUser Members

        string IUser.Login
        {
            get { return login; }
        }

        string IUser.Password
        {
            get { return password; }
        }

        object IUser.Key
        {
            get { return key; }
        }

        #endregion
    }
}
