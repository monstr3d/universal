using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada.Wpf
{

    public abstract class Abstract
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
            Value = GetValue();
        }

        protected abstract object GetValue();
    }

    public class Surface : Abstract
    {
        public Surface(XmlElement element) : base(element)
        {
        }

        protected override object GetValue()
        {
            throw new NotImplementedException();
        }

    }

    public class Sampler2D : Abstract
    {
        public Sampler2D(XmlElement element) : base(element)
        {
        }
        protected override object GetValue()
        {

            if (Value != null)
            {
                return Value;
            }
            var nl = own.GetElementsByTagName("source");
            if (nl.Count == 1)
            {
                var e = nl[0] as XmlElement;
                var t = e.InnerText;

                if (keyValues.ContainsKey(t))
                {
                    var c = keyValues[t];
                    if (c.Count == 1)
                    {
                        var o = c[0].Get();
                        if (o != null)
                        {
                            Value = o;
                            return o;
                        }
                    }
                }

            }
            return null;
        }
    }

    public class Parameter
    {
        private static Dictionary<string, List<Parameter>> parameters = new();

        public string Name { get; private set; }

        XmlElement xmlElement;

        public XmlElement Element { get => xmlElement; }

        public object Value { get; private set; }

        Dictionary<string, List<XmlElement>> keyValuePairs;

        static Dictionary<string, Func<XmlElement, object>> d = new()
        { {"sampler2D", GetSampler} ,
            {  "surface", e =>{ return new Surface(e); } }


        };

    
        public Parameter(XmlElement xmlElement, Dictionary<string, List<XmlElement>> dic)
        {
            keyValuePairs = dic;
            this.xmlElement = xmlElement;
            Name = xmlElement.GetAttribute("sid");
            object o = Create();
            Value = o;
            if (o == null)
            {
                throw new Exception(); 
            }
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

        }

        public XmlElement Xml => xmlElement;
        

        object Create()
        {
            var fc = xmlElement.FirstChild;
            var en = fc.InnerText;
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
            return parameters[s];
        }

        public static void Clear()
        {
            parameters.Clear();
        }

        #region Functions

        static object GetSampler(XmlElement xmlElement)
        {
            return new Sampler2D(xmlElement);
        }

        #endregion

    }
}
