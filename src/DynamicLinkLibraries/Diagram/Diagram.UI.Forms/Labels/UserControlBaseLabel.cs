using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using CategoryTheory;
using Diagram.UI.Forms.Interfaces;
using Diagram.UI.Interfaces;
using ErrorHandler;
using NamedTree;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Base label for all labers
    /// </summary>
    [Serializable()]
    public abstract partial class UserControlBaseLabel : UserControl,
        ISerializable, IObjectLabel, INonstandardLabel, IEnabled, IPostLoadControl
    {
        #region Fields

        /// <summary>
        /// Child control
        /// </summary>
        protected UserControl control;

        /// <summary>
        /// Type of object
        /// </summary>
        protected Type type;

        /// <summary>
        /// Icon
        /// </summary>
        protected Image icon;

        /// <summary>
        /// Kind
        /// </summary>
        protected string kind;

        /// <summary>
        /// Desktop
        /// </summary>
        protected IDesktop desktop;

        /// <summary>
        /// Error message
        /// </summary>
        public const string IllegalParent = "You should not set parent to UI component";

        /// <summary>
        /// Firswt load sign
        /// </summary>
        bool firslLoad = true;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Object type</param>
        /// <param name="kind">Object kind</param>
        /// <param name="icon">Object icon</param>
        protected UserControlBaseLabel(Type type, string kind, Image icon)
        {
            InitializeComponent();
            this.type = type;
            this.kind = kind;
            this.icon = icon;
            SetControl();
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected UserControlBaseLabel(SerializationInfo info, StreamingContext context)
        {
            InitializeComponent();
            Load(info, context);
            SetControl();
        }



        #endregion

        #region Members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return (this as IObjectLabel).RootName + " (" + base.ToString() + ")";
        }

        /// <summary>
        /// Creates User control label
        /// </summary>
        /// <param name="changeSize">The "change size" sign</param>
        /// <returns>The label</returns>
        public UserControlLabel Create(bool changeSize)
        {
            return UserControlLabel.CreateLabel(this, icon, changeSize);
        }

        /// <summary>
        /// Creates label
        /// </summary>
        /// <param name="type">Type of child label</param>
        /// <param name="changeSize">The "change size" sign</param>
        /// <returns>UI Label</returns>
        internal static UserControlLabel Create(Type type, bool changeSize)
        {
            ConstructorInfo cons = type.GetConstructor(new Type[0]);
            UserControlBaseLabel lab = cons.Invoke(new object[0]) as UserControlBaseLabel;
            return lab.Create(changeSize);
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected abstract UserControl Control
        {
            get;
        }

        /// <summary>
        /// Base load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        new protected virtual void Load(SerializationInfo info, StreamingContext context)
        {
            try
            {
              //  type = info.GetValue("Type", typeof(Type)) as Type;
            }
            catch (Exception)
            {

            }
            IObjectLabel l = this;
            object o = l.Object;
            if (o != null)
            {
                type = o.GetType();
            }    
            try
            {
                kind = info.GetString("Kind");

            }
            catch (Exception)
            {
            }
            try
            {
                icon = info.GetValue("Image", typeof(Image)) as Image;
            }
            catch (Exception)
            {
            }
        }

        private void SetControl()
        {
            control = Control;
            Width = control.Width;
            Height = control.Height;
            control.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(control);
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var o = typeof(Type).GetAttribute<SerializableAttribute>();
            if (o != null)
            {
                info.AddValue("Type", type, typeof(Type));
            }
            else
            {
                info.AddValue("Type", type + "");
            }
            info.AddValue("Kind", kind);
            info.AddValue("Image", icon, typeof(Image));
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        public abstract ICategoryObject Object
        {
            get;
            set;
         }

        #endregion

        #region INamedComponent Members

        string INamed.Name
        {
            get => this.GetRootLabel().Name;
            set => throw new IllegalSetPropetryException("LABEL");
        }

        string INamedComponent.Kind
        {
            get { return kind; }
        }

        string INamedComponent.Type
        {
            get 
            {   if (type == null)
                {
                    IObjectLabel l = this;
                    type = l.Object.GetType();
                }
                return type.FullName; 
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
                if (desktop != null)
                {
                    return desktop;
                }
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
                throw new OwnException(IllegalParent);
            }
        }

        INamedComponent INamedComponent.GetRoot(IDesktop desktop)
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
            get { return PureObjectLabel.GetRoot(this, desktop); }
        }

        #endregion

        #region IPostLoadControl Members

        void IPostLoadControl.PostLoad()
        {
            if (!firslLoad)
            {
                return;
            }
            firslLoad = false;
            Post();
        }

        #endregion

        #region INonstandardLabel Members

        /// <summary>
        /// Initialization
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public virtual void Post()
        {
            
        }

       /// <summary>
        /// Resize operation
        /// </summary>
        public new virtual void Resize()
        {
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public virtual void CreateForm()
        {
        }


        /// <summary>
        /// Associated form
        /// </summary>
        public virtual object Form
        {
            get { return null; }
        }

        object INonstandardLabel.Image
        {
            get { return icon; }
        }

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                Control c = this;
                return c.Enabled;
            }
            set
            {
                this.Enabled = value;
                if (control is IEnabled)
                {
                    IEnabled en = control as IEnabled;
                    en.Enabled = value;
                }

            }
        }

        #endregion

    }
}
