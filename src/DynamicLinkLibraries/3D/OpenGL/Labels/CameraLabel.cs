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
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using InterfaceOpenGL.Forms;
using Motion6D;



namespace InterfaceOpenGL.Labels
{
    [Serializable()]
    public partial class CameraLabel : UserControl,
        IObjectLabel, IRedraw, ISerializable, IBlocking, INonstandardLabel, IStartStop
    {

        #region Fields
        

        OpenGLCamera camera;

        string name = "";

  

        private Forms.FormCamera form;

        private bool blocked = true;
 
        #endregion

        #region Ctor

        internal CameraLabel()
        {
            InitializeComponent();
            init();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arguments">Values of arguments</param>
        /// <param name="function">Values of function</param>
        protected CameraLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IRedraw Members

        void IRedraw.Redraw()
        {
            camera.Child.UpdateImage();
        }

        #endregion

        #region IBlocking Members

        bool IBlocking.IsBlocked
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
                    pan.Paint -= paintC;
                    return;
                }
                pan.Paint += paintC;
            }
        }

        #endregion
 
        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return camera;
            }
            set
            {
                if (!(value is OpenGLCamera))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                camera = value as OpenGLCamera;
                camera.Child = new OpenGLCamera();
            }
        }

        #endregion

        #region INamedComponent Members

        string INamedComponent.Name
        {
            get { return name; }
        }

        string INamedComponent.Kind
        {
            get { return ""; }
        }

        string INamedComponent.Type
        {
            get { return "InterfaceOpenGL.OpenGLCamera"; }
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
        new public void Resize()
        {
        }


        public void CreateForm()
        {
            form = new Forms.FormCamera(camera);
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
                return ResourceImage.Camera;
            }
        }


        public void Post()
        {
            Graphics g = Graphics;
            camera.Child.Graphics = g;
            // this.Size = new Size(camera.LabelWidth, camera.LabelHeight);
            resize();
            camera.Child.Prepare(g, 0);
            base.Resize += ResizeLabel;
        }



        #endregion

        #region Members

        void init()
        {
            pan.BackColor = Color.FromArgb(0, 0, 255);

        }
 

        internal Graphics Graphics
        {
            get
            {
                return Graphics.FromHwnd(pan.Handle);
            }
        }

 



        private void ResizeLabel(object sender, EventArgs e)
        {
            resize();
        }

        

 
        private void paintC(object c, PaintEventArgs e)
        {
            INamedComponent nc = this;
            PanelDesktop d = nc.Desktop as PanelDesktop;
            if (d.IsMoved)
            {
                return;
            }
            lock (this)
            {
                if (form != null)
                {
                    if (!form.IsDisposed)
                    {
                        return;
                    }
                }
                camera.Child.UpdateImage();
            }
        }

 
  
        private void resize()
        {
             OpenGLCamera c = camera.Child;
             c.Set(pan.Width, pan.Height);
         }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            if (form == null)
            {
                return;
            }
            if (form.IsDisposed)
            {
                return;
            }
            IStartStop ss = form;
          //  ss.Action(type, start);
        }

        #endregion
    }
}
