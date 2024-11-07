using System;
using System.Collections.Generic;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("source")]
    public class Source : Collada.XmlHolder
    {

        static private Dictionary<string, Source> keyValuePairs = new();

        public static Source Get(string id)
        {
            if (keyValuePairs.ContainsKey(id))
            { return keyValuePairs[id]; }
            return null;
        }


        public string Name { get; private set; }
        Dictionary<XmlElement, object> children;

        public float[] Array { get; private set; }


        public object[] Children { get; private set; }

        protected Source(XmlElement element) : base(element)
        {
            Name = element.InnerText;
            try
            {
                Array = element.Get<Float_Array, float[]>();
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