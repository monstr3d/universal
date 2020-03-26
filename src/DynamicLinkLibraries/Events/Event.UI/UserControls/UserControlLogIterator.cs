using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event.Portable;

namespace Event.UI.UserControls
{
    /// <summary>
    /// Editor of log directory
    /// </summary>
    public partial class UserControlLogIterator : UserControl
    {
        public UserControlLogIterator()
        {
            InitializeComponent();
        }

        internal LogIterator Iterator
        {
            set
            {
                checkBox.Checked = value.IsDirectoryOriented;
                checkBox.CheckStateChanged += (object sender, EventArgs e) =>
                {
                    value.IsDirectoryOriented = checkBox.Checked;
                };
            }
        }

    }
}
