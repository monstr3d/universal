using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using CategoryTheory;

using MathGraph;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Forms.Interfaces;

using SerializationInterface;

using System.ComponentModel;
using System.Threading.Tasks;

using Common.UI;

using ToolBox;
using ErrorHandler;
using NamedTree;
using WindowsExtensions;
using System.Threading;


namespace Diagram.UI
{
    /// <summary>
    /// The desktop of situation object
    /// </summary>
    public class PanelDesktop : Panel, IDesktop, ICancellation
    {

        #region Fields


        Diagram.UI.Performer p = new Diagram.UI.Performer();

        IComponentCollection collection;

        CancellationToken cancellationToken;

        /// <summary>
		/// Then "is not equal" string
		/// </summary>
		public static readonly string IsNotEqual = "is not equal";

        /// <summary>
        /// Transformer of objects
        /// </summary>
        public static readonly Func<object, object> ObjectTransformer = transformObjectLabel;

        /// <summary>
        /// Transformer of arrows
        /// </summary>
        public static readonly Func<object, object> ArrowTransformer = transformArrowLabel;

        /// <summary>
        /// The tools
        /// </summary>
        private ToolsDiagram tools;

        /// <summary>
        /// The buffer image
        /// </summary>
        private Image image;

        /// <summary>
        /// The clean brush
        /// </summary>
        private Brush brush;

        /// <summary>
        /// The collection of object pairs
        /// </summary>
        private ArrayList pairs = new ArrayList();

        /// <summary>
        /// The activated arrow
        /// </summary>
        private ICategoryArrow activeArrow;

        /// <summary>
        /// The activated object label
        /// </summary>
        private IObjectLabel activeObjectLabel;

        /// <summary>
        /// The pen to draw arrows
        /// </summary>
        private Pen linePen;

        /// <summary>
        /// The x coordinate of selection
        /// </summary>
        private int xSelect;

        /// <summary>
        /// The y coordinate of selection
        /// </summary>
        private int ySelect;

        /// <summary>
        /// The flag of selection performing
        /// </summary>
        private bool performsSelection;

        /// <summary>
        /// Creator of comments
        /// </summary>
        private static ICommentsCreator commentsCreator;

        /// <summary>
        /// File extension
        /// </summary>
        private string ext;

        /// <summary>
        /// Cleaner of desktop
        /// </summary>
        private static IDesktopCleaner cleaner;

        /// <summary>
        /// The is moved sign
        /// </summary>
        private bool isMoved;

        /// <summary>
        /// The edit enabled sign
        /// </summary>
        private bool editEnabled = true;

        private Action<Stream> afterDrag = null;

        private List<string> files = new List<string>();

        IComponentCollection component;



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tools">The tools</param>
        public PanelDesktop(ToolsDiagram tools)
        {
            collection = this;
            this.tools = tools;
            component = this;
            Paint += new PaintEventHandler(onPaint);
            brush = new SolidBrush(Color.White);
            MouseUp += new MouseEventHandler(onMouseUp);
            MouseMove += new MouseEventHandler(onMouseMoveArrow);
            MouseDown += new MouseEventHandler(onMouseDownSelect);
            InitializeComponent();
            linePen = new Pen(Color.Black);
            BackColor = Color.White;
            DragEnter += FileDragEnter;
            DragDrop += FileDragDrop;
            this.SetDragDrop();
        }

        #endregion

        #region IDesktop Members

        /// <summary>
        /// Components
        /// </summary>
        public IEnumerable<object> Components
        {
            get
            {
                foreach (object o in Controls)
                {
                    if (o is INamedComponent)
                    {
                        yield return o;
                    }
                }
            }
        }

        /// <summary>
        /// All components
        /// </summary>
        public IEnumerable<object> AllComponents
        {
            get
            {
                return this.GetAllObjects();
            }
        }

        /// <summary>
        /// Objects
        /// </summary>
        public IEnumerable<IObjectLabel> Objects
        {
            get
            {
                foreach (object o in Controls)
                {
                    if (o is IObjectLabel)
                    {
                        yield return o as IObjectLabel;
                    }
                }
            }
        }

        /// <summary>
        /// Arrows
        /// </summary>
        public IEnumerable<IArrowLabel> Arrows
        {
            get
            {
                foreach (object o in Controls)
                {
                    if (o is IArrowLabel)
                    {
                        yield return o as IArrowLabel;
                    }
                }
            }
        }

        /// <summary>
        /// Copies objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="associated">Sign for setting associated objects</param>
        protected virtual void Copy(IEnumerable<IObjectLabel> objects, IEnumerable<IArrowLabel> arrows, bool associated)
        {
            List<IObjectLabel> objs = new List<IObjectLabel>();
            List<IObjectLabel> obb = objects.ToList<IObjectLabel>();
            foreach (IObjectLabel l in objects)
            {

                IObjectLabelUI lab = null;
                IObjectLabelHolder lh = l.GetSimpleObject<IObjectLabelHolder>();
                if (lh != null)
                {
                    lab = lh.Label.GetSimpleObject<IObjectLabelUI>();
                }
                if (lab == null)
                {
                    lab = tools.Factory.CreateLabel(l.Object);
                }
                if (lab == null)
                {
                    lab = tools.Factory.CreateObjectLabel(tools.FindButton(l));
                }
                lab.X = l.X;
                lab.Y = l.Y;
                IObjectLabel la = lab;
                lab.ComponentName = l.Name;
                lab.Object = l.Object;
                lab.Initialize();
                AddNewObjectLabel(lab);
                objs.Add(lab);
                if (lab is IContainerObjectLabel)
                {
                    IContainerObjectLabel cl = lab as IContainerObjectLabel;
                    cl.Expand();
                }
                StaticExtensionDiagramUIForms.PostLabelLoad(lab);
            }
            List<IArrowLabel> arrs = new List<IArrowLabel>();
            foreach (IArrowLabel l in arrows)
            {
                IArrowLabelUI lab = null;
                IArrowLabelHolder lh = l.GetSimpleObject<IArrowLabelHolder>();
                if (lh != null)
                {
                    lab = lh.Label.GetSimpleObject<IArrowLabelUI>();
                }
                IObjectLabel source = PureDesktop.Find(obb, objs, l.Source, l.Desktop);
                IObjectLabel target = PureDesktop.Find(obb, objs, l.Target, l.Desktop);
                if (lab == null)
                {
                    lab = tools.Factory.CreateArrowLabel(tools.FindButton(l), l.Arrow, source, target);
                }
                lab.ComponentName = l.Name;
                lab.Arrow = l.Arrow;
                lab.Source = source;
                lab.Target = target;
                arrs.Add(lab);
            }
            if (!associated)
            {
                return;
            }
            this.SetParents();
            IEnumerable<IObjectLabel> objj = Objects;
            PureObjectLabel.SetLabels(objj);
            PureArrowLabel.SetLabels(arrs);
            foreach (IObjectLabel l in objj)
            {
                tools.AddObjectNode(l);
            }
            foreach (IArrowLabel l in arrs)
            {
                AddArrowLabel(l);
            }
            foreach (object o in Objects)
            {
                if (o is Control post)
                {
                    post.PostSet();
                }

            }
            foreach (object o in Arrows)
            {
                if (o is Control control)
                {
                    control.PostSet();
                }
            }
        }

