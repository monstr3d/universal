using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using CategoryTheory;

using MathGraph;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using ErrorHandler;

using NamedTree;



namespace Diagram.UI
{
    /// <summary>
    /// Base class of desktop
    /// </summary>
    public class PureDesktop : IDesktop
    {
        IComponentCollection collection;

        /// <summary>
        /// All objects
        /// </summary>
        ICollection<object> allObjects;

        /// <summary>
        /// Desktop;
        /// </summary>
        IDesktop desktop;

        protected INode<IComponentCollection> ParentNode
        {
            get; set;
        }

        protected virtual INode<IComponentCollection> Parent { get => ParentNode; set => ParentNode = value; }

        protected List<IComponentCollection> ChildrenNodes { get; } = new List<IComponentCollection>();

        protected virtual IEnumerable<IComponentCollection> Children => ChildrenNodes;

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


        #region Fields

        Performer performer = new();

     //   NamedTree.Performer p = new ();

        IComponentCollection component;

     
        /// <summary>
        /// Parent container
        /// </summary>
        protected IObjectContainer parent;


        /// <summary>
        /// List of exceptios
        /// </summary>
        protected static List<Exception> exceptions;


        /// <summary>
        /// Objects
        /// </summary>
        protected List<IObjectLabel> objects = new List<IObjectLabel>();

        /// <summary>
        /// Arrows
        /// </summary>
        protected List<IArrowLabel> arrows = new List<IArrowLabel>();

 
        /// <summary>
        /// Auxiliary table for searching of componenrs
        /// </summary>
        protected Dictionary<string, INamedComponent> table = new Dictionary<string, INamedComponent>();

        /// <summary>
        /// String resources
        /// </summary>
        static private Dictionary<string,string> resources;

 
        /// <summary>
        /// Post Load
        /// </summary>
        private static event Action<IDesktop> desktopPostLoad;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PureDesktop()
        {
            collection = this;
            component = this;
        }

        #endregion


        #region IComponentCollection Members

        IEnumerable<object> IComponentCollection.AllComponents
        {
            get { return AllComponents.ToArray(); }
        }

        IDesktop IComponentCollection.Desktop
        {
            get { return desktop; }
        }

        #region NEW
        INode<IComponentCollection> INode<IComponentCollection>.Parent { get => Parent; set { Parent = value; } }
        IEnumerable<INode<IComponentCollection>> INode<IComponentCollection>.Nodes { get => Children; set { } }

        IComponentCollection INode<IComponentCollection>.Value => this;



        IEnumerable<IObjectLabel> IComponentCollection.Objects => collection.Get<IObjectLabel>();

        IEnumerable<IArrowLabel> IComponentCollection.Arrows => collection.Get<IArrowLabel>();

   
        IEnumerable<ICategoryObject> IComponentCollection.CategoryObjects => collection.Get<ICategoryObject>();

        IEnumerable<ICategoryArrow> IComponentCollection.CategoryArrows => collection.Get<ICategoryArrow>();

 
     
        void INode<IComponentCollection>.Add(INode<IComponentCollection> node)
        {
            Add(node);
        }

        void INode<IComponentCollection>.Remove(INode<IComponentCollection> node)
        {
            Remove(node);
        }

        #endregion


        #endregion



        #region IDesktop Members

        string INamed.Name
        {
            get => Name;
            set => Name = value;
        }

        IEnumerable<T> IComponentCollection.Get<T>() where T : class 
        {
            return performer.GetObjectsAndArrows<T>(this);
        }


        /// <summary>
        /// Array of all components
        /// </summary>
        public IEnumerable<object> Components
        {
            get
            {
                foreach (object o in objects)
                {
                    yield return o;
                }
                foreach (object o in arrows)
                {
                    yield return o;
                }
            }
        }

        /// <summary>
        /// All components
        /// </summary>
        public virtual IEnumerable<object> AllComponents
        {
            get
            {
                return Components.ToArray();
            }
        }

        /// <summary>
        /// Array of all objects
        /// </summary>
        public IEnumerable<IObjectLabel> Objects
        {
            get
            {
                foreach (IObjectLabel lab in objects)
                {
                    yield return lab;
                }
              }
        }

