using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;

using SerializationInterface;
using ErrorHandler;


namespace Diagram.UI.Labels
{
    /// <summary>
    /// Base class for all user control labels
    /// </summary>
    [SerializableLabel()]
    [Serializable()]
    public partial class UserControlLabel :
        UserControl, IObjectLabelUI, ISerializable, IShowForm,
        IProperties, IStartStopConsumer, IEnabled
    {

        #region Fields

        bool isInitialized = false;

        private INamedComponent nc;

        private TreeNode node;

        private bool selected;

        string name = "";

        bool arrowSelected;

        /// <summary>
        /// Associated form
        /// </summary>
        protected Form form;

        int x;

        int y;

        Image icon;

        Image im;

        private Panel[] sel;


        private IPaletteButton button;

        private NonstandardLabel hLab;

        /// <summary>
        /// The font of caption label
        /// </summary>
        protected Font font;

        /// <summary>
        /// The brush for caption drawing
        /// </summary>
        protected Brush textBrush;

        private ICategoryObject obj;

        /// <summary>
        /// Internal size
        /// </summary>
        protected Size inSize;

        /// <summary>
        /// Serializable bytes
        /// </summary>
        protected byte[] bytes;

        /// <summary>
        /// Main panel
        /// </summary>
        protected Panel mainPanel;

        /// <summary>
        /// Child label
        /// </summary>
        protected IObjectLabel child;

        /// <summary>
        /// Properties
        /// </summary>
        protected object properties;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected UserControlLabel()
        {
            InitializeComponent();
            captionEditor.KeyUp += KeyUp;
            nc = this;
            Disposed += UserControlLabel_Disposed;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected UserControlLabel(SerializationInfo info, StreamingContext context)
        {
            InitializeComponent();
            nc = this;
            NonstandardLabel.Load(this, info);
            bytes = PureDesktopPeer.LoadProperties(info);
            IProperties p = this;
            SetControl(p.Properties);
            if (child != null)
            {
                if (child is Control)
                {
                    Control c = child as Control;
                    c.Parent = panelCenter;
                }
            }
            try
            {
                icon = info.Deserialize<Image>("Icon");
                if (icon != null)
                {
                    pictureBoxIcon.Image = image;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(-1);
            }
            captionEditor.KeyUp += KeyUp;
            Disposed += UserControlLabel_Disposed;
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
            NonstandardLabel.Save(this, info);
            PureDesktopPeer.SaveProperties(properties, bytes, info);
            if (icon != null)
            {
                info.Serialize<Image>("Icon", icon);
            }
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Associated object
        /// </summary>
        public virtual ICategoryObject Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                if (value == null)
                {
                    return;
                }
                if (value is IProperties)
                {
                    IProperties pr = value as IProperties;
                    pr.Properties = this;
                }
                if (child != null)
                {
                    child.Object = value;
                    value.Object = this;
                }
                Init();
            }
        }

        #endregion

        #region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
        new public virtual string Name
        {
            get => name;
            set => throw new IllegalSetPropetryException("LABEL");
        }

        /// <summary>
        /// Kind
        /// </summary>
        public virtual string Kind
        {
            get { return child.Kind; }
        }

        /// <summary>
        /// Type
        /// </summary>
        public virtual string Type
        {
            get { return child.Type; }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public virtual void Remove()
        {
            if (child != null)
            {
                child.Remove();
                if (child is IDisposable)
                {
                    IDisposable d = child as IDisposable;
                    d.Dispose();
                }
            }
            Dispose();
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        int INamedComponent.X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                Left = value;
            }
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        int INamedComponent.Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                Top = value;
            }
        }


        IDesktop INamedComponent.Desktop
        {
            get
            {
                return Parent as IDesktop;
            }
            set
            {
            }
        }

        int INamedComponent.Ord
        {
            get
            {
                Control c = Parent;
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
                throw new ErrorHandler.OwnException("You should not set parent to UI component");
            }
        }

        /// <summary>
        /// Root
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Root</returns>
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
            { return nc.GetName(nc.Desktop.Root); }
        }

