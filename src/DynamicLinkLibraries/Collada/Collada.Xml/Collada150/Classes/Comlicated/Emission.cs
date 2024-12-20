using System;
using System.Xml;
using Abstract3DConverters.Materials;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("emission")]
    public class Emission : MaterialColor
    {

        private Emission(XmlElement element) : base(element)
        {

        }

        override protected Type Type => typeof(EmissiveMaterial);

        public static IClear Clear => StaticExtensionCollada.GetClear<Emission>();


        public static object Get(XmlElement element)
        {
            var a = new Emission(element);
            return a.Get();
        }
    }
}
