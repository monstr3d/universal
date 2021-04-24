using System;
using System.Collections.Generic;
using System.Text;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// User
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Login
        /// </summary>
        string Login
        {
            get;
        }

        /// <summary>
        /// Password
        /// </summary>
        string Password
        {
            get;
        }

        /// <summary>
        /// Key of user
        /// </summary>
        object Key
        {
            get;
        }
    }
}
