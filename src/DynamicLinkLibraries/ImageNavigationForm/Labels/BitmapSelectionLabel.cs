using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;

using Diagram.UI;
using CategoryTheory;
using Regression;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;


namespace ImageNavigation.Labels
{
    [Serializable()]
    public partial class BitmapSelectionLabel : UserControl,
        IObjectLabel, ISerializable, IUpdatableSelection, Diagram.UI.Interfaces.IBlocking, INonstandardLabel
    {

        #region Fields


        private Forms.FormBitmapSelection form;

        private BitmapSelection selection;

        private Bitmap bmp;

        private bool blocked = true;

        #endregion

        #region Ctor

        public BitmapSelectionLabel()
        {
            InitializeComponent();
        }

        private BitmapSelectionLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
        }

        #endregion

 
        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return selection;
            }
            set
            {
                if (!(value is BitmapSelection))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                selection = value as BitmapSelection;
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get { return ""; }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return "ImageNavigation.BitmapSelection"; }
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
                return this.GetRootLabel().Desktop;
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
        public new void Resize()
        {
        }


        public void CreateForm()
        {
            form = new Forms.FormBitmapSelection(this);
        }

        public object Form
        {
            get
            {
                return form;
            }
        }

        public object Image
        {
            get
            {
                return ResourceImage.Contour;
            }
        }


        public void Post()
        {
            base.Resize += ResizeLabel;
        }



        #endregion

        #region IUpdatableSelection Members

        void IUpdatableSelection.UpdateSelection()
        {
            resize();
            panel.Refresh();
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    form.Update();
                }
            }
        }

        #endregion

        #region Diagram.UI.Interfaces.IBlocking Members

        bool Diagram.UI.Interfaces.IBlocking.IsBlocked
        {
            get
            {
                return blocked;
            }
            set
            {
                if (blocked == value)
                {
                    return;
                }
                blocked = value;
                if (blocked)
                {
                    panel.Paint -= paintC;
                    return;
                }
                if (bmp == null)
                {
                    resize();
                }
                panel.Paint += paintC;
                Refresh();
            }
        }

        #endregion

        #region Members

        private void paintC(object c, PaintEventArgs e)
        {
            INamedComponent nc = this;
            PanelDesktop d = nc.Desktop as PanelDesktop;
            if (d.IsMoved)
            {
                return;
            }
            if (bmp == null)
            {
                return;
            }
            e.Graphics.DrawImage(bmp, 0, 0);
        }


        private void resize()
        {
            if (blocked)
            {
                return;
            }
            bmp = selection.CreateBitmap(panel.Width, panel.Height);
        }


        private void ResizeLabel(object sender, EventArgs e)
        {
            resize();
        }



        #endregion


    }
}
