using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Powered object
    /// </summary>
    public interface IPowered
    {
        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IsPowered
        {
            get;
        }
 
    }
}
