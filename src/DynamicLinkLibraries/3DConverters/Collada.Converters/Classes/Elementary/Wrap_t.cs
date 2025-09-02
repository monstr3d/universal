using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada.Converters.Classes.Abstract;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("wrap_t", true)]
    internal class Wrap_t : Wrap
    {
        internal Wrap_t(XmlElement element) : base(element)
        {

        }

        public static IClear Clear => StaticExtensionCollada.GetClear<Wrap_t>();

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Wrap_t(element);
            return a.Get();
        }

    }
}
