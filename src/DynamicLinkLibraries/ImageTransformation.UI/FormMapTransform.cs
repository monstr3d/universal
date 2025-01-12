using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Diagram.UI.Utils;


using DataPerformer.Portable;

using BitmapConsumer;


namespace ImageTransformations
{
    public partial class FormMapTransform : Form, IUpdatableForm, IRedraw
    {
        private Panel pan = null;
        private MapTransformation trans;
        private IObjectLabel label;
        private Point point = new Point(0, 0);
        private ComboBox[] comboIn;
        private ComboBox[] comboOut;
        
        private FormMapTransform()
        {
            InitializeComponent();
            comboIn = new ComboBox[] { comboBoxXIn, comboBoxYIn };
            comboOut = new ComboBox[] { comboBoxXOut, comboBoxYOut };
        }

        public FormMapTransform(IObjectLabel label)
            : this()
        {
            this.label = label;
            ResourceService.Resources.LoadControlResources(this, ImageTransformations.Utils.ControlUtilites.Resources);
            trans = label.Object as MapTransformation;
            pan = panelDesktopCenter;
            UpdateFormUI();
            fillCombo();
            selectCombo();
            textBoxWidth.Text = trans.Width + "";
            textBoxHeight.Text = trans.Height + "";
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



        private void fillCombo()
        {
            Double a = 0;
            IList<string> al = trans.GetAliases(a);
            comboIn.FillCombo(al);
            IList<string> m = trans.GetAllMeasurements(a);
            comboOut.FillCombo(m);
        }

        private void selectCombo()
        {
            string[] al = trans.Input;
            for (int i = 0; i < al.Length; i++)
            {
                Diagram.UI.Utils.ControlUtilites.SelectCombo(comboIn[i], al[i]);
            }
            string[] m = trans.Output;
            for (int i = 0; i < m.Length; i++)
            {
                Diagram.UI.Utils.ControlUtilites.SelectCombo(comboOut[i], m[i]);
            }
        }

        private void acceptPar()
        {
            string[] instr = new string[2];
            for (int i = 0; i < comboIn.Length; i++)
            {
                object it = comboIn[i].SelectedItem;
                if (it == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Undefined parameter");
                    return;
                }
                instr[i] = it + "";
            }
            string[] outstr = new string[2];
            for (int i = 0; i < comboOut.Length; i++)
            {
                object it = comboOut[i].SelectedItem;
                if (it == null)
                {
                    WindowsExtensions.ControlExtensions.ShowMessageBoxModal("Undefined parameter");
                    return;
                }
                outstr[i] = it + "";
            }
            trans.Set(instr, outstr);
        }


        private void save(string filename)
        {
  /*          BitmapConsumer.IBitmapProvider p = camera;
            Bitmap bmp = p.Bitmap;
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);*/
        }

        private void saveAs()
        {
            if (saveFileDialogBmp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            save(saveFileDialogBmp.FileName);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAs();
        }


        #region IRedraw Members

        void IRedraw.Redraw()
        {
            IBitmapConsumer cons = trans;
            cons.Process();
            pan.Refresh();
        }

        #endregion

        private void buttonStart_Click(object sender, EventArgs e)
        {
       /*     IProcess p = Motion6D.Camera.Process;
            if (p != null)
            {
                p.Start();
            }*/
        }

        private void buttonApplyCoord_Click(object sender, EventArgs e)
        {
            acceptPar();
            IRedraw r = this;
            r.Redraw();
        }

        private void panelDesktopCenter_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            IBitmapProvider p = trans;
            Image im = p.Bitmap;
            if (im != null)
            {
                e.Graphics.DrawImage(im, point);
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            IRedraw r = this;
            r.Redraw();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            try
            {
                int w = Int32.Parse(textBoxWidth.Text);
                int h = Int32.Parse(textBoxHeight.Text);
                trans.Set(w, h);
                refresh();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }
    }
}