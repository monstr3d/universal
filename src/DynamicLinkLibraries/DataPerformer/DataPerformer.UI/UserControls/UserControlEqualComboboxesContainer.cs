using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataPerformer.UI.UserControls
{
    public partial class UserControlEqualComboboxesContainer : UserControl
    {
        internal List<UserControlEqualComboboxes> Children = new List<UserControlEqualComboboxes>();

        public UserControlEqualComboboxesContainer()
        {
            InitializeComponent();
        }

        internal ComboBox[][] Boxes
        {
            get
            {
                List<ComboBox> l1 = new List<ComboBox>();
                List<ComboBox> l2 = new List<ComboBox>();
                foreach (UserControlEqualComboboxes uc in Children)
                {
                   ComboBox[] cb = uc.Boxes;
                    l1.Add(cb[0]);
                    l2.Add(cb[1]);
                }
                return new ComboBox[][] { l1.ToArray(), l2.ToArray() };
            }
        }

        internal List<string>[] Texts
        {
            get
            {
                List<string>[] l = new List<string>[] { new List<string>(), new List<string>() };
                foreach (UserControlEqualComboboxes uc in Children)
                {
                    string[] s = uc.Texts;
                    for (int i = 0; i < 2; i++)
                    {
                        l[i].Add(s[i]);
                    }
                }
                return l;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int Number
        {
            set
            {
                if (value == Children.Count)
                {
                    return;
                }
                Children.Clear();
                panelCenter.Controls.Clear();
                int y = 0;
                for (int i = 0; i < value; i++)
                {
                    UserControlEqualComboboxes c = new UserControlEqualComboboxes();
                    c.Top = y;
                    c.Left = 0;
                    y += c.Height;
                    Children.Add(c);
                    c.Width = panelCenter.Width - 2;
                    panelCenter.Controls.Add(c);
                }
            }
        }

        private void panelCenter_Resize(object sender, EventArgs e)
        {
            foreach (Control c in Children)
            {
                c.Width = panelCenter.Width - 2;
            }
        }
    }
}
