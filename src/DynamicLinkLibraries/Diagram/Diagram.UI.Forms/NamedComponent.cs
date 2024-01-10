using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Configuration.Assemblies;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;

using CategoryTheory;
using MathGraph;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;

namespace Diagram.UI.Labels
{
	/// <summary>
	/// The base class of named components: object components
	/// and arrow components
	/// </summary>
	[Serializable()]
	public abstract class NamedComponent : Panel, ISerializable, INamedComponent, IShowForm
	{
		
		#region Fields
		
		/// <summary>
		/// The name editor rectangle
		/// </summary>
		protected Rectangle editorRect;

		/// <summary>
		/// The editor of component caption
		/// </summary>
		protected TextBox captionEditor;

		/// <summary>
		/// The position of the component image
		/// </summary>
		protected PointF imagePosition;

		/// <summary>
		/// The name of the component
		/// </summary>
		protected string name;


		/// <summary>
		/// String kind
		/// </summary>
		protected string kind;

		/// <summary>
		/// The button associated with component
		/// </summary>
		protected IPaletteButton button;

		/// <summary>
		/// The font of caption label
		/// </summary>
		protected Font font;

		/// <summary>
		/// The brush for caption drawing
		/// </summary>
		protected Brush textBrush;

		/// <summary>
		/// The form for component properties edining
		/// </summary>
		protected Form form;


		/// <summary>
		/// The type of the component
		/// </summary>
		protected string type;

		/// <summary>
		/// The selection flag
		/// </summary>
		protected bool selected;

		/// <summary>
		/// Tree nodes
		/// </summary>
		protected ArrayList nodes = new ArrayList();

		/// <summary>
		/// The node
		/// </summary>
		protected TreeNode node;

        /// <summary>
        /// Width of image
        /// </summary>
        protected int imageWidth;

        /// <summary>
        /// Height of image
        /// </summary>
        protected int imageHeight;

 

		#endregion

		#region Constructors / Destructor

		/// <summary>
		/// Constructor
		/// </summary>
		protected NamedComponent()
		{
		}


		/// <summary>
		/// Constructor from correspond button
		/// </summary>
		/// <param name="button">the button</param>
		protected NamedComponent(IPaletteButton button)
		{
			this.button = button;
			this.type = button.Type;
            this.kind = button.Kind;
			name = "";
		}

		/// <summary>
        /// Deserialization constructor
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		public NamedComponent(SerializationInfo info, StreamingContext context)
		{
			type = (string)info.GetValue("Type", typeof(string));
			name = (string)info.GetValue("Name", typeof(string));

		}
		/// <summary>
		/// Destructor
		/// </summary>
		~NamedComponent()
		{
			if (form != null)
			{
				form.Dispose();
				form = null;
				GC.Collect();
			}
		}

		#endregion

		#region ISerializable Members

		/// <summary>
		/// ISerializable interface implementation
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Type", type);
			info.AddValue("Name", name);
		}

		#endregion

		#region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
		new public virtual string Name
		{
			get
			{
				return ComponentName;
			}
		}

        /// <summary>
        /// Removes itself
        /// </summary>
		public void Remove()
		{
			
		}

        /// <summary>
        /// X - coordinate
        /// </summary>
		public virtual int X
		{
			get
			{
				return Left;
			}
			set
			{
				Left = value;
			}
		}