        /// <summary>
        /// Array of all arrows
        /// </summary>
        public IEnumerable<IArrowLabel> Arrows
        {
            get
            {
                foreach (IArrowLabel lab in arrows)
                {
                    yield return lab;
                }
            }
        }

        IEnumerable<INamedComponent> IComponentCollection.NamedComponents => component.GetAll<INamedComponent>();

        /// <summary>
        /// Copies objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="associated">Sign for setting associated objects</param>
        protected virtual void Copy(IEnumerable<IObjectLabel> objects, 
            IEnumerable<IArrowLabel> arrows, bool associated)
        {
            List<IObjectLabel> objs = new List<IObjectLabel>();
            List<IObjectLabel> tobjs = new List<IObjectLabel>();
            foreach (IObjectLabel l in objects)
            {
                objs.Add(l);
                IObjectLabel lab = new PureObjectLabel(l.Name, l.Kind, l.Type, l.X, l.Y);
                tobjs.Add(lab);
                lab.Object = l.Object;
                lab.Desktop = this;
                this.objects.Add(lab);
                if (l.Object is IObjectContainer)
                {
                    IObjectContainer oc = l.Object as IObjectContainer;
                    oc.SetParents(this);
                    oc.Load();
                }
                // components.Add(lab);
                table[l.Name] = lab;
            }
            List<IArrowLabel> arrs = new List<IArrowLabel>();
            foreach (IArrowLabel l in arrows)
            {
                IArrowLabel lab = new PureArrowLabel(l.Name, l.Kind, l.Type, l.X, l.Y);
                lab.Arrow = l.Arrow;
                lab.Desktop = this;
                arrs.Add(lab);
                table[l.Name] = lab;
                IObjectLabel source = Find(objs, tobjs, l.Source, l.Desktop);
                IObjectLabel target = Find(objs, tobjs, l.Target, l.Desktop);
                lab.Source = source;
                lab.Target = target;
            }
            if (!associated)
            {
                return;
            }
            this.SetParents();
            PureObjectLabel.SetLabels(objects);
            PureArrowLabel.SetLabels(arrs);
            foreach (IArrowLabel l in arrs)
            {
                this.arrows.Add(l);
            }
        }


        /// <summary>
        /// Access to component
        /// </summary>
        /// <param name="name">Component name</param>
        /// <returns>The component</returns>
        public virtual INamedComponent this[string name]
        {
            get
            {
                if (table.ContainsKey(name))
                {
                    return table[name] as INamedComponent;
                }
                INamedComponent nc = GetFromRoot(this, name);
                if (nc != null)
                {
                    return nc;
                }
                nc = this.GetChild(name);
                if (nc != null)
                {
                    return nc;
                }
                return null;
            }
        }

        /// <summary>
        /// Access to object
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>The object</returns>
        public object GetObject(string name)
        {
            return this.GetAssociatedObject(name);
        }

