using System;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf
{

    public class Abstract
    {

        protected XmlElement parent;


        protected XmlElement own;

        protected Dictionary<string, List<XmlElement>> keyValues;

        public object Value { get; protected set; }


        public Abstract(XmlElement element)
        {
            keyValues = Function.Instance.KeyValuePairs;
            parent = element;
            own = element.FirstChild as XmlElement;
            var o = GetValue();
            if (o is IEnumerable<Parameter>)
            {
                Value = false;
            }
            else
            {
                Value = o;
            }
        }

        protected virtual object GetValue()
        {
            if (Value != null)
            {
                return Value;
            }
            var nl = own.GetElementsByTagName("source");
            XmlNode fc = own;
            do
            {
                var t = fc.InnerText;
                if (keyValues.ContainsKey(t))
                {
                    var n = keyValues[t];
                    if (n.Count == 1)
                    {
                        return n[0].Get();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                var pas =  Parameter.Get(t);
                var iso = pas.GetImageSource(null);
                if (iso is ImageSource imageSource)
                {
                    return imageSource;
                }
                if (fc is XmlText)
                {
                    break;
                }
                fc = fc.FirstChild;

            }
            while (fc != null);
            return null;
        }
    }

    public class Surface : Abstract
    {
        public Surface(XmlElement element) : base(element)
        {
        }

        protected override object GetValue()
        {
            var o = base.GetValue();
            if (o != null)
            {
                return o;
            }
            return null;
        }

    }

    public class Sampler2D : Abstract
    {
        public Sampler2D(XmlElement element) : base(element)
        {
        }
        protected override object GetValue()
        {
            var o = base.GetValue();
            if (o != null)
            {
                return o;
            }
            return null;
        }
    }

    public class Parameter
    {
        private static Dictionary<string, List<Parameter>> parameters = new();

        private static List<XmlElement> elements = new();

        public string Name { get; private set; }

        XmlElement xmlElement;

        public XmlElement Element { get => xmlElement; }

        public object Value { get; private set; }

        Dictionary<string, List<XmlElement>> keyValuePairs;

        static Dictionary<string, Func<XmlElement, object>> d = new()
        { {"sampler2D", GetSampler} ,
            {  "surface", e =>{ return new Surface(e); } }


        };

        static public object GetParameter(XmlElement xmlElement, Dictionary<string, List<XmlElement>> dic)
        {
            if (elements.Contains(xmlElement))
            {
                return false;
            }
            elements.Add(xmlElement);
            var p = new Parameter(xmlElement, dic);
            var v = p.Value;
            if (v == null)
            {
                return false;
            }
            if (v.GetType() == typeof(bool))
            {
                return false;
            }
            return p;
        }



        public Parameter(XmlElement xmlElement, Dictionary<string, List<XmlElement>> dic)
        {
            keyValuePairs = dic;
            this.xmlElement = xmlElement;
            Name = xmlElement.GetAttribute("sid");
            object o = Create();
            if (o is Parameter pp)
            {
                Value = false;
                return;
            }
            else if (o == null)
            {
                Value = false;
                return;
            }
            else 
            {
                Value = o;
                List<Parameter> l = null;
                if (parameters.ContainsKey(Name))
                {
                    l = parameters[Name];
                }
                else
                {
                    l = new List<Parameter>();
                    parameters[Name] = l;
                }
                l.Add(this);
                return;
            }
        }

        public XmlElement Xml => xmlElement;
        

        object Create()
        {
            var fc = xmlElement.FirstChild;
            var en = fc.InnerText;
            if (keyValuePairs.ContainsKey(en))
            {
                var kvp = keyValuePairs[en];
                if (kvp.Count == 1)
                {
                    return kvp[0].Get();
                }
                throw new Exception();
            }
            if (d.ContainsKey(fc.Name))
            {
                return d[fc.Name](xmlElement);
            }
            var n = fc.InnerText;
            if (keyValuePairs.ContainsKey(n))
            {
                var e = keyValuePairs[n];
                if (e.Count == 1)
                {
                    return e[0].Get();
                }
                throw new Exception();
            }
            
            return null;
        }

        public static List<Parameter> Get(string s)
        {
            if (!parameters.ContainsKey(s))
            {
                return null;
            }
            return parameters[s];
        }

        public static void Clear()
        {
            parameters.Clear();
            elements.Clear();
        }

        #region Functions

        static object GetSampler(XmlElement xmlElement)
        {
            return new Sampler2D(xmlElement);
        }

        #endregion

    }
}
