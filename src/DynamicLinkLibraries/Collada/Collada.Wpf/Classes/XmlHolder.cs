using System;
using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public class XmlHolder : Collada.XmlHolder
    {
        protected XmlHolder(XmlElement element) : base(element)
        {
            var s = element.ChildNodes<Source>().ToArray();
            if (s.Length > 0)
            {
                throw new Exception();
            }
        }
    }
}