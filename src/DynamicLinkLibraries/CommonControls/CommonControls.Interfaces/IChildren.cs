using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Object with children
    /// </summary>
    public interface IChildren
    {
        /// <summary>
        /// Children
        /// </summary>
        object[] Children
        {
            get;
        }
    }
}
