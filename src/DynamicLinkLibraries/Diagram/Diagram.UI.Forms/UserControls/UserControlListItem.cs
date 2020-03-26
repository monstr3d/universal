using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Item of list
    /// </summary>
    public partial class UserControlListItem : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlListItem()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Label
        /// </summary>
        public string Label
        {
            get
            {
                return labelText.Text;
            }
            set
            {
                labelText.Text = value;
            }
        }

        /// <summary>
        /// Box
        /// </summary>
        public ComboBox Box
        {
            get
            {
                return comboBox;
            }
        }
    }
}