        /// <summary>
        /// Access to component
        /// </summary>
        public INamedComponent this[string name]
        {
            get
            {
                if (name == null)
                {
                    return null;
                }
                foreach (object o in Controls)
                {
                    if (!(o is INamedComponent))
                    {
                        continue;
                    }
                    INamedComponent c = o as INamedComponent;
                    if (name.Equals(c.Name))
                    {
                        return c;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Gets object by name
        /// </summary>
        /// <param name="name">Name of object</param>
        /// <returns>The object</returns>
		public object GetObject(string name)
        {
            return this.GetAssociatedObject(name);
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public IDesktop Desktop
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Saves comments
        /// </summary>
        public void SaveComments()
        {
            IEnumerable<object> en = AllComponents;
            foreach (object o in en)
            {
                if (o is ISaveComments)
                {
                    (o as ISaveComments).Save();
                }
                if (o is NamedComponent)
                {
                    NamedComponent l = o as NamedComponent;
                    l.SaveComments();
                }
            }
        }

        /// <summary>
        /// The edit enabled sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// The edit enabled sign
        /// </summary>
        public bool EditEnabled
        {
            get
            {
                return editEnabled;
            }
            set
            {
                editEnabled = false;
            }
        }

        /// <summary>
        /// Gets desktop from abstract object
        /// </summary>
        /// <param name="desktop">The abstract object</param>
        /// <returns>The desktop</returns>
        public static PanelDesktop GetDesktop(IDesktop desktop)
        {
            return desktop as PanelDesktop;
        }

        /// <summary>
        /// Overriden dispoise
        /// </summary>
        /// <param name="disposing">The "disposing" sign</param>
        protected override void Dispose(bool disposing)
        {
            /*  if (disposing && (components != null))
              {
                  components.Dispose();
              }*/
            base.Dispose(disposing);
            this.DisposeDesktop();
        }


        /// <summary>
        /// Creator of comments
        /// </summary>
        public static ICommentsCreator CommentsCreator
        {
            get
            {
                return commentsCreator;
            }
            set
            {
                commentsCreator = value;
            }
        }

        /// <summary>
        /// The "is moved" sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// The "is moved" sign
        /// </summary>
        public bool IsMoved
        {
            get
            {
                return isMoved;
            }
            set
            {
                isMoved = value;
            }
        }

        /// <summary>
        /// Saves selected objects
        /// </summary>
        /// <param name="stream">The stream to save</param>
        public void SaveSelected(Stream stream)
        {
            IList<IObjectLabel> objs;
            IList<IArrowLabel> arrs;
            GetSelected(out objs, out arrs);
            Save(objs, arrs, stream, false);
        }

        /// <summary>
        /// File extension
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// File extension
        /// </summary>
        public string Extension
        {
            get
            {
                return ext;
            }
            set
            {
                ext = value;
            }
        }

        /// <summary>
        /// Sets components in frame
        /// </summary>
        public void SetInFrame()
        {
            foreach (Control c in Controls)
            {
                if (c.Left < 0)
                {
                    c.Left = 0;
                }
                if (c.Top < 0)
                {
                    c.Top = 0;
                }
                if (c.Left > Width - c.Width)
                {
                    c.Left = Width - c.Width;
                }
                if (c.Top > Height - c.Height)
                {
                    c.Top = Height - c.Height;
                }
            }
        }

        /// <summary>
        /// Deletes all comments
        /// </summary>
        public void DeleteComments()
        {
            ArrayList l = new ArrayList();
            foreach (Control c in Controls)
            {
                if (!(c is INamedComponent))
                {
                    l.Add(c);
                }
            }
            foreach (Control c in l)
            {
                Controls.Remove(c);
            }
        }


        /// <summary>
        /// Sets selection sign
        /// </summary>
        /// <param name="selection">The sign</param>
        public void SetSelection(bool selection)
        {
            foreach (object o in Controls)
            {
                if (!(o is NamedComponent))
                {
                    continue;
                }
                NamedComponent c = o as NamedComponent;
                c.Selected = selection;
            }
        }

        /// <summary>
        /// Saves all items to stream
        /// </summary>
        /// <param name="stream">The stream to save</param>
        public void SaveAll(Stream stream)
        {
            this.Prepare(true);
            SaveComments();
            IList<IObjectLabel> objects = new List<IObjectLabel>();
            IList<IArrowLabel> arrows = new List<IArrowLabel>();
            foreach (Control c in Controls)
            {
                if (c is IObjectLabelUI)
                {
                    objects.Add(c as IObjectLabel);
                }
                if (c is IArrowLabelUI)
                {
                    arrows.Add(c as IArrowLabel);
                }
            }
            Save(objects, arrows, stream, true);
        }

        /// <summary>
        /// All objects on desktop
        /// </summary>
        public ArrayList[] AllObjects
        {
            get
            {
                ArrayList objects = new ArrayList();
                ArrayList arrows = new ArrayList();
                foreach (Control c in Controls)
                {
                    if (c is IObjectLabelUI)
                    {
                        objects.Add(c);
                    }
                    if (c is IArrowLabelUI)
                    {
                        arrows.Add(c);
                    }
                }
                return new ArrayList[] { objects, arrows };
            }
        }

        /// <summary>
        /// Names of aliases
        /// </summary>
        public ArrayList AliasNames
        {
            get
            {
                ArrayList l = new ArrayList();
                foreach (Control c in Controls)
                {
                    if (c is IObjectLabelUI)
                    {
                        IObjectLabelUI ol = c as IObjectLabelUI;
                        ICategoryObject ob = ol.Object;
                        if (!(ob is IAlias))
                        {
                            continue;
                        }
                        IAlias a = ob as IAlias;
                        IList<string> an = a.AliasNames;
                        string name = ol.Name;
                        foreach (string s in an)
                        {
                            l.Add(name + "." + s);
                        }
                    }
                    if (c is IArrowLabelUI)
                    {
                        IArrowLabelUI al = c as IArrowLabelUI;
                        ICategoryArrow ar = al.Arrow;
                        if (!(ar is IAlias))
                        {
                            continue;
                        }
                        IAlias a = ar as IAlias;
                        IList<string> an = a.AliasNames;
                        string name = al.Name;
                        foreach (string s in an)
                        {
                            l.Add(name + "." + s);
                        }
                    }
                }
                return l;
            }
        }

        /// <summary>
        /// Transforms digraph
        /// </summary>
        /// <param name="graph">Digraph to transform</param>
        public void TransformDigraph(Digraph graph)
        {
            graph.Transform(ObjectTransformer, ArrowTransformer);
        }

        /// <summary>
        /// Gets diagram of definite types
        /// </summary>
        /// <param name="objectTypes">List of object types</param>
        /// <param name="arrowTypes">List of arrow types</param>
        /// <returns>Array of arrays of objects and arrows [0] - objects, [1] - arrows</returns>
        public ArrayList[] GetTypedDiagram(ArrayList objectTypes, ArrayList arrowTypes)
        {
            ArrayList[] list = new ArrayList[] { new ArrayList(), new ArrayList() };
            foreach (object o in Controls)
            {
                if (o is IObjectLabelUI)
                {
                    IObjectLabelUI l = o as IObjectLabelUI;
                    if (objectTypes.Contains(l.Kind))
                    {
                        list[0].Add(l);
                    }
                    continue;
                }
                if (o is IArrowLabelUI)
                {
                    IArrowLabelUI l = o as IArrowLabelUI;
                    if (arrowTypes.Contains(l.Kind))
                    {
                        list[1].Add(l);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Creates XML Element from selected objects
        /// </summary>
        /// <param name="doc">The document</param>
        /// <returns></returns>
        public XmlElement CreateSelectedXml(XmlDocument doc)
        {
            IList<IObjectLabel> objs;
            IList<IArrowLabel> arrs;
            GetSelected(out objs, out arrs);
            return CreateXml(objs, arrs, doc);
        }

        /// <summary>
        /// Creates XML Element from all objects
        /// </summary>
        /// <param name="doc">The document</param>
        /// <returns></returns>
        public XmlElement CreateXml(XmlDocument doc)
        {
            List<IObjectLabel> ob = new List<IObjectLabel>();
            List<IArrowLabel> ar = new List<IArrowLabel>();
            foreach (Control c in Controls)
            {
                if (c is IObjectLabelUI)
                {
                    ob.Add(c as IObjectLabel);
                    continue;
                }
                if (c is IArrowLabelUI)
                {
                    ar.Add(c as IArrowLabel);
                }
            }
            return CreateXml(ob, ar, doc);
        }

        /// <summary>
        /// Removes selected objects
        /// </summary>
        public void RemoveSelected()
        {
            ArrayList list = new ArrayList();
            List<Control> cont = new List<Control>();
            List<IArrowLabelUI> al = new List<IArrowLabelUI>();

            foreach (Control c in Controls)
            {
                if (c is IArrowLabelUI)
                {
                    IArrowLabelUI alui = c as IArrowLabelUI;
                    al.Add(alui);
                    cont.Add(c);
                }
                if (!(c is IObjectLabelUI))
                {
                    continue;
                }
                IObjectLabelUI label = c as IObjectLabelUI;
                if (label.Selected)
                {
                    list.Add(c);
                    cont.Add(c);
                }
            }
            foreach (Control c in cont)
            {
                c.PreRemove();
            }
            List<IArrowLabelUI> ald = new List<IArrowLabelUI>();
            foreach (IObjectLabelUI label in list)
            {
                foreach (IArrowLabelUI alab in al)
                {
                    if (alab.Source == label | alab.Target == label)
                    {
                        if (!ald.Contains(alab))
                        {
                            ald.Add(alab);
                            if (alab is Control)
                            {
                                (alab as Control).PreRemove();
                            }
                        }
                    }
                }
                label.Remove(true);
            }
            PureDesktop.DisposeCollection(list);
            list.Clear();
            list = null;
            foreach (Control c in Controls)
            {
                if (!(c is IArrowLabelUI))
                {
                    continue;
                }
                IArrowLabelUI label = c as IArrowLabelUI;
                if (label.Selected)
                {

                    if (!ald.Contains(label))
                    {
                        ald.Add(label);
                    }
                }
            }
            foreach (IArrowLabelUI label in ald)
            {
                label.Remove(true);
            }
            PureDesktop.DisposeCollection(ald);
            ald.Clear();
            ald = null;
            list = null;
            GC.Collect();
        }

        /// <summary>
        /// Removes all objects
        /// </summary>
        public void RemoveAll()
        {
            foreach (Control c in Controls)
            {
                c.PreRemove();
            }
            SetBlocking(true);
            ArrayList arrs = new ArrayList();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is IArrowLabelUI)
                {
                    arrs.Add(Controls[i]);

                }
            }
            object[] ob = arrs.ToArray();
            for (int i = 0; i < ob.Length; i++)
            {
                IArrowLabelUI l = ob[i] as IArrowLabelUI;
                l.Remove(true);
            }
            ArrayList objs = new ArrayList();
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is IObjectLabelUI)
                {
                    objs.Add(Controls[i]);
                }
            }
            object[] o = objs.ToArray();
            for (int i = 0; i < o.Length; i++)
            {
                IObjectLabelUI l = o[i] as IObjectLabelUI;
                l.Remove(true);
            }
            PureDesktop.DisposeCollection(arrs);
            PureDesktop.DisposeCollection(objs);
            arrs = null;
            ob = null;
            objs = null;
            o = null;
            SetBlocking(false);
            GC.Collect();
        }

        /// <summary>
        /// Creates image of arrow
        /// </summary>
        /// <param name="label">Label of arrow</param>
        /// <param name="x">X shift of image label</param>
        /// <param name="y">Y shift of image label</param>
        public void CreateImage(IArrowLabelUI label, int x, int y)
        {
            IImageArrow hom = label.Arrow as IImageArrow;
            ICategoryArrow to = hom.ToImage;
            ICategoryArrow from = hom.FromImage;
            ICategoryObject im = to.Target;
            IObjectLabelUI labImObj = tools.Factory.CreateObjectLabel(Tools.Factory.GetObjectButton(im));
            IObjectLabelUI labSource = label.Source as IObjectLabelUI;
            IObjectLabelUI labTarget = label.Target as IObjectLabelUI;
            labImObj.Object = im;
            im.Object = labImObj;
            labImObj.Y = labTarget.Y + y;
            labImObj.X = labTarget.X + x;
            labImObj.ComponentName = "Im (" + label.Name + ")";
            AddNewObjectLabel(labImObj);
            tools.AddObjectNode(labImObj);
            IArrowLabelUI arrowSo = tools.Factory.CreateArrowLabel(Tools.Factory.GetArrowButton(to), to, labSource, labImObj);
            to.Object = arrowSo;
            arrowSo.ComponentName = "im (" + label.Name + ")";
            AddNewArrowLabel(arrowSo);
            IArrowLabelUI arrowTa = tools.Factory.CreateArrowLabel(Tools.Factory.GetArrowButton(from), from, labImObj, labTarget);
            from.Object = arrowTa;
            arrowTa.ComponentName = "Im (" + label.Name + ")";
            AddNewArrowLabel(arrowTa);
            Redraw();
        }

        /// <summary>
        /// Selects all
        /// </summary>
        /// <param name="selected">The "selected" sign</param>
        public void SelectAll(bool selected)
        {
            foreach (Control c in Controls)
            {
                if (c is IObjectLabelUI)
                {
                    IObjectLabelUI olui = c as IObjectLabelUI;
                    olui.Selected = selected;
                    continue;
                }
                if (c is IArrowLabelUI)
                {
                    IArrowLabelUI alui = c as IArrowLabelUI;
                    alui.Selected = selected;
                }
            }
        }

        /// <summary>
        /// Gets selected objects and arrows
        /// </summary>
        public void GetSelected(out IList<IObjectLabel> objects, out IList<IArrowLabel> arrows)
        {
            objects = new List<IObjectLabel>();
            arrows = new List<IArrowLabel>();
            foreach (Control control in Controls)
            {
                if (!(control is IArrowLabelUI))
                {
                    continue;
                }
                IArrowLabelUI label = control as IArrowLabelUI;
                if (!label.Selected)
                {
                    continue;
                }
                arrows.Add(label);
            }
            foreach (Control control in Controls)
            {
                if (!(control is IObjectLabelUI))
                {
                    continue;
                }
                IObjectLabelUI label = control as IObjectLabelUI;
                if (label.Selected & !(label.ArrowSelected))
                {
                    objects.Add(label);
                }
            }
            foreach (IObjectLabelUI label in objects)
            {
                label.ArrowSelected = false;
            }
        }

        /// <summary>
        /// All object labels
        /// </summary>
		public List<object>[] AllLabels
        {
            get
            {
                List<object>[] l = new List<object>[] { new List<object>(), new List<object>() };
                foreach (object o in Controls)
                {
                    if (o is IObjectLabelUI)
                    {
                        l[0].Add(o);
                        continue;
                    }
                    if (o is IObjectLabelUI)
                    {
                        l[1].Add(o);
                    }
                }
                return l;
            }
        }

        /// <summary>
        /// Adds arrow label with existing source and target object labels
        /// </summary>
        /// <param name="arrow">Associated arrow</param>
        /// <returns>The arrow label</returns>
        public IArrowLabelUI AddArrowWithExistingObjects(ICategoryArrow arrow)
        {
            ICategoryObject s = arrow.Source;
            ICategoryObject t = arrow.Target;
            IObjectLabel sl = s.Object as IObjectLabel;
            IObjectLabel tl = t.Object as IObjectLabel;
            IArrowLabelUI arrowLabel = tools.Factory.CreateArrowLabel(tools.Factory.GetArrowButton(arrow), arrow, sl, tl);
            arrowLabel.Source = sl;
            arrowLabel.Target = tl;
            arrowLabel.Arrow = arrow;
            arrow.Object = arrowLabel;
            AddNewArrowLabel(arrowLabel);
            return arrowLabel;

        }

        /// <summary>
        /// Saves objects and arrows to stream
        /// </summary>
        /// <param name="objects">List of objects</param>
        /// <param name="arrows">List of arrows</param>
        /// <param name="stream">The stream</param>
        /// <param name="comments">Comments saving sign</param>
		public void Save(IList<IObjectLabel> objects, IList<IArrowLabel> arrows, Stream stream, bool comments)
        {
            PureDesktopPeer desktop = new PureDesktopPeer();
            IDesktop d = desktop;
            d.Copy(objects, arrows, false);
            if (comments)
            {
                List<object> comm = ControlPanel.GetComments(this);
                List<object> c = desktop.Comments;
                foreach (object o in comm)
                {
                    c.Add(o);
                }
            }
            desktop.Save(stream);
            if (objects.Count == 0)
            {
                return;
            }
            IObjectLabel l = objects[0] as IObjectLabel;
            l.Desktop.SetParents();
        }

        /// <summary>
        /// Creates serializable copy
        /// </summary>
        /// <returns>The copy</returns>
        public PureDesktopPeer Copy()
        {
            PureDesktopPeer desktop = new PureDesktopPeer();
            copy(desktop);
            return desktop;
        }

        /// <summary>
        /// Copies all content to desktop
        /// </summary>
        /// <param name="desktop">The copy desktop</param>
        public void Copy(PureDesktopPeer desktop)
        {
            desktop.ClearAll();
            copy(desktop);
        }

        /// <summary>
        /// Loads from serializable desktop
        /// </summary>
        /// <param name="desktop">The serializable desktop</param>
        public void Load(PureDesktopPeer desktop)
        {
            SetBlocking(true);
            desktop.Copy(this);
            this.PostLoad();
            RedrawImage();
            SetBlocking(false);
            Refresh();
            List<object> c = desktop.Comments;
            ControlPanel.LoadControls(this, c);
        }

        /// <summary>
        /// Parent desktop
        /// </summary>
        public virtual IDesktop ParentDesktop
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Level of desktop
        /// </summary>
        public virtual int Level
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Root desktop
        /// </summary>
        public IDesktop Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets desktop object label
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>The label</returns>
        public IObjectLabelUI GetObjectLabel(string name)
        {
            foreach (Control c in Controls)
            {
                if (!(c is IObjectLabelUI))
                {
                    continue;
                }
                IObjectLabelUI l = c as IObjectLabelUI;
                if (name.Equals(l.Name))
                {
                    return l;
                }
            }
            return null;
        }



        /// <summary>
        /// Names of selected components
        /// </summary>
        public IList<string>[] SelectedNames
        {
            get
            {
                IList<IObjectLabel> objs;
                IList<IArrowLabel> arrs;
                GetSelected(out objs, out arrs);
                //ArrayList[] s = Selected;
                IList<string>[] n = new IList<string>[] { new List<string>(), new List<string>() };
                foreach (IObjectLabelUI l in objs)
                {
                    n[0].Add(l.Name);
                }
                foreach (IArrowLabelUI l in arrs)
                {
                    n[1].Add(l.Name);
                }
                return n;
            }
        }

        /// <summary>
        /// String representation of path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns> String representation of path</returns>
        static public string ToString(DigraphPath path)
        {
            IObjectLabelUI l = path[path.Count - 1].Object as IObjectLabelUI;
            string s = l.Name;
            for (int i = path.Count - 2; i >= 0; i--)
            {
                l = path[i].Object as IObjectLabelUI;
                s += " * " + l.Name;
            }
            return s;
        }

         /// <summary>
        /// Performs all operations for adding object label
        /// </summary>
        /// <param name="lab">Object label to add</param>
        public void AddNewObjectLabel(IObjectLabel lab)
        {
            Controls.Add(lab as Control);
            object obj = lab.Object;
            lab.Object.Object = lab;
            if (lab.Object is IFactoryObject)
            {
                IFactoryObject f = lab.Object as IFactoryObject;
                f.Facrory = Tools.Factory;
            }

            if (lab.Object is IPostSerialize)
            {
                IPostSerialize p = lab.Object as IPostSerialize;
                p.PostSerialize();
            }

        }

        /// <summary>
        /// Objects
        /// </summary>
        public IEnumerable<ICategoryObject> CategoryObjects
        {
            get
            {
                IList<ICategoryObject> objs = new List<ICategoryObject>();
                IList<ICategoryArrow> arrs = new List<ICategoryArrow>();
                GetAll(this, objs, arrs);
                return objs;
            }
        }

        /// <summary>
        /// Arrows
        /// </summary>
        public IEnumerable<ICategoryArrow> CategoryArrows
        {
            get
            {
                IList<ICategoryObject> objs = new List<ICategoryObject>();
                IList<ICategoryArrow> arrs = new List<ICategoryArrow>();
                GetAll(this, objs, arrs);
                return arrs;
            }
        }

        /// <summary>
        /// Performs all operations for adding arrow label
        /// </summary>
        /// <param name="arrow">Arrow label to add</param>
        public void AddNewArrowLabel(IArrowLabel arrow)
        {
            AddArrowLabel(arrow);
            arrow.Arrow.Object = arrow;
            if (true)
            {
                IAssociatedObject ass = arrow.Arrow as IAssociatedObject;
                ass.Object = arrow;
            }
            if (arrow.Arrow is IFactoryObject)
            {
                IFactoryObject f = arrow.Arrow as IFactoryObject;
                f.Facrory = Tools.Factory;
            }
            PureDesktop.PostSetArrow(arrow.Arrow);
        }

        /// <summary>
        /// Gets path from arrows
        /// </summary>
        /// <param name="arrows">Arrows</param>
        /// <returns>The path</returns>
        public static ArrayList GetPath(IList<IArrowLabel> arrows)
        {
            Hashtable hash = new Hashtable();
            foreach (IArrowLabelUI l in arrows)
            {
                IObjectLabel s = l.Source;
                object[] os = null;
                if (hash.Contains(s))
                {
                    os = hash[s] as object[];
                    if (os[1] != null)
                    {
                        throw new ErrorHandler.OwnException("Two sources");
                    }
                }
                else
                {
                    os = new object[3];
                    os[0] = s;
                    hash[s] = os;
                }
                os[1] = l;
                IObjectLabel t = l.Target;
                object[] ot = null;
                if (hash.Contains(t))
                {
                    ot = hash[t] as object[];
                    if (ot[2] != null)
                    {
                        throw new ErrorHandler.OwnException("Two targets");
                    }
                }
                else
                {
                    ot = new object[3];
                    ot[0] = t;
                    hash[t] = ot;
                }
                ot[2] = l;
            }
            object[] b = null;
            foreach (object[] o in hash.Values)
            {
                if ((o[1] != null) & (o[2] == null))
                {
                    b = o;
                    break;
                }
            }
            if (b == null)
            {
                throw new ErrorHandler.OwnException("Source is not defined");
            }
            ArrayList path = new ArrayList();
            while (true)
            {
                if (b[1] == null)
                {
                    break;
                }
                IArrowLabelUI a = b[1] as IArrowLabelUI;
                path.Add(a);
                b = hash[a.Target] as object[];
            }
            if (path.Count != arrows.Count)
            {
                throw new ErrorHandler.OwnException("Two paths");
            }
            return path;
        }

           /// <summary>
        /// Creates xml from objects and arriws
        /// </summary>
        /// <param name="objects">List of objects</param>
        /// <param name="arrows">List of arrows</param>
        /// <param name="doc">XML Document</param>
        /// <returns></returns>
        static public XmlElement CreateXml(IList<IObjectLabel> objects, IList<IArrowLabel> arrows, XmlDocument doc)
        {
            foreach (IArrowLabelUI label in arrows)
            {
                label.SourceNumber = objects.IndexOf(label.Source);
                label.TargetNumber = objects.IndexOf(label.Target);
            }
            XmlElement root = doc.CreateElement("Situation");
            XmlAttribute now = doc.CreateAttribute("DateTime");
            now.Value = DateTime.Now.ToString();
            root.Attributes.Append(now);
            XmlElement objectRoot = doc.CreateElement("Objects");
            foreach (IObjectLabelUI label in objects)
            {
                XmlElement element = label.CreateXml(doc);
                int id = objects.IndexOf(label);
                XmlAttribute attrId = doc.CreateAttribute("ObjectId");
                attrId.Value = id + "";
                element.Attributes.Append(attrId);
                objectRoot.AppendChild(element);
            }

            root.AppendChild(objectRoot);
            XmlElement arrowRoot = doc.CreateElement("Arrows");
            foreach (IArrowLabelUI label in arrows)
            {
                XmlElement element = label.CreateXml(doc);
                int id = arrows.IndexOf(label);
                XmlAttribute attrId = doc.CreateAttribute("ArrowId");
                attrId.Value = id + "";
                element.Attributes.Append(attrId);
                XmlAttribute sourceId = doc.CreateAttribute("SourceId");
                sourceId.Value = label.SourceNumber + "";
                element.Attributes.Append(sourceId);
                XmlAttribute sourceName = doc.CreateAttribute("SourceName");
                sourceName.Value = label.Source.Name;
                element.Attributes.Append(sourceName);
                XmlAttribute targetId = doc.CreateAttribute("TargetId");
                targetId.Value = label.TargetNumber + "";
                element.Attributes.Append(targetId);
                XmlAttribute targetName = doc.CreateAttribute("TargetName");
                targetName.Value = label.Target.Name;
                element.Attributes.Append(targetName);
                arrowRoot.AppendChild(element);
            }
            root.AppendChild(arrowRoot);
            return root;
        }

        /// <summary>
        /// Loads arrows and objects from stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="x">The x shift to set controls</param>
        /// <param name="y">The y shift to set controls</param>
        /// <param name="binder">Seialization binder</param>
        /// <returns>True in success and false otherwise</returns>
		public bool Load(Stream stream, int x, int y, SerializationBinder binder)
        {
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                load(stream, b);
                return true;

            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            BinaryFormatter bformatter = new BinaryFormatter();
            if (binder != null)
            {
                bformatter.Binder = binder;
                try
                {
                    load(stream, bformatter);
                    return true;
                }
                catch (Exception exc)
                {
                    exc.HandleException(10);
                }
            }
            return false;
        }

        /// <summary>
        /// The tools of this diagram
        /// </summary>
        public ToolsDiagram Tools
        {
            get
            {
                return tools;
            }
        }

        /// <summary>
        /// Active arrow
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICategoryArrow ActiveArrow
        {
            get
            {
                return activeArrow;
            }
            set
            {
                activeArrow = value;
            }
        }

        /// <summary>
        /// Pairs of objects
        /// </summary>
        public ArrayList Pairs
        {
            get
            {
                return pairs;
            }
        }

        /// <summary>
        /// Active label of object
        /// </summary>
        /// <summary>
        /// Active label of object
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IObjectLabel ActiveObjectLabel
        {
            get
            {
                return activeObjectLabel;
            }
            set
            {
                activeObjectLabel = value;
            }
        }

        /// <summary>
        /// Resizes background image
        /// </summary>
        public void ResizeImage()
        {
            if (Width <= 0 | Height <= 0)
            {
                return;
            }
            image = new Bitmap(Width, Height);
            clearImage();
        }

        /// <summary>
        /// Adds object label
        /// </summary>
        /// <param name="x">x - coordinate to set label</param>
        /// <param name="y">y - coordinate to set label</param>
        public void AddObjectLabel(int x, int y)
        {
            IObjectLabelUI label = tools.Factory.CreateObjectLabel(tools.Active);
            label.X = x;
            label.Y = y;
            if (label is Control)
            {
                StaticExtensionDiagramUIForms.PostLabelLoad(label);
            }
            Action<IObjectLabelUI> act = StaticExtensionDiagramUIForms.PostLabelLoad;
            if (act != null)
            {
                act(label);
            }
            ICategoryObject ob = tools.Factory.CreateObject(tools.Active);
            if (ob != null)
            {
                StaticExtensionDiagramUI.PostCreateObject(ob);
                label.Object = ob;
                ob.SetAssociatedObject(label);
                label.Object.SetAssociatedObject(label);
            }
            if (label is IContainerObjectLabel & !(ob is IObjectContainer))
            {
                label = tools.Factory.CreateLabel(ob) as IObjectLabelUI;
                ob.Object = label;
                label.Object = ob;
                label.Object.SetAssociatedObject(label);
                label.X = x;
                label.Y = y;
            }
            Controls.Add(label.Control as Control);
            if (label is IContainerObjectLabel)
            {
                IContainerObjectLabel cont = label as IContainerObjectLabel;
                IObjectContainer con = label.Object as IObjectContainer;
                con.Load();
                con.PostLoad();
                con.SetParents(this);
                cont.Expand();
            }
            tools.AddObjectNode(label);
        }
  
        /// <summary>
        /// Adds converter for drag
        /// </summary>
        /// <param name="converter">The converter to add</param>
        public void Add(ICategoryObjectConverter converter)
        {
            new DragDropConverter(converter, this);
        }

        /// <summary>
        /// Adds drag drop stream creator
        /// </summary>
        /// <param name="name">Creator name</param>
        /// <param name="afterDrag">After drag event</param>
        public void AddStreamCreator(string name, Action<Stream> afterDrag)
        {
            DragDropStream dds = new DragDropStream(name, this);
            if (afterDrag != null)
            {
                dds.AfterDrag += afterDrag;
                this.afterDrag = afterDrag;
            }
        }

        /// <summary>
        /// Adds arrow label to this component
        /// </summary>
        /// <param name="label">The label to add</param>
        public void AddArrowLabel(IArrowLabel label)
        {
            ObjectsPair pair = null;
            object[] ps = pairs.ToArray();
            for (int i = 0; i < ps.Length; i++)
            {
                ObjectsPair p = (ObjectsPair)ps[i];
                if (p.Belongs(label))
                {
                    pair = p;
                    break;
                }
            }
            if (pair == null)
            {
                pair = new ObjectsPair(label.Source, label.Target);
                pair.Desktop = this;
                pairs.Add(pair);
            }
            pair.Add(label as IArrowLabelUI);
            Controls.Add(label as Control);
            tools.AddArrowNode(label as IArrowLabelUI);
        }

        /// <summary>
        /// Removes object label
        /// </summary>
        /// <param name="label">The label to remove</param>
        public void Remove(IObjectLabelUI label)
        {
            label.RemoveFromComponent();
            for (int i = pairs.Count - 1; i >= 0; i--)
            {
                ObjectsPair p = pairs[i] as ObjectsPair;
                if (p.Belongs(label))
                {
                    p.Remove();
                }
            }
            if (label is IShowForm)
            {
                IShowForm sf = label as IShowForm;
                Form f = sf.Form as Form;
                if (f != null)
                {
                    if (f is IDisposable rf)
                    {
                        rf.Dispose();
                    }
                }
            }
            if (label is IDisposable rl)
            {
                rl.Dispose();
            }
            object obj = label.Object;
            if (obj is IDisposable ro)
            {
                ro.Dispose();
            }
            tools.RemoveObjectNode(label);
            GC.Collect();
        }

        /// <summary>
        /// Checks all objects
        /// </summary>
        public void CheckCorrectness()
        {
            foreach (Control c in Controls)
            {
                object o = null;
                if (c is IObjectLabel)
                {
                    IObjectLabel l = c as IObjectLabel;
                    o = l.Object;
                }
                else if (c is IArrowLabel)
                {
                    IArrowLabel l = c as IArrowLabel;
                    o = l.Arrow;
                }
                else
                {
                    continue;
                }
                if (!(o is ICheckCorrectness))
                {
                    continue;
                }
                ICheckCorrectness check = o as ICheckCorrectness;
                check.CheckCorrectness();
            }
        }

        /// <summary>
        /// Removes the pair of objects
        /// </summary>
        /// <param name="p">The pair to remove</param>
        public void Remove(ObjectsPair p)
        {
            pairs.Remove(p);
        }

        /// <summary>
        /// Gets resources string
        /// </summary>
        /// <param name="s">Source string</param>
        /// <param name="resources">Resources</param>
        /// <returns>Resources string</returns>
        public static string GetResourceString(String s, Dictionary<string, string> resources)
        {
            if (resources != null)
            {
                string rs = resources[s];
                if (rs != null)
                {
                    return rs;
                }
            }
            return s;
        }


        /// <summary>
        /// Checks order
        /// </summary>
        public void CheckOrder()
        {
            tools.Factory.CheckOrder(this);
        }

        /// <summary>
        /// Sets visibility for control and all its children
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="visible">The visible sign</param>
        public static void SetVisibility(Control control, bool visible)
        {
            control.Visible = visible;
            foreach (Control c in control.Controls)
            {
                SetVisibility(c, visible);
            }
        }

        /// <summary>
        /// Draws arrow from object label
        /// </summary>
        /// <param name="l">The object label</param>
        /// <param name="e">The event arguments</param>
        public void DrawArrow(Control l, MouseEventArgs e)
        {
            lock (this)
            {
                Redraw();
                Graphics g = Graphics.FromImage(image);
                float x = l.Left + l.Width / 2;
                float y = l.Top + l.Height / 2;
                g.DrawLine(linePen, x, y, e.X + l.Left, e.Y + l.Top);
                g.Dispose();
                Refresh();
            }
        }

        /// <summary>
        /// Cleaner of desktop
        /// </summary>
        public static IDesktopCleaner Cleaner
        {
            get
            {
                return cleaner;
            }
            set
            {
                cleaner = value;
            }
        }

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => component.Get<INamedComponent>();


        /// <summary>
        /// Redraws itself
        /// </summary>
        public void Redraw()
        {
            SetBlocking(true);
            RedrawImage();
            SetBlocking(false);
            Refresh();
        }

        /// <summary>
        /// Sets blocking
        /// </summary>
        /// <param name="blocked">Blocked</param>
        public void SetBlocking(bool blocked)
        {
            SetBlocking(this, blocked);
        }

        /// <summary>
        /// Sets blocking of control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="blocked">Blocked</param>
        public static void SetBlocking(Control control, bool blocked)
        {
            if (control is IBlocking)
            {
                IBlocking b = control as IBlocking;
                b.IsBlocked = blocked;
            }
            foreach (Control c in control.Controls)
            {
                SetBlocking(c, blocked);
            }
        }

 
        /// <summary>
        /// Temporary delete
        /// </summary>
        public void TempDelete()
        {
            DeleteAll(true);
        }

        /// <summary>
        /// Final Delete
        /// </summary>
        public void FinalDelete()
        {
            DeleteAll(false);
        }

        /// <summary>
        /// Saves desktop to C# code
        /// </summary>
        /// <param name="fileName">The fileName</param>
        /// <param name="namespacE">Namespace</param>
        /// <param name="className">Classname</param>
        public void SaveCSCodeToFile(string fileName, string namespacE, string className, bool staticClass = true)
        {
            MemoryStream stream = new MemoryStream();
            SaveAll(stream);
            // RemoveAll();
            PureDesktopPeer d = new PureDesktopPeer();
            bool b = d.Load(stream, null, true);
            //  d.Refresh();
            List<string> l = d.CreateInitDesktopCSharpCode(namespacE, className, staticClass);
            using (TextWriter w = new StreamWriter(fileName))
            {
                foreach (string s in l)
                {
                    w.WriteLine(s);
                }
            }
        }

        /// <summary>
        /// Refreshs itself
        /// </summary>
        public void RefreshObjects()
        {
            MemoryStream stream = new MemoryStream();
            SaveAll(stream);
            RemoveAll();
            PureDesktopPeer d = new PureDesktopPeer();
            bool b = d.Load(stream, null, true);
            SetBlocking(true);
            Copy(d.Objects, d.Arrows, true);
            this.PostSetArrow();
            this.PostLoad();
            PostLoadControl();
            SetBlocking(false);
            RedrawImage();
            Refresh();
        }

        public async Task<bool> LoadAsync(IDataAsync data, SerializationBinder binder, 
            string ext, string extd, CancellationToken cancellation)
        {
            var cur = Cursor;
            Cursor = Cursors.WaitCursor;
            try
            {
                var t = data.GetDataAsync(cancellation);
                await t;
                using var stream = new MemoryStream(t.Result);
                stream.Position = 0;
                var tt  = LoadFromStreamAsync(stream, binder, ext, extd);
                await tt;
                Cursor = cur;
                return tt.Result;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            Cursor = cur;
            return false;
        }

        public async Task<bool> LoadFromStreamAsync(Stream stream, SerializationBinder binder, string ext,
            string extd, bool changCuror = false)
        {
            var cur = Cursor;
            try
            {
                if (changCuror)
                {
                    Cursor = Cursors.WaitCursor;
                }
                Func<bool> f = () => LoadFromStreamInvoke(stream, binder, ext, extd);
                var t = Task.FromResult(f());
                await t;
                if (changCuror)
                {
                    Cursor = cur; ;
                }
                return t.Result;
            }
            catch (Exception e)
            {
                e.HandleException();
            }
            if (changCuror)
            {
                Cursor = cur; ;
            }
            return false;
        }

        public bool  LoadFromStreamInvoke(Stream stream, SerializationBinder binder, string ext, string extd)
        {
            bool b = false;
            var act = () =>
            {
                b = LoadFromStream(stream, binder, ext, extd);
            };
            this.InvokeIfNeeded(act);
            return b;
        }


        /// <summary>
        /// Loading
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="binder">Serialization binde</param>
        /// <param name="ext">Extension</param>
        /// <param name="extd">Typical extension</param>
        /// <returns>True in success and false otherwise</returns>
        public bool LoadFromStream(Stream stream, SerializationBinder binder, string ext, string extd)
        {
            PureDesktopPeer dp = new PureDesktopPeer();
            IDesktop d = dp;
            long pos = -1;
            bool b = true;
            if (ext.ToLower().Equals(extd))
            {
                b = dp.Load(stream, binder, true);
                pos = dp.StreamPosition;
            }
            else
            {
                IObjectContainer oc = stream.Deserialize<IObjectContainer>();
                oc.LoadDesktop();
                d = oc.Desktop;
            }
            if (b)
            {
                long k = 0;
                try
                {
                    SetBlocking(true);
                    d.Copy(this);
                    this.PostSetArrow();
                    this.PostLoad();
                    PostLoadControl();
                    RedrawImage();
                    SetBlocking(false);
                    Refresh();
                    List<object> c = dp.Comments;
                    ControlPanel.LoadControls(this, c);
                    k = pos;
                    if (k < 0)
                    {
                        k = stream.Position;
                    }
                }
                catch (Exception exception)
                {
                    exception.HandleException(1); ;
                }
                ControlPanel.LoadControls(this, stream, null, k);
            }
            return b;
        }

        /// <summary>
        /// Load from buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        public void Load(byte[] buffer)
        {
            PureDesktopPeer d = new PureDesktopPeer();
            d.Load(buffer);
            Load(d);
        }

        /// <summary>
        /// Loads itself from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public void Load(IDesktop desktop)
        {
            SetBlocking(true);
            desktop.Copy(this);
            this.PostLoad();
            RedrawImage();
            SetBlocking(false);
            Refresh();
            //ToolBox.ControlPanel.LoadControls(this, stream, null);
        }

        /// <summary>
        /// Gets double value of control
        /// </summary>
        /// <param name="c">Control</param>
        /// <param name="a">value</param>
        public static void GetValue(Control c, ref double a)
        {
            try
            {
                a = Double.Parse(c.Text);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        /// <summary>
        /// Gets int value of contol
        /// </summary>
        /// <param name="c">Control</param>
        /// <param name="a">Value</param>
        public static void GetValue(Control c, ref int a)
        {
            try
            {
                a = int.Parse(c.Text);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }

        /// <summary>
        /// Gets Values of controls
        /// </summary>
        /// <param name="c">Controls</param>
        /// <param name="a">Values</param>
        public static void GetValue(Control[] c, int[] a)
        {
            for (int i = 0; i < c.Length; i++)
            {
                GetValue(c[i], ref a[i]);
            }
        }

        /// <summary>
        /// Gets Values of controls
        /// </summary>
        /// <param name="c">Controls</param>
        /// <param name="a">Values</param>
        public static void GetValue(Control[] c, double[] a)
        {
            for (int i = 0; i < c.Length; i++)
            {
                GetValue(c[i], ref a[i]);
            }
        }

        /// <summary>
        /// Checks itself
        /// </summary>
        public void Check()
        {
            List<Exception> l = PureDesktopPeer.Check(this, null);
            if (l != null)
            {
                throw l[0];
            }
        }

        #region Private & Internal

        /// <summary>
        /// Loads itself
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="binder">Binder</param>
        /// <returns>True is success</returns>
        bool Load(string filename, SerializationBinder binder)
        {
            Stream stream = null;
            bool b = false;
            try
            {
                stream = File.OpenRead(filename);
                b = LoadFromStream(stream, binder, ext, ext);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            if (stream != null)
            {
                stream.Close();
            }
            return b;
        }

        /// <summary>
        /// Deletes all components
        /// </summary>
        private void DeleteAll(bool redraw)
        {
            DeleteComments();
            RemoveAll();
            if (!redraw)
            {
                return;
            }
            Redraw();
            Refresh();
            if (cleaner != null)
            {
                cleaner.Clean();
            }
            GC.Collect();
        }

        /// <summary>
        /// Removes object label
        /// </summary>
        /// <param name="label">The label to remove</param>
        internal void remove(IChildObjectLabel label)
		{
            Control c = label as Control;
			Controls.Remove(c);
			for (int i = pairs.Count - 1; i >= 0; i--)
			{
				ObjectsPair p = pairs[i] as ObjectsPair;
				if (p.belongs(label))
				{
					p.Remove();
				}
			}
            GC.Collect();
		}

        /// <summary>
        /// Post Load control operation
        /// </summary>
        private void PostLoadControl()
        {
            try
            {
                this.ForEach((IAssociatedObject ao) =>
                {
                    object o = ao.Object;
                    if (o is Control)
                    {
                        Control c = o as Control;
                        var children = c.FindChildren<IPostLoadControl>();
                        if (children != null)
                        {
                            foreach (var child in children)
                            {
                                child.PostLoad();
                            }
                        }
                    }
                });
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
            }
        }


        private void load(Stream stream, BinaryFormatter bformatter)
        {
            stream.Position = 0;
            object[] objs = (object[])bformatter.Deserialize(stream);
            object[] arrs = (object[])bformatter.Deserialize(stream);
            IObjectLabelUI[] objects = new IObjectLabelUI[objs.Length];
            IArrowLabelUI[] arrows = new IArrowLabelUI[arrs.Length];
            int i = 0;
            foreach (IObjectLabelUI obj in objs)
            {
                obj.ComponentButton = tools.FindButton(obj);
                obj.X += 0;
                obj.Y += 0;
                objects[i] = obj;
                obj.Initialize();
                AddNewObjectLabel(obj);
                tools.AddObjectNode(obj);
                ++i;
            }
            foreach (IArrowLabelUI arrow in arrs)
            {
                arrow.ComponentButton = tools.FindButton(arrow);
                arrow.Initialize();
                IObjectLabelUI source = objects[(int)arrow.SourceNumber];
                IObjectLabelUI target = objects[(int)arrow.TargetNumber];
                arrow.Arrow.Source = source.Object;
                arrow.Arrow.Target = target.Object;
                arrow.Source = source;
                arrow.Target = target;
                AddNewArrowLabel(arrow);
            }
            foreach (IObjectLabelUI lab in objects)
            {
                ICategoryObject obj = lab.Object;
                PureDesktop.PostSetArrow(obj);
            }
            foreach (IArrowLabelUI lab in arrs)
            {
                object obj = lab.Arrow;
                if (obj is IPostSerialize)
                {
                    IPostSerialize post = obj as IPostSerialize;
                    post.PostSerialize();
                }
            }
        }

        internal void Add(ICategoryObject ob, int x, int y)
        {
            IObjectLabelUI la = tools.Factory.CreateLabel(ob);
            la.X = x;
            la.Y = y;
            la.Object = ob;
            IObjectLabelUI label = tools.Factory.CreateObjectLabel(tools.FindButton(la));
            label.X = x;
            label.Y = y;
            if (ob != null)
            {
                label.Object = ob;
                ob.SetAssociatedObject(label);
                label.Object.SetAssociatedObject(label);
            }
            if (label is IContainerObjectLabel & !(ob is IObjectContainer))
            {
                label = tools.Factory.CreateLabel(ob);
                ob.Object = label;
                label.Object = ob;
                label.Object.SetAssociatedObject(label);
                label.X = x;
                label.Y = y;
            }
            Controls.Add(label.Control as Control);
            if (label is IContainerObjectLabel)
            {
                IContainerObjectLabel cont = label as IContainerObjectLabel;
                IObjectContainer con = label.Object as IObjectContainer;
                con.PostLoad();
                con.SetParents(this);
                cont.Expand();
            }
            tools.AddObjectNode(label);
        }

        /// <summary>
        /// Selects objects by mouse
        /// </summary>
        /// <param name="x">x- coordinate of mouse</param>
        /// <param name="y">y- coordinate of mouse</param>
        private void selectMouse(int x, int y)
		{
			int[,] corners = new int[4, 2];
			performsSelection = false;
			foreach (Control control in Controls)
			{
				if (!(control is INamedComponent))
				{
					continue;
				}
				INamedComponent comp = control as INamedComponent;
                corners[0, 0] = control.Left;
                corners[0, 1] = control.Top;
                corners[1, 0] = control.Left + control.Width;
                corners[1, 1] = control.Top;
                corners[2, 0] = control.Left + control.Width;
                corners[2, 1] = control.Top + control.Height;
                corners[3, 0] = control.Left;
                corners[3, 1] = control.Top + control.Height;
				bool sel = false;
				for (int i = 0; i < 4; i++)
				{
					double xc = corners[i, 0];
					double yc = corners[i, 1];
					if (xSelect < xc & x > xc & ySelect < yc & y > yc)
					{
						sel = true;
						break;
					}
				}
				if (sel)
				{
                    if (comp is IObjectLabelUI)
                    {
                        IObjectLabelUI olui = comp as IObjectLabelUI;
                        olui.Selected = true;
                    }
                    if (comp is IArrowLabelUI)
                    {
                        IArrowLabelUI alui = comp as IArrowLabelUI;
                        alui.Selected = true;
                    }
				}
			}
		}

		/// <summary>
		/// The "on mouse up" event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseUp(object sender, MouseEventArgs e)
		{
			if (performsSelection)
			{
				selectMouse(e.X, e.Y);
				return;
			}
			if (tools.Active == null)
			{
				return;
			}
			if (tools.Active.IsArrow)
			{
				if (activeArrow != null)
				{
					activeArrow = null;
				}
				return;
			}
			AddObjectLabel(e.X, e.Y);
		}
		
		/// <summary>
		/// The "on mouse down" event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseDownSelect(object sender, MouseEventArgs e)
		{
			if (Tools.Active == null)
			{
				return;
			}
			if (Tools.Active.ReflectionType != null)
			{
				return;
			}
			performsSelection = true;
			xSelect = e.X;
			ySelect = e.Y;
		}

		/// <summary>
		/// The "on mouse move" event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseMoveArrow(object sender, MouseEventArgs e)
		{
			if (!performsSelection)
			{
				return;
			}
			Graphics g = RedrawImage();
			g.DrawRectangle(linePen, xSelect, ySelect, e.X - xSelect, e.Y - ySelect);
			Refresh();
		}
		
		/// <summary>
		/// Redraws bakground image
		/// </summary>
		/// <returns></returns>
		private Graphics RedrawImage()
		{
			clearImage();
			lock(this)
			{
				Graphics g = Graphics.FromImage(image);
				object[] p = pairs.ToArray();
				for (int i = 0; i < p.Length; i++)
				{
					ObjectsPair pair = (ObjectsPair)p[i];
					pair.SetArrows(g);
				}
				return g;
			}
			
		}

        /// <summary>
        /// The "on paint" event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private void onPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(image, 0, 0, image.Width, image.Height);
        }



        /// <summary>
        /// Gets all objects of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        private void GetAll(PanelDesktop desktop, IList<ICategoryObject> objects, IList<ICategoryArrow> arrows)
        {
           IEnumerable<IObjectLabel> objs = Objects;
            foreach (IObjectLabel l in objs)
            {
                desktop.GetObjects(l.Object as IAssociatedObject, objects, arrows);
            }
            IEnumerable<IArrowLabel> arrs = Arrows;
            foreach (IArrowLabel l in arrs)
            {
                desktop.GetObjects(l.Arrow, objects, arrows);
            }
        }


        void GetObjects(IAssociatedObject ao, IList<ICategoryObject> objects, IList<ICategoryArrow> arrows)
        {
            if (ao is IObjectContainer)
            {
                IObjectContainer oc = ao as IObjectContainer;
                IDesktop d = oc.Desktop;
                IEnumerable<object> c = d.AllComponents;
                foreach (object o in c)
                {
                    if (o is IObjectLabel)
                    {
                        IObjectLabel ol = o as IObjectLabel;
                        GetObjects(ol.Object, objects, arrows);
                    }
                    if (o is IArrowLabel)
                    {
                        IArrowLabel al = o as IArrowLabel;
                        GetObjects(al.Arrow, objects, arrows);
                    }
                }
            }
            else
            {
                if (ao is ICategoryObject)
                {
                    ICategoryObject cob = ao as ICategoryObject;
                    if (!objects.Contains(cob))
                    {
                        objects.Add(cob);
                    }
                }
                if (ao is ICategoryArrow)
                {
                    ICategoryArrow car = ao as ICategoryArrow;
                    if (!arrows.Contains(car))
                    {
                        arrows.Add(car);
                    }
                }
                if (ao is IChildren<IAssociatedObject> co)
                {
                    IAssociatedObject[] ass = co.Children.ToArray();
                    if (ass != null)
                    {
                        foreach (IAssociatedObject asso in ass)
                        {
                            if (asso != null)
                            {
                                GetObjects(asso, objects, arrows);
                            }
                        }
                    }
                }
            }
        }

		/// <summary>
		/// Transforms object label
		/// </summary>
		/// <param name="o">Transformed object</param>
		/// <returns>Transformation result</returns>
		private static object transformObjectLabel(object o)
		{
			IObjectLabel l = o as IObjectLabel;
			return l.Object;
		}

		/// <summary>
		/// Transforms arrow label
		/// </summary>
		/// <param name="o">Transformed object</param>
		/// <returns>Transformation result</returns>
		private static object transformArrowLabel(object o)
		{
			IArrowLabel l = o as IArrowLabel;
			return l.Arrow;
		}

		/// <summary>
		/// Clears background image
		/// </summary>
		private void clearImage()
		{
			lock(this)
			{
				Graphics g = Graphics.FromImage(image);
				g.FillRectangle(brush, 0, 0, image.Width, image.Height);
				g.Dispose();
			}
		}


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PanelDesktop
            // 
            this.AutoSizeChanged += new System.EventHandler(this.PanelDesktop_SizeChanged);
            this.Resize += new System.EventHandler(this.PanelDesktop_SizeChanged);
            this.ResumeLayout(false);

        }

        private void copy(PureDesktopPeer desktop)
        {
            IDesktop d = desktop;
            d.Copy(Objects, Arrows, false);
            desktop.PreSave();
            List<object> comm = ControlPanel.GetComments(this);
            List<object> c = desktop.Comments;
            foreach (object o in comm)
            {
                c.Add(o);
            }
        }

        private void PanelDesktop_SizeChanged(object sender, EventArgs e)
        {
            ResizeImage();
            RedrawImage();
            Refresh();
        }

        bool Detect(string[] ob)
        {
            files.Clear();
            foreach (string fn in ob)
            {
               string ex = Path.GetExtension(fn);
                if (ex.ToLower().Equals(ext.ToLower()))
                {
                    files.Add(fn);
                }
            }
            return files.Count > 0;
        }

        void FileDragEnter(object sender, DragEventArgs e)
        {
            if (ext == null)
            {
                return;
            }
            IDataObject d = e.Data;
            if (d.GetDataPresent("FileDrop"))
            {
                string[] s = d.GetData("FileDrop") as string[];
                if (Detect(s))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void FileDragDrop(object sender, DragEventArgs e)
        {
            if (ext == null)
            {
                return;
            }
            IDataObject d = e.Data;
            if (d.GetDataPresent("FileDrop"))
            {
                string[] s = d.GetData("FileDrop") as string[];
              //  string[] o = d.GetData("FileNameW") as object[];
                if (Detect(s))
                {
                    if (files.Count == 1)
                    {
                        //  List<string> l = 
                        string fn = files[0];
                        string ex = System.IO.Path.GetExtension(fn);
                        if (ex.ToLower().Equals(ext.ToLower()))
                        {
                            Load(fn, SerializationInterface.StaticExtensionSerializationInterface.Binder);
                            if (afterDrag != null)
                            {
                                Stream st = File.OpenRead(fn);
                                afterDrag(st);
                             }
                            return;
                        }
                    }
                    files.ToArray().Start();    
                }
            }
        }

        IEnumerable<T> IComponentCollection.Get<T>()
        {
          return  p.GetObjectsAndArrows<T>(this);
        }
        #endregion

        #endregion

        #region

        #region IComponentCollection Members

        IEnumerable<object> IComponentCollection.AllComponents
        {
            get { return AllComponents; }
        }

        IDesktop IComponentCollection.Desktop
        {
            get { return this; }
        }

        #region NEW

        IEnumerable<IObjectLabel> IComponentCollection.Objects => collection.Get<IObjectLabel>();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => collection.Get<IArrowLabel>();

   
        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => collection.Get<ICategoryObject>();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => collection.Get<ICategoryArrow>();

        string INamed.Name { get => Name; set => Name = value; }

 
        void INode<IComponentCollection>.Add(INode<IComponentCollection> node)
        {
            Add(node);
        }

        void INode<IComponentCollection>.Remove(INode<IComponentCollection> node)
        {
            Remove(node);
        }

        INode<IComponentCollection> INode<IComponentCollection>.Parent { get => Parent; set { Parent = value; } }
        IEnumerable<INode<IComponentCollection>> INode<IComponentCollection>.Nodes { get => Children; set { } }

        IComponentCollection INode<IComponentCollection>.Value => this;

        protected INode<IComponentCollection> ParentNode
        {
            get; set;
        }

        protected virtual INode<IComponentCollection> Parent { get => ParentNode; set => ParentNode = value; }


        #endregion


        #endregion


        #endregion

        protected event Action<IComponentCollection> onAdd;

        protected event Action<IComponentCollection> onRemove;

        protected virtual event Action<IComponentCollection> OnAdd
        {
            add
            {
                onAdd += value;
            }

            remove
            {
                onAdd -= value;
            }
        }


        protected virtual event Action<IComponentCollection> OnRemove
        {
            add
            {
                onRemove += value;
            }

            remove
            {
                onRemove -= value;
            }
        }



        event Action<IComponentCollection> INode<IComponentCollection>.OnAdd
        {
            add
            {
                OnAdd += value;
            }

            remove
            {
                OnAdd -= value;
            }
        }

        event Action<IComponentCollection> INode<IComponentCollection>.OnRemove
        {
            add
            {
                OnRemove += value;

            }

            remove
            {
                OnRemove -= value;
            }
        }

        protected List<IComponentCollection> ChildrenNodes { get; } = new List<IComponentCollection>();

        protected virtual IEnumerable<IComponentCollection> Children => ChildrenNodes;

        protected virtual void Add(INode<IComponentCollection> collection)
        {
            ChildrenNodes.Add(collection.Value);
            onAdd?.Invoke(collection.Value);
        }

        protected virtual void Remove(INode<IComponentCollection> collection)
        {
            ChildrenNodes.Remove(collection.Value);
            onRemove?.Invoke(collection.Value);
        }

        void IDesktop.Copy(IEnumerable<IObjectLabel> objects, IEnumerable<IArrowLabel> arrows, bool associated)
        {
            var obj = objects.ToArray();
            var arrs = arrows.ToArray();
            Copy(obj, arrs, associated);
        }

        CancellationToken ICancellation.CancellationToken => cancellationToken;

        CancellationToken ICancellation.CreateCancellationToken()
        {
            cancellationToken = new CancellationToken();
            return cancellationToken; 
        }
    }
}
