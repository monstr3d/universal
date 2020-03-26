using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motion6D.Drawing.Interfaces
{
    /// <summary>
    /// Control proxy
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// Width
        /// </summary>
        int Width
        {
            get;
        }

        /// <summary>
        /// Height
        /// </summary>
        int Height
        {
            get;
        }
    }
}
