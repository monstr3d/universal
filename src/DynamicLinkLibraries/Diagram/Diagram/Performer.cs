using CategoryTheory;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using ErrorHandler;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Diagram.UI
{
    public class Performer
    {


        /// <summary>
        /// Gets relative name
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>The relative name</returns>
        public string GetRelativeName(INamedComponent source, INamedComponent target)
        {
            return target.GetName(source.Desktop);
        }


        public IEnumerable<T> Get<T>(IEnumerable<object> objects) where T : class
        {
            return from o in objects where o is T select o as T;
        }

        public IEnumerable<T> Get<T>(IComponentCollection desktop) where T : class
        {
            return Get<T>(desktop.Desktop);
        }


        public IEnumerable<T> GetEnumerable<T>(IEnumerable<object> collection, bool find = false) where T : class
        {
            foreach (object o in collection)
            {
                if (o is T t)
                {
                    yield return t;
                }
                if (o is IObjectLabel l)
                {
                    object obj = l.Object;
                    var enu = GetEnumerable<T>(new object[] { obj }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
                if (o is IArrowLabel al)
                {
                    object obj = al.Arrow;
                    var enu = GetEnumerable<T>(new object[] { obj }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
                if (o is IAssociatedObject)
                {
                    var enu = GetEnumerable<T>(new object[] { o }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
            }

        }

        /// <summary>
        /// Sets collection folders
        /// </summary>
        /// <param name="componentCollection">The collection</param>
        public void SetComponentCollectionHolders(IComponentCollection componentCollection)
        {
           ForEach(componentCollection, (IComponentCollectionHolder componentCollectionHolder) =>
            { componentCollectionHolder.ComponentCollection = componentCollection; });
        }

        /// <summary>
        /// Common desktop of two components
        /// </summary>
        /// <param name="c1">First component</param>
        /// <param name="c2">Second component</param>
        /// <returns>Common desktop</returns>
        public  IDesktop GetCommonDesktop(INamedComponent c1, INamedComponent c2)
        {
            List<IDesktop> l1 = GetPath(c1);
            List<IDesktop> l2 = GetPath(c2);
            foreach (IDesktop d in l1)
            {
                if (l2.Contains(d))
                {
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// Path of component desktops
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>Desktop path</returns>
        public List<IDesktop> GetPath(INamedComponent component)
        {
            List<IDesktop> l = new List<IDesktop>();
            IDesktop d = component.Desktop;
            while (true)
            {
                if (d == null)
                {
                    break;
                }
                l.Add(d);
                d = d.ParentDesktop;
            }
            return l;
        }

        /// <summary>
        /// Converts Enumerable to string
        /// </summary>
        /// <param name="enumerable">Enumerable</param>
        /// <returns>String</returns>
        public string EnumerableToString(IEnumerable<string> enumerable)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in enumerable)
            {
                sb.Append(s + Environment.NewLine);
            }
            return sb + "";
        }

        /// <summary>
        /// Gets child named component
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Name of object</param>
        /// <returns>The child component</returns>
        public INamedComponent GetChild(IDesktop desktop, string name)
        {
            IEnumerable<IObjectLabel> c = desktop.Objects;
            foreach (IObjectLabel l in c)
            {
                object ob = l.Object;
                if (!(ob is IObjectContainer))
                {
                    continue;
                }
                IObjectContainer cont = ob as IObjectContainer;
                ICollection<object> all = cont.AllObjects;
                foreach (INamedComponent nc in all)
                {
                    string n = nc.GetName(desktop);
                    if (n.Equals(name))
                    {
                        return nc;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets name of associated object
        /// </summary>
        /// <param name="associatedObject">The object</param>
        /// <returns>The name</returns>
        public string GetName(IAssociatedObject associatedObject)
        {
            if (associatedObject is INamedComponent)
            {
                return (associatedObject as INamedComponent).Name;
            }
            object o = associatedObject.Object;
            if (o is INamedComponent)
            {
                return (o as INamedComponent).Name;
            }
            return null;
        }

        /// <summary>
        /// Gets root desktop of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public IDesktop GetRootDesktop(IAssociatedObject obj)
        {
            IDesktop d = GetDesktop(obj);
            if (d == null)
            {
                return null;
            }
            return d.Root;
        }

        /// <summary>
        /// Gets desktop of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public  IDesktop GetDesktop(IAssociatedObject obj)
        {
            INamedComponent nc = GetNamedComponent(obj);
            if (nc == null)
            {
                return null;
            }
            return nc.Desktop;
        }



        /// <summary>
        /// Gets root  name of associated object
        /// </summary>
        /// <param name="associatedObject">The object</param>
        /// <returns>The name</returns>
        public string GetRootName(IAssociatedObject associatedObject)
        {
            var root = GetRootDesktop(associatedObject);
            return GetName(associatedObject, root);
        }

        public Dictionary<string, object> GetAllAliases(IComponentCollection desktop)
        {
            IEnumerable<IAlias> l = GetObjectsAndArrows<IAlias>(desktop).ToArray();
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (var al in l)
            {
                IAssociatedObject ao = al as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = nc.GetName(desktop);
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }
                IList<string> an = al.AliasNames;
                foreach (string nam in an)
                {
                    string n = name + "." + nam;
                    if (d.ContainsKey(n))
                    {
                        throw new OwnException("Double alias");
                    }
                    d[n] = al[nam];
                }
            }
            return d;
        }


        /// <summary>
        /// Sets aliases
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="names">Names</param>
        /// <param name="parametres">Aliases</param>
        public void SetAliases(IDesktop desktop, Dictionary<string, string> names,
            Dictionary<string, object> parametres)
        {
            Dictionary<string, object> d = GetAllAliases(desktop);
            Dictionary<string, object> dd = new Dictionary<string, object>();
            foreach (string n in names.Keys)
            {
                if (!parametres.ContainsKey(n))
                {
                    continue;
                }
                string ali = names[n];
                if (d.ContainsKey(ali))
                {
                    dd[ali] = parametres[n];
                }
            }
            SetAliases(desktop, dd);
        }

        /// <summary>
        /// Sets all aliases of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="aliases">Dictionary of aliases</param>
        public void SetAliases(IDesktop desktop, Dictionary<string, object> aliases)
        {
            IEnumerable<object> l = GetObjectsAndArrows<object>(desktop);
            foreach (object o in l)
            {
                if (!(o is IAlias))
                {
                    continue;
                }
                IAssociatedObject ao = o as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = nc.GetName(desktop);
                IAlias al = o as IAlias;
                IList<string> an = al.AliasNames;
                foreach (string nam in an)
                {
                    string n = name + "." + nam;
                    if (aliases.ContainsKey(n))
                    {
                        al[nam] = aliases[n];
                    }
                }
            }
        }


        /// <summary>
        /// Gets order of object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Order</returns>
        public int GetOdrer(object obj)
        {
            if (obj is INamedComponent)
            {
                return (obj as INamedComponent).Ord;
            }
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                object o = ao.Object;
                if (o is INamedComponent)
                {
                    return (o as INamedComponent).Ord;
                }
            }
            return 0;
        }


        /// <summary>
        /// Compares two objects by order
        /// </summary>
        /// <param name="x">First parameter</param>
        /// <param name="y">Second parameter</param>
        /// <returns>
        /// Less than zero - x is less than y. 
        /// Zero -  x equals y
        /// Greater than zero x is greater than y
        ///</returns>
        public  int Compare(object x, object y)
        {
            return GetOdrer(x) - GetOdrer(y);
        }

        /// <summary>
        /// Gets all objects of defined type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <returns>Array of objects</returns>
        public  T[] GetAll<T>(IDesktop desktop) where T : class
        {
            List<T> l = new List<T>();
            foreach (ICategoryObject obj in desktop.CategoryObjects)
            {
                T t = obj.GetObject<T>();
                if (t != null)
                {
                    l.Add(t);
                }
            }
            foreach (ICategoryArrow arr in desktop.CategoryArrows)
            {
                T t = arr.GetObject<T>();
                if (t != null)
                {
                    l.Add(t);
                }
            }
            return l.ToArray();
        }



        /// <summary>
        /// Desktop copy
        /// </summary>
        /// <param name="src">Source</param>
        /// <param name="dst">Target</param>
        public void Copy(IDesktop src, IDesktop dst)
        {
            dst.Copy(src.Objects, src.Arrows, true);
        }

        /// <summary>
        /// Gets composition of constructors
        /// </summary>
        /// <param name="types">Types</param>
        /// <param name="ob">Initial object</param>
        /// <returns>Comosition</returns>
        public object GetConstructorComposition(Type[] types, object ob = null)
        {
            object o = ob;
            foreach (Type type in types)
            {
                TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
                if (o == null)
                {
                    o = ti.GetConstructor(new Type[0]).Invoke(new object[0]);
                    continue;
                }
                o = ti.GetConstructor(new Type[]
                    { typeof(object)}).Invoke(new object[] { o });
            }
            return o;
        }

        /// <summary>
        /// Gets composition of constructors
        /// </summary>
        /// <param name="types"></param>
        /// <returns>Comosition</returns>
        public  object GetConstructorComposition(string[] types)
        {
            List<Type> l = new List<Type>();
            string str = null;
            foreach (string s in types)
            {
                Type t = Type.GetType(s);
                if (t == null)
                {
                    str = s;
                    continue;
                }
                l.Add(Type.GetType(s));
            }
            return GetConstructorComposition(l.ToArray(), str);
        }


        /// <summary>
        /// Gets order of object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="enumerable">Enumerable</param>
        /// <param name="obj">Object</param>
        /// <returns>Order</returns>
        public int GetOrder<T>(IEnumerable<T> enumerable, T obj) where T : class
        {

            int i = 0;
            foreach (T t in enumerable)
            {
                if (t == obj)
                {
                    return i;
                }
                ++i;
            }
            return -1;
        }

        /// <summary>
        /// Converts reader to string enumerable
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Enumerable of strings</returns>
        public IEnumerable<string> ToEnumerable(System.IO.TextReader reader)
        {
            while (true)
            {
                string s = reader.ReadLine();
                if (s == null)
                {
                    break;
                }
                yield return s;
            }
        }

        /// <summary>
        /// Checks whether string is empty
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>False if string is empty</returns>
        public bool IsEmpty(string str)
        {
            if (str != null)
            {
                return str.Length == 0;
            }
            return true;
        }

        /// <summary>
        /// Gets objects of aliases
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public void Get(Dictionary<IAlias, Dictionary<string, object[]>> dictionary)
        {
            foreach (IAlias alias in dictionary.Keys)
            {
                Dictionary<string, object[]> d = dictionary[alias];
                foreach (string key in d.Keys)
                {
                    object[] o = d[key];
                    o[1] = alias[key];
                    alias[key] = o[0];
                }
            }
        }

        /// <summary>
        /// Sets objects of aliases
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public void Set(Dictionary<IAlias, Dictionary<string, object[]>> dictionary)
        {
            foreach (IAlias alias in dictionary.Keys)
            {
                Dictionary<string, object[]> d = dictionary[alias];
                foreach (string key in d.Keys)
                {
                    alias[key] = d[key][1];
                }
            }
        }

        /// <summary>
        /// Gets all objects related to category theory
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>The objects</returns>
        public  object[] GetAllRelatedObjects(IDesktop desktop)
        {
            List<object> l = new List<object>();
            IEnumerable<ICategoryObject> co = desktop.CategoryObjects;
            foreach (object o in co)
            {
                l.Add(o);
            }
            IEnumerable<ICategoryArrow> ca = desktop.CategoryArrows;
            foreach (object a in ca)
            {
                l.Add(a);
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets aliases
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="names">Names of aliases</param>
        /// <returns>Values of aliases</returns>
        public Dictionary<string, object> GetAliases(IDesktop desktop, Dictionary<string, string> names)
        {
            Dictionary<string, object> d = GetAllAliases(desktop);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (string n in names.Keys)
            {
                string a = names[n];
                if (d.ContainsKey(a))
                {
                    dic[n] = d[a];
                }
            }
            return dic;
        }

        /// <summary>
        /// Gets names of aliases
        /// </summary>
        /// <param name="vector">Alias vector</param>
        /// <returns>Names of aliases</returns>
        public IList<string> GetAliasNames(IAliasVector vector)
        {
            return vector.AliasNames;
        }

        /// <summary>
        /// Ordered keys of dictionary
        /// </summary>
        /// <typeparam name="S">Key type</typeparam>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>Ordered keys</returns>
        public S[] OrderedKeys<S, T>(IDictionary<S, T> dictionary)
        {
            var l = new List<S>(dictionary.Keys);
            l.Sort();
            return l.ToArray();
        }

        /// <summary>
        /// Compares values
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <typeparam name="S"Key type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="list">List</param>
        /// <returns>Double value</returns>
        public T CompareValue<T, S>(Dictionary<S, T> dictionary, List<T> list)
        {
            foreach (var t in dictionary.Values)
            {
                if (list.Contains(t))
                {
                    return t;
                }
                list.Add(t);
            }
            return default(T);
        }



        /// Transforms collection
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <typeparam name="S">Inupt type</typeparam>
        /// <param name="collection">Input collection</param>
        /// <returns>Output collection</returns>
        public IEnumerable<T> ForEach<T, S>(IEnumerable<S> collection)
            where T : class where S : class
        {
            foreach (S s in collection)
            {
                if (s is T t)
                {
                    yield return t;
                }
                if (s is IObjectLabel l)
                {
                    object obj = l.Object;
                    if (obj is T to)
                    {
                        yield return to;
                    }
                }
                if (s is IArrowLabel al)
                {
                    object a = al.Arrow;
                    if (a is T ta)
                    {
                        yield return ta;
                    }
                }
                if (s is IAssociatedObject ao)
                {
                    T tc = ao.Find<T>();
                    if (tc != null)
                    {
                        yield return tc;
                    }
                }
            }
        }


        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public  void ForEach<T>(IEnumerable<object> collection, 
            Action<T> action, 
            bool find = false)
            where T : class
        {
            foreach (object o in collection)
            {
                if (o is T t)
                {
                    Execute(t, action, find);
                    continue;
                }
                if (o is IObjectLabel)
                {
                    IObjectLabel l = o as IObjectLabel;
                    object obj = l.Object;
                    Execute(obj, action, find);
                }
                if (o is IArrowLabel)
                {
                    IArrowLabel l = o as IArrowLabel;
                    object obj = l.Arrow;
                    Execute(obj, action, find);
                }
                if (o is IAssociatedObject)
                {
                    Execute(o, action, find);
                }
            }
        }

        /// <summary>
        /// Gets root desktop
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Root desktop</returns>
        public  IDesktop GetRootDesktop(ICategoryObject obj)
        {
            object o = obj.Object;
            if (o == null)
            {
                return null;
            }
            INamedComponent nc = o as INamedComponent;
            nc = nc.Root;
            return nc.Desktop;
        }

        /// <summary>
        /// Gets root desktop
        /// </summary>
        /// <param name="arr">Arrow</param>
        /// <returns>Root desktop</returns>
        public  IDesktop GetRootDesktop(ICategoryArrow arr)
        {
            object o = arr.Object;
            INamedComponent nc = o as INamedComponent;
            nc = nc.Root;
            return nc.Desktop;
        }


        /// <summary>
        /// Gets Named Component
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Named Component</returns>
        public  INamedComponent GetNamedComponent(IAssociatedObject obj)
        {
            if (obj is INamedComponent)
            {
                return obj as INamedComponent;
            }
            object o = obj.Object;
            if (o is INamedComponent)
            {
                return o as INamedComponent;
            }
            return null;
        }

        /// <summary>
        /// Gets category object
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The object</returns>
        public  ICategoryObject GetCategoryObject(IAssociatedObject obj)
        {
            object o = GetObject(obj);
            if (o is ICategoryObject)
            {
                return o as ICategoryObject;
            }
            return null;
        }

        /// <summary>
        /// Adds object label to desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="label">The label</param>
        /// <param name="categoryObject">The object</param>
        /// <param name="associated">The "assoicated" sign</param>
        public  void AddObjectLabel(IDesktop desktop, IObjectLabel label, ICategoryObject categoryObject, bool associated)
        {
            label.Object = categoryObject;
            categoryObject.Object = label;
            List<IObjectLabel> l = new List<IObjectLabel>();
            l.Add(label);
            List<IArrowLabel> la = new List<IArrowLabel>();
            desktop.Copy(l, la, associated);
        }

        /// <summary>
        /// Gets object name
        /// </summary>
        /// <param name="ao">Object</param>
        /// <returns>The name</returns>
        public  string GetObjectName(IAssociatedObject ao)
        {
            object o = ao.Object;
            if (!(o is INamedComponent))
            {
                throw new OwnException("Get object Name");
            }
            INamedComponent nc = o as INamedComponent;
            return nc.Name + "";
        }


        /// <summary>
        /// Sets value of alias variable
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <param name="val">The alias value</param>
        public void SetAliasValue(IDesktop desktop, string alias, object val)
        {
            int n = alias.LastIndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            al[alName] = val;
        }


        /// <summary>
        /// Gets alias value
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <returns>The alias value</returns>
        public object GetAliasValue(IDesktop desktop, string alias)
        {
            int n = alias.IndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            return al[alName];
        }





        /// <summary>
        /// Gets category arrow
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The arrow</returns>
        public ICategoryArrow GetCategoryArrow(IAssociatedObject obj)
        {
            object o = GetObject(obj);
            if (o is ICategoryArrow)
            {
                return o as ICategoryArrow;
            }
            return null;
        }


        /// <summary>
        /// Gets alias type
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <returns>The alias value</returns>
        public object GetAliasType(IDesktop desktop, string alias)
        {
            int n = alias.IndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            return al.GetType(alName);
        }


        /// <summary>
        /// Gets arrow label from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="name">Arrow name</param>
        /// <returns>The arrow label</returns>
        public IArrowLabel GetArrowLabel(IDesktop desktop, string name)
        {
            object o = desktop[name];
            if (o == null)
            {
                return null;
            }
            if (!(o is IArrowLabel))
            {
                return null;
            }
            return o as IArrowLabel;
        }

        /// <summary>
        /// Gets associated object of desktop component
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Component name</param>
        /// <returns>Associated object</returns>
        public  object GetAssociatedObject(IDesktop desktop, string name)
        {
            INamedComponent comp = desktop[name];
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                return lab.Object;
            }
            if (comp is IArrowLabel)
            {
                IArrowLabel lab = comp as IArrowLabel;
                return lab.Arrow;
            }
            return null;
        }

        /// <summary>
        /// Gets associated object that implements the interface
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Name of object</param>
        /// <returns>The object</returns>
        public T GetAssociatedObject<T>(IDesktop desktop, string name) where T : class
        {
            object obj = GetAssociatedObject(desktop, name);
            if (!(obj is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ao = obj as IAssociatedObject;
            return ao.GetObject<T>();
        }

        /// <summary>
        /// Gets relative object
        /// </summary>
        /// <typeparam name="T">Type of relative object</typeparam>
        /// <param name="obj">This object</param>
        /// <param name="name">Object name</param>
        /// <returns>Relative object</returns>
        public T GetRelativeObject<T>(ICategoryObject obj, string name) where T : class
        {
            IAssociatedObject ao = obj;
            INamedComponent nc = ao.Object as INamedComponent;
            IDesktop d = nc.Desktop;
            return GetAssociatedObject<T>(d, name);
        }


        /// <summary>
        /// Gets source arrows of object
        /// </summary>
        /// <typeparam name="T">Arrow type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>The arrows</returns>
        public T[] GetSourceArrows<T>(ICategoryObject obj) where T : class
        {
            List<T> l = new List<T>();
            IDesktop d = GetRootDesktop(obj);
            IEnumerable<ICategoryArrow> arr = d.CategoryArrows;
            foreach (ICategoryArrow a in arr)
            {
                ICategoryObject o = a.Source;
                if (o == obj)
                {
                    if (a is T)
                    {
                        l.Add(a as T);
                    }
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets target arrows of object
        /// </summary>
        /// <typeparam name="T">Arrow type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>The arrows</returns>
        public  T[] GetTargetArrows<T>(ICategoryObject obj) where T : class
        {
            List<T> l = new List<T>();
            IDesktop d = GetRootDesktop(obj);
            IEnumerable<ICategoryArrow> arr = d.CategoryArrows;
            foreach (ICategoryArrow a in arr)
            {
                ICategoryObject o = a.Target;
                if (o == obj)
                {
                    if (a is T)
                    {
                        l.Add(a as T);
                    }
                }
            }
            return l.ToArray();
        }

        #region NEW

        /// <summary>
        /// Push
        /// </summary>
        /// <param name="collection">collection</param>
        public  void Push(IComponentCollection collection)
        {
            IEnumerable<object> coll = collection.AllComponents;
            foreach (object o in coll)
            {
                if (o is IStack)
                {
                    IStack stack = o as IStack;
                    stack.Push();
                }
            }
        }

        /// <summary>
        /// Pop
        /// </summary>
        /// <param name="collection">collection</param>
        public void Pop(IComponentCollection collection)
        {
            IEnumerable<object> coll = collection.AllComponents;
            foreach (object o in coll)
            {
                if (o is IStack)
                {
                    IStack stack = o as IStack;
                    stack.Pop();
                }
            }
        }

        /// <summary>
        /// Throws exception linked with object
        /// </summary>
        /// <param name="o">The linked object</param>
        /// <param name="message">Exception message</param>
        public  void Throw(object o, string message)
        {
           Throw(o, new OwnException(message));
        }

        /// <summary>
        /// Throws exception linked with object
        /// </summary>
        /// <param name="o">The linked object</param>
        /// <param name="exception">The parent exception</param>
        public void Throw(object o, Exception exception)
        {
            if ((exception is DiagramException) | (exception is AssociatedException))
            {
                throw exception;
            }
            if (o == null)
            {
                throw exception;
            }
            if (o is INamedComponent n)
            {
                throw new DiagramException(exception, n);
            }
            if (o is IAssociatedObject)
            {
                IAssociatedObject ass = o as IAssociatedObject;
                object ob = ass.Object;
                if (ob is INamedComponent nc)
                {
                    throw new DiagramException(exception, nc);
                }
            }
            throw exception;
        }

        /// <summary>
        /// Gets object from collection
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="collection">Collection of objects</param>
        /// <param name="name">Full name</param>
        /// <returns>Object if exist and false otherwise</returns>
        public  T GetObject<T>(IComponentCollection collection, string name) where T : class
        {
            return GetLabelObject<T>(GetObject(collection, name));
        }


        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="o">Object</param>
        /// <returns>The object</returns>
        public  T GetLabelObject<T>(object o) where T : class
        {
            if (o == null)
            {
                return null;
            }
            T t = null;
            if (o is T)
            {
                t = o as T;
            }
            else if (o is IAssociatedObject)
            {
                t = (o as IAssociatedObject).GetObject<T>();
            }
            else if (o is IObjectLabel ol)
            {
                t = GetLabelObject<T>(ol.Object);
            }
            else if (o is IArrowLabel al)
            {
                t = GetLabelObject<T>(al.Arrow);
            }
            return t;
        }




        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public T GetCollectionObject<T>(IComponentCollection collection, string name) where T : class
        {
            return GetLabelObject<T>(GetObject(collection, name));
        }

        /// <summary>
        /// Gets children objects
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="childrenObject"></param>
        /// <returns>children</returns>
        public  IEnumerable<T> GetChildren<T>(IChildren<IAssociatedObject> childrenObject) where T : class
        {
            IAssociatedObject[] children = childrenObject.Children.ToArray();
            foreach (object o in children)
            {
                if (o is T)
                {
                    yield return o as T;
                }
                if (o is IChildren<IAssociatedObject> tt)
                {
                    IEnumerable<T> en = GetChildren<T>(tt);
                    foreach (T t in en)
                    {
                        yield return t;
                    }
                }
            }
        }

        /// <summary>
        /// Gets all names of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>List of names</returns>
        public  IEnumerable<string> GetAllNames<T>(IComponentCollection collection) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            string n = null;
            foreach (object o in c)
            {
                n = GetName(o, collection);
                if (n == null)
                {
                    continue;
                }
                T t = GetLabelObject<T>(o);
                if (t != null)
                {
                    yield return n;
                }
            }
        }




        #endregion NEW

        /// <summary>
        /// Gets all category objects and arrows of collectiob
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>All category objects and arrows</returns>
        public IEnumerable<object> GetObjectsAndArrows(IEnumerable<object> collection)
        {
            List<object> l = new List<object>();
            ForEach<ICategoryObject>(collection, (ICategoryObject o) => { if (!l.Contains(o)) { l.Add(o); } });
            ForEach<ICategoryArrow>(collection, (ICategoryArrow o) => { if (!l.Contains(o)) { l.Add(o);  } });
            return l;
        }





        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public void ForAll<T>(IComponentCollection collection,
            Action<T> action, bool find = true) where T : class
        {
            IEnumerable<object> en = collection.AllComponents;
            foreach (var a in en)
            {
                if (a is T t)
                {
                    Execute(t, action, find);
                }
                if (a is IObjectLabel)
                {
                    var o = (a as IObjectLabel).Object;
                    if (o is T tt)
                    {
                      Execute(tt, action, find);
                    }
                    if (o is IObjectContainer)
                    {
                        ForAll((o as IObjectContainer).Desktop, action, find);
                    }
                }
            }
        }

 

        /// <summary>
        /// Performs action for each desktop objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Base object</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public void ForEach<T>(ICategoryObject obj, Action<T> action, bool find = false) where T : class
        {
            IDesktop desktop = GetRootDesktop(obj);
            ForEach(desktop, action, find);
        }



        public  void GetAll<T>(IComponentCollection collection, IList<T> list)
                where T : class
        {
            list.Clear();
            IEnumerable<T> en = GetObjectsAndArrows<T>(collection);
            foreach (T t in en)
            {
                if (!list.Contains(t))
                {
                    list.Add(t);
                }
            }
        }

        /// <summary>
        /// Gets all objects of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>List of objects</returns>
        public  List<T> GetAll<T>(IComponentCollection collection)
            where T : class
        {
            List<T> list = new List<T>();
            GetAll(collection, list);
            return list;
        }

        /// <summary>
        /// Gets absulute name (with respect to root desktop)
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Absolute name</returns>
        public string GetAbsoluteName(IAssociatedObject obj)
        {
            var root = GetRootDesktop(obj);
            return GetName(obj, root); 
        }

        /// <summary>
        /// Gets named component of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public  INamedComponent GetComponent(IAssociatedObject obj)
        {
            INamedComponent nc = null;
            if (obj is INamedComponent)
            {
                nc = obj as INamedComponent;
            }
            else
            {
                object o = obj.Object;
                if (o is INamedComponent)
                {
                    nc = o as INamedComponent;
                }
            }
            return nc;
        }




        /// <summary>
        /// Gets object
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public object GetObject(IComponentCollection collection, string name)
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                string n = GetName(o, collection);
                if (n != null)
                {
                    if (n.Equals(name))
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets mame of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="collection">The collection</param>
        /// <returns>The name</returns>
        public  string GetName(object o, IComponentCollection collection)
        {
            INamedComponent nc = null;
            if (o is INamedComponent nm)
            {
                nc = nm;
            }
            else if (o is IAssociatedObject ao)
            {
                object ob = ao.Object;
                if (ob is INamedComponent nn)
                {
                    nc = nn;
                }
            }
            if (nc == null)
            {
                return null;
            }
            IDesktop d = collection.Desktop;
            if (d == null)
            {
                d = collection as IDesktop;
                if (d == null)
                {
                    return null;
                }
            }
            return nc.GetName(d);
        }


        /// <summary>
        /// Copy of an array to a string
        /// </summary>
        /// <param name="x">The array</param>
        /// <param name="sep">The sting separator</param>
        /// <param name="end">The en</param>
        /// <returns>The string</returns>
        public  string CopyTo(double[] x, string sep, string end)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < x.Length; i++)
            {
                sb.Append(x[i]);
                if (i < x.Length - 1)
                {
                    sb.Append(sep);
                }
            }
            sb.Append(end);
            return sb.ToString();
        }

        /// <summary>
        /// Loads array from string
        /// </summary>
        /// <param name="s">The str</param>
        /// <param name="x"></param>
        public  void LoadFromString(string str, out double[] x, char[] sep)
        {
            var ss = str.Split(sep);
            var l = new List<double>();
            foreach (var ps in ss)
            {
                double y = 0;
                if (double.TryParse(ps, out y))
                {
                    l.Add(y);
                }
            }
            x = l.ToArray();
        }

    

 
        /// <summary>
        /// Gets display objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objects">Objects</param>
        /// <param name="reason">Reason</param>
        /// <returns>Display objects</returns>
        public IEnumerable<T> GetDisplayObjects<T>(
            IEnumerable<T> objects, string reason) where T : class
        {
            foreach (object o in objects)
            {
                if (o is T)
                {
                    T t = o as T;
                    DisplayReasonsAttribute attr = o.GetType().
                        ToTypeInfo().
                        GetCustomAttribute<DisplayReasonsAttribute>();
                    if (attr != null)
                    {
                        string[] reasons = attr.Reasons;
                        foreach (string r in reasons)
                        {
                            if (r.Equals(reason))
                            {
                                yield return t;

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets linked type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The linked type</returns>
        public  Type GetLinkedType(Type type)
        {
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
            LinkedTypeAttribute attr =
                CustomAttributeExtensions.
                GetCustomAttribute<LinkedTypeAttribute>(ti);
            if (attr == null)
            {
                return null;
            }
            return attr.Type;
        }

        /// <summary>
        /// Copmares type with linked type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="linked">The linked type</param>
        /// <returns>True in case of equality</returns>
        public  bool CompareLinkedType(Type type, Type linked)
        {
            Type t = GetLinkedType(type);
            if (t == null)
            {
                return false;
            }
            return linked.Equals(t);
        }


        /// <summary>
        /// String value of object
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>String value</returns>
        public  string StringValue(object o)
        {
            Type t = o.GetType();
            if (t.Equals(typeof(double)))
            {
                double a = (double)o;
                return DoubleToString(a);
            }
            if (t.Equals(typeof(bool)))
            {
                return ((bool)o) ? "true" : "false";
            }
            return o + "";
        }

        /// <summary>
        /// Converts to string
        /// </summary>
        /// <param name="a">Double value</param>
        /// <returns>String</returns>
        public  string DoubleToString(double a)
        {
            return a.ToString("G17", System.Globalization.CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Any to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public  string AnyToString(object obj)
        {
            Type t = obj.GetType();
            string s = StringValue(obj);
            if (t.Equals(typeof(double)))
            {
                return "(double)" + s;
            }
            if (t.Equals(typeof(string)))
            {
                return "\"" + s + "\"";
            }
            return s;
        }

        public  List<ICategoryObject> ToList(IEnumerable<IObjectLabel> labels)
        {
            List<ICategoryObject> list = new List<ICategoryObject>();
            foreach (IObjectLabel l in labels)
            {
                list.Add(l.Object);
            }
            return list;
        }

        /// <summary>
        /// Gets children
        /// </summary>
        /// <typeparam name="T">Type of retutn</typeparam>
        /// <param name="childrenObject">The children object</param>
        /// <returns>The children</returns>
        public T GetChild<T>(IChildren<IAssociatedObject> childrenObject) where T : class
        {
            if (childrenObject is T)
            {
                return childrenObject as T;
            }
            var children = childrenObject.Children;
            foreach (object o in children)
            {
                if (o is T)
                {
                    return o as T;
                }
                if (o is IChildren<IAssociatedObject> tt)
                {
                    T t =  GetChild<T>(tt);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Sets parents of objects of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public  void SetParents(IDesktop desktop)
        {
            IEnumerable<IObjectLabel> objects = desktop.Objects;
            foreach (IObjectLabel ol in objects)
            {
                if (ol.Object is IObjectContainer)
                {
                    IObjectContainer oc = ol.Object as IObjectContainer;
                    oc.SetParents(desktop);
                }
            }
        }

        /// <summary>
        /// Gets all objects of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Collection of all objects including children</returns>
        public  ICollection<object> GetAllObjects(IDesktop desktop)
        {
            List<object> l = new List<object>();
            IEnumerable<object> components = desktop.Components;
            l.AddRange(components);
            IEnumerable<IObjectLabel> objs = desktop.Objects;
            foreach (IObjectLabel o in objs)
            {
                if (o.Object is IObjectContainer)
                {
                    IObjectContainer oc = o.Object as IObjectContainer;
                    l.AddRange(oc.AllObjects);
                }
            }
            return l;
        }

        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public void ForEach<T>(IComponentCollection collection, Action<T> action, bool find = false) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            ForEach(c, action, find);
        }

        /// <summary>
        /// Gets relative name
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>The relative name</returns>
        public string GetRelativeName(IAssociatedObject source, IAssociatedObject target)
        {
            INamedComponent cs = null;
            if (source is INamedComponent)
            {
                cs = source as INamedComponent;
            }
            else
            {
                cs = source.Object as INamedComponent;
            }
            INamedComponent ct = null;
            if (target is INamedComponent ctt)
            {
                ct = ctt;
            }
            else
            {
                ct = target.Object as INamedComponent;
            }
            return GetRelativeName(cs, ct);
        }


        #region PRIVATE

        /// <summary>
        /// Gets object or arrow
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>Object or arrow</returns>
        private  object GetObject(IAssociatedObject obj)
        {
            if (!(obj is INamedComponent))
            {
                return obj;
            }
            INamedComponent nc = obj as INamedComponent;
            if (nc is IObjectLabel)
            {
                IObjectLabel l = nc as IObjectLabel;
                return l.Object;
            }
            if (nc is IArrowLabel)
            {
                IArrowLabel l = nc as IArrowLabel;
                return l.Arrow;
            }
            return null;
        }


        private IObjectContainer ParentContainer(INamedComponent nc)
        {
            IDesktop d = nc.Desktop;
            if (!(d is PureDesktop))
            {
                return null;
            }
            PureDesktop pd = d as PureDesktop;
            return pd.internalParent;
        }
        private  int GetOrder(INamedComponent nc, IDesktop desktop)
        {
            if (nc.Desktop == desktop)
            {
                return nc.Ord;
            }
            IObjectContainer oc = ParentContainer(nc);
            IAssociatedObject ao = oc as IAssociatedObject;
            INamedComponent comp = ao.Object as INamedComponent;
            return GetOrder(comp, desktop);
        }


        private  string GetUrl( IAssociatedObject obj, List<IAssociatedObject> l)
        {
            if (obj == null)
            {
                return null;
            }
            if (l.Contains(obj))
            {
                return null;
            }
            l.Add(obj);
            var p = new NamedTree.Performer();
            UrlAttribute attr = p.GetAttribute<UrlAttribute>(obj);
            if (attr != null)
            {
                return attr.Url;
            }
            if (obj is IChildren<IAssociatedObject> ttt)
            {
                IAssociatedObject[] ch = ttt.Children.ToArray();
                if (ch != null)
                {
                    foreach (IAssociatedObject aa in ch)
                    {
                        string s = GetUrl(aa, l);
                        if (s != null)
                        {
                            return s;
                        }
                    }
                }
            }
            object ob = obj.Object;
            if (ob is IObjectLabel)
            {
                IAssociatedObject aob = (ob as IObjectLabel).Object;
                if (!l.Contains(aob))
                {
                    return GetUrl(aob, l);
                }
            }
            return null;
        }


        /// <summary>
        /// Gets all objects of defined type with defined attribute
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <param name="attrType">Type of attribute</param>
        /// <returns>Array of objects</returns>
        public  T[] GetAll<T, S>(IDesktop desktop, Type attrType) where T : class where S : Attribute
        {
            T[] objects = GetAll<T>(desktop);
            List<T> l = new List<T>();
            foreach (T x in objects)
            {
                if (x.HasAttribute<S>())
                {
                    l.Add(x);
                }
            }
            return l.ToArray();
        }



        /// <summary>
        /// Gets intersection of desktop objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="types">Types of objects</param>
        /// <returns>The intersection</returns>
        public  object[] GetIntersectObjects(IDesktop desktop, Type[] types)
        {
            object[] objs = GetAllRelatedObjects(desktop);
            List<object> l = new List<object>();
            foreach (object o in objs)
            {
                foreach (Type t in types)
                {
                    TypeInfo ott = o.ToTypeInfo();
                    if (ott.IsSubclassOf(t))
                    {
                        l.Add(o);
                        goto fin;
                    }
                    IEnumerable<Type> inter = ott.ImplementedInterfaces;
                    foreach (Type ti in inter)
                    {
                        if (ti.Equals(t))
                        {
                            l.Add(o);
                            goto fin;
                        }
                    }
                }
            fin:
                continue;
            }
            return l.ToArray();
        }



        /// <summary>
        /// Set aliases of desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="document">Document</param>
        public  void SetAliases(IDesktop desktop, XElement document)
        {
            IEnumerable<XElement> nl = document.GetElementsByTagName("Aliases");

            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XElement el in nl)
            {
                foreach (XElement e in el.GetChildNodes())
                {
                    d[e.Name.LocalName] = e.Value;
                }
                SetAliasValue(desktop, d["Name"], d["Value"].FromString(d["Type"]));
            }
        }


        /// <summary>
        /// Object from string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="type">Type</param>
        /// <returns>Object</returns>
        public object FromString(string str, object type)
        {
            double a = 0;
            if (type.Equals(a))
            {
                return ParseDouble(str);
            }
            return str;
        }

        /// <summary>
        /// Parses double
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Double</returns>
        public double ParseDouble(string str)
        {
            return Double.Parse(str,
                System.Globalization.CultureInfo.InvariantCulture);
        }



        /// <summary>
        /// Gets texts of elements
        /// </summary>
        /// <param name="element">Parent none</param>
        /// <param name="tag">Tag name</param>
        /// <returns>List of texts</returns>
        public List<string> GetTexts(XElement element, string tag)
        {
            List<string> l = new List<string>();
            IEnumerable<XElement> list = element.GetElementsByTagName(tag);
            foreach (XElement node in list)
            {
                l.Add(node.Value);
            }
            return l;
        }

        /// <summary>
        /// Sets texts to childen elements
        /// </summary>
        /// <param name="element">Parent element</param>
        /// <param name="tag">Tag name</param>
        /// <param name="list">List</param>
        public void SetTexts(XElement element, string tag, List<string> list)
        {
            foreach (string s in list)
            {
                XElement e = CreateXElement(element, tag);
                e.Value = s;
            }
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The element</returns>
        public  XElement CreateXElement(string tag)
        {
            return XElement.Parse("<" + tag + "/>");
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="obj">The object</param>
        /// <returns>The element</returns>
        public  XElement CreateXElement(object obj, string tag)
        {
            XElement e = CreateXElement(tag);
            if (obj is XElement)
            {
                (obj as XElement).Add(e);
            }
            return e;
        }





        /// <summary>
        /// Prepares collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="find">Find sign</param>
        public void Prepare(IComponentCollection collection, bool find = false)
        {
            ForEach(collection, (IPreparation preparation) => { preparation.Prepare(); }, find);
        }


        /// <summary>
        /// Prepares an object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="find">Find sign</param>
        public void Prepare(IAssociatedObject obj, bool find = false)
        {
            if (obj is IPreparation)
            {
                (obj as IPreparation).Prepare();
            }
            if (find)
            {
                IPreparation p = obj.Find<IPreparation>();
                if (p != null)
                {
                    p.Prepare();
                }
            }
        }

        private  IEnumerable<T> Enumerate<T>(object obj, bool find) where T : class
        {
            if (obj is T t)
            {
                yield return t;
            }
            if (find)
            {
                if (obj is IAssociatedObject ao)
                {
                    T ta = ao.Find<T>();
                    if (ta != null)
                    {
                        yield return ta;
                    }
                }
            }

        }

        /// <summary>
        /// Executes action
        /// </summary>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <param name="obj">object</param>
        /// <param name="action">Action</param>
        /// <param name="find">Find sign</param>
        private void Execute<T>(object obj, Action<T> action, bool find) where T : class
        {
            if (obj == null)
            {
                return;
            }
            if (obj is T t)
            {
                action(t);
                return;
            }
            if (find)
            {
                if (obj is IAssociatedObject ao)
                {
                    T ta = ao.Find<T>();
                    if (ta != null)
                    {
                        action(ta);
                    }
                }
            }
        }

        private static void AddChildren(IChildren<IAssociatedObject> co, List<object> l)
        {
            IAssociatedObject[] ao = co.Children.ToArray();
            if (ao != null)
            {
                foreach (IAssociatedObject aa in ao)
                {
                    if (aa != null)
                    {
                        if (!l.Contains(aa))
                        {
                            l.Add(aa);
                        }
                    }
                    if (aa is IChildren<IAssociatedObject> rr)
                    {
                        AddChildren(rr, l);
                    }
                }
            }
        }

        public  List<List<object>> GetConnectedList(IComponentCollection collection)
        {
            List<List<object>> list = new List<List<object>>();
            Action<ICategoryObject> act = (ICategoryObject obj) =>
            {
                List<object> l = new List<object>();
                if (obj is IObjectContainer)
                {
                    IObjectContainer oc = obj as IObjectContainer;
                    ForEach(oc, (object obb) =>
                    {
                        if (!(obb is IObjectContainer))
                        {
                            if (!l.Contains(obb))
                            {
                                l.Add(obb);
                            }
                        }
                    });
                    return;
                }
                if (!l.Contains(obj))
                {
                    l.Add(obj);
                }
                list.Add(l);
                if (obj is IChildren<IAssociatedObject> t)
                {
                    AddChildren(t, l);
                }
            };
            IEnumerable<object> en = collection.AllComponents;
            foreach (object ob in en)
            {
                if (ob is IObjectLabel)
                {
                    act((ob as IObjectLabel).Object);
                }
            }
            Action<ICategoryArrow> arrowAction = (ICategoryArrow arrow) =>
            {
                List<List<object>> ll = new List<List<object>>(list);
                foreach (List<object> l in ll)
                {
                    object s = arrow.Source;
                    object t = arrow.Target;
                    if (l.Contains(s))
                    {
                        l.Add(arrow);
                        if (!l.Contains(t))
                        {
                            List<List<object>> lll = new List<List<object>>(list);
                            foreach (List<object> lm in lll)
                            {
                                if (lm.Contains(t))
                                {
                                    l.AddRange(lm);
                                    list.Remove(lm);
                                    break;
                                }
                            }
                        }
                    }
                }
            };
            ForEach(collection, arrowAction);
            List<List<object>> llist = new List<List<object>>();
            foreach (List<object> l in list)
            {
                List<object> ll = new List<object>();
                llist.Add(ll);
                foreach (object o in l)
                {
                    ll.Add((o as IAssociatedObject).Object);
                }
            }
            return llist;
        }

        /// <summary>
        /// Gets names of typed objects 
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <returns>Array of names</returns>
        public string[] GetNames<T>(IDesktop desktop) where T : class
        {
            T[] t = GetAll<T>(desktop);
            List<string> l = new List<string>();
            foreach (T obj in t)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string n = nc.GetName(desktop);
                if (l.Contains(n))
                {
                    throw new OwnException("Name " + n + " alerady exists");
                }
                l.Add(n);
            }
            return l.ToArray();
        }



        /// <summary>
        /// Gets url
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Url</returns>
        public  string GetUrl(IAssociatedObject obj)
        {
            List<IAssociatedObject> l = new List<IAssociatedObject>();
            return GetUrl(obj, l);
        }




        #endregion

        #region Dependent

        private void GetDependentObjects(ICategoryObject obj, IEnumerable<ICategoryArrow> arrows,
   Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
 arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> dependent)
        {
            foreach (var a in arrows)
            {
                if (!arrowCondition(a))
                {
                    continue;
                }
                var s = a.Source;
                var t = a.Target;
                if ((s != obj) & (t != obj))
                {
                    continue;
                }
                if (t == obj)
                {
                    if (sourceCondition != null)
                    {
                        if (sourceCondition(a))
                        {
                            if (objectCondition(s))
                            {
                                if (!dependent.Contains(s))
                                {
                                    dependent.Add(s);
                                    if (s is IChildren<IAssociatedObject> cobj)
                                    {
                                        IEnumerable<ICategoryObject> en =
                                            GetChildren<ICategoryObject>(cobj);
                                        foreach (ICategoryObject co in en)
                                        {
                                            if (!dependent.Contains(co))
                                            {
                                                if (objectCondition(co))
                                                {
                                                    dependent.Add(co);
                                                }
                                            }
                                        }
                                    }
                                    GetDependentObjects(s, arrows,
                                        objectCondition, arrowCondition, sourceCondition, dependent);
                                }
                            }
                        }
                    }
                    continue;
                }
                if (t == null)
                {
                    throw new OwnException("Dependend objects");
                }
                if (!objectCondition(t))
                {
                    continue;
                }
                if (dependent.Contains(t))
                {
                    continue;
                }
                dependent.Add(t);
                if (t is IChildren<IAssociatedObject> cob)
                {
                    IEnumerable<ICategoryObject> en = GetChildren<ICategoryObject>(cob);
                    foreach (ICategoryObject co in en)
                    {
                        if (!dependent.Contains(co))
                        {
                            if (objectCondition(co))
                            {
                                dependent.Add(co);
                            }
                        }
                    }
                }
                GetDependentObjects(t, arrows, objectCondition, arrowCondition, sourceCondition, dependent);
            }
        }


        private void GetDependentObjects( ICategoryObject obj,
        IEnumerable<ICategoryArrow> arrows,
        Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
      arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> dependent,
        List<ICategoryObject> all)
        {
            GetDependentObjects(obj, arrows, objectCondition, arrowCondition, sourceCondition, dependent);
            foreach (ICategoryObject co in all)
            {
                if (dependent.Contains(co) & !(co is IChildren<IAssociatedObject>))
                {
                    continue;
                }
                if (co is IChildren<IAssociatedObject> ch)
                {
                    IEnumerable<IAssociatedObject> ao = GetChildren<IAssociatedObject>(ch);
                    if (ao != null)
                    {
                        foreach (object c in ao)
                        {
                            if (c is ICategoryObject)
                            {
                                ICategoryObject ca = c as ICategoryObject;
                                if (dependent.Contains(ca))
                                {
                                    if (objectCondition(co))
                                    {
                                        if (!dependent.Contains(co))
                                        {
                                            dependent.Add(co);
                                            GetDependentObjects(co, arrows, objectCondition,
                                                arrowCondition, sourceCondition, dependent, all);
                                        }
                                        goto m;
                                    }
                                }
                            }
                        }
                        continue;

                    m:
                        foreach (object c in ao)
                        {

                            if (c is ICategoryObject ca)
                            {
                                if (!dependent.Contains(ca))
                                {
                                    dependent.Add(ca);
                                    GetDependentObjects(ca, arrows, objectCondition,
                                        arrowCondition, sourceCondition, dependent, all);
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "insert source" condition</param>
        /// <returns>List of dependent objects</returns>
        public List<ICategoryObject> GetDependentObjects(ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool> sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            GetDependentObjects(obj, objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">Source inclide condition</param>
        /// <returns>List of dependent objects</returns>
        public  void GetDependentObjects(ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition, List<ICategoryObject> output)
        {
            IDesktop root = GetRootDesktop(obj);
            if (root == null)
            {
                return;
            }
            IEnumerable<ICategoryArrow> arrows = root.CategoryArrows;
            IEnumerable<ICategoryObject> objects = root.CategoryObjects;
            GetDependentObjects(obj, arrows, objectCondition, arrowCondition, sourceCondition, output,
                objects.ToList());
        }



        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "include source" condition</param>
        /// <returns>List of dependent objects</returns>
        public List<ICategoryObject> GetDependentObjects(ICategoryObject obj,
            IEnumerable<ICategoryArrow> arrows,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            GetDependentObjects(obj, arrows, objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        public IEnumerable<T> GetObjectsAndArrows<T>(IComponentCollection collection) where T : class
        {
            var objs = collection.AllComponents.ToArray();
            foreach (object o in objs)
            {
                if (o is T t)
                {
                    yield return t;
                }
                else if (o is IObjectLabel ol)
                {
                    if (ol.Object is T ttt)
                    {
                        yield return ttt;
                    }
                }
                else if (o is IArrowLabel al)
                {
                    if (al.Arrow is T ttt)
                    {
                        yield return ttt;
                    }
                }

                else if (o is IAssociatedObject ao)
                {
                    if (ao.Object is T tt)
                    {
                        yield return tt;
                    }
                }
            }
        }



        #endregion

    }
}