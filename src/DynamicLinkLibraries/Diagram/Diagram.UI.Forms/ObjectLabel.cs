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
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Labels
{
	/// <summary>
	/// Component that shows the object on desktop
	/// </summary>
	[Serializable()]
	public class ObjectLabel : NamedComponent, 
        ISerializable, IXmlElementCreator, IObjectLabelUI
    {

        #region Fields
        /// <summary>
		/// Width
		/// </summary>
		protected int width = 100;

		/// <summary>
		/// Height
		/// </summary>
		protected int height = 100;

		/// <summary>
		/// Height of caption indicator
		/// </summary>
		protected int captionHeight = 30;

		/// <summary>
		/// The "is moved" flag
		/// </summary>
		protected bool isMoved;

		/// <summary>
		/// Old mouse x position
		/// </summary>
		protected int mouseX;

		/// <summary>
		/// Old mouse y position
		/// </summary>
		protected int mouseY;

		/// <summary>
		/// The correspond object
		/// </summary>
		protected ICategoryObject theObject;

		/// <summary>
		/// Brush for caption foreground
		/// </summary>
		protected Brush captionBrush;

		/// <summary>
		/// The pen of border
		/// </summary>
		protected Pen borderPen;
		
		/// <summary>
		/// Brush for caption foreground for inactive object
		/// </summary>
		protected Brush captionInactiveBrush;

		/// <summary>
		/// The pen of border for inactive object
		/// </summary>
		protected Pen borderInactivePen;

		/// <summary>
		/// Auxiliary variable
		/// </summary>
		protected bool arrowSelected;


		/// <summary>
		/// The events initialized flag
		/// </summary>
		protected bool eventsInitialized = false;

        /// <summary>
        /// Brush of name
        /// </summary>
        protected Brush nameBrush = new SolidBrush(Color.Black);

        #endregion

        #region Ctor

        /// <summary>
		/// Constructor
		/// </summary>
		private ObjectLabel()
		{
            Disposed += ObjectLabel_Disposed;
		}

		private void ObjectLabel_Disposed(object sender, EventArgs e)
		{
			if (theObject == null) return;
			if (theObject is IDisposable d) d.Dispose();
			theObject = null;
		}

        /// <summary>
        /// Construcor from correspond button
        /// </summary>
        /// <param name="button">Correspond button</param>
        public ObjectLabel(IPaletteButton button) : base(button)
		{
			Initialize();
            Disposed += ObjectLabel_Disposed;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ObjectLabel(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			Left = (int)info.GetValue("Left", typeof(int));
			Top = (int)info.GetValue("Top", typeof(int));
			theObject = (ICategoryObject)info.GetValue("Object", typeof(object));
			if (true)
			{
				IAssociatedObject obj = theObject as IAssociatedObject;
                SetOwnName();
                obj.SetAssociatedObject(this);
			}
            Disposed += ObjectLabel_Disposed;
        }

        #endregion

        /// <summary>
		/// ISerializable interface implementation
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		new public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Left", Left);
			info.AddValue("Top", Top);
			info.AddValue("Object", theObject);
		}

		#region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
		public override string Name
		{
			get
			{
				return ComponentName;
			}
		}

 
        /// <summary>
        /// Type
        /// </summary>
		public override string Type
		{
			get
			{
				return type;
			}
		}

		void INamedComponent.Remove()
		{
		}

        /// <summary>
        /// X - coordinate
        /// </summary>
		public override int X
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
		public override int Y
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

		#endregion


		/// <summary>
		/// Desktop
		/// </summary>
		public override PanelDesktop Desktop
		{
			get
			{
				return Parent as PanelDesktop;
			}
		}




		
		/// <summary>
		/// The associated object
		/// </summary>
        public ICategoryObject Object
        {
            get
            {
               return theObject;
            }
            set
            {
                theObject = value;
				if (value == null)
				{
					return;
				}
                SetOwnName();
                theObject.SetAssociatedObject(this);
            }
        }


        private void SetOwnName()
        {
            if (theObject == null)
            {
                return;
            }
        }
		
		/// <summary>
		/// Removes itself
		/// </summary>
		/// <param name="formRemove">The "should remove properties editor" flag</param>
		public virtual void Remove(bool formRemove)
		{
			Desktop.Remove(this);
			if (formRemove)
			{
				RemoveForm();
			}
			theObject = null;
			GC.Collect();
		}

		/// <summary>
		/// Overriden to string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return RootName + " (" + base.ToString() + ")";
		}

		/// <summary>
		/// Updates all associated properties editors
		/// </summary>
		public override void UpdateForms()
		{
			UpdateForm();
			ArrayList pairs = Desktop.Pairs;
			for (int i = 0; i < pairs.Count; i++)
			{
				ObjectsPair pair = pairs[i] as ObjectsPair;
				if (!pair.Belongs(this))
				{
					continue;
				}
				pair.UpdateForms();
			}
		}

		/// <summary>
		/// The selection flag
		/// </summary>
		public override bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				if (selected != value)
				{
					selected = value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// Auxiliary property
		/// </summary>
		public bool ArrowSelected
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

		/// <summary>
		/// Initialization
		/// </summary>
		public virtual void Initialize()
		{
			if (eventsInitialized)
			{
				return;
			}
			eventsInitialized = true;
			Width = width;
			Height = height;
			Rectangle r = new Rectangle();
			r.Width = Width;
			r.Height = captionHeight;
			EditorRectangle = r;
			textBrush = new SolidBrush(Color.White);
			captionBrush = new SolidBrush(SystemColors.ActiveCaption);
			borderPen = new Pen(Color.Black);
			captionInactiveBrush = new SolidBrush(Color.DarkGray);
			borderInactivePen = new Pen(Color.LightGray);
			initEventHandlers();
			captionEditor.Visible = false;
			arrowSelected = false;
		}

		/// <summary>
		/// Creates correspond xml
		/// </summary>
		/// <param name="doc">document to create element</param>
		/// <returns>The created element</returns>
		public XmlElement CreateXml(XmlDocument doc)
		{
			XmlElement element = doc.CreateElement("ObjectLabel");
			XmlAttribute attrName = doc.CreateAttribute("Name");
			attrName.Value = ComponentName;
			element.Attributes.Append(attrName);
			if (Object is IXmlElementCreator)
			{
				IXmlElementCreator c = Object as IXmlElementCreator;
				XmlElement child = c.CreateXml(doc);
				element.AppendChild(child);
			}
			return element;
		}

		/// <summary>
		/// Event handlers initialisation
		/// </summary>
		protected void initEventHandlers()
		{
			initNamedEventHandlers();
            imagePosition = new PointF((Width - imageWidth) / 2,
              editorRect.Height +
              (-editorRect.Height + Height - imageHeight) / 2);
			MouseDown += new MouseEventHandler(onMouseDownMoveEventHandler);
			MouseUp += new MouseEventHandler(onMouseUpMoveEventHandler);
			MouseLeave += new EventHandler(onLeaveEventHandler);
			MouseMove += new MouseEventHandler(onMouseMoveEventHandler) + 
				new MouseEventHandler(onMouseMoveArrow);
			Paint += new PaintEventHandler(onPaint);
		}

		/// <summary>
		/// The On Paint event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Brush brush = (theObject == null) ? captionInactiveBrush : captionBrush;
			g.FillRectangle(brush, EditorRectangle);
			Pen pen = (theObject == null) ? borderInactivePen : borderPen;
			g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
			g.DrawString(ComponentName, font, textBrush, 5F, 5F);
            if (theObject != null)
            {
                if (theObject is INamedObject)
                {
                    INamedObject no = theObject as INamedObject;
                    string name = no.Name;
                    g.DrawString(name, font, nameBrush, 5, captionHeight + 2); 
                }
            }

		}
		
		/// <summary>
		/// The on mouse down event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onMouseDownMoveEventHandler(object sender, MouseEventArgs e)
		{
            
			if ((ModifierKeys & Keys.Shift) == Keys.Shift)
			{
				return;
			}
            if (!StaticExtensionDiagramUIForms.IsArrowClick(e))
			{
				return;
			}
			if (EditorRectangle.Contains(e.X, e.Y))
			{
				return;
			}
			PaletteButton active = Desktop.Tools.Active; 
			if (active != null)
			{
				if (active.IsArrow & active.ReflectionType != null)
				{
					try
					{
						ICategoryArrow arrow = Desktop.Tools.Factory.CreateArrow(active);
						arrow.Source = Object;
						Desktop.ActiveArrow = arrow;
						Desktop.ActiveObjectLabel = this;
						return;
					}
					catch (Exception ex)
					{
                        ex.ShowError(10);
 						return;
					}
				}
			}
			isMoved = true;
            Desktop.IsMoved = true;
            Desktop.SetBlocking(true);
			mouseX = e.X;
			mouseY = e.Y;
		}

		/// <summary>
		/// The on mouse up event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onMouseUpMoveEventHandler(object sender, MouseEventArgs e)
		{
			isMoved = false;
            Desktop.IsMoved = false;
            Desktop.SetBlocking(false);
			ICategoryArrow arrow = Desktop.ActiveArrow;
            if (!e.IsArrowClick())
			{
				return;
			}
			try
			{
				if (arrow == null)
				{
                    Desktop.Redraw();
					return;
				}
				int x = Left + e.X;
				int y = Top + e.Y;
				for (int i = 0; i < Desktop.Controls.Count; i++)
				{
					if (!(Desktop.Controls[i] is IChildObjectLabel) & !(Desktop.Controls[i] is IObjectLabel))
					{
						continue;
					}
					Control c = Desktop.Controls[i];
					bool hor = x < c.Left | x > c.Left + c.Width;
					bool vert = y < c.Top | y > c.Top + c.Height;
					if (hor | vert)
					{
						continue;
					}
					IObjectLabel label = null;
					if (Desktop.Controls[i] is IObjectLabel)
					{
						label = Desktop.Controls[i] as IObjectLabel;
					}
					else
					{
						IChildObjectLabel child = Desktop.Controls[i] as IChildObjectLabel;
						label = child.Label;
					}

					arrow.Target = label.Object;
					IArrowLabel lab = Desktop.Tools.Factory.CreateArrowLabel(Desktop.Tools.Active, arrow, this, label);
                    lab.Arrow.SetAssociatedObject(lab);
					Desktop.AddArrowLabel(lab);
					break;
				}
			}
			catch (Exception ex)
			{
                ex.ShowError(10);
                if (arrow != null)
				{
					if (arrow is IDisposable d)
					{
						d.Dispose();
					}
				}
                ex.ShowError(1); ;
            }
			Desktop.ActiveArrow = null;
			Desktop.Redraw();
		}

		/// <summary>
		/// The on mouse move event handler
		/// Draws correspond arrows
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onMouseMoveArrow(object sender, MouseEventArgs e)
		{
            if (!StaticExtensionDiagramUIForms.IsArrowClick(e))
			{
				return;
			}
			if (Desktop.ActiveArrow == null)
			{
				return;
			}
			Desktop.DrawArrow(this, e);
		}

		/// <summary>
		/// The on mouse move event handler
		/// Moves itself
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onMouseMoveEventHandler(object sender, MouseEventArgs e)
		{
			if (!isMoved)
			{
				return;
			}
			Left += e.X - mouseX;
			Top += e.Y - mouseY;
			if (Selected)
			{
				foreach (Control control in Desktop.Controls)
				{
					if (!(control is IObjectLabelUI))
					{
						continue;
					}
					IObjectLabelUI comp = control as IObjectLabelUI;
					if (comp.Selected & comp != this)
					{
						comp.X += e.X - mouseX;
						comp.Y += e.Y - mouseY;
					}
				}
			}
			Desktop.Redraw();
		}

        

        static internal Image GetImage(ObjectLabel label)
        {
            Image im = label.button.ButtonImage as Image;
            if (im != null)
            {
                return im;
            }
            if (label.Object == null)
            {
                return im;
            }
            IPropertiesEditor pe = label.Object.GetLabelObject<IPropertiesEditor>();
            if (pe != null)
            {
                object o = pe.Editor;
                if (o is Array)
                {
                    Array arr = o as Array;
                    if (arr.Length > 1)
                    {
                        object image = arr.GetValue(1);
                        if (image is Image)
                        {
                            im = image as Image;
                        }
                        if (image is Icon)
                        {
                            Icon ic = image as Icon;
                            im = ic.ToBitmap();
                        }
                    }
                }
            }
            return im;
        }

        /// <summary>
        /// On paint event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected override void ImagedPaintEventHandler(object sender, PaintEventArgs e)
        {
            Image im = GetImage(this);
             Graphics g = e.Graphics;
            if (selected)
            {
                BackColor = Color.LightGray;
            }
            else
            {
                BackColor = Color.White;
            }
            g.DrawImage(im,   new Rectangle((int)imagePosition.X, (int)imagePosition.Y, imageWidth, imageHeight),
                new Rectangle(0, 0, im.Width,
                im.Height),
                GraphicsUnit.Pixel);
        }
		

		/// <summary>
		/// The on mouse leave event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onLeaveEventHandler(object sender,	EventArgs e)
		{
			isMoved = false;
            Desktop.IsMoved = false;
            Desktop.SetBlocking(false);

		}

        /// <summary>
        /// Associated control
        /// </summary>
        public object Control
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Associated image
        /// </summary>
        public object Image
        {
            get
            {
                return GetImage(this);
            }
        }
 
        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            StaticExtensionDiagramUIForms.Action(form, type, actionType);
        }

        #endregion
    }

}
