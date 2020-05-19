using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using BitmapConsumer;
using ImageTransformations.Forms;
using ColorUI;


namespace ImageTransformations.Labels
{
    [Serializable()]
    public partial class BitmapProviderLabel : UserControl,
        IObjectLabel, ISerializable, INonstandardLabel
    {
        #region Fields

        private IBitmapProvider provider;

        private IDesktop desktop;

        private Form form;

        private Image image;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BitmapProviderLabel(Image image)
        {
            InitializeComponent();
            this.image = image;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BitmapProviderLabel(SerializationInfo info, StreamingContext context)
            : this(null)
        {
            try
            {
                image = info.GetValue("Image", typeof(Image)) as Image;
            }
            catch (Exception)
            {
                image = ResourceImage.SourceBitmap.ToBitmap();
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Image", image, typeof(Image));
        }

        #endregion

        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return provider as ICategoryObject;
            }
            set
            {
                provider = value.GetObject<IBitmapProvider>();
                Image im = provider.ToImage();
                if (im != null)
                {
                    image = im;
                }
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get { return this.GetRootLabel().Name; }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get
            {
                if (provider == null)
                {
                    return "";
                }
                return provider.GetType().FullName;
            }
        }


        void INamedComponent.Remove()
        {
        }

        int INamedComponent.X
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        int INamedComponent.Y
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        IDesktop INamedComponent.Desktop
        {
            get
            {
                if (desktop == null)
                {
                    desktop = this.GetRootLabel().Desktop;
                }
                return desktop;
            }
            set
            {
            }
        }

        int INamedComponent.Ord
        {
            get
            {
                INamedComponent nc = this;
                Control c = nc.Desktop as Control;
                return c.Controls.GetChildIndex(this);
            }
        }


        INamedComponent INamedComponent.Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new Exception("You should not set parent to UI component");
            }
        }

        public INamedComponent GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }

        string INamedComponent.GetName(IDesktop desktop)
        {
            return PureObjectLabel.GetName(this, desktop);
        }

        string INamedComponent.RootName
        {
            get
            {
                INamedComponent nc = this;
                return nc.GetName(nc.Desktop.Root);
            }
        }

        INamedComponent INamedComponent.Root
        {
            get { return PureObjectLabel.GetRoot(this); }
        }


        INamedComponent INamedComponent.GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }


        #endregion

        #region Create form members


        /// <summary>
        /// Initialization
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Resize
        /// </summary>
        new public void Resize()
        {
        }


        /// <summary>
        /// Creates Form
        /// </summary>
        public void CreateForm()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    return;
                }
            }
            if (provider is SourceBitmap)
            {
                form = new FormSourceBitmap(this);
                return;
            }
            if (provider is BitmapTransformer)
            {
                form = new FormBitmapTransformer(this);
                return;
            }
            if (provider is MapTransformation)
            {
                form = new FormMapTransform(this);
                return;
            }
            if (provider is DataPicture)
            {
                form = new FormDataPicture(this);
            }
        }

        /// <summary>
        /// Form
        /// </summary>
        public object Form
        {
            get
            {
                if (form != null)
                {
                    if (form.IsDisposed)
                    {
                        form = null;
                    }
                }
                return form;
            }
        }

        /// <summary>
        /// Image
        /// </summary>
        public object Image
        {
            get
            {
                return image;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public void Post()
        {
        }



        #endregion

        #region Event Handlers

        private void BitmapProviderLabel_Paint(object sender, PaintEventArgs e)
        {
            if (provider == null)
            {
                return;
            }
            Bitmap bmp = provider.Bitmap;
            if (bmp == null)
            {
                return;
            }
            float bw = (float)bmp.Width;
            float bh = (float)bmp.Height;
            float cw = (float)Width;
            float ch = (float)Height;
            float rw = cw / bw;
            float rh = ch / bh;
            float delta = 0;
            Graphics g = e.Graphics;
            RectangleF srcRect = new RectangleF(0, 0, bmp.Width, bmp.Height);
            if (rw > rh)
            {
                delta = rw - rh;
                float dx = (delta * cw / 2);
                RectangleF destRect = new RectangleF(dx, 0, Width - 2 * dx, Height);
                if ((destRect.Width > 0) & (destRect.Height > 0))
                {
                    g.DrawImage(bmp, destRect, srcRect, GraphicsUnit.Pixel);
                }
                return;
            }
            delta = rh - rw;
            float dy = (delta * cw / 2);
            RectangleF destRectY = new RectangleF(0, dy, Width, Height - 2 * dy);
            g.DrawImage(bmp, destRectY, srcRect, GraphicsUnit.Pixel);
        }

        private void BitmapProviderLabel_Resize(object sender, EventArgs e)
        {
            Refresh();
        }

        #endregion

    }
}
