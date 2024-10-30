using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionCollada
    {
        static StaticExtensionCollada()
        {
            dictionary = new();
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

        static ICollada collada;

     


        static Dictionary<XmlElement, object> dictionary;

        static private XmlElement xmlElement;

        static string filename;

        public static XmlElement Xml => xmlElement;

        public static IEnumerable<XmlElement> Elements => GetElements(xmlElement);


        private static IEnumerable<XmlElement> GetElements(XmlNode node)
        {
            if (node is XmlElement element)
            {
                yield return element;
            }   
            foreach (XmlNode n in node.ChildNodes)
            {
                var x = GetElements(n);
                foreach (var y  in x)
                {
                    yield return y;
                }
            }
        }

        static  void Set(this XmlElement element, object value)
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
        }

        static  object CloneItself(this object obj)
        {
            return collada.Clone(obj);
        }

        public static object Get(this XmlElement element)
        {
            if (dictionary.ContainsKey(element))
            {
                return dictionary[element].CloneItself();
            }
            var tag = element.Name;
            if (collada.Functions.ContainsKey(tag))
            {
                var o = collada.Functions[tag].CloneItself();
                element.Set(o);
                return o;
            }
            return null;
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

        static  void PreLoad(this XmlNode element)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                node.PreLoad();
            }
            if (element is XmlElement xmlElement)
            {
                xmlElement.Get();
            }
        }

        static bool IsCombined(this XmlElement node)
        {
            var a = node.GetAttribute("IsCombined");
            return (a == "True");
        }

        static void SetCombined(this XmlElement xmlElement)
        {
            xmlElement.SetAttribute("IsCombined", "True");
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
            }
        }

        static public object GetCombined(XmlElement element)
        {
            if (IsCombined(element))
            {
                return element.Get();
            }
            var o = element.Combine();
            return o.CloneItself();
        }

        static  object Combine(this XmlElement xmlElement)
        {
            object obj = 9;
            var o = xmlElement.Get();
            if (!IsCombined(xmlElement))
            {
                return o;
            }
            Func<XmlElement, object> f = null;
            xmlElement.SetCombined();
            if (o == null)
            {

            }
            Type t = o.GetType();
            while (true)
            {
                if (t == null)
                {
                    break;
                }
                if (collada.Combined.ContainsKey(t))
                {
                    f = collada.Combined[t];
                    break;
                }
                t = t.BaseType;
            }
            if (f != null)
            {
                var res = f(xmlElement);
                xmlElement.ReSet(res);
                obj = res;
            }
            return obj;
        }

        public static string Filename => filename;

        public static XmlElement XmlElement
        {
            get => xmlElement;
            set
            {
                Clear();
                value.PreLoad();
                value.Combine();
                xmlElement = value;
            }
        }

        public static void Load(this string filename)
        {
            StaticExtensionCollada.filename = filename;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlElement = xmlDoc.DocumentElement;
        }

    }

}

