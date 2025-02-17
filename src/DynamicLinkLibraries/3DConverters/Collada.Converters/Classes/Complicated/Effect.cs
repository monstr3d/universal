using System.Xml;

using Abstract3DConverters.Interfaces;

using Collada.Converters.MeshCreators;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("effect")]
    internal class Effect : Collada.XmlHolder
    {

 

        internal Abstract3DConverters.Materials.Effect EffectP { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Effect>();



        private Effect(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            ColladaMeshCreator creator = meshCreator as ColladaMeshCreator;
            var phong = element.Get<Phong>();
            EffectP = phong.Effect;
            creator.Eff[EffectP.Name] = this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Effect(element, meshCreator);
            return a;
        }
    }
}