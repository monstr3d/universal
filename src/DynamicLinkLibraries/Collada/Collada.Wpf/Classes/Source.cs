using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("source")]
    internal class Source : Collada.XmlHolder
    {
        static public readonly string Tag = "source";

        static private Dictionary<string, Source> keyValuePairs = new();


        public string Name { get; private set; }
        Dictionary<XmlElement, object> children;

    
        public object[] Children { get; private set; }

        protected Source(XmlElement element) : base(element)
        {
            Name = element.InnerText;
            try
            {
                children = new Dictionary<XmlElement, object>(); ;
               // element.AllDictionary(children);
                if (children.Count != 0)
                {

                }
            }
            catch (Exception e)
            {

            }
            var id = element.GetAttribute("id");
            if (id.Length > 0)
            {
                if (keyValuePairs.ContainsKey(id))
                {
                    throw new Exception();
                }
                keyValuePairs[id] = this;
            }
        }

        protected object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Source(element);
            return a.Get();
        }

        internal static void Clear()
        {
            keyValuePairs.Clear();
        }
    }
}