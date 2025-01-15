using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Reflection;
using System.Net.WebSockets;

namespace Collada
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionCollada
    {
        static public string Id
        { get; set; }

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

        static Dictionary<Type, IClear> clears;

    


        static StaticExtensionCollada()
        {
            dictionary = new();
            keyValuePairs = new();
            completed = new();
            begins = new();
            tags = new();
            types = new();
            clears = new();
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

        public static string ConvertExtension(this string f, string ext, bool check = false)
        {
            var dir = Path.GetDirectoryName(f);
            var fn = Path.GetFileNameWithoutExtension(f) + ext;
            fn = Path.Combine(dir, fn);
            if (check)
            {
                if (!File.Exists(fn))
                {
                    throw new FileNotFoundException(f);
                }
            }
            return fn;
        }


        public static TagAttribute GetTag(this Type type)
        {
            return types[type];
        }


        public static byte ToByte(this double d)
        {
            var x = Math.Floor(d * 256);
            if (x == 256)
            {
                x = 255;
            }
            int k = (int)x;
            return (byte)k;
        }

        public static T[,] ToMatrix<T>(this T[] matrix, int row)
        {
            var col = matrix.Length / row;
            var res = new T[row, col];
            int i = 0;
            for (var j = 0; j < row; j++)
            {
                for (var k = 0; k < col; k++)
                {
                    res[j, k] = matrix[i];
                    ++i;
                }
            }
            return res;
        }

        public static Type AdditionalType
        {
            get;
            set;
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

        static public T Get<T>(this string id) where T: class
        {
            if (id.Length == 0)
            {
                return null;
            }
            var t = typeof(T);
            IClear clear = t.GetClear();
            var d = clear as DictionayClear<T>;
            if (d.ContainsKey(id))
            {
                return d[id];
            }
            return null;
        }

        public static IClear GetClear<T>()
            where T : class
        {
            return new DictionayClear<T>();
        }

       

        static public T GetStatic<T>(this XmlElement element) where T : class
        {
            var id = element.GetAttribute(Id);
            if (id.Length == 0)
            {
                return null;
            }
            return id.Get<T>();
        }

       

        public static void PutObject(this XmlElement xml, object value)
        {
            var id = xml.GetAttribute(Id);
            if (id.Length == 0)
            {
                return;
            }
            var t = value.GetType();
            var s = t.GetClear() as IClear;
            if (s == null)
            {
                return;
            }
            s.PutObject(id, value);
        }


        static public void Put<T>(this XmlElement xml, T value) where T : class
        {
            var id = xml.GetAttribute(Id);
            if (id.Length == null)
            {
                return;
            }
            id.Put(value);
        }

        static public void Put<T>(this string s, T value) where T : class
        {
            if (s.Length == 0)
            {
                return;
            }
            var clear = typeof(T).GetClear();
            if (clear == null)
            {
                return;
            }
            var d = clear as DictionayClear<T>;
            d[s] = value;
        }

        static public void  Put<T>(this XmlElement xml, T value, DictionayClear<T> d) where T : class
        {
            var ids = xml.GetAttribute(Id);
            if (ids.Length == 0)
            {
                return;
            }
            d.Put(ids, value);
        }



        public static void InitClear(this Type type, List<string> clear)
        {
            PropertyInfo property = type.GetProperty("Clear", typeof(IClear));
            if (property == null)
            {
                clear.Add(type.Name);
                return;
            }
            var c = property.GetValue(null, null) as IClear;
            clears[type] = c;
        }
        public static IClear GetClear(this Type type)
        {
            if (clears.ContainsKey(type))
            {
                return clears[type];
            }
            return null;
        }

        public static DictionayClear<T> GetDictionary<T>(this Type type) where T : class
        {
            var clear = type.GetClear();
            if (clear == null)
            {
                return null;
            }
            return clear as DictionayClear<T>;
        }

        public static T Get<T>(this object obj) where T : class
        {
            var source = obj.GetType().GetDictionary<T>();
            return source.Get<T>();
        }

        public static void Put(this object obj)
        {
            var t = obj.GetType();
            
        }


        public static void Put<T>(this T value) where T : class
        {
            value.Put(value);
        }


        public static void  Put<T>(this object obj, T value) where T : class
        {
            if (value == null)
            {
                return; 
            }
            var t = obj.GetType();
            var source = t.GetDictionary<T>();
            source.Put(value);
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
            foreach (var i in clears.Values)
            {
                i.Clear();
            }
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
            return enu.Select(e => e.Get());
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



        public static IEnumerable<object> GetAllObjectChildren<T>(this XmlElement element)
        {
            var type = typeof(T);
            var name = types[type].Tag;
            var nl = element.GetAllElementsByTagName(name).Where(e => e != element);
            return nl.Select(e => e.Get());
        }

        public static IEnumerable<T> GetAllChildren<T>(this XmlElement element) where T : class
        {
            var nl = element.GetAllObjectChildren<T>();
            return nl.Where(e => e is T).Select(e => e as T);
        }

        public static T GetFirstChild<T>(this XmlElement element) where T : class
        {
            var nl = element.GetAllObjectChildren<T>();
            var a = nl.Where(e => e is T).Select(e => e as T).ToArray();
            return a.Length > 0 ? a[0] : null;
        }


        public static IEnumerable<S> GetAllChildren<T, S>(this XmlElement element) where T : class where S : class
        {
            var nl = element.GetAllObjectChildren<T>();
            return nl.Where(e => e is T).Select(e => e as S);
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
            enu.Select(e => e.Get()).ToArray();
         }

   

        public static void Get(this IEnumerable<string> filter)
        {
            foreach (var e in filter)
            {
                e.Get();    
            }
        }

        public static void Detect(this Type type, Dictionary<string, MethodInfo> methods, List<string> elementary, 
            List<string> all, List<string> clear, List<string> method)
        {
            TagAttribute attr = CustomAttributeExtensions.GetCustomAttribute<TagAttribute>(IntrospectionExtensions.GetTypeInfo(type));
            if (attr == null)
            {
                return;
            }
            type.InitClear(clear);
            var tag = attr.Tag;
            types[type] = attr;
            tags[tag] = attr; 
            if (tag.Length == 0)
            {
                return;
            }
            MethodInfo mi = null;
            if (AdditionalType != null)
            {
                mi = type.GetMethod("Get", [typeof(XmlElement), AdditionalType]);
            }
            else
            {
               mi =  type.GetMethod("Get", [typeof(XmlElement)]);
            }
            if (mi == null)
            {
                method.Add(tag);
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
            var clear = new List<string>();
            var method = new List<string>();
            foreach (var item in types)
            {
                item.Detect(methods, elementary, all, clear, method);
            }
            if (clear.Count > 0 | method.Count > 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Conversion
        /// </summary>
        /// <typeparam name="T">Type of source</typeparam>
        /// <typeparam name="S">Type of result</typeparam>
        /// <param name="source">The source</param>
        /// <returns>The result</returns>
        public static IEnumerable<S> Convert<T, S>(this IEnumerable<T> source, Func<T, S> f) where T : struct where S : struct
        {
            return source.Select(e => f(e));
        }

        static public void GetAll(this IEnumerable<string> filter)
        {
            var arr = filter.ToArray();
            Func<XmlElement, bool> func = (e) => { return arr.Contains(e.Name); };
            var enu = xmlElement.GetElements(func);
            enu.Select(e => e.Get()).ToArray();
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

        static public T GetParent<T>(this XmlNode element) where T : class
        {
            var tag = typeof(T).GetTag().Tag;
            var p = element.ParentNode;
            if (p == null)
            {
                return null;
            }
            if (p is XmlElement e)
            {
                if (e.Name == tag)
                {
                    return e.Get() as T;
                }
            }
            return p.GetParent<T>();
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

        static public S Get<T, S>(this XmlElement element) where T : class where S : class
        {
            var o = element.GetAllChildren<T, S>().ToArray();
            switch (o.Length)
            {
                case 0: return null;
                case 1: return o[0];
                default: throw new Exception();
            }
        }



        static public object GetObject<T>(this XmlElement element) where T : class
        {
            var o = element.GetAllObjectChildren<T>().ToArray();
            switch (o.Length)
            {
                case 0: return null;
                case 1: return o[0];
                default: throw new Exception();
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

  
        /// <summary>
        /// Working directory
        /// </summary>
        public static string Directory
        {
            get;
            set;
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
            function.Filename = filename;
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

        public static T[] ToRealArray<T>(this string str) where T : struct
        {
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

