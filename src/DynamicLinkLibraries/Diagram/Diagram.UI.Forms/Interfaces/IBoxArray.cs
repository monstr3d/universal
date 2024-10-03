using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Array of comboboxes
    /// </summary>
    public interface IBoxArray
    {
        /// <summary>
        /// The boxes
        /// </summary>
        ComboBox[] Boxes
        {
            get;
        }
    }
}
