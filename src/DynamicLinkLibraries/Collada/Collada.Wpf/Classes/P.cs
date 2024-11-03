using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class P : XmlHolder
    {
        static public readonly string Tag = "p";

        public int[] p { get; private set; }

        private P(XmlElement element) : base(element)
        {
            p = element.ToRealArray<int>();
        }

        object Get()
        {
            return p;
        }

        public static object Get(XmlElement element)
        {
            var a = new P(element);
            return a.Get();
        }

    }
}