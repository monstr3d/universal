using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

using CategoryTheory;

using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Labels
{
	/// <summary>
	/// The associated with Arrow control
	/// </summary>
	[Serializable()]
	public class ArrowLabel : NamedComponent, ISerializable, IArrowLabelUI
	{
        #region Fields

        /// <summary>
        /// Width
        /// </summary>
        const int width = 40;

		/// <summary>
		/// Height
		/// </summary>
		const int height = 40;

		/// <summary>
		/// Height of caption
		/// </summary>
		const int captionHeight = 20;

		/// <summary>
		/// The base triangle for arrow drawing
		/// </summary>
		private static int[] triangle = new int[]{0, 0, -10, 4, -10, -4};

		/// <summary>
		/// The label of source object
		/// </summary>
		private IObjectLabel source;

		/// <summary>
		/// The label of target object
		/// </summary>
		private IObjectLabel target;

		/// <summary>
		/// The pair of correspond object label
		/// </summary>
		private IObjectsPair pair;

		/// <summary>
		/// Matrix for arrow triangle drawing
		/// </summary>
		private Matrix matrix;

		/// <summary>
		/// Pen for border drawing
		/// </summary>
		private Pen borderPen;

		/// <summary>
		/// The associated arrow
		/// </summary>
		private ICategoryArrow arrow;

		/// <summary>
		/// Pen for arrow line drawing
		/// </summary>
		private Pen linePen;

		/// <summary>
		/// The brush for arrow triangle drawing
		/// </summary>
		private Brush triangleBrush;

		/// <summary>
		/// The triangle vertices
		/// </summary>
		private PointF[] trianglePoints;

		/// <summary>
		/// The number of source object
		/// </summary>
		private object sourceNumber;

		/// <summary>
		/// The number of target object
		/// </summary>
		private object targetNumber;

		/// <summary>
		/// Brush for text foreground drawing
		/// </summary>
		new private Brush textBrush;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        private ArrowLabel()
		{

		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="button">Associated button</param>
		/// <param name="arrow">Associated arrow</param>
		/// <param name="source">Associated source</param>
		/// <param name="target">Associated target</param>
		public ArrowLabel(IPaletteButton button, ICategoryArrow arrow, 
			IObjectLabel source, IObjectLabel target) : base(button)
		{
			this.arrow = arrow;
			this.source = source;
			this.target = target;
			Initialize();
            Disposed += ArrowLabel_Disposed;
		}

        private void ArrowLabel_Disposed(object sender, EventArgs e)
        {
			if (arrow == null) return;
            if (arrow is IDisposable disposable) disposable.Dispose();
			arrow = null;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ArrowLabel(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			arrow = (ICategoryArrow)info.GetValue("Arrow", typeof(object));
			sourceNumber = (int)info.GetValue("SourceNumber", typeof(int));
            Disposed += ArrowLabel_Disposed;
            targetNumber = (int)info.GetValue("TargetNumber", typeof(int));
		}

		#endregion

		/// <summary>
		/// Overriden to string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return RootName + " (" + base.ToString() + ")";
		}

		/// <summary>
		/// ISerializable interface implementation
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		new public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("Arrow", arrow);
			info.AddValue("SourceNumber", sourceNumber);
			info.AddValue("TargetNumber", targetNumber);
		}

		/// <summary>
		/// Desktop
		/// </summary>
		new public PanelDesktop Desktop
		{
			get
			{
				return Parent as PanelDesktop;
			}
		}


		/// <summary>
		/// Removes itself
		/// </summary>
		/// <param name="removeForm">The "should remove properties editor" flag</param>
		public void Remove(bool removeForm)
		{
            if (Desktop == null)
            {
                return;
            }
			Desktop.Tools.RemoveArrowNode(this);
			RemoveFromComponent();
			pair.Remove(this);
			pair.Refresh();
			if (removeForm)
			{
				RemoveForm();
			}
			if (Arrow is IDisposable disposable)
			{
				disposable.Dispose();
			}
			arrow = null;
			GC.Collect();
		}

		/// <summary>
		/// Updates associated forms
		/// </summary>
		public override void UpdateForms()
		{
			UpdateForm();
		}

		/// <summary>
		/// The selected flag
		/// </summary>
		public override bool Selected
		{
			get
			{
				return selected;
			}
			set
			{
				if (value)
				{
				}
				if (selected != value)
				{
					selected = value;
					Refresh();
				}
			}
		}

		/// <summary>
		/// The label associated with arrow source
		/// </summary>
		public virtual IObjectLabel Source
		{
			get
			{
				return source;
			}
			set
			{
				source = value;
			}
		}

		/// <summary>
		/// The label associated with arrow target
		/// </summary>
		public virtual IObjectLabel Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		/// <summary>
		/// The number of source object
		/// </summary>
		public object SourceNumber
		{
			get
			{
				return sourceNumber;
			}
			set
			{
				sourceNumber = value;
			}
		}

		
		/// <summary>
		/// The number of target object
		/// </summary>
		public object TargetNumber
		{
			get
			{
				return targetNumber;
			}
			set
			{
				targetNumber = value;
			}
		}

		/// <summary>
		/// The associated arrow
		/// </summary>
		public ICategoryArrow Arrow
		{
			get
			{
				return arrow;
			}
			set
			{
				arrow = value;
			}
		}


		/// <summary>
		/// Initialization
		/// </summary>
		public void Initialize()
		{
			Paint += new PaintEventHandler(onPaint);
			initNamedEventHandlers();
            captionEditor.Visible = false;
			imagePosition = new PointF(5, 20);
			Width = width;
			Height = height;
            imageWidth = (int)((double)Width / (1.4));
            imageHeight = (int)((double)Height / (1.4));
			Rectangle r = new Rectangle();
			r.Width = Width;
			r.Height = captionHeight;
			EditorRectangle = r;
			textBrush = new SolidBrush(Color.White);
			borderPen = new Pen(Color.Black);
			linePen = new Pen(Color.Black);
			matrix = new Matrix();
			trianglePoints = new PointF[3];
			textBrush = new SolidBrush(Color.Black);
			for (int i = 0; i < 3; i++)
			{
				trianglePoints[i] = new PointF(0, 0);
			}
			triangleBrush = new SolidBrush(Color.Black);
            imagePosition = new PointF((Width - imageWidth) / 2,
              editorRect.Height +
              (-editorRect.Height + Height - imageHeight) / 2);
        }

		/// <summary>
		/// The pair of associated objects labels 
		/// </summary>
		IObjectsPair IArrowLabelUI.Pair
		{
			set
			{
				if (!value.Belongs(source, target))
				{
					throw new ErrorHandler.OwnException("IArrowLabelUI.Pair");

                }
				pair = value;
			}
            get
            {
                return pair;
            }
		}
		
		/// <summary>
		/// Draws itself
		/// </summary>
		/// <param name="gr">Graphics to draw</param>
		public void Draw(object gr)
		{
            Graphics g = gr as Graphics;
			int x1 = 0;
			int y1 = 0;
			int x2 = 0;
			int y2 = 0;
			int x3 = 0;
			int y3 = 0;
			Control p = null;
			if (Source is Panel | Source is UserControl)
			{
                p = Source as Control;
			}
			else
			{
                p = ContainerPerformer.GetPanel(Source) as Control;
			}
			x1 = p.Left + p.Width / 2;
			y1 = p.Top + p.Height / 2;
			x2 = Left + Width / 2;
			y2 = Top + Height / 2;
            if (Target is Panel | Target is UserControl)
			{
                p = Target as Control;
			}
			else
			{
                p = ContainerPerformer.GetPanel(Target) as Control;
			}
			x3 = p.Left + p.Width / 2;
			y3 = p.Top + p.Height / 2;
			g.DrawLine(linePen, x1, y1, x2, y2);
			g.DrawLine(linePen, x2, y2, x3, y3);
			for (int i = 0; i < 3; i++)
			{
				trianglePoints[i].X = triangle[2 * i];
				trianglePoints[i].Y = triangle[2 * i + 1];
			}
			matrix.Reset();
			float dx = x3 - x2;
			float dy = y3 - y2;
			double s = Math.Sqrt(dx * dx + dy * dy);
			if (s == 0)
			{
				return;
			}
			double angle = 180 * Math.Atan2(dy / s, dx / s) / Math.PI;
			matrix.Translate(x2 + dx / 2, y2 + dy / 2);
			matrix.RotateAt((float)angle, trianglePoints[0]);
			matrix.TransformPoints(trianglePoints);
			g.FillPolygon(triangleBrush, trianglePoints);
		}

		/// <summary>
		/// Creates correspond xml
		/// </summary>
		/// <param name="doc">document to create element</param>
		/// <returns>The created element</returns>
		public XmlElement CreateXml(XmlDocument doc)
		{
			XmlElement element = doc.CreateElement("ArrowLabel");
			XmlAttribute attrName = doc.CreateAttribute("Name");
			attrName.Value = ComponentName;
			element.Attributes.Append(attrName);
			if (Arrow is IXmlElementCreator)
			{
				IXmlElementCreator c = Arrow as IXmlElementCreator;
				XmlElement child = c.CreateXml(doc);
				element.AppendChild(child);
			}
			return element;
		}

		/// <summary>
		/// The on paint event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event handler arguments</param>
		protected void onPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawRectangle(borderPen, 0, 0, Width - 1, Height - 1);
			g.DrawString(ComponentName, font, textBrush, 5F, 5F);
		}
		#region IArrowLabel Members

		IObjectLabel IArrowLabel.Source
		{
			get
			{
				return source;
			}
			set
			{
				source = value as IObjectLabel;
			}
		}

		IObjectLabel IArrowLabel.Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value as IObjectLabel;
			}
		}

		#endregion

		#region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
		protected override string Name
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

        /// <summary>
        /// Removes itself
        /// </summary>
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
                IPaletteButton button =	this.GetButton();
                return button.ButtonImage;
            }
        }

	}

}
