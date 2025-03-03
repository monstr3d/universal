using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada.Converters.Classes.Abstract;
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

        protected override void Create(XmlElement xmlElement)
        {
            var p = ParentEffectXml;
            var mat = new BlinnMaterial("", p);
            var name = p.GetAttribute("id");
            Effect = new Abstract3DConverters.Materials.Effect(meshCreator, name, mat);
        }

    }

}
