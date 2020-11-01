using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Control proxy
    /// </summary>
    public interface IControl
    {
        Color BackColor
        {
            get;
        }

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
