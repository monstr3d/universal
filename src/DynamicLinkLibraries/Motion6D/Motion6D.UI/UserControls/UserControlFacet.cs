using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// Editor of facet
    /// </summary>
    public partial class UserControlFacet : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFacet()
        {
            InitializeComponent();
        }

        internal ComboBox[] Coord
        {
            get
            {
                return userControlComboboxListCoord.Boxes.ToArray();
            }
        }
    }
}
