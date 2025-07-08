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
    /// User control for coordinate color editor
    /// </summary>
    public partial class UserControlCoordColor : UserControl
    {

        private ComboBox[] boxes;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCoordColor()
        {
            InitializeComponent();
            userControlCoordinates.TextWidth = userControlColors.TextWidth;
        }


        /// <summary>
        /// Width of text
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int TextWidth
        {
            get
            {
                return userControlColors.TextWidth;
            }
            set
            {
            }
        
        }

        internal ComboBox[] Boxes
        {
            get
            {
                if (boxes == null)
                {
                    List<ComboBox> l = new List<ComboBox>();
                    l.AddRange(userControlCoordinates.Boxes);
                    l.AddRange(userControlColors.Boxes);
                    boxes = l.ToArray();
                }
                return boxes;
            }
        }
    }
}
