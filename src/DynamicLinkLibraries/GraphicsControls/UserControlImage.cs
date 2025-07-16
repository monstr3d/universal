using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsControls
{
    /// <summary>
    /// Image user control
    /// </summary>
    public partial class UserControlImage : UserControl
    {
        #region Fields

        bool isScaled = false;

        Image im;

        Image image;

        event Action<bool> changeScale = (bool b) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlImage()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Image
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image Image
        {
            set
            {
                image = value;
                pictureBoxImage.Image = OwnImage;
            }
        }

        /// <summary>
        /// "is scaled" sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsScaled
        {
            get
            {
                return isScaled;
            }
            set
            {
                if (value == isScaled)
                {
                    return;
                }
                isScaled = value;
                changeScale(value);
                isScaledToolStripMenuItem.Checked = value;
                /*if (image == null)
                {
                    return;
                }
                pictureBoxImage.Image = OwnImage;*/
                pictureBoxImage.Visible = !value;
                if (value)
                {
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Change scale event
        /// </summary>
        public event Action<bool> ChangeScale
        {
            add { changeScale += value; }
            remove { changeScale -= value; }
        }

        #endregion

        #region Private Members

        private Image OwnImage
        {
            get
            {
                if (!isScaled)
                {
                    return image;
                }
                if (im == null)
                {
                    CreateImage();
                }
                return im;
            }
        }

        private void resize()
        {
            if (!isScaled)
            {
                return;
            }
            CreateImage();
            pictureBoxImage.Image = im;
        }

        private void CreateImage()
        {
            if (image == null | !isScaled)
            {
                return;
            }
            int w = pictureBoxImage.Width;
            int h = pictureBoxImage.Height;
            float bw = (float)image.Width;
            float bh = (float)image.Height;
            float cw = (float)pictureBoxImage.Width;
            float ch = (float)pictureBoxImage.Height;
            float rw = cw / bw;
            float rh = ch / bh;
            float delta = 0;
            if (im == null)
            {
                im = new Bitmap(w, h);
            }
            else
            {
                if ((im.Width == w) & (im.Height == h))
                {
                    return;
                }

            }
            using (Graphics g = Graphics.FromImage(im))
            {
                RectangleF srcRect = new RectangleF(0, 0, image.Width, image.Height);
                if (rw > rh)
                {
                    delta = rw - rh;
                    float dx = (delta * cw / 2);
                    RectangleF destRect = new RectangleF(dx, 0, Width - 2 * dx, Height);
                    if ((destRect.Width > 0) & (destRect.Height > 0))
                    {
                        g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    return;
                }
                delta = rh - rw;
                float dy = (delta * cw / 2);
                RectangleF destRectY = new RectangleF(0, dy, Width, Height - 2 * dy);
                g.DrawImage(image, destRectY, srcRect, GraphicsUnit.Pixel);
            }
        }

        #endregion

        #region Event handlers

        private void pictureBoxImage_Resize(object sender, EventArgs e)
        {
            resize();
        }

        #endregion

        #region Event handlers

        private void Check(object sender, EventArgs e)
        {
            IsScaled = isScaledToolStripMenuItem.Checked;
        }

        #endregion

        private void UserControlImage_Paint(object sender, PaintEventArgs e)
        {
            if (image == null)
            {
                return;
            }
            if (!isScaled)
            {
                return;
            }
            this.DrawImage(image, e.Graphics);
        }
    }
}
