using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Diagram.UI;

namespace DataPerformer.UI.UserControls
{

    /// <summary>
    /// User control for regression alias editor
    /// </summary>
    public partial class RegressionAliasUserControl : UserControl
    {
        ComboBox cb = new ComboBox();
        TextBox dispEdi = new TextBox();
        TextBox deltaEdi = new TextBox();

        private RegressionAliasUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">List of alias names</param>
        public RegressionAliasUserControl(List<string> list)
            : this()
        {
            List<string> lc = new List<string>(list);
            lc.Sort();
            foreach (string s in lc)
            {
                cb.Items.Add(s);
            }
            Label l = new Label();
            l.Text = PureDesktop.GetResourceString("Parameter");
            l.Left = 10;
            l.Top = 10;
            Controls.Add(l);
            cb.Left = l.Left;
            cb.Top = 10 + l.Top + l.Height;
            Controls.Add(cb);
            l = new Label();
            l.Text = PureDesktop.GetResourceString("Dispersion");
            l.Left = cb.Left;
            l.Top = cb.Top + cb.Height + 10;
            Controls.Add(l);
            dispEdi.Top = l.Top + l.Height + 10;
            dispEdi.Left = l.Left;
            dispEdi.Text = "0";
            Controls.Add(dispEdi);
            l = new Label();
            l.Text = PureDesktop.GetResourceString("Delta");
            l.Left = cb.Left;
            l.Top = dispEdi.Top + dispEdi.Height + 10;
            Controls.Add(l);
            deltaEdi.Top = l.Top + l.Height + 10;
            deltaEdi.Left = l.Left;
            deltaEdi.Text = "1e-5";
            Controls.Add(deltaEdi);
            Height = deltaEdi.Top + deltaEdi.Height + 10;
            this.LoadResources();
        }

        /// <summary>
        /// Creates necessary objects
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] Object
        {
            get
            {
                object[] o = new object[3];
                o[0] = cb.SelectedItem.ToString();
                o[1] = Double.Parse(dispEdi.Text);
                o[2] = Double.Parse(deltaEdi.Text);
                return o;
            }
            set
            {
                string n = value[0] as string;
                double disp = (double)value[1];
                double delta = (double)value[2];
                dispEdi.Text = disp + "";
                deltaEdi.Text = delta + "";
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    if (n.Equals(cb.Items[i].ToString()))
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }

           
        }

        private void RegressionAliasUserControl_Resize(object sender, EventArgs e)
        {
            cb.Width = Width - 2 * cb.Left;
        }
    }
}
