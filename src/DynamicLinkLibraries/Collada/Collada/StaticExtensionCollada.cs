using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Collada
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionCollada
    {

        static ICollada collada;

        static IFunction function;

        static List<ICombining> currentCombinins = new();

        static Dictionary<XmlElement, ICombining> combinations = new();

        static List<ICombining> globalCominings = new();

        private static readonly char[] sep = "\r\n ".ToCharArray();


        static Dictionary<XmlElement, object> dictionary;

        static private Dictionary<string, XmlElement> keyValuePairs;

        static private XmlElement xmlElement;

        static string filename;

        static List<XmlElement> completed;

        static List<XmlElement> begins;

        static Dictionary<string, TagAttribute> tags;

        static Dictionary<Type, TagAttribute> types;



        static StaticExtensionCollada()
        {
            dictionary = new();
            keyValuePairs = new();
            completed = new();
            begins = new();
            tags = new();
            types = new();
        }



        public static ICollada Collada
        {
            get => collada;
            set
            {
                collada = value;
                Clear();
                filename = null;
            }
        }

        public static IFunction Function
        {
            get => function;
            set
            {
                function = value;
                Clear();
                filename = null;
            }
        }

        #region Members

        public static TagAttribute GetTag(this Type type)
        {
            return types[type];
        }

        public static bool IsUknown(this Type type)
        {
            return !types.ContainsKey(type);
        }

        public static bool IsAccessible(this XmlElement element)
        {
            return element.GetTag() != null;
        }

        public static Dictionary<XmlElement, object> ChildDictionary(this XmlElement xml)
        {
            Dictionary<XmlElement, object> d = new();
            var nl = xml.GetElements().Where(e => e.ParentNode == xml & e.IsAccessible());
            foreach (XmlElement e in nl)
            {
                d[e] = e.Get();
            }
            return d;
        }
        public static void AllDictionary(this XmlElement xml, Dictionary<XmlElement, object> d)
        {
            Func<XmlElement, bool> f = (e) =>
                {
                    if (e == xml)
                    {
                        return false;
                    }
                    return e.IsAccessible();
                };
            var nl = xml.GetElements().Where(f);
            foreach (XmlElement e in nl)
            {
                d[e] = e.Get();
            }
        }
        
        public static Dictionary<XmlElement, object> AllDictionary(this XmlElement xml)
        {
            Dictionary<XmlElement, object> d = new();
            var nl = xml.GetElements().Where(e =>  e.IsAccessible());
            foreach (XmlElement e in nl)
            {
                d[e] = e.Get();
            }
            return d;
        }

        public static TagAttribute GetTag(this XmlElement element)
        {
            var name = element.Name;
            if (!tags.ContainsKey(name))
            {
                return null;
            }
            var tag = tags[name];
            return tag;
        }

        public static bool IsElementary(this XmlElement element)
        {
            var tag = element.GetTag();
            var b = tag.IsElemenary;
            return b;
        }

        public static bool IsUnknown(this XmlElement element)
        {
            return !tags.ContainsKey(element.Name);
        }

        public static void CheckElementary(this XmlElement element)
        {
            
            if (!element.IsElementary())
            {
                return;
            }
            var x = element.GetElements();
            foreach (var e in x)
            {
                if (e == element)
                {
                    continue;
                }
                if (e.IsUnknown())
                {
                    continue;
                }
                if (!e.IsElementary())
                {
                    throw new Exception();
                }
            }
        }
   

        public static IEnumerable<T> ChildNodes<T>(this XmlElement xmlElement) 
        {
            var type = typeof(T);
            var name = types[type].Tag;
            var nl = xmlElement.ChildNodes;
            foreach (var item in nl)
            {
                if (item is XmlElement e)
                {
                    if (e.ParentNode == xmlElement)
                    {
                        if (e.Name == name)
                        {
                            var t = (T)e.Get();
                            if (t != null)
                            {
                                yield return t;
                            }
                        }
                    }
                }
            }
        }

        static public IEnumerable<T> GetElements<T>() where T : class
        {
            foreach (var item in dictionary.Values)
            {
                if (item is T t)
                {
                    yield return t;
                }
            }
        }

        /// <summary>
        /// The unique id of element
        /// </summary>
        /// <param name="xmlElement">TheElement</param>
        /// <returns>The unique id</returns>
        static public string UniqueId(this XmlElement xmlElement)
        {
            return collada.UniqueId(xmlElement);
        }

        public static double NumberToDouble(this object value)
        {
            var t = value.GetType();
            if (t == typeof(double))
            {
                return (double)value;
            }
            float f = (float)value;
            return (double)f;
        }


        static public IEnumerable<T> GetElements<T>(Func<T, bool> func) where T : class
        {
            IEnumerable<T> items = GetElements<T>();
            foreach (var item in items)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }



        public static XmlElement Xml => xmlElement;

        public static IEnumerable<XmlElement> Elements => GetElements(xmlElement);

        static public void Set(this XmlElement element, object value)
        {
            if (dictionary.ContainsKey(element))
            {
                throw new Exception();
            }
            dictionary[element] = value;
        }

        static  void ReSet(this XmlElement element, object value)
        {
           dictionary[element] = value;
        }

        static int number = int.MaxValue;

       /* static  bool FullIterate()
        {
            number = int.MaxValue; 
            
            for (int i = 0; i < NumerOfIteration; i++)
            {
                globalCominings.Clear();
                var el = Elements;
                foreach (var item in el)
                {
                    if (collada.IsUnknown(item))
                    {
                        continue;
                    }
                    item.GetCombined();
                }
                if (globalCominings.Count == 0)
                {
                    return true;
                }
                if (globalCominings.Count == number)
                {
                    return false;
                }
                number = globalCominings.Count;
           }
            return false;
        }
       */


        public static int NumerOfIteration { get; set; } = 1;

        /**
        static object GetCombined(this XmlElement element)
        {
            var o = element.Get();
            if (o is ICombining combining)
            {
                if (currentCombinins.Contains(combining))
                {
                    return combining;
                }
                var v = combining.Value;
                element.ReSet(v);
                currentCombinins.Remove(combining);
                globalCominings.Add(combining);
                element.ReSet(v);
                return v;
            }
            return o;
        }*/


        static public void ClearCombinations()
        {
            combinations.Clear();
        }

        static  void Clear()
        {
            ClearCombinations();
            dictionary.Clear();
            keyValuePairs.Clear();
            if (collada != null)
            {
                collada.Clear();
            }
            if (function != null)
            {
                function.Clear();
            }
            completed.Clear();
            begins.Clear();
        }

        public static IEnumerable<object> GetProxyObjects<T>(this XmlElement element)
        {
            var tag = types[typeof(T)];
            var enu = element.GetElements().Where(e => e != element & e.Name.Equals(tag));
            foreach (var x in enu)
            {
                yield return x.Get();
            }    
        }

        public static object GetProxyObject<T>(this XmlElement element)
        {
            var c = element.GetProxyObjects<T>().ToArray();
            switch (c.Length)
            {
                case 0: return null;
                    case 1: return c[0];
                    default: throw new Exception();
            }
     
        }


        public static IEnumerable<T> GetAllChildren<T>(this XmlElement element) where T : class
        {
            var type = typeof(T);
            var name = types[type].Tag;
            var nl = element.GetAllElementsByTagName(name).Where(e => e != element);
            foreach (var n in nl)
            {
                T t = n.Get() as T;
                if (t != null)
                {
                    yield return t;
                }
            }
        }

        public static IEnumerable<T> GetOwnChildren<T>(this XmlElement element)
        {
            var type = typeof(T);
            var name = types[type].Tag;
            var nl = element.ChildNodes;
            foreach (XmlNode n in nl )
            {
                if (n.ParentNode != element)
                {
                    continue;
                }
                if (n is XmlElement e)
                {
                    if (e.Name == name)
                    {
                        T t = (T)e.Get();
                        if (t != null)
                        {
                            yield return t;
                        }
                    }
                }
            }
        }

        public static IEnumerable<XmlElement> GetAllElementsByTagName(this XmlElement element, string name)
        {
            var e = element.GetElements();
            return e.Where(e => e.Name == name);
        }

        public static IEnumerable<T> ByTag<T>(this string tag, XmlElement element) where T : class
        {
            IEnumerable<XmlElement> p = tag.ByTag(element);
            foreach (var el in p)
            {
                T t = el.Get() as T;
                if (t == null)
                {
                    throw new Exception();
                }
                yield return t;
            }
        }

        public static IEnumerable<XmlElement> ByTag(this string tag, XmlElement element)
        {
            var nodelist = element.GetElementsByTagName(tag);
            foreach (XmlNode item in nodelist)
            {
                if (item.ParentNode != element)
                {
                    continue;
                }
                if (item is XmlElement el)
                {
                    yield return el;
                }
            }
        }

        public static XmlElement FirstElement(this XmlElement xmlElement)
        {
            return xmlElement.FirstChild as XmlElement;
        }

        public static XmlElement ByTagUnique(this string tag, XmlElement element)
        {
            var l = tag.ByTagAll(element).ToArray();
            if (l.Length != 1)
            {
                throw new Exception();
            }
            return l[0];
        }

        public static IEnumerable<XmlElement> ByTagAll(this string tag, XmlElement element)
        {
            var nodelist = element.GetElementsByTagName(tag);
            foreach (XmlNode item in nodelist)
            {
                if (item is XmlElement el)
                {
                    yield return el;
                }
            }
        }


        static object CloneItself(this object obj)
        {
            return function.Clone(obj);
        }


        static public void Get(this string filter)
        {
            Func<XmlElement, bool> func = (e) => { return e.Name == filter; };
            var enu = xmlElement.GetElements(func);
            foreach (var e in enu)
            {
                e.Get();
            }
        }

   

        public static void Get(this IEnumerable<string> filter)
        {
            foreach (var e in filter)
            {
                e.Get();    
            }
        }

        public static void Detect(this Type type, Dictionary<string, MethodInfo> methods, List<string> elementary, List<string> all)
        {
            TagAttribute attr = CustomAttributeExtensions.GetCustomAttribute<TagAttribute>(IntrospectionExtensions.GetTypeInfo(type));
            if (attr == null)
            {
                return;
            }
            var tag = attr.Tag;
            types[type] = attr;
            tags[tag] = attr; 
            if (tag.Length == 0)
            {
                return;
            }
            MethodInfo mi = type.GetMethod("Get", [ typeof(XmlElement) ]);
            if (mi == null)
            {
                throw new Exception();
            }
            if (all.Contains(tag))
            {
                throw new Exception();
            }
            all.Add(tag);
            methods[tag] = mi;
            if (attr.IsElemenary)
            {
                elementary.Add(tag);
            }
        }

        public static void Detect(this Assembly assembly, Dictionary<string, MethodInfo> methods, List<string> elementary, List<string> all)
        {
            var types = assembly.GetTypes();
            foreach (var item in types)
            {
                item.Detect(methods, elementary, all);
            }
        }

        static public void GetAll(this IEnumerable<string> filter)
        {
            var arr = filter.ToArray();
            Func<XmlElement, bool> func = (e) => { return arr.Contains(e.Name); };
            var enu = xmlElement.GetElements(func);
            foreach (var e in enu)
            {
                e.Get();
            }
        }

        public static object GetFirstChild(this XmlElement element)
        {
            return (element.FirstChild as XmlElement).Get();
        }

        /// <summary>
        /// Gets object from element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The object</returns>
        /// <exception cref="Exception">The exception</exception>
        public static object Get(this XmlElement element)
        {
            if (dictionary.ContainsKey(element))
            {
                return dictionary[element].CloneItself();
            }
            if (element.IsUnknown())
            {
                return null;
            }
            var func = function[element];
            if (func != null)
            {
                var o = func(element);
                if (o == null)
                {
                    throw new Exception();
                }
                element.Set(o);
                if (o is ICombining c)
                {
                    c.Combine();
                    var p = dictionary[element];
                    if (p is ICombining comb)
                    {
                        combinations[element] = comb;
                    }
                    else if (combinations.ContainsKey(element))
                    {
                        combinations.Remove(element);
                    }
                }
                return o.CloneItself();
            }
            throw new Exception();
        }

        static public T Get<T>(this XmlElement element) where T : class
        {
            var o = element.GetAllChildren<T>().ToArray();
            switch (o.Length)
            {
                case 0: return null;
                case 1: return o[0];
                    default : throw new Exception();
            }
         }

        static  public T GetStruct<T>(this XmlElement element) where T : struct
        {
            return (T)element.Get();
        }

        static public object GetFromNode(this XmlNode node)
        {
            if (node is XmlElement e)
            {
                return e.Get();
            }
            return null;
        }

        static public object FromCollada(this string s)
        {
            return collada.Get(s);
        }

        static void Get(this XmlNode element)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                node.Get();
            }
            if (element is XmlElement xmlElement)
            {
                if (xmlElement.IsUnknown())
                {
                    return;
                }
                xmlElement.Get();
            }
        }

        static void PreLoad(this XmlNode element)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                node.PreLoad();
            }
            if (element is XmlElement xmlElement)
            {
                if (!xmlElement.IsUnknown())
                {
                    collada.Put(xmlElement);
                }
                var id = xmlElement.UniqueId();
                if (id != null)
                {
                    if (keyValuePairs.ContainsKey(id))
                    {
                        throw new Exception();
                    }
                    keyValuePairs[id] = xmlElement;
                }
            }
        }

        public static XmlElement ToXml(this string id)
        {
            if (keyValuePairs.ContainsKey(id))
            { 
                return keyValuePairs[id]; 
            }
            return null;
        }

  

        public static string Directory
        {
            get;
            private set;
        }

        static bool IsCombined(this XmlElement node)
        {
           return completed.Contains(node);
        }

        static void SetCombined(this XmlElement xmlElement)
        {
            completed.Add(xmlElement);
        }

        static  void Combine(this XmlNode element)
        {
            if (element is XmlElement xmlElement)
            {
                if (IsCombined(xmlElement))
                {
                    return;
                }
            }
            foreach (XmlNode node in element.ChildNodes)
            {
                node.Combine();
            }
            if (element is XmlElement xml)
            {
                if (IsCombined(xml))
                {
                    return;
                }
                xml.Combine();
                xml.SetCombined();
            }
        }
