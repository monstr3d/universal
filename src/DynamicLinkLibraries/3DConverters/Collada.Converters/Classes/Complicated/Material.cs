using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Collada;
using System.Xml;
using Abstract3DConverters.Materials;
using System.ComponentModel.DataAnnotations;
using Abstract3DConverters;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("material")]
    internal class Material : XmlHolder
    {

        internal Abstract3DConverters.Materials.Effect Effect { get; private set; }

     //   internal List<Material> Materials { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Material>();



        private Material(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var id = element.GetAttribute("id");
            var url = element.Get<Elementary.InstanceEffect>().Url;
            url = url.Substring(1);
            MeshCreator.EffectToMaterial[url] = id;
            var eff = MeshCreator.Eff[url];
            meshCreator.Effects[id] = eff.EffectP;
            Effect = eff.EffectP;

            return;
        }



        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Material(element, meshCreator);
            return a.Get();
        }
    }
}
