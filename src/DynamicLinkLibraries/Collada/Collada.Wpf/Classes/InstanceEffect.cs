using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("instance_effect")]
    internal class InstanceEffect : XmlHolder
    {
 
        public Material Material { get; private set; }

        private InstanceEffect(XmlElement element) : base(element)
        {
            var url = element.GetAttribute("url").Substring(1);
            var material = url.FromCollada() as Material;
            if (material == null)
            {

            }
            else
            {
                Material = material;
            }

        }

        Material GetInstanceEffect(XmlElement element)
        {
            var url = element.GetAttribute("url").Substring(1);
            Material m = url.FromCollada() as Material;
            if (m == null)
            {
                throw new Exception();
            }
            if (element.ChildNodes.Count != 0)
            {
                throw new Exception();
            }
            return m;
        }

        object Get()
        {
            return Material;
        }

        public static object Get(XmlElement element)
        {
            var a = new InstanceEffect(element);
            return a.Get();
        }
    }
}