/*
        static public object GetCombined(this XmlElement element)
        {
            if (IsCombined(element))
            {
                return element.Get();
            }
            var o = element.Combine();
            return o.CloneItself();
        }
*/
        static public XmlElement GetXmlElement(this string key)
        {
            if (keyValuePairs.ContainsKey(key))
            {
                return keyValuePairs[key];
            }
            return null;
        }

        /*
        static public object GetCombined(this string s)
        {
            return s.GetXmlElement().GetCombined();
        }
        */
        static object Combine(this XmlElement xmlElement)
        {
            var o = xmlElement.Get();
            var obj = o;
            if (IsCombined(xmlElement))
            {
                return o;
            }
            if (begins.Contains(xmlElement))
            {
                throw new Exception();
            }
            begins.Add(xmlElement);
            Func<XmlElement, object, object> f = function.Combine(xmlElement, o);
            if (f != null)
            {
                var res = f(xmlElement, o);
                xmlElement.ReSet(res);
                obj = res;
            }
            xmlElement.SetCombined();
            return obj.CloneItself();
        }

        public static string Filename => filename;

        public static bool IsBase(this Type baseType, Type type)
        {
            var t = type;
            while (t != null)
            {
                if (t ==  baseType)
                {  
                    return true; 
                }
                t = t.BaseType;
            }
            return false;
        
        }

        public static XmlElement XmlElement
        {
            get => xmlElement;
            set
            {
                Clear();
                xmlElement = value;
                collada.Init(value);
                function.Init(value);
                return;
                value.PreLoad();
                (value as XmlNode).Get();
 //               Success = FullIterate();
            }
        }

        public static bool Success { get; private set; }

        public static void Load(this string filename)
        {
            StaticExtensionCollada.filename = filename;
            Directory = Path.GetDirectoryName(filename);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement = xmlDoc.DocumentElement;
        }

        #endregion


        #region Service

        public static T Find<T>(this string name) where T : class
        {
            return name.GetXmlElement().Find<T>(); ;
        }

        private static T Find<T>(this XmlElement el) where T : class
        {
          return  el.Get() as T;
        }
  
        public static double ToDouble(this string str)
        {
            return double.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }

        public static float ToFloat(this string str)
        {
            return float.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }


        static public XmlElement GetChild(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return nl[0] as XmlElement;
            }
            return null;
        }

        static public string[] Separate(this string str)
        {
            return str.Split(sep);
        }


        

        public static double ToDouble(this XmlElement element)
        {
            if (element.Name.Equals("float"))
            {
                return element.InnerText.ToDouble();
            }
            XmlNodeList nl = element.GetElementsByTagName("float");
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
            throw new Exception();
        }

        public static double ToDouble(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
            throw new Exception();
        }

        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }

        
   

        public static object GetArray<T>(XmlElement element) where T : struct
        {
            return element.ToRealArray<T>();
        }


        static public string ToFileName(this string str)
        {
            return Path.Combine(Directory, Path.GetFileName(str));
        }

        static public T ToReal<T>(this string s) where T : struct
        {
            object obj = null;
            var t = typeof(T);
            if (t == typeof(double))
            {
                obj = s.ToDouble();
            }
            else if (t == typeof(float))
            {
                obj = float.Parse(s);
            }
            else if (t == typeof(int))
            {
                obj = int.Parse(s);
            }
            return (T)obj;
        }

        public static IEnumerable<XmlNode> GetNodes(this XmlNode node)
        {
            if (node != null)
            {
                yield return node;
                foreach (XmlNode n in node.ChildNodes)
                {
                    var nd = n.GetNodes();
                    foreach (XmlNode ndd in nd)
                    {
                        yield return ndd;
                    }
                }
            }
        }

        public static IEnumerable<object> GetOwnChildren(this XmlElement e)
        {
            foreach (XmlNode node in e.ChildNodes)
            {
                if (node == e)
                {
                    continue;
                }
                if (node is XmlElement element)
                {
                    yield return element.Get();
                }
            }
        }

        public static IEnumerable<XmlElement> GetElements(this XmlNode node)
        {
            var nd = node.GetNodes();
            foreach (XmlNode ndd in nd)
            {
                if (ndd is XmlElement e)
                {
                    yield return e;
                }
            }
        }

        public static IEnumerable<XmlElement> GetElements(this XmlNode node, Func<XmlElement, bool> func)
        {
            var nd = node.GetNodes();
            foreach (XmlNode ndd in nd)
            {
                if (ndd is XmlElement e)
                {
                    if (func(e))
                    {
                        yield return e;
                    }
                }
            }
        }





        static public T[] ToRealArray<T>(this XmlNode node) where T : struct
        {
            string str = node.InnerText;
            string[] ss = str.Split(sep);

            var l = new List<T>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    T a = s.ToReal<T>();
                    l.Add(a);
                }
            }
            return l.ToArray();

        }



        #endregion

    }

}

