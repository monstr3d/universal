using System.Xml;

using Abstract3DConverters.Interfaces;

using Collada.Converters.Classes.Abstract;

namespace Collada.Converters.Classes.Complicated
{

    [Tag("diffuse")]
    internal class Diffuse : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Diffuse>();

        private Diffuse(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Diffuse(element);
            return a.Get();
        }
    }
}