        INamedComponent INamedComponent.Root
        {
            get { return PureObjectLabel.GetRoot(this); }
        }



        #endregion

        #region IObjectLabelUI Members

        object IObjectLabelUI.Control
        {
            get { return this; }
        }

        string IObjectLabelUI.ComponentName
        {
            set 
            { 
                name = value;
                if (form != null)
                {
                    if (!form.IsDisposed)
                    {
                        if (form is IUpdatableForm)
                        {
                            IUpdatableForm f = form as IUpdatableForm;
                            f.UpdateFormUI();
                        }
                    }
                }
                if (name != null)
                {
                    captionEditor.Text = name;
                }
                Refresh();
            }
        }

        bool IObjectLabelUI.Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                if (selected)
                {
                    foreach (Panel p in sel)
                    {
                        p.BackColor = Color.LightGray;
                    }
                    return;
                }
                foreach (Panel p in sel)
                {
                    p.BackColor = Color.White;
                }
            }
        }

        void IObjectLabelUI.UpdateForm()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    if (form is IUpdatableForm)
                    {
                        IUpdatableForm uf = form as IUpdatableForm;
                        uf.UpdateFormUI();
                    }
                }
            }
        }

        object IObjectLabelUI.Node
        {
            get
            {
                return node;
            }
            set
            {
                node = value as TreeNode;
            }
        }


        /// <summary>
        /// Image
        /// </summary>
        public virtual object Image
        {
            get
            {
                if (child is INonstandardLabel)
                {
                    INonstandardLabel l = child as INonstandardLabel;
                    return l.Image;
                }
                return null;
            }
        }

        int IObjectLabelUI.Ord
        {
            get
            {
                Control c = base.Parent;
                return c.Controls.GetChildIndex(this);
            }
            set
            {
                Control c = base.Parent;
                c.Controls.SetChildIndex(this, value);
            }
        }

        void IObjectLabelUI.Initialize()
        {
        }

        void IObjectLabelUI.Remove(bool removeForm)
        {
            hLab.Remove(removeForm);
        }

        bool IObjectLabelUI.ArrowSelected
        {
            get
            {
                return arrowSelected;
            }
            set
            {
                arrowSelected = value;
            }
        }

        System.Xml.XmlElement IObjectLabelUI.CreateXml(System.Xml.XmlDocument doc)
        {
            return null;
        }

        void IObjectLabelUI.RemoveFromComponent()
        {
            hLab.Remove(false);
        }

        IPaletteButton IObjectLabelUI.ComponentButton
        {
            get
            {
                return button;
            }
            set
            {
                button = value;
            }
        }

        #endregion

        #region IShowForm Members

        void IShowForm.ShowForm()
        {
            if (form == null)
            {
                CreateForm();
                if (form == null)
                {
                    return;
                }
            }
            else if (form.IsDisposed)
            {
                CreateForm();
            }
            if (form == null)
            {
                return;
            }
            form.Show();
            form.BringToFront();
            form.Activate();
            form.Focus();
            form.Show();

        }

        void IShowForm.RemoveForm()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    form.Dispose();
                }
                form = null;
                GC.Collect();
            }
        }

        object IShowForm.Form
        {
            get
            {
                if (form != null)
                {
                    if (!form.IsDisposed)
                    {
                        return form;
                    }
                }
                form = null;
                return null;
            }
        }

        #endregion

        #region IProperties Members

        object IProperties.Properties
        {
            get
            {
                if (properties == null)
                {
                    properties = PureDesktopPeer.GetProperties(properties, bytes);
                    bytes = null;
                }
                return properties;
            }
            set
            {
                properties = value;
                SetControl(value);
                Init();
            }
        }

        #endregion

        #region IRemovableObject Members

        /// <summary>
        /// Removes associated object
        /// </summary>
        public virtual void RemoveObject()
        {
            if (child != null)
            {
                if (child is IDisposable)
                {
                    IDisposable d = child as IDisposable;
                    d.Dispose();
                }
            }
            if (obj == null) return;
            if (obj is IDisposable disposable) disposable.Dispose();
            obj = null;
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            if (child is IStartStop)
            {
                IStartStop ss = child as IStartStop;
                ss.Action(type, actionType);
            }
        }

        #endregion

        #region IStartStopConsumer Members

        IStartStop IStartStopConsumer.StartStop
        {
            get
            {
                if (child is IStartStopConsumer)
                {
                    IStartStopConsumer ssc = child as IStartStopConsumer;
                    return ssc.StartStop;
                }
                return null;
            }
            set
            {
                if (child is IStartStopConsumer)
                {
                    IStartStopConsumer ssc = child as IStartStopConsumer;
                    ssc.StartStop = value;
                }
            }
        }

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                if (child is IEnabled)
                {
                    IEnabled en = child as IEnabled;
                    return en.Enabled;
                }
                if (child is Control)
                {
                    Control c = child as Control;
                    return c.Enabled;
                }
                return true;
            }
            set
            {
                if (child is IEnabled)
                {
                    IEnabled en = child as IEnabled;
                    en.Enabled = value;
                }
                if (child is Control)
                {
                    Control c = child as Control;
                    c.Enabled = value;
                }
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Paint event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Arguments of event</param>
        protected void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(caption, font, textBrush, 5F + pictureBoxIcon.Right, 5F);

        }

        private Rectangle captionRect
        {
            get
            {
                string s = caption;
                Graphics g = Graphics.FromHwnd(panelTop.Handle);
                int w = (int)g.MeasureString(s, font).Width;
                return new Rectangle(captionEditor.Left, captionEditor.Top, w, captionEditor.Height);
            }
        }


        private void EditorMouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = captionRect;
            if (r.Contains(e.X, e.Y))
            {
                hLab.IsMoved = false;
                captionEditor.Visible = true;
                return;
            }
            captionEditor.Text = name;
            captionEditor.Visible = false;
        }

        #endregion

        #region Common Members

        #region Public

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (this as IObjectLabel).RootName + " (" + base.ToString() + ")";
        }

        /// <summary>
        /// Sets image
        /// </summary>
        /// <param name="image">The image to set</param>
        public void SetImage(Image image)
        {
            icon = image;
        }

        /// <summary>
        /// The name of the component
        /// </summary>
        public string ComponentName
        {
            set
            {
                name = value;
            }
        }
       
        /// <summary>
        /// Initialization
        /// </summary>
        public virtual void Init()
        {
            if (isInitialized)
            {
                return;
            }
            isInitialized = true;
            if (child is INonstandardLabel)
            {
                INonstandardLabel l = child as INonstandardLabel;
                l.Initialize();
            }
            mainPanel = panelCenter;
            textBrush = new SolidBrush(Color.White);
            font = (Font)captionEditor.Font.Clone();
            hLab = new NonstandardLabel(this, new Control[] { panelTop, pictureBoxIcon }, captionEditor, Post, Resize);
            panelTop.MouseDown += EditorMouseDown;
            panelTop.Paint += OnPaint;
            sel = new Panel[] { panelLeft, panelRight, panelBottom };
        }

        #endregion

        #region Protected

        /// <summary>
        /// Post operation
        /// </summary>
        protected virtual void Post()
        {
            Init();
            if (child is INonstandardLabel)
            {
                INonstandardLabel l = child as INonstandardLabel;
                l.Post();
            }
        }

        /// <summary>
        /// Resize operation
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="args">Arguments</param>
        new protected virtual void Resize(object sender, EventArgs args)
        {
            if (child is INonstandardLabel)
            {
                INonstandardLabel l = child as INonstandardLabel;
                l.Resize();
            }
        }

        /// <summary>
        /// Creates form
        /// </summary>
        protected virtual void CreateForm()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    return;
                }
            }
            if (child == null)
            {
                return;
            }
            if (!(child is INonstandardLabel))
            {
                return;
            }
            INonstandardLabel l = child as INonstandardLabel;
            l.CreateForm();
            form = l.Form as Form;
            Icon ico = Icon;
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    if (ico != null)
                    {
                        form.Icon = ico;
                    }
                    Action<Form> act = StaticExtensionDiagramUIForms.PostFormLoad;
                    if (act != null)
                    {
                        act(form);
                    }
                    form.FormClosing += (object sender, FormClosingEventArgs e) =>
                    {
                        form.Prepare();
                    };
                    if (form is IUpdatableForm)
                    {
                        (form as IUpdatableForm).UpdateFormUI();
                    }
                }
            }
        }


        #endregion

        #region Private

        private PanelDesktop Desktop
        {
            get
            {
                if (Parent == null)
                {
                    return null;
                }
                return Parent as PanelDesktop;
            }
        }

        private Image image
        {
            get
            {
                if (icon == null)
                {
                    return null;
                }
                if (im == null)
                {
                    if ((icon.Width < pictureBoxIcon.Width) & (icon.Height < pictureBoxIcon.Height))
                    {
                        im = icon;
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(pictureBoxIcon.Width, pictureBoxIcon.Height);
                        Graphics g = Graphics.FromImage(bmp);
                        Rectangle r = new Rectangle(0, 0, pictureBoxIcon.Width, pictureBoxIcon.Height);
                        g.DrawImage(icon, r, 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel);
                        im = bmp;
                    }
                }
                return im;
            }
        }

        private string caption
        {
            get
            {
                if (name == null)
                {
                    return "[Name]";
                }
                if (name.Length == 0)
                {
                    return "[Name]";
                }
                return name;
            }
        }

        private void SetControl(object obj)
        {
            if (obj is Control)
            {
                Control c = obj as Control;
                c.Dock = DockStyle.Fill;
                panelCenter.Controls.Add(c);
            }
            if (obj is IObjectLabel)
            {
                child = obj as IObjectLabel;
                if (icon == null)
                {
                    if (child is INonstandardLabel)
                    {
                        INonstandardLabel nl = child as INonstandardLabel;
                        Image im = nl.Image as Image;
                        if (im != null)
                        {
                            icon = im;
                            pictureBoxIcon.Image = im;
                        }
                    }
                }
                properties = child;
            }
        }

        new private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                UpdateNode();
            }
        }


        private void UpdateNode()
        {
            if (node != null)
            {
                try
                {
                    node.Text = captionEditor.Text;
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                }
            }
        }

        #endregion

        #endregion

        #region Internal Members

        internal Icon Icon
        {
            get
            {
                if (icon != null)
                {
                    try
                    {
                        using (Bitmap bmp = new Bitmap(icon.Width, icon.Height))
                        {
                            bmp.MakeTransparent(Color.White);
                            Graphics.FromImage(bmp).DrawImage(icon, 0, 0, icon.Width, icon.Height);
                            return Icon.FromHandle(bmp.GetHicon());
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return null;
            }
        }

        #endregion

        #region Static Members

        /// <summary>
        /// Creates Wrapper
        /// </summary>
        /// <param name="label">Wrapped label</param>
        /// <param name="icon">Icon</param>
        /// <param name="changeSize">The "change size" sign</param>
        /// <returns>Wrapper</returns>
        internal static UserControlLabel CreateLabel(IObjectLabel label, object icon, bool changeSize)
        {
            UserControlLabel l = new UserControlLabel();
            if (changeSize)
            {
                if (label is Control c)
                {
                    if (c.Width > l.panelCenter.Width)
                    {
                        l.Width += c.Width - l.panelCenter.Width;
                    }
                    if (c.Height > l.panelCenter.Height)
                    {
                        l.Height += c.Height - l.panelCenter.Height;
                    }
                }
            }
            Image ic = icon as Image;
            if (ic == null)
            {
                if (label is INonstandardLabel nl)
                {
                    ic = nl.Image as Image;
                }
            }
            l.icon = ic;
            l.pictureBoxIcon.Image = l.image;
            IProperties p = l;
            p.Properties = label;
            if (label is Control)
            {
                Control c = label as Control;
                c.Parent = l.panelCenter;
            }
            return l;
        }

        #endregion

        private void UserControlLabel_Disposed(object sender, EventArgs e)
        {
            RemoveObject();
        }

    }
}