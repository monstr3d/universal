using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;


using Motion6D.Interfaces;

using WpfInterface.Objects3D;
using NamedTree;


namespace WpfInterface.UI.UserControls
{
    public partial class UserControlDeformed : UserControl
    {
        #region Fields

        private ComboBox[] comboIn;
        private ComboBox[] comboOut;
        private IObjectLabel label;
        private DeformedWpfShape shape;
        private IDesktop d;
        private string fn;

        #endregion

        #region Ctor

        public UserControlDeformed()
        {
            InitializeComponent();
        }


        #endregion

        #region Members


        internal void Set(IPosition p, IVisible v)
        {
            IAssociatedObject ao = p as IAssociatedObject;
            label = ao.Object as IObjectLabel;
            d = label.Desktop;
            shape = v as DeformedWpfShape;
            comboIn = new ComboBox[] { comboBox1, comboBox2, comboBox3 };
            comboOut = new ComboBox[] { comboBox4, comboBox5, comboBox6 };
            fill();
            select();
        }

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
                        WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, "Abscent");
                        return;
                    }
                    string sss = cbbb.SelectedItem + "";
                    if (sss.Length == 0)
                    {
                        WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, "Abscent");
                        return;
                    }
                    ss[j] = sss;
                }
            }
            shape.Data = d;
        }

        bool save(string filename)
        {
            string s = shape.Xaml;
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(s);
            sw.Flush();
            sw.Close();
            this.filename = filename;
            return true;
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


        #endregion

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            save();
        }


    }
}
