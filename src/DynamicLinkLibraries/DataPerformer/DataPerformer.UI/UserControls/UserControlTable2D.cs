using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Diagram.UI;

using DataPerformer;
using DataPerformer.UI;
using ErrorHandler;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// 2D Table user control
    /// </summary>
    public partial class UserControlTable2D : UserControl
    {

        #region Fields

        /// <summary>
        /// The table
        /// </summary>
        protected Table2D table;

        /// <summary>
        /// Bitmap for table
        /// </summary>
        protected Bitmap bmp;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlTable2D()
        {
            InitializeComponent();
            CreateBitmap();
        }

        #endregion

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Table2D Table
        {
            get
            {
                return table;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                table = value;
                DrawBitmap();
                Refresh();
            }
        }

        internal void Open()
        {
            if (openFileDialogTable2D.ShowDialog(this.ParentForm) != DialogResult.OK)
            {
                return;
            }
            Stream stream = null;
            try
            {
                stream = File.OpenRead(openFileDialogTable2D.FileName);
                table.Load(stream);
                Refresh();
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            if (stream != null)
            {
                stream.Close();
            }
        }

        internal void Save()
        {
            Stream stream = null;
            if (saveFileDialogTable2D.ShowDialog(this.ParentForm) != DialogResult.OK)
            {
                return;
            }
            try
            {
                stream = File.OpenWrite(saveFileDialogTable2D.FileName);
                table.Save(stream);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            if (stream != null)
            {
                stream.Close();
            }
        }

        private void CreateBitmap()
        {
            bmp = new Bitmap(Width, Height);
        }

         private void DrawBitmap()
         {
            Graphics g = Graphics.FromImage(bmp);
            if (table != null)
            {
                StaticExtensionDataPerformerUI.Draw(table, g, 0, 0, Width, Height);
            }
        }

        private void UserControlTable2D_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void UserControlTable2D_Resize(object sender, EventArgs e)
        {
            CreateBitmap();
            DrawBitmap();
            Refresh();
        }
        /// <summary>
        /// Draws two parameter table
        /// </summary>
        /// <param name="t">The table to draw</param>
        /// <param name="g">Graphics to draw</param>
        /// <param name="x">Left corner coordinate</param>
        /// <param name="y">Top corner coordinate</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public static void Draw(Table2D t, Graphics g, int x, int y, int w, int h)
        {
            if (t == null)
            {
                return;
            }
            double[,] b = t.Bounds;
            double[] e = t.Extremums;
            int xc = t.XCount;
            int yc = t.YCount;
            double ww = w;
            double hh = h;
            bool bx = ww > hh;
            double coeff = 1 / (1 + Math.Sqrt(0.5));
            double delta = (bx ? ww : hh) * coeff;
            double w1 = w - delta;
            double h1 = h - delta;
            double vScale = 0;
            if (e[1] != e[0])
            {
                vScale = h1 / (e[1] - e[0]);
            }
            double yScale = 0;
            if (b[1, 1] != b[1, 0])
            {
                yScale = delta / (b[1, 1] - b[1, 0]);
            }
            double xScale = 0;
            if (t.XCount > 1)
            {
                if (b[0, 1] != b[0, 0])
                {
                    xScale = w1 / ((2 * Math.Sqrt(0.5)) * (b[0, 1] - b[0, 0]));
                }
            }
            Pen pen = new Pen(Color.Magenta);
            double x0 = x + w1;
            double y0 = y + h1;
            for (int i = 0; i < t.XCount; i++)
            {
                double xx = t.GetX(i);
                double dx = xx - b[0, 0];
                double x1 = x0 - dx * xScale;
                double y1 = y0 + dx * xScale;
                float xOld = 0;
                float yOld = 0;
                for (int j = 0; j < t.YCount; j++)
                {
                    double v = t[i, j];
                    double vc = v - e[0];
                    vc = -vc * vScale;
                    vc += y1;
                    double yf = t.GetY(j);
                    yf = (yf - b[1, 0]) * yScale;
                    yf += x1;
                    float xd = (float)yf;
                    float yd = (float)vc;
                    if (j > 0)
                    {
                        g.DrawLine(pen, xOld, yOld, xd, yd);
                    }
                    xOld = xd;
                    yOld = yd;
                }
            }
        }

    }
}
