using System.Xml;
using System;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada150.Classes.Complicated
{
    [Tag("bind_material")]
    public class BindMaterial : XmlHolder
    {
        public static IClear Clear => StaticExtensionCollada.GetClear<BindMaterial>();


        public Abstract3DConverters.Materials.Material Material { get; private set; }
        private BindMaterial(XmlElement element) : base(element, null)
        {
            var inst = element.Get<Instance_Material>();
            if (inst == null)
            {
                return;
            }
            Material = inst.Material;

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new BindMaterial(element);
            return a.Get();
        }
    }
}