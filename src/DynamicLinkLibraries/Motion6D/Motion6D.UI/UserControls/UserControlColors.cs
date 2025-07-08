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
    /// Editor of colors
    /// </summary>
    public partial class UserControlColors : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlColors()
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
                return userControlComboboxListLeftColor.TextWidth;
            }
            set
            {
                userControlComboboxListLeftColor.TextWidth = value;
            }
        }

        internal ComboBox[] Boxes
        {
            get
            {
                return userControlComboboxListLeftColor.Boxes.ToArray();
            }
        }
    }
}