using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Collada
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionCollada
    {
   
        static ICollada collada;

        static IFunction function;

        private static readonly char[] sep = "\r\n ".ToCharArray();


        static Dictionary<XmlElement, object> dictionary;

        static private Dictionary<string, XmlElement> keyValuePairs;

        static private XmlElement xmlElement;

        static string filename;

        static List<XmlElement> completed;

        static StaticExtensionCollada()
        {
            dictionary = new();
            keyValuePairs = new();
            completed= new();
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

        static  void Clear()
        {
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
        }

        static  object CloneItself(this object obj)
        {
            return function.Clone(obj);
        }

        static public void Get(this IEnumerable<string> filter)
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

        public static object Get(this XmlElement element)
        {
            if (collada.IsUnknown(element))
            {
                return null;
            }
            if (dictionary.ContainsKey(element))
            {
                return dictionary[element].CloneItself();
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
                return o.CloneItself();
            }
            throw new Exception();
        }

        static public T Get<T>(this XmlElement element) where T : class 
        {
            var o = element.Get();
            if (o is T t)
            {
                return (T) t;
            }
            return null;
        }

        static  public T GetStruct<T>(this XmlElement element) where T : struct
        {
            return (T)element.Get();
        }

        static void Get(this XmlNode element)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                node.Get();
            }
            if (element is XmlElement xmlElement)
            {
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
                if (!collada.IsUnknown(xmlElement))
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

        static public object GetCombined(this XmlElement element)
        {
            if (IsCombined(element))
            {
                return element.Get();
            }
            var o = element.Combine();
            return o.CloneItself();
        }

        static public XmlElement GetXmlElement(this string key)
        {
            if (keyValuePairs.ContainsKey(key))
            {
                return keyValuePairs[key];
            }
            return null;
        }

        static public object GetCombined(this string s)
        {
            return s.GetXmlElement().GetCombined();
        }

        static object Combine(this XmlElement xmlElement)
        {
            var o = xmlElement.Get();
            var obj = o;
            if (!IsCombined(xmlElement))
            {
                return o;
            }
            Func<XmlElement, object, object> f = function.Combine(xmlElement, o);
            xmlElement.SetCombined();
            if (f != null)
            {
                var res = f(xmlElement, o);
                xmlElement.ReSet(res);
                obj = res;
            }
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
                value.PreLoad();
                (value as XmlNode).Get();
                value.Combine();
            }
        }

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

