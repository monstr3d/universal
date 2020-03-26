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
    /// User control for size editor
    /// </summary>
    public partial class UserControlCoordColorSize : UserControl
    {
        private ComboBox[] boxes;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCoordColorSize()
        {
            InitializeComponent();
            userControlComboboxListLeft.TextWidth =
                userControlCoordColor.TextWidth;
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Comboboxes
        /// </summary>
        protected ComboBox[] Boxes
        {
            get
            {
                if (boxes == null)
                {
                    List<ComboBox> l = new List<ComboBox>();
                    l.AddRange(userControlCoordColor.Boxes);
                    l.AddRange(userControlComboboxListLeft.Boxes);
                    boxes = l.ToArray();
                }
                return boxes;
            }
        }
        
    }
}
