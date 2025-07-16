using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BitmapConsumer;


namespace ImageTransformations
{
    public partial class PanelBitmap : Control
    {
        private IBitmapDrawing drawing;
        Bitmap bmp;
        public PanelBitmap()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBitmapDrawing Drawing
        {
            get
            {
                return drawing;
            }
            set
            {
                bmp = null;
                drawing = value;
                init();
            }
        }

        public void ForceRefresh()
        {
            if (drawing == null | bmp == null)
            {
                return;
            }
            drawing.Draw(bmp);
            Refresh();
        }


        void createBitmap()
        {
            if (Width < 1 | Height < 1)
            {
                return;
            }
            bmp = new Bitmap(Width, Height);
            if (drawing != null)
            {
                drawing.Draw(bmp);
            }
        }


        void init()
        {
            if (bmp == null)
            {
                createBitmap();
                return;
            }
            if (bmp.Width != Width | bmp.Height != Height)
            {
                createBitmap();
            }
        }


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            init();
            if (bmp == null)
            {
                return;
            }
            pe.Graphics.DrawImage(bmp, 0, 0);
        }

        private void PanelBitmap_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
