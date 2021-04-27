using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;

using Motion6D.Interfaces;


namespace InterfaceOpenGL
{
    public partial class FormDeformed : Form, IUpdatableForm
    {
        private ComboBox[] comboIn;
        private ComboBox[] comboOut;
        private IObjectLabel label;
        private DeformedShapeGL shape;
        private IDesktop d;
        private string fn;

        private FormDeformed()
        {
            InitializeComponent();
        }


        internal FormDeformed(IPosition p, IVisible v)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, InterfaceOpenGL.Utils.ControlUtilites.Resources);
            IAssociatedObject ao = p as IAssociatedObject;
            label = ao.Object as IObjectLabel;
            d = label.Desktop;
            UpdateFormUI();
            shape = v as DeformedShapeGL;
            comboIn = new ComboBox[] { comboBox1, comboBox2, comboBox3 };
            comboOut = new ComboBox[] { comboBox4, comboBox5, comboBox6 };
            fill();
            select();
        }


        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

        private string filename
        {
            set
            {
                fn = value;
            }
        }

        void fill()
        {
            Double a = 0;
            List<string> l = new List<string>();
            shape.GetAliases(d, l, a);
            comboIn.FillCombo(l);
            IList<string> lo = shape.GetAllMeasurements(d, a);
            comboOut.FillCombo(lo);
        }

        void select()
        {
            string[][] d = shape.Data;
            ComboBox[][] cb = new ComboBox[][] { comboIn, comboOut };
            for (int i = 0; i < cb.Length; i++)
            {
                ComboBox[] cbb = cb[i];
                string[] ss = d[i];
                for (int j = 0; j < cbb.Length; j++)
                {
                    string sss = ss[j];
                    ComboBox cbbb = cbb[j];
                    cbbb.SelectCombo(sss);
                }
            }
        }

        void accept()
        {
            string[][] d = new string[2][];
            ComboBox[][] cb = new ComboBox[][] { comboIn, comboOut };
            for (int i = 0; i < cb.Length; i++)
            {
                ComboBox[] cbb = cb[i];
                string[] ss = new string[3];
                d[i] = ss;
                for (int j = 0; j < cbb.Length; j++)
                {
                    ComboBox cbbb = cbb[j];
                    if (cbbb.SelectedItem == null)
                    {
                        MessageBox.Show(this, "Abscent");
                        return;
                    }
                    string sss = cbbb.SelectedItem + "";
                    if (sss.Length == 0)
                    {
                        MessageBox.Show(this, "Abscent");
                        return;
                    }
                    ss[j] = sss;
                }
            }
            shape.Data = d;
        }

        bool save(string filename)
        {
            Stream stream = File.OpenWrite(filename);
            bool b = shape.Save(stream);
            if (b)
            {
                this.filename = filename;
            }
            stream.Close();
            return b;
        }

        bool saveAs()
        {
            if (saveFileDialogFigure.ShowDialog(this) != DialogResult.OK)
            {
                return false;
            }
            return save(saveFileDialogFigure.FileName);
        }

        bool save()
        {
           return saveAs();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }
    }
}