        /// <summary>
        /// Parent desktop
        /// </summary>
        public virtual IDesktop ParentDesktop
        {
            get
            {
                return parentDesktop;
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
        public virtual IDesktop Root
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Category objects
        /// </summary>
        public IEnumerable<ICategoryObject> CategoryObjects
        {
            get
            {
                IList<ICategoryObject> objs = new List<ICategoryObject>();
                IList<ICategoryArrow> arrs = new List<ICategoryArrow>();
                GetAllPrivate(this, objs, arrs);
                return objs;
            }
        }
        
        /// <summary>
        /// Category arrows
        /// </summary>
        public IEnumerable<ICategoryArrow> CategoryArrows
        {
            get
            {
                IList<ICategoryObject> objs = new List<ICategoryObject>();
                IList<ICategoryArrow> arrs = new List<ICategoryArrow>();
                GetAllPrivate(this, objs, arrs);
                return arrs;
            }
        }



        #endregion

        #region Specific members

        #region Public Members

        /// <summary>
        /// Gets child named component form root desktop
        /// </summary>
        /// <param name="desktop">Root desktop</param>
        /// <param name="name">Name of object</param>
        /// <returns>The child component</returns>
        static public INamedComponent GetFromRoot(IDesktop desktop, string name)
        {
            if (name.Length >= 3)
            {
                if (name.Substring(0, 3).Equals("../"))
                {
                    PureDesktop d = desktop as PureDesktop;
                    IObjectContainer cont = d.parent;
                    IAssociatedObject ao = cont as IAssociatedObject;
                    INamedComponent cnc = ao.Object as INamedComponent;
                    INamedComponent nc = cnc.Desktop[name.Substring(3)];
                    if (nc != null)
                    {
                        return nc;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// The "has parent" sign
        /// </summary>
        public bool HasParent
        {
            get;
            set;
        } = false;

        /// <summary>
        /// Sets names of objects
        /// </summary>
        public void SetObjectNames()
        {
            foreach (IObjectLabel label in objects)
            {
                table[label.Name] = label;
            }
        }

        /// <summary>
        /// Clears all components
        /// </summary>
        public virtual void ClearAll()
        {
            arrows.Clear();
            objects.Clear();
        }

        /// <summary>
        /// Gets objects from names
        /// </summary>
        /// <param name="names">Names</param>
        /// <param name="desktop">Desktop</param>
        /// <returns>Objects</returns>
        public static object[] GetObjects(ICollection<string> names, IDesktop desktop)
        {
            List<object> l = new List<object>();
            foreach (string name in names)
            {
                l.Add(desktop.GetObject(name));
            }
            return l.ToArray();
        }
  
        /// <summary>
        /// Gets names of objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The names</returns>
        public static string[] GetObjectNames<T>(IDesktop desktop) where T : class
        {
            List<string> l = new List<string>();
            T[] objs = desktop.GetAll<T>();
            foreach (T o in objs)
            {
                if (!(o is IAssociatedObject))
                {
                    continue;
                }
                IAssociatedObject ao = o as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                l.Add(nc.GetName(desktop));
            }
            return l.ToArray();
        }

 
        /// <summary>
        /// Performs action with object
        /// Throws associated exception
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="o">Associated object</param>
        public static void PerformObjectAction(Action action, object o)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                exception.HandleException(0);
            }
        }

 
        /// <summary>
        /// Sorts list of objects
        /// </summary>
        /// <param name="labels">Objects</param>
        /// <returns>Sorted list</returns>
        public static IList<IObjectLabel> Sort(IList<IObjectLabel> labels)
        {
            Dictionary<string, IObjectLabel> d = new Dictionary<string, IObjectLabel>();
            List<string> l = new List<string>();
            foreach (IObjectLabel lab in labels)
            {
                string n = lab.Name;
                l.Add(n);
                d[n] = lab;
            }
            l.Sort();
            IList<IObjectLabel> list = new List<IObjectLabel>();
            foreach (string s in l)
            {
                list.Add(d[s]);
            }
            return list;
        }

        public void PreSave()
        {
            try
            {
                this.SetParents();
                PureObjectLabel.SetType(objects);
                PureArrowLabel.SetType(arrows);
                foreach (IArrowLabel label in arrows)
                {
                    if (objects.Contains(label.Source))
                    {
                        label.SourceNumber = objects.IndexOf(label.Source);
                    }
                    else
                    {
                        IObjectLabel ls = label.Source.GetRoot(this) as IObjectLabel;
                        int sn = objects.IndexOf(ls);
                        IObjectContainer scont = ls.Object as IObjectContainer;
                        string ns = scont.GetName(label.Source);
                        label.SourceNumber = new object[] { sn, ns };
                    }
                    if (objects.Contains(label.Target))
                    {
                        label.TargetNumber = objects.IndexOf(label.Target);
                    }
                    else
                    {
                        IObjectLabel lt = label.Target.GetRoot(this) as IObjectLabel;
                        int tn = objects.IndexOf(lt);
                        IObjectContainer tcont = lt.Object as IObjectContainer;
                        string nt = tcont.GetName(label.Target);
                        label.TargetNumber = new object[] { tn, nt };
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Pure desktop. Presave");
            }
            
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
 

        /// <summary>
        /// Table of resources
        /// </summary>
        static public Dictionary<string,string> Resources
        {
            set
            {
                foreach (string o in value.Keys)
                {
                    if (!(o is string))
                    {
                        throw new OwnException("Resources exception 1");
                    }
                    if (!(value[o] is String))
                    {
                        throw new OwnException("Resources exception 2");
                    }
                }
                resources = value;
            }
        }

        /// <summary>
        /// Creates digraph from objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="checkObject">Checks objects</param>
        /// <param name="checkArrow">Checks arrows</param>
        /// <returns>The digraph</returns>
        static public Digraph CreateDigraph(List<IObjectLabel> objects, List<IArrowLabel> arrows,
            CheckObject checkObject, CheckObject checkArrow)
        {
            Digraph graph = new Digraph();
            foreach (IArrowLabel label in arrows)
            {
                if (checkArrow != null)
                {
                    if (!checkArrow(label))
                    {
                        continue;
                    }
                }
                label.SourceNumber = objects.IndexOf(label.Source);
                label.TargetNumber = objects.IndexOf(label.Target);
            }
            List<DigraphVertex> vertices = new List<DigraphVertex>();
            foreach (IObjectLabel label in objects)
            {
                if (checkObject != null)
                {
                    if (!checkObject(label))
                    {
                        continue;
                    }
                }
                DigraphVertex v = new DigraphVertex(graph);
                vertices.Add(v);
                v.Object = label;
            }
            foreach (IArrowLabel label in arrows)
            {
                if (checkArrow != null)
                {
                    if (!checkArrow(label))
                    {
                        continue;
                    }
                }
                DigraphEdge edge = new DigraphEdge();
                edge.Object = label;
                if (label.SourceNumber is Int32 && label.TargetNumber is Int32)
                {
                    int sourceNum = (int)label.SourceNumber;
                    DigraphVertex vs = vertices[sourceNum] as DigraphVertex;
                    edge.Source = vs;
                    int targetNum = (int)label.TargetNumber;
                    DigraphVertex vt = vertices[targetNum] as DigraphVertex;
                    edge.Target = vt;
                }
            }
            return graph;
        }

        /// <summary>
        /// Creates digraph from objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <returns>The digraph</returns>
        static public Digraph CreateDigraph(IList<IObjectLabel> objects, IList<IArrowLabel> arrows)
        {
            Digraph graph = new Digraph();
            foreach (IArrowLabel label in arrows)
            {
                label.SourceNumber = objects.IndexOf(label.Source);
                label.TargetNumber = objects.IndexOf(label.Target);
            }
            List<DigraphVertex> vertices = new List<DigraphVertex>();
            foreach (IObjectLabel label in objects)
            {
                DigraphVertex v = new DigraphVertex(graph);
                vertices.Add(v);
                v.Object = label;
            }
            foreach (IArrowLabel label in arrows)
            {
                DigraphEdge edge = new DigraphEdge();
                edge.Object = label;
                if (label.SourceNumber is Int32 && label.TargetNumber is Int32)
                {
                    int sourceNum = (int)label.SourceNumber;
                    DigraphVertex vs = vertices[sourceNum] as DigraphVertex;
                    edge.Source = vs;
                    int targetNum = (int)label.TargetNumber;
                    DigraphVertex vt = vertices[targetNum] as DigraphVertex;
                    edge.Target = vt;
                }
            }
            return graph;
        }

 

        /// <summary>
        /// Gets resources string
        /// </summary>
        /// <param name="str">String name</param>
        /// <returns>The resources string</returns>
        static public string GetResourceString(string str)
        {
            if (resources != null)
            {
                if (resources.ContainsKey(str))
                {
                    return resources[str] as string;
                }
            }
            return str;
        }

 
        /// <summary>
        /// Disposes all objects of collection
        /// </summary>
        /// <param name="collection">The collection</param>
        static public void DisposeCollection(ICollection collection)
        {
            foreach (object o in collection)
            {
                StaticExtensionDiagramUI.DisposeAssociatedObject(o);
            }
        }

        /// <summary>
        /// Post load desktop operation
        /// </summary>
        static public event Action<IDesktop> DesktopPostLoad
        {
            add { desktopPostLoad += value; }
            remove { desktopPostLoad -= value; }
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

        /// <summary>
        /// Post load operation
        /// </summary>
        /// <param name="desktop">The desktop for post load</param>
        public static void PostLoad(IDesktop desktop)
        {
            desktopPostLoad?.Invoke(desktop);
        }

        /// <summary>
        /// Finds object from array
        /// </summary>
        /// <param name="source">Source labels</param>
        /// <param name="target">Target labels</param>
        /// <param name="label">Prototype label</param>
        /// <param name="desktop">The desktop</param>
        /// <returns>Found object</returns>
        /// <summary>
        /// Finds object from array
        /// </summary>
        /// <param name="source">Source labels</param>
        /// <param name="target">Target labels</param>
        /// <param name="label">Prototype label</param>
        /// <param name="desktop">The desktop</param>
        /// <returns>Found object</returns>
        static public IObjectLabel Find(IList<IObjectLabel> source, IList<IObjectLabel> target, IObjectLabel label, IDesktop desktop)
        {
            if (source.Contains(label))
            {
                int n = source.IndexOf(label);
                return target[n] as IObjectLabel;
            }
            IObjectLabel ol = label.GetRoot(desktop) as IObjectLabel;
            int nt = source.IndexOf(ol);
            IObjectContainer oct = ol.Object as IObjectContainer;
            string tn = oct.GetName(label);
            IObjectLabel ot = target[nt] as IObjectLabel;
            IObjectContainer ct = ot.Object as IObjectContainer;
            return ct[tn] as IObjectLabel;
        }


        /// <summary>
        /// Recursive post set arrow
        /// </summary>
        /// <param name="obj">Object for post set arrow</param>
        public static void PostSetArrow(IAssociatedObject obj)
        {
            try
            {
                if (obj == null)
                {
                    return;
                }
                if (obj is IPostSetArrow)
                {
                    IPostSetArrow p = obj as IPostSetArrow;
                    p.PostSetArrow();
                }
                if (obj is IChildren<IAssociatedObject> cho)
                {
                    IAssociatedObject[] ch = cho.Children.ToArray();
                    if (ch != null)
                    {
                        foreach (IAssociatedObject ao in ch)
                        {
                            PostSetArrow(ao);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("PostSetArrow(IAssociatedObject obj)");
            }
        }

        /// <summary>
        /// Recursive post set arrow
        /// </summary>
        /// <param name="obj">Object for post set arrow</param>
        public static void PostSetObject(IAssociatedObject obj)
        {
            if (obj == null)
            {
                return;
            }
            if (obj is IPostSetObject p)
            {
                p.PostSetObject();
            }
            if (obj is IChildren<IAssociatedObject> cho)
            {
                IAssociatedObject[] ch = cho.Children.ToArray();
                if (ch != null)
                {
                    foreach (IAssociatedObject ao in ch)
                    {
                        PostSetObject(ao);
                    }
                }
            }
        }


        #endregion


        #region Protected Members

        /// <summary>
        /// The post load operation
        /// </summary>
        /// <returns></returns>
        public bool PostLoad()
        {
            try
            {
                PureObjectLabel.SetLabels(this.Objects);
                PureArrowLabel.SetLabels(this.Arrows);
                this.SetParents();
                IEnumerable<object> components = Components;
                foreach (INamedComponent nc in components)
                {
                    nc.Desktop = this;
                    table[nc.Name] = nc;
                    if (nc is IObjectLabel)
                    {
                        IObjectLabel ol = nc as IObjectLabel;
                        if (ol.Object is IObjectContainer)
                        {
                            IObjectContainer oc = ol.Object as IObjectContainer;
                            bool b = oc.PostLoad();
                            if (!b)
                            {
                                return false;
                            }
                        }
                    }
                }
                foreach (IArrowLabel arrow in arrows)
                {
                    IObjectLabel source = null;
                    IObjectLabel target = null;
                    if (arrow.SourceNumber is Int32)
                    {
                        source = objects[(int)arrow.SourceNumber] as IObjectLabel;
                    }
                    else
                    {
                        object[] os = arrow.SourceNumber as object[];
                        IObjectLabel so = objects[(int)os[0]] as IObjectLabel;
                        IObjectContainer sc = so.Object as IObjectContainer;
                        source = sc[os[1] as string] as IObjectLabel;
                    }
                    if (arrow.TargetNumber is Int32)
                    {
                        target = objects[(int)arrow.TargetNumber] as IObjectLabel;
                    }
                    else
                    {
                        object[] ot = arrow.TargetNumber as object[];
                        IObjectLabel to = objects[(int)ot[0]] as IObjectLabel;
                        IObjectContainer tc = to.Object as IObjectContainer;
                        target = tc[ot[1] as string] as IObjectLabel;
                    }
                    arrow.Arrow.Source = source.Object;
                    arrow.Arrow.Target = target.Object;
                    arrow.Source = source;
                    arrow.Target = target;
                    IAssociatedObject ass = arrow.Arrow as IAssociatedObject;
                    ass.Object = arrow;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                if (exceptions != null)
                {
                    exceptions.Add(ex);
                }
            }
            return false;
        }

        /// <summary>
        /// Parent desktop
        /// </summary>
        internal IDesktop parentDesktop
        {
            get
            {
                if (parent == null)
                {
                    return null;
                }
                IAssociatedObject obj = parent as IAssociatedObject;
                INamedComponent nc = obj.Object as INamedComponent;
                return nc.Desktop;
            }
        }

        internal void setParent(IObjectContainer parent)
        {
            this.parent = parent;
        }


        /// <summary>
        /// Post deserialization operation
        /// </summary>
        /// <returns>True in success and false otherwise</returns>
        protected bool PostDeserialize()
        {
            try
            {
                var objects = CategoryObjects;
                foreach (var obj in objects)
                {
                    if (obj is IPostDeserialize deserialize)
                    {
                        deserialize.PostDeserialize();
                    }
                }
                var arrows = CategoryArrows;
                foreach (var arrow in arrows)
                {
                    if (arrow is IPostDeserialize deserialize)
                    {
                        deserialize.PostDeserialize();
                    }
                }
                foreach (var arrow in arrows)
                {
                    PostSetArrow(arrow);
                }
                foreach (var lab in objects)
                {
                    PostSetArrow(lab);
                }
                foreach (ICategoryArrow lab in arrows)
                {
                    if (lab is IPostSerialize)
                    {
                        IPostSerialize post = lab as IPostSerialize;
                        post.PostSerialize();
                    }
                }
                if (!HasParent)
                {
                    PostLoad(this);
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.HandleException(10, "PureDesktop.PostDeserialize");
                if (exceptions != null)
                {
                    exceptions.Add(ex);
                }
            }
            return false;
        }      
        
        /// <summary>
        /// Gets objects and arrows of associated object
        /// </summary>
        /// <param name="ao">The associated object</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        protected virtual void GetObjects(IAssociatedObject ao, IList<ICategoryObject> objects, IList<ICategoryArrow> arrows)
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
                GetObjectsPrivate(ao, objects, arrows);
            }
        }

        /// <summary>
        /// Creates default object from string
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="type">Type of object</param>
        /// <returns>The object</returns>
        protected static object Create(string s, Type type)
        {
            if (type.Equals(typeof(string)))
            {
                return s;
            }
            if (type.Equals(typeof(int)))
            {
                return Int32.Parse(s);
            }
            return null;
        }



        #endregion


        #region Internal Members

        internal IObjectContainer internalParent
        {
            get
            {
                return parent;
            }
        }


        #endregion


        #region Private Members

        private void GetObjectsPrivate(IAssociatedObject ao, IList<ICategoryObject> objects, IList<ICategoryArrow> arrows)
        {
            {
                if (ao is ICategoryObject)
                {
                    objects.Add(ao as ICategoryObject);
                }
                if (ao is ICategoryArrow)
                {
                    arrows.Add(ao as ICategoryArrow);
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

        protected virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets all arrows and objects
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        private void GetAllPrivate(PureDesktop desktop, IList<ICategoryObject> objects, IList<ICategoryArrow> arrows)
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






        #endregion

        #endregion

        #region Overriden

        /// <summary>
        /// To string overriden
        /// </summary>
        /// <returns>Overriden to string</returns>
        public override string ToString()
        {
            string s = base.ToString();
            if (Name != null)
            {
                if (Name.Length > 0)
                {
                    return Name + " (" + s + ")";
                }
            }
            return s;
        }

        void IDesktop.Copy(IEnumerable<IObjectLabel> objects, IEnumerable<IArrowLabel> arrows, bool associated)
        {
            Copy(objects, arrows, associated);
        }

        #endregion

    }

    #region Helper Delegate

    /// <summary>
    /// Delegate of object checking
    /// </summary>
    /// <param name="obj">The object</param>
    /// <returns>True if object is checked and false otherwise</returns>
    public delegate bool CheckObject(object obj);


    #endregion

}
