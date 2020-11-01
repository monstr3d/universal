using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace CategoryTheory
{
    /// <summary>
    /// Extensions methods
    /// </summary>
    public static class StaticExtensionCategoryTheory
    {

        #region Fields

        /// <summary>
        /// Exception message
        /// </summary>
        public static readonly string 
            TargetSourceArrow = "Target of first arrow does not coincide with source of next arrow";

        /// <summary>
        /// Object finder
        /// </summary>
        private static IFindObject findObject;

        #region XML related fields

        const string Name = "Name";

        const string Value = "Value";

        const string Objects = "Objects";

        const string Item = "Item";

        #endregion

        #endregion

        #region Public Members


        #region Pure XML Members

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="tagName">The tag name</param>
        /// <returns>The list</returns>
        public static List<XElement> GetElementsByTagName(this XElement element, string tagName)
        {
            IEnumerable<XElement> enu = element.Elements();
            List<XElement> list = new List<XElement>();
            foreach (XElement e in enu)
            {
                if (e.Name.ToString().Equals(tagName))
                {
                    list.Add(e);
                }
            }
            return list;
        }

        /// <summary>
        /// Adds items
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="tagName">Name of tag</param>
        /// <param name="items">Items</param>
        public static void AddItems(this XElement document, string tagName, IEnumerable<string> items)
        {
            XElement e = XElement.Parse("<" + tagName + "/>");
            document.Add(e);
            foreach (string item in items)
            {
                XElement el = XElement.Parse("<" + Item + "/>");
                el.Add(item);
                e.Add(el);
            }
        }

        /// <summary>
        /// Gets item list
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="tagName">Name of tag</param>
        /// <returns>Item list</returns>
        public static List<string> GetItems(this XElement document, string tagName)
        {
            List<string> l = new List<string>();
            List<XElement> nl = document.GetElementsByTagName(tagName);
            if (nl.Count == 0)
            {
                return l;
            }
            List<XElement> list = nl[0].GetElementsByTagName(Item);
            foreach (XElement e in list)
            {
                l.Add(e.InnerText());
            }
            return l;
        }

        /// <summary>
        /// Inner text of an element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The innner text</returns>
        public static string InnerText(this XElement element)
        {
            string s = element.ToString();
            int n = s.IndexOf('>') + 1;
            s = s.Substring(n);
            n = s.LastIndexOf('<');
            s = s.Substring(0, n);
            return s;
        }

        /// <summary>
        /// Sets name value
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public static void SetNameValue(this XElement element, string name, string value)
        {
            XElement n = XElement.Parse("<" + Name + "/>");
            n.Add(name);
            element.Add(n);
            XElement v = XElement.Parse("<" + Value + "/>");
            v.Add(value);
            element.Add(v);
        }

        /// <summary>
        /// Gets name value
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public static void GetNameValue(this XElement element, out string name, out string value)
        {
            name = element.GetElementsByTagName(Name)[0].InnerText();
            value = element.GetElementsByTagName(Value)[0].InnerText();
        }

        #endregion

        #region Other Members


        /// <summary>
        /// Checks whether the type is base type
        /// </summary>
        /// <param name="baseType">The base type</param>
        /// <param name="type">The type</param>
        /// <returns>True is base type and false otherwise</returns>
        static public bool IsBase(this object baseType, object type)
        {
            return baseType.GetType().IsBase(type.GetType());
        }


        /// <summary>
        /// Checks whether the type is base type
        /// </summary>
        /// <param name="baseType">The base type</param>
        /// <param name="type">The type</param>
        /// <returns>True is base type and false otherwise</returns>
        static public bool IsBase(this Type baseType, Type type)
        {
            Type bt = type.BaseType;
            if (bt == null)
            {
                return false;
            }
            if (bt == baseType)
            {
                return true;
            }
            return IsBase(baseType, bt);
        }

        /// <summary>
        /// Compares dictionaries
        /// </summary>
        /// <typeparam name="T">Key type</typeparam>
        /// <typeparam name="S">Value type</typeparam>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>True in case of equal</returns>
        public static bool IsEqual<T, S>(this IDictionary<T, S> source, IDictionary<T, S> target)
        {
            if (source.Count != target.Count)
            {
                return false;
            }
            foreach (T key in source.Keys)
            {
                if (!target.ContainsKey(key))
                {
                    return false;
                }
                if (!source[key].Equals(target[key]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Dictionary key from value
        /// </summary>
        /// <typeparam name="S">Key type</typeparam>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <param name="value">The value</param>
        /// <returns>The key if value exists and null otherwise</returns>
        static public S Invert<S, T>(this IDictionary<S, T> dictionary, T value) where S : class
        {
            foreach (S s in dictionary.Keys)
            {
                if (dictionary[s].Equals(value))
                {
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// Inverts the dictionary
        /// </summary>
        /// <typeparam name="T">Key type</typeparam>
        /// <typeparam name="S">Value type</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>Inversion result</returns>
        static public Dictionary<T, S> Invert<T, S>(this IDictionary<S, T> dictionary)
        {
            Dictionary<T, S> dict = new Dictionary<T, S>();
            foreach (S key in dictionary.Keys)
            {
                dict[dictionary[key]] = key;
            }
            return dict;
        }

        /// <summary>
        /// Transformation of enumerables
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <typeparam name="S">Input type</typeparam>
        /// <param name="input">Input</param>
        /// <param name="transformation">Transformation function</param>
        /// <returns>Transformation result</returns>
        static public IEnumerable<T> EnumerableTransform<T, S>(this IEnumerable<S> input, Func<S, T> transformation)
        {
            foreach (S s in input)
            {
                yield return transformation(s);
            }
        }

        /// <summary>
        /// Queue buffer
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="input">Input</param>
        /// <returns>Buffer</returns>
        static public IEnumerable<T> QueueBuffer<T>(this IEnumerable<T> input)
        {
            Queue<T> queue = new Queue<T>();
            foreach (var x in input)
            {
                queue.Enqueue(x);
            }
            while (queue.Count > 0)
            {
                yield return queue.Dequeue();
            }
        }

        /// <summary>
        /// Transformation of enumerables
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <typeparam name="S">Input type</typeparam>
        /// <param name="input">Input</param>
        /// <param name="transformation">Transformation function</param>
        /// <returns>Transformation result</returns>
        static public IEnumerable<T> EnumerableTransform<T, S>(this IEnumerable<IEnumerable<S>> input, Func<S, T> transformation)
        {
            foreach (IEnumerable<S> item in input)
            {
                foreach (S s in item)
                {
                    yield return transformation(s);
                }
            }
        }

        /// <summary>
        /// Addition of actions
        /// </summary>
        /// <param name="act1">First action</param>
        /// <param name="act2">Second action</param>
        /// <returns>Sum of actions</returns>
        static public Action Add(this Action act1, Action act2)
        {
            if (act1 != null)
            {
                if (act2 != null)
                {
                    return act1 + act2;
                }
                return act1;
            }
            if (act2 != null)
            {
                return act2;
            }
            return null;
        }

        /// <summary>
        /// Sorts partially ordered set
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="list">The set</param>
        /// <param name="comparer">The comparer</param>
        public static void SortPatriallyOrderedSet<T>(this List<T> list,
            IComparer<T> comparer)
        {
            list.Sort(comparer);
        label:
            List<T> l = new List<T>(list);
            for (int i = 0; i < l.Count; i++)
            {
                T x = l[i];
                for (int j = i + 1; j < l.Count; j++)
                {
                    T y = l[j];
                    int comp = comparer.Compare(x, y);
                    int compa = comparer.Compare(y, x);
                    if (comp > 0)
                    {
                        if (compa < 0 | true)
                        {
                            list.Remove(y);
                            list.Insert(i, y);
                            goto label;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clears doubling from list
        /// </summary>
        /// <typeparam name="T">Name of type</typeparam>
        /// <param name="list">The list</param>
        public static void ClearDoubleObjectsFormList<T>(this List<T> list)
        {
            List<T> l = new List<T>(list);
            IEnumerable<T> ex = l.ClearDoubleObjects<T>();
            list.Clear();
            list.AddRange(ex);
        }

        /// <summary>
        /// Clears double objects
        /// </summary>
        /// <typeparam name="T">Type of objects</typeparam>
        /// <param name="objects">Objects</param>
        /// <returns>Collection without double objects</returns>
        public static IEnumerable<T> ClearDoubleObjects<T>(this IEnumerable<T> objects)
        {
            List<T> l = new List<T>();
            foreach (T t in objects)
            {
                if (l.Contains(t))
                {
                    continue;
                }
                l.Add(t);
                yield return t;
            }

        }

        /// <summary>
        /// Gets interface
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Interface</returns>
        public static T GetInterface<T>(this IAssociatedObject obj) where T : class
        {
            if (obj is T)
            {
                return obj as T;
            }
            if (obj is IChildrenObject)
            {
                IChildrenObject co = obj as IChildrenObject;
                IAssociatedObject[] ch = co.Children;
                if (ch != null)
                {
                    foreach (IAssociatedObject ob in ch)
                    {
                        if (ob != null)
                        {
                            T o = GetInterface<T>(ob);
                            if (o != null)
                            {
                                return o;
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Converts object to type info
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        public static TypeInfo ToTypeInfo(this object ob)
        {
            return IntrospectionExtensions.GetTypeInfo(ob.GetType());
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return CustomAttributeExtensions.GetCustomAttribute<T>(obj.ToTypeInfo());
        }

        /// <summary>
        /// Hash Set Attribute
        /// <summary>
        /// Checks whether object has attribute
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>True if object has attribute</returns>
        public static bool HasAttribute<T>(this object obj) where T : Attribute
        {
            return obj.GetAttribute<T>() != null;
        }

        /// <summary>
        /// Hash Set Attribute
        /// <summary>
        /// Checks whether object has attribute
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>True if object has attribute</returns>
        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return CustomAttributeExtensions.GetCustomAttribute<T>(IntrospectionExtensions.GetTypeInfo(type)) != null;
        }

        /// <summary>
        /// Finds object
        /// </summary>
        public static IFindObject FindObject
        {
            get
            {
                return findObject;
            }
            set
            {
                findObject = value;
            }
        }

        /// <summary>
        /// Gets object of predefined type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="obj">The prototype</param>
        /// <returns>The object of predefined type</returns>
        public static T GetObject<T>(this IAssociatedObject obj) where T : class
        {
            // If obj is subtype of T
            if (obj is T)
            {
                // Returns obj as T
                return obj as T;
            }
            // Search in children
            // If obj is IChildrenObject
            if (obj is IChildrenObject)
            {
                IChildrenObject co = obj as IChildrenObject;
                // Gets children
                IAssociatedObject[] ch = co.Children;
                if (ch != null)
                {
                    // Recursive search among children
                    foreach (IAssociatedObject ob in ch)
                    {
                        T a = GetObject<T>(ob);
                        // If child object is found
                        if (a != null)
                        {
                            // Returns the object
                            return a;
                        }
                    }
                }
            }
            if (obj is IAssociatedObject)
            {
                return Find<T>(obj as IAssociatedObject);
            }
            return null;
        }

        /// <summary>
        /// Finds object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Found object</returns>
        public static T Find<T>(this IAssociatedObject obj) where T : class
        {
            if (findObject != null)
            {
                object f = findObject[typeof(T), obj];
                if (f != null)
                {
                    return f as T;
                }
            }
            return null;
        }

        /// <summary>
        /// Try to get object of predefined type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="obj">The prototype</param>
        /// <param name="message">The exception message</param>
        /// <returns>The object of predefined type</returns>
        public static T GetObject<T>(this IAssociatedObject obj, string message) where T : class
        {
            T a = GetObject<T>(obj);
            if (a != null)
            {
                return a;
            }
            throw new Exception(message);
        }

        /// <summary>
        /// Try to get source of the arrow
        /// </summary>
        /// <typeparam name="T">Source type</typeparam>
        /// <param name="obj">The prototype</param>
        /// <returns>The source</returns>
        public static T GetSource<T>(this IAssociatedObject obj) where T : class
        {
            return GetObject<T>(obj, CategoryException.IllegalSource);
        }

        /// <summary>
        /// Try to get target of arrow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Target type</param>
        /// <returns>The target</returns>
        public static T GetTarget<T>(this IAssociatedObject obj) where T : class
        {
            return GetObject<T>(obj, CategoryException.IllegalTarget);
        }

        /// <summary>
        /// Gets simple object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="o">Initial object</param>
        /// <returns>The object</returns>
        public static T GetSimpleObject<T>(this object o) where T : class
        {
            if (o is T)
            {
                return o as T;
            }
            return null;
        }

        /// <summary>
        /// Gets simple object
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="o">Initial object</param>
        /// <param name="message">Exception message</param>
        /// <returns>The object</returns>
        public static T GetSimpleObject<T>(this object o, string message) where T : class
        {
            T t = GetSimpleObject<T>(o);
            if (t != null)
            {
                return t;
            }
            throw new Exception(message);
        }

        /// <summary>
        /// Sets associated object to object and all its children;
        /// </summary>
        /// <param name="ao">The associated object</param>
        /// <param name="obj">The object to set</param>
        static public void SetAssociatedObject(this IAssociatedObject ao, object obj)
        {
            ao.Object = obj;
            if (ao is IChildrenObject)
            {
                IChildrenObject co = ao as IChildrenObject;
                IAssociatedObject[] ch = co.Children;
                if (ch != null)
                {
                    foreach (IAssociatedObject o in ch)
                    {
                        if (o != null)
                        {
                            SetAssociatedObject(o, obj);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks connection between first and next arrow
        /// </summary>
        /// <param name="first">The first arrow</param>
        /// <param name="next">The next arrow</param>
        static public void CheckArrowConnection(this ICategoryArrow first, ICategoryArrow next)
        {
            if (first.Source != next.Target)
            {
                throw new CategoryException(TargetSourceArrow);
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        /// <param name="obj">Object</param>
        static public void RemoveItself(this object obj)
        {
            if (obj is IDisposable)
            {
                IDisposable d = obj as IDisposable;
                d.Dispose();
            }

        }

        /// <summary>
        /// Composition with identical arrow
        /// </summary>
        /// <param name="first">First arrow</param>
        /// <param name="next">Next arrow</param>
        /// <returns>Composition if one arrow is identical and null otherwise</returns>
        public static IAdvancedCategoryArrow IdenticalComposition(this IAdvancedCategoryArrow first,
            IAdvancedCategoryArrow next)
        {
            IAdvancedCategoryArrow[] arr = new IAdvancedCategoryArrow[] { first, next };
            for (int i = 0; i < arr.Length; i++)
            {
                IAdvancedCategoryArrow a = arr[i];
                if (!a.HasAttribute<IdenticalAtrribute>())
                {
                    continue;
                }
                return arr[1 - i];
            }
            return null;
        }

        /// <summary>
        /// Gets constuctor from type info
        /// </summary>
        /// <param name="typeInfo">Type info</param>
        /// <param name="types">Types</param>
        /// <returns>Constructor</returns>
        public static ConstructorInfo GetConstructor(this TypeInfo typeInfo, 
            Type[] types)
        {
            IEnumerable<ConstructorInfo> cc = typeInfo.DeclaredConstructors;
            foreach (ConstructorInfo c in cc)
            {
               ParameterInfo[] p = c.GetParameters();
                if (p.Length != types.Length)
                {
                    continue;
                }
                for (int i = 0; i < p.Length; i++)
                {
                    if (!p[i].ParameterType.Equals(types[i]))
                    {
                        goto fin;
                    }
                }
                return c;
            fin:
                continue;
            }
            return null;
        }

        #endregion

        #endregion

    }
}
