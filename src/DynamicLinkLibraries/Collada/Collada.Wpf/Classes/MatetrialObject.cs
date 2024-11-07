using System;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Collada.Wpf.Classes
{
    [Tag("material")]
    internal class MaterialObject : XmlHolder
    {
        private static Dictionary<string, Material> materials = new();
        public Material Material { get; private set; }

        private MaterialObject(XmlElement element) : base(element)
        {
            if (element.ChildNodes.Count != 1)
            {
                throw new Exception();
            }
            var m = element.FirstElement().Get() as InstanceEffect;
            Material = m.Url.FromCollada() as Material;
            var id = element.GetAttribute("id");
            if (materials.ContainsKey(id))
            {
                throw new Exception();
            }
            materials[id] = Material;
        }

        object Get()
        {
            return Material;
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

        internal static void Clear()
        {
            materials.Clear();
        }
    }
}