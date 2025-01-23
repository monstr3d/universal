using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Collada;
using System.Xml;
using Collada.Converters.MaterialCreators;
using Collada.Converters.MeshCreators;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("effect")]
    internal class Effect : Collada.XmlHolder
    {

        internal List<Abstract3DConverters.Materials.Material> Materials { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Effect>();



        private Effect(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            ColladaMeshCreator creator = meshCreator as ColladaMeshCreator;
            var phong = element.Get<Phong>();
            Materials = phong.Materials;
            creator.Eff[element.GetAttribute("id")] = this;
        }



        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Effect(element, meshCreator);
            return a;
        }
    }
}