using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

using Event.Interfaces;
using NamedTree;

namespace Event.UI.UserControls
{
    /// <summary>
    /// Editor of event block
    /// </summary>
    public partial class UserControlEventBlock : UserControl
    {
        #region Fields

        IEventBlock block;

        List<ComboBox> lc = new List<ComboBox>();

        bool b = true;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlEventBlock()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event block
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICategoryObject Block
        {
            get
            {
                return block as ICategoryObject;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                IEventBlock b = value.GetObject<IEventBlock>();
                if (b == null)
                {
                    return;
                }
                block = b;
                Set();
            }
        }

        #endregion

        #region Private Members

        private void Set()
        {
            string[] names = block.Names;
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            numericUpDown.Value = names.Length;
        }

        #endregion

        #region Event handlers

        private void UserControlEventBlock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!b)
            {
                return;
            }
            List<string> l = new List<string>();
            int n = (int)numericUpDown.Value;
            for (int i = 0; i < n; i++)
            {
                object o = userControlComboboxList.Boxes[i].SelectedItem;
                if (o == null)
                {
                    return;
                }
                l.Add(o + "");
            }
            block.Names = l.ToArray();
        }

        void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            string[] names = block.Names;
            int n = (int)numericUpDown.Value;
            if (n == 0)
            {
                userControlComboboxList.Visible = false;
                return;
            }
            userControlComboboxList.Visible = true;
            userControlComboboxList.Count = (int)numericUpDown.Value;
            ICategoryObject co = Block;
            List<string> l = new List<string>();
            IDesktop desktop = co.GetRootDesktop();
            desktop.ForEach((IEvent ev) =>
                {
                    l.Add(co.GetRelativeName(ev as IAssociatedObject));
                });

            b = false;
            for (int i = 0; i < n; i++)
            {
                ComboBox cb = userControlComboboxList.Boxes[i];
                cb.Items.Clear();
                cb.FillCombo(l);
                if (i < names.Length)
                {
                    cb.SelectCombo(names[i]);
                }
                if (!lc.Contains(cb))
                {
                    cb.SelectedIndexChanged += UserControlEventBlock_SelectedIndexChanged;
                    lc.Add(cb);
                }
                b = true;
            }
        }

        #endregion
    }
}
