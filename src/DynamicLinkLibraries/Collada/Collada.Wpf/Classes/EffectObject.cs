using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("effect")]
    internal class EffectObject : SourceHolder
    {
        public static EffectObject Get(Material material)
        {
            if (effects.ContainsKey(material))
            {
                return effects[material];
            }
            return null;
        }
        static EffectObject()
        {
            effects = new();
        }

        public Material Material { get; private set; }

        internal static void Clear()
        {
            effects.Clear();
        }

        static Dictionary<Material, EffectObject> effects;



        private EffectObject(XmlElement element) : base(element)
        {
            var l = new List<Material>();
            var nl = element.GetElementsByTagName("phong");
            foreach (XmlElement e in nl)
            {
                Material material = e.Get() as Material;
                if (material != null)
                {
                    effects[material] = this;
                    l.Add(material);
                }
                else
                {
                    throw new Exception();
                }
            }

            Material = l.SimplifyMaterial();
        }

        object Get()
        {
            return Material;
        }

        public static object Get(XmlElement element)
        {
            var a = new EffectObject(element);
            return a.Get();
        }
    }
}