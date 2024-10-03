using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Object with propery decorator
    /// </summary>
    public interface IPropertySubstitute
    {
        /// <summary>
        /// Property decorator
        /// </summary>
        object PropertySubstitute
        {
            get;
        }
    }
}
