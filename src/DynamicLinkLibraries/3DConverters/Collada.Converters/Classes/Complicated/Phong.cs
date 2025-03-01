
using System.Xml;

using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("phong")]
    internal class Phong : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Phong>();

    
        private Phong(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Phong(element, meshCreator);
            return a;
        }

        protected override void Abstract()
        {
        }
    }
}
