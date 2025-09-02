using System;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Collada;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("instance_material")]
    public class Instance_Material : XmlHolder
    {

        internal Abstract3DConverters.Materials.Effect Effect { get; private set; }


        public static IClear Clear => StaticExtensionCollada.GetClear<Instance_Material>();


        private Instance_Material(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
           var target = element.GetAttribute("target");
            target = target.Substring(1);
            Effect = meshCreator.Effects[target];
        }


        static public object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return new Instance_Material(element, meshCreator);
        }

    }
}
