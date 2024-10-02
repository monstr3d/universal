using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Object with children
    /// </summary>
    public interface IChildrenObject
    {
        /// <summary>
        /// Children
        /// </summary>
        IAssociatedObject[] Children
        {
            get;
        }
    }
}
