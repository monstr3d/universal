using Abstract3DConverters.Interfaces;
using Collada;
using Collada150.Classes.Abstract;
using System.Xml;

namespace Collada150.Classes.Complicated
{
    [Tag("ambient")]
    internal class Ambient : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Ambient>();

        private Ambient(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Ambient(element);
            return a.Get();
        }
    }
}