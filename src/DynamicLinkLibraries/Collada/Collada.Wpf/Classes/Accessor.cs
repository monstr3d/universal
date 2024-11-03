using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class Accessor : XmlHolder
    {
        static public readonly string Tag = "accessor";

        public float[] Array { get; private set; }

        public Accessor(XmlElement element) : base(element)
        {
            var l = new List<Param>();
            var d = "param".ByTag(element);
            var s = element.GetAttribute("source");
            var ob = s.Substring(1).GetObject() as float[];
            if (ob == null)
            {
                throw new Exception();
            }
            Array = ob;
            foreach (var c in d)
            {
                Param par = c.Get() as Param;
                if (par == null)
                {
                    throw new Exception();
                }
                l.Add(par);
            }
        }

        public static object Get(XmlElement element)
        {
            return new Accessor(element);
        }
    }
}
