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
    /// User control of 6D Motion
    /// </summary>
    public partial class UserControl6D : UserControl
    {
        /// <summary>
        /// Boxes
        /// </summary>
        protected ComboBox[] boxes;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControl6D()
        {
            InitializeComponent();
            List<ComboBox> l = new List<ComboBox>();
            l.AddRange(userControlCoordinates.Boxes);
            l.AddRange(userControlQuaternion.Boxes);
            boxes = l.ToArray();
        }

        internal ComboBox[] Boxes
        {
            get
            {
                return boxes;
            }
        }

    }
}
