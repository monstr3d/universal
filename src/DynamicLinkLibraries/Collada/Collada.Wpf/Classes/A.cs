using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class A : XmlHolder
    {
        static public readonly string Tag = "";

        private A(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new A(element);
            return a.Get();
        }
    }
}