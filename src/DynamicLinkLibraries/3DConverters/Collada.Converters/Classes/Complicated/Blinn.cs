using Abstract3DConverters.Interfaces;
using System.Xml;

namespace Collada.Converters.Classes.Complicated
{

    [Tag("blinn")]
    internal class Blinn : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Blinn>();


        private Blinn(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Blinn(element, meshCreator);
            return a;
        }

        protected override void Abstract()
        {
        }
    }

}
