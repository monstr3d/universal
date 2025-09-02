using System.Xml;

using Abstract3DConverters.Interfaces;

using Collada.Converters.Classes.Abstract;

namespace Collada.Converters.Classes.Complicated
{

    [Tag("emission")]
    internal class Emission : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Emission>();

        private Emission(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Emission(element);
            return a.Get();
        }
    }
}
