using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Motion6D;
using Motion6D.Interfaces;



namespace InterfaceOpenGL.Labels
{
    [Serializable()]
    public partial class UserControl3DShape : UserControl,
        IObjectLabel, ISerializable, INonstandardLabel
    {

        #region Fields
        private ShapeGL shape;
        private IPosition position;

        private Motion6D.UI.Forms.FormFieldShape form;

        #endregion

        #region Ctor


        private UserControl3DShape()
        {
            InitializeComponent();
            pictureBoxSh.Image = ResourceImage.Cube.ToBitmap();
        }

        internal UserControl3DShape(IPosition position, ShapeGL shape)
            : this()
        {
            ResourceService.Resources.LoadControlResources(this, 
                InterfaceOpenGL.Utils.ControlUtilites.Resources);
            if (shape != null)
            {
                this.shape = shape;
                this.position = position;
                if (shape is Shape3DField)
                {
                    openFileDialogFigure.Filter = "OpenGL Binary Field files |*.glf";
                }
                showFilename();
            }
        }

        protected UserControl3DShape(SerializationInfo info, StreamingContext context)
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
                return shape;
            }
            set
            {
                shape = value.GetObject<ShapeGL>();
                if (value == null)
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                if (shape is Shape3DField)
                {
                    openFileDialogFigure.Filter = "OpenGL Binary Field files |*.glf";
                }
                showFilename();
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get
            {
                IObjectLabel l = this.GetParentLablel();
                if (l == null)
                {
                    return "";
                }
                return l.Name;
             }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return "Motion6D.SerializablePosition"; }
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

        public object Image
        {
            get
            {
                return ResourceImage.Cube.ToBitmap();
            }
        }

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


        public void CreateForm()
        {
            Shape3DField s3d = shape.GetObject<Shape3DField>();
            if (s3d == null)
            {
                return;
            }
            form = new Motion6D.UI.Forms.FormFieldShape(this);
        }

        public object Form
        {
            get
            {
                return form;
            }
        }

  

        public void Post()
        {
        }



        #endregion


        #region Specific Members

        private void open()
        {
            try
            {
                openFileDialogFigure.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "Shapes";
                if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                string fn = Path.GetFileName(openFileDialogFigure.FileName);
                shape.Filename = fn;
                showFilename();
            }
            catch (Exception)
            {
            }
        }

        private void showFilename()
        {
            labelFilename.Text = shape.Filename;
        }

        #endregion

        #region Event Handlers

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            open();
        }

        #endregion

    }
}
