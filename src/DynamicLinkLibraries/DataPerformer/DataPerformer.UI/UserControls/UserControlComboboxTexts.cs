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
