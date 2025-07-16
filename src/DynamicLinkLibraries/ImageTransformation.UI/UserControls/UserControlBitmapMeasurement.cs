using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsExtensions;


namespace ImageTransformations.UserControls
{
    public partial class UserControlBitmapMeasurement : UserControl
    {

        Bitmap bmp;

        Point p = new Point(0, 0);

        public UserControlBitmapMeasurement()
        {
            InitializeComponent();
        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null)
            {
                return;
            }
            e.Graphics.DrawImage(bmp, p);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal Bitmap Bitmap
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                bmp = value;
                this.InvokeIfNeeded(() =>
                {
                    panelCenter.Refresh();
                });

            }
        }
    }
}
