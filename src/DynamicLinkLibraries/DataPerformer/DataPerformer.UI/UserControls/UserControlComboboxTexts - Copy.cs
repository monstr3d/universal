using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlComboboxTexts : UserControl
    {
        public UserControlComboboxTexts()
        {
            InitializeComponent();
        }

        internal ComboBox ComboBox
        {
            get
            {
                return comboBox;
            }
        }

        internal TextBox TextBox
        {
            get
            {
                return textBox;
            }
        }

    }
}
