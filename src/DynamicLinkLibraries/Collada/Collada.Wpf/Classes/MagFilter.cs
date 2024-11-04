using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class MagFilter : Source
    {
        static public readonly string Tag = "magfilter";

        private MagFilter(XmlElement element) : base(element)
        {

        }


        public static object Get(XmlElement element)
        {
            var a = new MagFilter(element);
            return a.Get();
        }
    }
}
