using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;

using BitmapIndicator;
using ErrorHandler;


namespace ImageTransformations
{
    public partial class FormBitmapTransformer : Form, IUpdatableForm
    {
        private IObjectLabel label;

        private BitmapTransformer trans;

        private bool first = true;

        private ComboBox[] coord;

        private ComboBox[] colors;

        private ComboBox[, ,] extColors;

       // private static readonly string[] colstr = new string[] { "Red", "Green", "Blue" };

       // private static readonly Color[] colcol = new Color[] { Color.Red, Color.Green, Color.Blue };

        private BitmapIndicatorPerformer performer;

        private FormBitmapTransformer()
        {
            InitializeComponent();
        }

        public FormBitmapTransformer(IObjectLabel label)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, ImageTransformations.Utils.ControlUtilites.Resources);
            this.label = label;
            trans = label.Object as BitmapTransformer;
            coord = userControlComboboxListCoordinates.Boxes.ToArray();
            colors = userControlComboboxListColors.Boxes.ToArray();
            string[, ,] se = trans.ExternalColors;
            if (se != null)
            {
                if (se.Length > 0)
                {
                    numericUpDownL.Value = trans.Left;
                    numericUpDownT.Value = trans.Top;
                    numericUpDownR.Value = se.GetLength(0) - trans.Left - 1;
                    numericUpDownB.Value = se.GetLength(1) - trans.Top - 1;
                }
            }
            setNumbers();
            fill();
            select();
            performer = BitmapIndicator.Indicators.ObjectIndicator.Create(toolStripStatusLabel, null, panelImage);
            panelImage.Cursor = Cursors.Cross;
            this.UpdateFormUI();
        }

        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion


        private void accept()
        {
            try
            {
                string[] coo = ControlUtilites.GetSelectedStringArray(coord);
                string[] cc = ControlUtilites.GetSelectedStringArray(colors);
                string[, ,] ext = new string[extColors.GetLength(0), extColors.GetLength(1), 3];
                for (int i = 0; i < ext.GetLength(0); i++)
                {
                    for (int j = 0; j < ext.GetLength(1); j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            object o = extColors[i, j, k].SelectedItem;
                            if (o != null)
                            {
                                ext[i, j, k] = o + "";
                            }
                        }
                    }
                }
                bool zero = true;
                foreach (string s in ext)
                {
                    if (s != null)
                    {
                        zero = false;
                        break;
                    }
                }
                if (zero)
                {
                    ext = null;
                }
                trans.Set(ext, coo, cc, (int)numericUpDownL.Value, (int)numericUpDownT.Value);
                panelImage.Refresh();
            }
            catch (Exception e)
            {
                e.ShowError(10);
            }
        }


        private void select()
        {
            string[] scol = trans.Colors;
            ControlUtilites.SelectCombo(colors, scol);
            string[] scor = trans.Coordinates;
            ControlUtilites.SelectCombo(coord, scor);
            selectExt();
        }

        private void selectExt()
        {
            string[, ,] se = trans.ExternalColors;
            if (se == null)
            {
                return;
            }
            for (int i = 0; i < se.GetLength(0); i++)
            {
                for (int j = 0; j < se.GetLength(1); j++)
                {
                    for (int k = 0; k < se.GetLength(2); k++)
                    {
                        string s = se[i, j, k];
                        ComboBox b = extColors[i, j, k];
                        if (s != null)
                        {
                            ControlUtilites.SelectCombo(b, s);
                        }
                    }
                }
            }
        }

        private void setNumbers()
        {
            first = false;
            int l = (int)numericUpDownL.Value;
            int r = (int)numericUpDownR.Value;
            int t = (int)numericUpDownT.Value;
            int b = (int)numericUpDownB.Value;
            Double a = 0;
            List<string> al = trans.GetAliases(a);
            ArrayList list = new ArrayList(panelExt.Controls);
            foreach (Control c in list)
            {
                panelExt.Controls.Remove(c);
            }
            int w = l + r + 1;
            int h = t + b + 1;
            extColors = new ComboBox[w, h, 3];
            int y = 0;
            for (int i = 0; i < w; i++)
            {
                int ii = i - l;
                for (int j = 0; j < h; j++)
                {
                    int jj = j - t;
                    string s = "X = " + ii + "; Y = " + jj + ";";
                    Panel p = new Panel();
                    panelExt.Controls.Add(p);
                    int yy = 0;
                    p.Width = panelExt.Width - 30;
                    p.Top = y;
                    Label lab = new Label();
                    p.Controls.Add(lab);
                    lab.Text = s;
                    lab.Top = 5;
                    lab.Left = 5;
                    yy = lab.Bottom + 5;
                    Diagram.UI.UserControls.UserControlRGB uc = new Diagram.UI.UserControls.UserControlRGB();
                    ComboBox[] cb = uc.Boxes.ToArray();
                    p.Controls.Add(uc);
                    uc.Top = yy;

                    for (int k = 0; k < 3; k++)
                    {
                        extColors[i, j, k] = cb[k];
      /*                  Fill
                        Label lc = new Label();
                        lc.Top = yy;
                        lc.Left = lab.Left;
                        p.Controls.Add(lc);
                        lc.ForeColor = colcol[k];
                        lc.Text = colstr[k];
                        ComboBox cb = new ComboBox();
                        extColors[i, j, k] = cb;
                        yy = lc.Bottom + 5;
                        cb.Top = yy;
                        cb.Left = lab.Left;
                        cb.Width = p.Width - cb.Left - 10;
                        p.Controls.Add(cb);
                        yy = cb.Bottom + 5;*/
                    }
                    yy += 160;
                    p.Height = yy;
                    y = p.Bottom;
                    Panel pb = new Panel();
                    pb.Top = y;
                    pb.Height = 1;
                    pb.Width = p.Width;
                    pb.BackColor = Color.Black;
                    panelExt.Controls.Add(pb);
                    y = pb.Bottom;
                }
            }
            fillExt();
        }

        private void fillExt()
        {
            Double a = 0;
            ICollection<string> al = trans.GetAliases(a);
            foreach (ComboBox box in extColors)
            {
                box.FillCombo(al);
            }
        }

        private void fill()
        {
            Double a = 0;
            ICollection<string> al = trans.GetAliases(a);
            ControlUtilites.FillCombo(coord, al);
            ICollection<string> mea = trans.GetAllMeasurementsType(a);
            ControlUtilites.FillCombo(colors, mea);
        }

        private void save()
        {
            Bitmap b = bmp;
            if (b == null)
            {
                return;
            }
            if (saveFileDialogBmp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            b.Save(saveFileDialogBmp.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }


        private void changeBorders(object sender, EventArgs e)
        {
            if (first)
            {
                return;
            }
            setNumbers();
        }

        private void panelImage_Paint(object sender, PaintEventArgs e)
        {
            BitmapConsumer.IBitmapProvider p = trans;
            Bitmap b = p.Bitmap;
            if (b == null)
            {
                return;
            }
            performer.Bitmap = b;
            e.Graphics.DrawImage(b, 0, 0, b.Width, b.Height);
        }


        private Bitmap bmp
        {
            get
            {
                BitmapConsumer.IBitmapProvider p = trans;
                return p.Bitmap;
            }
        }

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