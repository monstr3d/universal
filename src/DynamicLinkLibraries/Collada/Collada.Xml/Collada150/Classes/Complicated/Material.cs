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

namespace Collada150.Classes.Complicated
{
    [Tag("material")]
    internal class Material : XmlHolder
    {

        internal MaterialGroup MaterialGroup { get; private set; }

        internal List<Material> Materials { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Material>();



        private Material(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var id = element.GetAttribute("id");
            
            MaterialGroup = new MaterialGroup(id);
            var url = element.Get<Elementary.InstanceEffect>().Url;
            url = url.Substring(1);
            var eff = MeshCreator.Eff[url];
            var mats = eff.Materials;
            MaterialGroup = new MaterialGroup(id);

            foreach (var mt in mats)
            {
                MaterialGroup.Children.Add(mt);
            }
            meshCreator.Materials[id] = MaterialGroup;


            return;
        }



        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Material(element, meshCreator);
            return a.Get();
        }
    }
}
