using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CategoryTheory;
using Diagram.UI.Interfaces;
using ErrorHandler;
using NamedTree;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Pure object label
    /// </summary>
    public class PureObjectLabel : IObjectLabel, IDisposable
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected ICategoryObject obj;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;

        /// <summary>
        /// Kind
        /// </summary>
        protected string kind;

        /// <summary>
        /// Type
        /// </summary>
        protected string type;

        /// <summary>
        /// The x coordinate
        /// </summary>
        protected int x;

        /// <summary>
        /// The y coorditate
        /// </summary>
        protected int y;

        /// <summary>
        /// The desktop
        /// </summary>
        protected IDesktop desktop;

        /// <summary>
        /// The parent
        /// </summary>
        protected INamedComponent parent;

  
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PureObjectLabel()
        {

        }

        /// <summary>
        /// Constructot
        /// </summary>
        /// <param name="name">Name of label</param>
        /// <param name="kind">Kind</param>
        /// <param name="objectType">Object type</param>
        /// <param name="x">X - position</param>
        /// <param name="y">Y - position</param>
        public PureObjectLabel(string name, string kind, Type objectType, int x, int y) :
            this(name, kind, objectType.ToString(), x, y)
        {

        }

        /// <summary>
        /// Constructot
        /// </summary>
        /// <param name="name">Name of label</param>
        /// <param name="kind">Kind</param>
        /// <param name="type">Type</param>
        /// <param name="x">X - position</param>
        /// <param name="y">Y - position</param>
        public PureObjectLabel(string name, string kind, string type, int x, int y)
        {
            this.name = name;
            this.kind = kind;
            this.type = type;
            this.x = x;
            this.y = y;
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Associated object
        /// </summary>
        public ICategoryObject Object
        {
            get
            {
                 return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                throw new IllegalSetPropetryException("NAME PROHIBITED");
            }
        }

        /// <summary>
        /// Kind
        /// </summary>
        public string Kind
        {
            get
            {
                return kind;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public void Remove()
        {
        }

        /// <summary>
        /// X - position
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Y - position
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// The desktop
        /// </summary>
        public IDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
            }
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Ord
        {
            get
            {
                return StaticExtensionDiagramUI.GetOrder<object>(desktop.Components, this);
            }
        }

        /// <summary>
        /// Parent component
        /// </summary>
        public INamedComponent Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Gets root component
        /// </summary>
        /// <param name="desktop">Desktop of root</param>
        /// <returns>The root</returns>
        public INamedComponent GetRoot(IDesktop desktop)
        {
            return GetRoot(this, desktop);
        }

        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        public virtual string GetName(IDesktop desktop)
        {
            return GetName(this, desktop);
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
                return GetRoot(this);
            }
        }

        string INamed.NewName { get; set; }

        #endregion

        #region Specific members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RootName + " (" + base.ToString() + ")";
        }

        /// <summary>
        /// Gets root component
        /// </summary>
        /// <param name="comp">Prototype</param>
        /// <param name="desktop">Root's desktop</param>
        /// <returns>The root</returns>
        public static INamedComponent GetRoot(INamedComponent comp, IDesktop desktop)
        {
            if (comp.Desktop == desktop)
            {
                return comp;
            }
            if (comp.Parent == null)
            {
                return comp;
            }
            return GetRoot(comp.Parent, desktop);
        }

        /// <summary>
        /// Sets type to itself
        /// </summary>
        public void SetType()
        {
            if (type == null)
            {
                type = Object.GetType().ToString();
            }
            if (type.Length == 0)
            {
                type = Object.GetType().ToString();
            }
        }

        /// <summary>
        /// Sets type for collection members
        /// </summary>
        /// <param name="c"></param>
        public static void SetType(ICollection c)
        {
            foreach (PureObjectLabel l in c)
            {
                l.SetType();
            }
        }

        /// <summary>
        /// Sets associated labels
        /// </summary>
        /// <param name="c">Collection of labels</param>
        static public void SetLabels(IEnumerable<IObjectLabel> c)
        {
            foreach (IObjectLabel l in c)
            {
                ICategoryObject o = l.Object;
                o.SetAssociatedObject(l);
            }
        }

        /// <summary>
        /// Suffix of alias
        /// </summary>
        /// <param name="str">alias</param>
        /// <returns>The suffix</returns>
        static public string Suffix(string str)
        {
            int n = str.LastIndexOf(".");
            return str.Substring(n + 1);
        }

        /// <summary>
        /// Checks whether str has prefix of component name 
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="str">String to check</param>
        /// <returns>The component and null otherwise</returns>
        static public INamedComponent PrefixComponent(object obj, string str)
        {
            if (!(obj is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ass = obj as IAssociatedObject;
            if (!(ass.Object is INamedComponent))
            {
                return null;
            }
            INamedComponent c = ass.Object as INamedComponent;
            int n = str.LastIndexOf(".");
            string s = str.Substring(0, n);
            if (s.Equals(c.Name))
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets root of the component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The root</returns>
        static public INamedComponent GetRoot(INamedComponent component)
        {
            IDesktop d = component.Desktop;
            if (d == null)
            {
                return component;
            }
            IDesktop desk = d.Root;
            return GetRoot(component, desk);
        }

        /// Gets relative name
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>The relative name</returns>
        static public string GetRelativeName(INamedComponent source, INamedComponent target)
        {
            return target.GetName(source.Desktop);
        }



        /// <summary>
        /// Checks whether str has prefix of component name
        /// </summary>
        /// <param name="ao">Relative object</param>
        /// <param name="obj">Object</param>
        /// <param name="str">String to check</param>
        /// <returns>The component and null otherwise</returns>
        static public INamedComponent PrefixComponent(IAssociatedObject ao, object obj, string str)
        {
            if (!(obj is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ass = obj as IAssociatedObject;
            if (!(ass.Object is INamedComponent))
            {
                return null;
            }
            INamedComponent c = ass.Object as INamedComponent;
            int n = str.LastIndexOf(".");
            string s = str.Substring(0, n);
            if (s.Equals(ao.GetRelativeName(ass)))
            {
                return c;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets object aliases
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="o">object</param>
        /// <param name="list">List of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetObjectAliases(IAssociatedObject baseObject, object o, List<string> list, object type)
        {
            IAssociatedObject ass = o as IAssociatedObject;
            IObjectLabel l = ass.Object as IObjectLabel;
            GetAliases(baseObject, l, list, type);
        }

        /// <summary>
        /// Gets all object aliases
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="o">object</param>
        /// <param name="list">List of aliases</param>
        /// <param name="type">Type of alias</param>
        public static void GetAllObjectAliases(IAssociatedObject baseObject, object o, List<string> list, object type)
        {
            IAssociatedObject ass = o as IAssociatedObject;
            IObjectLabel l = ass.Object as IObjectLabel;
            GetAllAliases(baseObject, l, list, type);
        }

        /// <summary>
        /// Gets aliases of associated object
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="lab">Label</param>
        /// <param name="list">List</param>
        /// <param name="type">Type of object</param>
        static public void GetAliases(IAssociatedObject baseObject, IObjectLabel lab, List<string> list, object type)
        {
            object ob = baseObject.Object;
            if (ob == null)
            {
                return;
            }
            INamedComponent nc = baseObject.Object as INamedComponent;
            GetAllAliases(nc, lab.Object, lab, list, type);
        }

        /// <summary>
        /// Gets list of aliases of associated object
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="lab">Label</param>
        /// <param name="list">List</param>
        /// <param name="type">Type of object</param>
        static public void GetAllAliases(IAssociatedObject baseObject, IObjectLabel lab, List<string> list, object type)
        {
            INamedComponent nc = baseObject.Object as INamedComponent;
            GetAllAliases(nc, lab.Object, lab, list, type);
        }

        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        public static string GetName(INamedComponent component, IDesktop desktop)
        {
            string name = GetDirectName(component, desktop);
            if (name != null)
            {
                return name;
            }
            IDesktop cd = component.Desktop;
            if (cd == null)
            {
                return component.Name;
            }
            int lc = cd.Level;
            int ld = desktop.Level;
            string p = "";
            List<IDesktop> lic = new List<IDesktop>();
            IDesktop dd = cd;
            while (true)
            {
                lic.Add(dd);
                dd = dd.ParentDesktop;
                if (dd == null)
                {
                    break;
                }
            }
            List<IDesktop> lid = new List<IDesktop>();
            dd = desktop;
            while (true)
            {
                lid.Add(dd);
                dd = dd.ParentDesktop;
                if (dd == null)
                {
                    break;
                }
            }

            int ic = 0;
            IDesktop dc = null;
            int jc = 0;
            for (; ic < lic.Count; ic++)
            {
                dc = lic[ic];
                for (jc = 0; jc < lid.Count; jc++)
                {
                    if (dc == lid[jc])
                    {
                        goto fin;
                    }
                }
            }
        fin:
            int kp = jc;
            for (int ii = 0; ii < kp; ii++)
            {
                p += "../";
            }
            string ph = GetDirectName(component, dc);
            if (ph == null)
            {
                return null;
            }
            return p + ph;
        }
               
        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="component">The component</param>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        private static string GetDirectName(INamedComponent component, IDesktop desktop)
        {
            if ((desktop == null) | (component == null))
            {
                return null;
            }
            string cn = component.Name;
            if (desktop == component.Desktop)
            {
                return cn;
            }
            string pn = GetDirectName(component.Parent, desktop);
            if (pn == null)
            {
                return null;
            }
            return pn + "/" + cn;
        }

        static private void GetAllAliases(INamedComponent nc, object o, IObjectLabel lab, List<string> list, object type)
        {
            if (o == null)
            {
                return;
            }
            IDesktop d = nc.Desktop;
            if (o is IAliasBase)
            {
                IAliasBase ab = o as IAliasBase;
                if (ab is IAlias)
                {
                    IAlias al = ab as IAlias;
                    foreach (string s in al.AliasNames)
                    {
                        string str = lab.GetName(d) + "." + s;
                        if (type != null)
                        {
                            if (!al.GetType(s).Equals(type))
                            {
                                continue;
                            }
                        }
                        if (list.Contains(str))
                        {
                            continue;
                        }
                        list.Add(lab.GetName(d) + "." + s);
                    }
                }
                if (ab is IAliasVector)
                {
                    IAliasVector av = ab as IAliasVector;
                    foreach (string s in av.AliasNames)
                    {
                        string str = lab.GetName(d) + "." + s;
                        if (type != null)
                        {
                            if (!av.GetType(s).Equals(type))
                            {
                                continue;
                            }
                        }
                        if (list.Contains(str))
                        {
                            continue;
                        }
                        list.Add(lab.GetName(d) + "." + s);
                    }

                }
            }
            if (o is IChildren<IAssociatedObject> co)
            {
                IAssociatedObject[] children = co.Children.ToArray();
                foreach (object child in children)
                {
                    GetAllAliases(nc, child, lab, list, type);
                }
            }
        }
 
        static private void GetAllAliases(INamedComponent nc, IObjectLabel lab, object labObject, List<string> list, object type)
        {
            if (labObject == null)
            {
                return;
            }
            IDesktop d = nc.Desktop;
            if (labObject is IAliasBase)
            {
                IAliasBase ab = labObject as IAliasBase;
                if (ab is IAlias)
                {
                    IAlias al = ab as IAlias;
                    foreach (string s in al.AliasNames)
                    {
                        string str = lab.GetName(d) + "." + s;
                        if (type != null)
                        {
                            if (!al.GetType(s).Equals(type))
                            {
                                continue;
                            }
                        }
                        if (list.Contains(str))
                        {
                            continue;
                        }
                        list.Add(lab.GetName(d) + "." + s);
                    }
                }
                if (ab is IAliasVector)
                {
                    IAliasVector av = ab as IAliasVector;
                    foreach (string s in av.AliasNames)
                    {
                        string str = lab.GetName(d) + "." + s;
                        if (type != null)
                        {
                            if (!av.GetType(s).Equals(type))
                            {
                                continue;
                            }
                        }
                        if (list.Contains(str))
                        {
                            continue;
                        }
                        list.Add(lab.GetName(d) + "." + s);
                    }

                }
            }
            if (labObject is IChildren<IAssociatedObject> co)
            {
                IAssociatedObject[] children = co.Children.ToArray();
                foreach (object child in children)
                {
                    GetAllAliases(nc, lab, child, list, type);
                }
            }
        }

        void IDisposable.Dispose()
        {
            if (obj == null)
            {
                return;
            }
            if (obj is IDisposable disposable)
            {
                disposable.Dispose();
            }
            obj = null;
        }

        #endregion

    }
}
