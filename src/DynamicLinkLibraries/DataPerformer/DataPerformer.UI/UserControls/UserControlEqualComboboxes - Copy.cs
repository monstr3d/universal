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
    public partial class UserControlEqualComboboxes : UserControl
    {

        internal ComboBox[] Boxes;

        public UserControlEqualComboboxes()
        {
            InitializeComponent();
            Boxes = new ComboBox[] { comboBoxLeft, comboBoxRight };
        }

        private void UserControlEqualComboboxes_Resize(object sender, EventArgs e)
        {
            int w = (Width - 6) / 2;
            panelLeft.Width = w;
            panelRight.Width = w;
        }

        internal void Select(string left, string right)
        {
            selectCombo(comboBoxLeft, left);
            selectCombo(comboBoxRight, right);
        }

        internal string[] Texts
        {
            get
            {
                string[] s = { "", "" };
                for (int i = 0; i < 2; i++)
                {
                    object o = Boxes[i].SelectedItem;
                    if (o != null)
                    {
                        s[i] = o + "";
                    }
                }
                return s;
            }
        }

        void selectCombo(ComboBox box, string item)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                string s = box.Items[i] + "";
                if (s.Equals(item))
                {
                    box.SelectedIndex = i;
                    return;
                }
            }
        }


    }
}
