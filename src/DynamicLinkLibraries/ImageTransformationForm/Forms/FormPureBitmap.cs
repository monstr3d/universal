using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPerformer.Interfaces;
using Event.Interfaces;

namespace ImageTransformations.Forms
{
    public partial class FormPureBitmap : Form, IRealtimeUpdate
    {
        IMeasurement measurement;

        Bitmap bitmap;

        public FormPureBitmap()
        {
            InitializeComponent();
        }


        internal FormPureBitmap(IMeasurement measurement) : this()
        {
            this.measurement = measurement;
        }


        new void Update()
        {
            object o = measurement.Parameter();
            if (o == bitmap)
            {
                return;
            }
            bitmap = o as Bitmap;
            userControlBitmapMeasurement.Bitmap = bitmap;
        }

        Action IRealtimeUpdate.Update
        {
            get
            {
                return Update;
            }
        }

        event Action IRealtimeUpdate.OnUpdate
        {
            add
            {
            }

            remove
            {
            }
        }

        void SaveBitmap()
        {
            if (bitmap == null)
            {
                return;
            }
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveBitmap();
        }
    }
}
