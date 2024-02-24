using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// The factory of category object
    /// </summary>
    public interface IObjectFactory
    {
        /// <summary>
        /// Names of objects
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Object by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The object</returns>
        ICategoryObject this[string name]
        {
            get;
        }
    }

}
