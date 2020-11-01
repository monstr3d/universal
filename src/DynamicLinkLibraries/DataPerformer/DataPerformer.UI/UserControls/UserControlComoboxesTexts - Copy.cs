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
    public partial class UserControlComoboxesTexts : UserControl
    {

        internal List<UserControlComboboxTexts> Children = new List<UserControlComboboxTexts>();

        public UserControlComoboxesTexts()
        {
            InitializeComponent();
        }

        internal int Count
        {
            get
            {
                return Children.Count;
            }
            set
            {
                if (Children.Count == value)
                {
                    return;
                }
                panelCenter.Controls.Clear();
                Children.Clear();
                int y = 0;
                for (int i = 0; i < value; i++)
                {
                    UserControlComboboxTexts c = new UserControlComboboxTexts();
                    Children.Add(c);
                    c.Width = panelCenter.Width - 10;
                    c.Left = 0;
                    c.Top = y;
                    panelCenter.Controls.Add(c);
                    y += c.Height;
                }
            }
        }

        private void panelCenter_Resize(object sender, EventArgs e)
        {
            foreach (UserControlComboboxTexts c in Children)
            {
                c.Width = panelCenter.Width - 10;
            }
        }
    }
}
