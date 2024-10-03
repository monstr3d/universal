using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Motion6D;
using Diagram.UI;
using CategoryTheory;
using Diagram.UI.Labels;

namespace Motion6D.UI
{
    /// <summary>
    /// User control for edition of relative field properties
    /// </summary>
    public partial class UserControlRelativeField : UserControl
    {
        private RelativeField field;

        private IAssociatedObject data;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRelativeField()
        {
            InitializeComponent();
        }


        internal void Accept()
        {
            if (field.Field == null)
            {
                return;
            }
            object o = comboBoxNum.SelectedItem;
            if (o == null)
            {
                return;
            }
            int n = Int32.Parse(o + "");
            field.Number = n;

        }

        internal void Set(IAssociatedObject data, RelativeField field)
        {
            this.data = data;
            this.field = field;
            fill();
        }


        void fill()
        {
            if (field == null)
            {
                return;
            }
            if (field.Field == null)
            {
                return;
            }
            Image im = 
                (field.Field as ICategoryObject).GetImage();
            pictureBoxGrav.Image = im;
            string name =
                data.GetRelativeName(field.Field as ICategoryObject);
            labelName.Text = name;
            int[] n = field.Numbers;
            foreach (int i in n)
            {
                comboBoxNum.Items.Add(i + "");
            }
            int k = field.Number;
            if (k < 0)
            {
                return;
            }
            string sk = k + "";
            for (int i = 0; i < comboBoxNum.Items.Count; i++)
            {
                string s = comboBoxNum.Items[i] + "";
                if (s.Equals(sk))
                {
                    comboBoxNum.SelectedIndex = i;
                    break;
                }
            }

        }




    }
}
