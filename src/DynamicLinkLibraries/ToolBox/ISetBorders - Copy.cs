using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToolBox
{
    /// <summary>
    /// Object that sets borders
    /// </summary>
    public interface ISetBorders
    {
        /// <summary>
        /// Gets corner control
        /// </summary>
        /// <param name="i">Control number</param>
        /// <returns>Corner control</returns>
        ControlPanel this[int i]
        {
            get;
        }

        /// <summary>
        /// Deactivates itself
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Moved pictute
        /// </summary>
        Control MovePicture
        {
            get;
        }

        /// <summary>
        /// The "is empty" sign
        /// </summary>
        bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// The "is active" sign
        /// </summary>
        bool IsActive
        {
            get;
        }
    }
}
