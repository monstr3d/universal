using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object with characteristic length
    /// </summary>
    public interface ILength
    {
        /// <summary>
        /// Characteristic length
        /// </summary>
        double Length
        {
            get;
            set;
        }
    }
}
