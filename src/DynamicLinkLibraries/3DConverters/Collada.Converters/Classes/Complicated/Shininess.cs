using Abstract3DConverters.Interfaces;
using Collada;
using System.Xml;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("shininess")]
    internal class Shininess : FloatWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Shininess>();

        private Shininess(XmlElement element) : base(element)
        {
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return new Shininess(element);
        }
    }
}
