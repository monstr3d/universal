using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataPerformer.TestInterface.UI.UserConrols
{
    public partial class UserControlSeriesTest : UserControl
    {
        public UserControlSeriesTest()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ObjectNumber
        {
            get
            {
                return (int)numericUpDown.Value;
            }
            set
            {
                numericUpDown.Value = 0;
            }
        }
    }
}
