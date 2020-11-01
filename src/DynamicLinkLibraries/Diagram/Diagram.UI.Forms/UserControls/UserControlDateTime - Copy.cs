using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// User control for date time with milliseconds
    /// </summary>
    public partial class UserControlDateTime : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserControlDateTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Date Time
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                DateTime dt = dateTimePicker.Value;
                dt = dt.AddMilliseconds((int)numericUpDown.Value);
                return dt;
            }
            set
            {
                dateTimePicker.Value = value;
                numericUpDown.Value = value.Millisecond;
            }
        }
    }
}