        /// <summary>
        /// Y - coordinate
        /// </summary>
		public virtual int Y
		{
			get
			{
				return Top;
			}
			set
			{
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

		string INamedComponent.Kind
		{
			get
			{
				return kind;
			}
		}

		/// <summary>
		/// Order on desktop
		/// </summary>
		public int Ord
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



		/// <summary>
		/// The type of the component
		/// </summary>
		public virtual string Type
		{
			get
			{
				return type;
			}
		}
		


		/// <summary>
		/// Parent component
		/// </summary>
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

        /// <summary>
        /// Root
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Root</returns>
        public INamedComponent GetRoot(IDesktop desktop)
		{
			return PureObjectLabel.GetRoot(this, desktop);
		}


		/// <summary>
		/// Gets component name relatively desktop
		/// </summary>
		/// <param name="desktop">The desktop</param>
		/// <returns>Relalive name</returns>
		public string GetName(IDesktop desktop)
		{
			return PureObjectLabel.GetName(this, desktop);
		}

		/// <summary>
		/// Gets name relatively root
		/// </summary>
		public string RootName
		{
			get
			{
				return GetName(Desktop.Root);
			}
		}

		/// <summary>
		/// Root control
		/// </summary>
		public INamedComponent Root
		{
			get
			{
				return PureObjectLabel.GetRoot(this);
			}
		}

		#endregion

		#region Specific Members


		/// <summary>
		/// Editor of properties
		/// </summary>
		public object Form
		{
			get
			{
				return form;
			}
		}

		/// <summary>
		/// The name of the component
		/// </summary>
		public virtual string ComponentName
		{
			get
			{
				return name;
			}
			set
			{
                if (value == null)
                {
                    return;
                }
				name = value;
                if (node != null)
                {
                    node.Text = value;
                }
			}
		}


		/// <summary>
		/// Adds node to tree
		/// </summary>
		/// <param name="node">The node</param>
		public void AddNode(NamedNode node)
		{
			nodes.Add(node);
		}


		/// <summary>
		/// The associated button
		/// </summary>
		public IPaletteButton ComponentButton
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

		/// <summary>
		/// The node
		/// </summary>
		public object Node
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
		/// The selection indicator
		/// </summary>
		public abstract bool Selected
		{
			get;
			set;
		}
		

		
		/// <summary>
		/// Refreshs the property editor
		/// </summary>
		public void RefreshForm()
		{
			if (form != null)
			{
				form.Refresh();
			}
		}
		
		/// <summary>
		/// The desktop
		/// </summary>
		public virtual PanelDesktop Desktop
		{
			get
			{
				return (PanelDesktop)Parent;
			}
			set
			{
			}
		}

		/// <summary>
		/// Sets name
		/// </summary>
		/// <param name="name">The name</param>
		public void SetName(string name)
		{
			this.name = name;
			updateNodes();
			UpdateForms();
			Refresh();
		}




		

		/// <summary>
		/// Removes itself from desktop
		/// </summary>
		public void RemoveFromComponent()
		{
			Desktop.Controls.Remove(this);
		}

		/// <summary>
		/// Removes properties editor
		/// </summary>
		public void RemoveForm()
		{
			if (form != null)
			{
                try
                {
                    if (!form.IsDisposed)
                    {
                        form.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
				form = null;
				GC.Collect();
			}
		}

		/// <summary>
		/// Updates property editor
		/// </summary>
		public void UpdateForm()
		{
			if (form == null)
			{
				return;
			}
			if (!(form is IUpdatableForm))
			{
				return;
			}
			IUpdatableForm updatable = form as IUpdatableForm;
			updatable.UpdateFormUI();
		}

        /// <summary>
        /// Saves comments
        /// </summary>
        public void SaveComments()
        {
            if (form != null)
            {
                if (!form.IsDisposed)
                {
                    if (form is ISaveComments)
                    {
                        (form as ISaveComments).Save();
                    }
                }
            }
        }

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="form">Parent form</param>
		public void ShowDialog(Form form)
		{
			Form f = Desktop.Tools.Factory.CreateForm(this) as Form;
			f.ShowDialog(form);
		}
		

		/// <summary>
		/// Updates forms
		/// </summary>
		public abstract void UpdateForms();

		/// <summary>
		/// The rectangle of the name editor
		/// </summary>
		protected Rectangle EditorRectangle
		{
			get
			{
				return editorRect;
			}
			set
			{
				editorRect = value;
			}
		}




		/// <summary>
		/// Event handlers initialization
		/// </summary>
		protected virtual void initNamedEventHandlers()
		{
            imageWidth = Width / 2;
            imageHeight = Height / 2;
			captionEditor = new TextBox();
			Controls.Add(captionEditor);
			font = (Font)captionEditor.Font.Clone();
			MouseDown += new MouseEventHandler(namedComponentMouseEventHandler) + 
				new MouseEventHandler(selectMouseClick);
			captionEditor.KeyUp += new KeyEventHandler(namedComponentKeyEventHandler);
			Paint += new PaintEventHandler(ImagedPaintEventHandler);
            MouseUp += new MouseEventHandler(showForm);
		}

		/// <summary>
		/// The key event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void namedComponentKeyEventHandler(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Cancel)
			{
				captionEditor.Visible = false;
				Refresh();
				return;
			}
			if (e.KeyData == Keys.Enter)
			{
				name = captionEditor.Text;
				captionEditor.Visible = false;
				updateNodes();
				UpdateForms();
				Refresh();
			}
		}

		/// <summary>
		/// The selection event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void selectMouseClick(object sender, MouseEventArgs e)
		{
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				Selected = !Selected;
			}
		}

		/// <summary>
		/// The name editor event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void namedComponentMouseEventHandler(object sender, MouseEventArgs e)
		{
			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				return;
			}
            if (!e.IsArrowClick())
			{
				return;
			}
			if (!editorRect.Contains(e.X, e.Y))
			{
				if (captionEditor.Visible)
				{
					name = captionEditor.Text;
					updateNodes();
					captionEditor.Visible = false;
					UpdateForms();
					Refresh();
					return;
				}
			}
			else
			{
				captionEditor.Visible = true;
				captionEditor.Text = name;
			}
		}




		/// <summary>
		/// On paint event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected virtual void ImagedPaintEventHandler(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			if (selected)
			{
				BackColor = Color.LightGray;
			}
			else
			{
				BackColor = Color.White;
			}
			g.DrawImage(button.ButtonImage as Image, imagePosition.X, imagePosition.Y);
		}


