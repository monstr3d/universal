using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    internal class Input : XmlHolder
    {
        public static readonly string Tag = "input";

        public string Source { get; private set; }
        private Input(XmlElement element) : base(element)
        {
            Source = element.GetAttribute("source").Substring(1);
            if (Source.Length == 0)
            {
                throw new Exception();
            }
        }

        internal static object Get(XmlElement element)
        {
            return new Input(element);
        }
    }
}
