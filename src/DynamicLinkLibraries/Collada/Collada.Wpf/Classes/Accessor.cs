using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("accessor", true)]
    public class Accessor : XmlHolder
    {
        static public readonly string Tag = "accessor";

        public float[] Array { get; private set; }

        public Param[] Params { get; private set; }

        public Accessor(XmlElement element) : base(element)
        {
            Params = "param".ByTag<Param>(element).ToArray(); ;
            var s = element.GetAttribute("source");
            var ob = s.Substring(1).GetObject() as float[];
            if (ob == null)
            {
                throw new Exception();
            }
            Array = ob;
        }

        public static object Get(XmlElement element)
        {
            return new Accessor(element);
        }
    }
}
