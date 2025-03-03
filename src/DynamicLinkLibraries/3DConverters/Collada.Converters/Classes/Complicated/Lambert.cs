using Abstract3DConverters.Interfaces;
using Collada.Converters.Classes.Abstract;
using System.Xml;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("lambert")]
    internal class Lambert : AbstractMaterial
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<Lambert>();


        private Lambert(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement, meshCreator)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Lambert(element, meshCreator);
            return a;
        }

        protected override void Create(XmlElement xmlElement)
        {
        }


    }
}