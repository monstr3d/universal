using System;
using System.Linq;
using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Collada.Wpf.Classes
{
    public class XmlHolder : Collada.XmlHolder
    {

        protected IMeshCreator creator;

        protected XmlHolder(XmlElement element) : base(element)
        {
            creator = Collada as IMeshCreator;
            if (element.IsElementary())
            {
                return;
            }
            var nl = element.GetAllElementsByTagName("source").Where(e => e != element).ToArray();
            if (nl.Length > 0)
            {
                throw new Exception();
            }
            return;
        }

        protected virtual object Get()
        {
            return this;
        }
    }
}