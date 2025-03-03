using System;
using System.Windows.Forms;
using System.IO;

using PhysicalField;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Motion6D.UI
{
    /// <summary>
    /// Editor of properties of spherical magnetic field
    /// </summary>
    public partial class FormSphericalMagnnetic : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private SphericalFieldWrapper field;

        private FormSphericalMagnnetic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of object</param>
        /// <param name="field">Magnetic field</param>
        public FormSphericalMagnnetic(IObjectLabel label, SphericalFieldWrapper field)
            : this()
        {
            this.label = label;
            this.field = field;
            refresh();
            Text = "";
            IUpdatableForm f = this;
            f.UpdateFormUI();
        }





        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogField.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            load(openFileDialogField.FileName);
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }


        void load(string filename)
        {
            try
            {
                int n = (int)numericUpDownN.Value;
                double[][] g = new double[n + 1][];
                double[][] h = new double[n + 1][];
                for (int i = 0; i < g.Length; i++)
                {
                    g[i] = new double[i + 1];
                    h[i] = new double[i + 1];
                }
                char[] sep = "\t ".ToCharArray();

                StreamReader r = new StreamReader(filename);

                r.ReadLine();

                while (true)
                {
                    string str = r.ReadLine();
                    if (str.Contains("9999999999999999"))
                    {
                        break;
                    }
                    string[] s = str.Split(sep);
                    int k = 0;
                    int i = 0, j = 0;
                    for (; k < s.Length; k++)
                    {
                        string ss = s[k];
                        if (ss.Length != 0)
                        {
                            i = Int32.Parse(ss);
                            break;
                        }
                    }
                    ++k;
                    for (; k < s.Length; k++)
                    {
                        string ss = s[k];
                        if (ss.Length != 0)
                        {
                            j = Int32.Parse(ss);
                            break;
                        }
                    }
                    ++k;
                    for (; k < s.Length; k++)
                    {
                        string ss = s[k];
                        if (ss.Length != 0)
                        {
                            g[i][j] = tr(ss);
                            break;
                        }
                    }
                    ++k;
                    for (; k < s.Length; k++)
                    {
                        string ss = s[k];
                        if (ss.Length != 0)
                        {
                            h[i][j] = tr(ss);
                            break;
                        }
                    }
                }
                field.Set(n, n, g, h, radius);
                refresh();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }

        }


        private double radius
        {
            get
            {
                return Double.Parse(textBoxR.Text);
            }
        }

        static double tr(string s)
        {
            string ss = (s + "").Trim();
            ss = ss.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (ss[0] == '.')
            {
                ss = '0' + ss;
            }
            return Double.Parse(ss);
        }



        private void refresh()
        {
            textBoxR.Text = field.Radius + "";
            numericUpDownM.Value = field.M;
            numericUpDownN.Value = field.N;
            //double[] C = field.Cnm;
            //double[] S = field.Snm;
            int k = 0;
            int n0 = field.N;

            double[][] c = field.Cos;
            double[][] s = field.Sin;

            listViewHarm.Items.Clear();
            if (c == null)
            {
                return;
            }
            for (int i = 0; i <= n0; i++)
            {
          /*      int p = i;
                if (p < 2)
                {
                    p = 2;
                }*/
                for (int j = 0; j <= i; j++)
                {
                    ListViewItem it = new ListViewItem(new string[] { i + "", j + "", c[i][j] + "", s[i][j] + "" });
                    listViewHarm.Items.Add(it);
                    ++k;
                }
            }
        }

       private void buttonAccept_Click(object sender, EventArgs e)
        {
           /* field.N0 = (int)numericUpDownN.Value;
            field.NK = (int)numericUpDownM.Value;
            refresh();*/
        }


    }
}