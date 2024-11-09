using System.Windows.Media.Media3D;
using System.Xml;
using System;

namespace Collada.Wpf.Classes
{
    [Tag("bind_material")]
    public class BindMaterial : XmlHolder
    {
 
        public Material Material { get; private set; }
        private BindMaterial(XmlElement element) : base(element)
        {
            var inst = element.Get<Instance_Material>();
            if (inst == null)
            {
                return;
            }
            Material = element.Get<Instance_Material>().Material;

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new BindMaterial(element);
            return a.Get();
        }
    }
}