		private static void removeForm(INamedComponent component)
		{
			if (component is NamedComponent)
			{
				NamedComponent nc = component as NamedComponent;
				nc.RemoveForm();
				return;
			}
            if (component is IShowForm)
            {
                IShowForm sf = component as IShowForm;
                sf.RemoveForm();
                return;
            }
            IChildObjectLabel l = ContainerPerformer.GetPanel(component as IObjectLabel) as IChildObjectLabel;
			l.RemoveForm();
		}


		private void updateNodes()
		{
			foreach (NamedNode node in nodes)
			{
				node.Text = this.name;
			}
		}

		/// <summary>
		/// The properties editor event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void showForm(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}
            IShowForm sf = this;
			sf.Show();
		}

		#endregion

        #region IShowForm Members

        void IShowForm.ShowForm()
        {
            try
            {
                bool init = false;
                if (form == null)
                {
                    form = Desktop.Tools.Factory.CreateForm(this) as Form;
                    init = true;
                }
                if (form != null)
                {
                    if (form.IsDisposed)
                    {
                        form = Desktop.Tools.Factory.CreateForm(this) as Form;
                        init = true;
                   }
                    if (button is PaletteButton)
                    {
                        Image im = (button as PaletteButton).ButtonImage as Image;
                        if (im != null)
                        {
                            try
                            {
                                using (Bitmap bmp = new Bitmap(im.Width, im.Height))
                                {
                                    bmp.MakeTransparent(Color.White);
                                    Graphics.FromImage(bmp).DrawImage(im, 0, 0, im.Width, im.Height);
                                    form.Icon = Icon.FromHandle(bmp.GetHicon());
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    if (init)
                    {
                        if (form is ISaveComments)
                        {
                            form.FormClosed +=  (object sender, FormClosedEventArgs e) =>
                            {
                                CloseReason r = e.CloseReason;
                                if (r == CloseReason.UserClosing)
                                {
                                    (form as ISaveComments).Save();
                                }
                            };
                        }
                        Action<Form> act = StaticExtensionDiagramUIForms.PostFormLoad;
                        if (act != null)
                        {
                            act(form);
                        }
                        init = false;
                    }
                    form.Show();
                    form.BringToFront();
                    form.Activate();
                    form.Focus();
                    form.Show();
                }
            }
            catch (Exception e)
            {
                e.ShowError(1); ;
                form = null;
            }
        }

        object IShowForm.Form
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

        #endregion
    }

}
