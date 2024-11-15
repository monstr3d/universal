using System;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Collections.Generic;

namespace Collada.Wpf.Classes
{
    [Tag("material")]
    internal class MaterialObject : XmlHolder
    {
        private static Dictionary<string, Material> materials = new();
        public Material Material 
        { 
            get; 
            private set; 
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<MaterialObject>();


        private MaterialObject(XmlElement element) : base(element)
        {
            var id = element.GetAttribute("id");
            var mtr = StaticExtensionColladaWpf.GetMaterial(id);
            if (mtr != null)
            {
                Material = mtr;
            }
            else
            {
                if (element.ChildNodes.Count != 1)
                {
                    throw new Exception();
                }
                var m = element.FirstElement().Get() as InstanceEffect;
                var o = m.Url.FromCollada();
                if (o is Material mat)
                {
                    Material = mat;
                }
                else
                {

                }
            }
            if (materials.ContainsKey(id))
            {
                throw new Exception();
            }
            materials[id] = Material;
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new MaterialObject(element);
            return a.Get();
        }

        internal static Material Get(string s)
        {
            if (!materials.ContainsKey(s))
            {
                throw new Exception();
            }
            return materials[s];
        }

    }
}
