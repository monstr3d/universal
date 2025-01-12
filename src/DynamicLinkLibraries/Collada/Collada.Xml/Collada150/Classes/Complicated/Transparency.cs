using Abstract3DConverters.Interfaces;
using System.Xml;
using Collada;
using Collada150.Classes.Elementary;

namespace Collada150.Classes.Complicated
{
    [Tag("transparency")]
    internal class Transparency : FloatWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Transparency>();

        private Transparency(XmlElement element) : base(element)
        {
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return  new Transparency(element);
        }
    }
}

