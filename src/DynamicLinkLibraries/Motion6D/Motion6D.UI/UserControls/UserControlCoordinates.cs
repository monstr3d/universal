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
    /// User control for editor of coordinates
    /// </summary>
    public partial class UserControlCoordinates : UserControl
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCoordinates()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Width of text
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int TextWidth
        {
            get
            {
                return userControlComboboxListLeft.TextWidth;
            }
            set
            {
                userControlComboboxListLeft.TextWidth = value;
            }
        }

        internal ComboBox[] Boxes
        {
            get
            {
                return userControlComboboxListLeft.Boxes.ToArray();
            }
        }

    }
}
