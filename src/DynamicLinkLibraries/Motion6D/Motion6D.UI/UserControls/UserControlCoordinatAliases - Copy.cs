using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Motion6D.UI.Factory;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// Editor of coordinat aliases
    /// </summary>
    public partial class UserControlCoordinatAliases : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCoordinatAliases()
        {
            InitializeComponent();
        }

        internal ComboBox[] Coord
        {
            get
            {
                return userControlComboboxList.Boxes.ToArray();
            }
        }
    }
}
