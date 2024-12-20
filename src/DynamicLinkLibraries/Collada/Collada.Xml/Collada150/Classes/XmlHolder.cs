using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes
{
    public class XmlHolder : Collada.XmlHolder
    {

        protected IMeshCreator meshCreator;

        protected XmlHolder(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            this.meshCreator = meshCreator;
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