using System;
using System.Windows.Media.Media3D;
using System.Xml;
using Collada;

namespace Collada150.Classes.Comlicated


{
    [Tag("reflective")]
    internal class Reflective : MaterialColor
    {
        static public readonly string Tag = "reflective";

        public EmissiveMaterial EmissiveMaterial { get; private set; }

        private Reflective(XmlElement element) : base(element)
        {
            EmissiveMaterial = Material as EmissiveMaterial;
        }

        protected override Type Type => typeof(EmissiveMaterial);

        public static object Get(XmlElement element)
        {
            var a = new Reflective(element);
            return a.Get();
        }
    }
}

//                 {"diffuse", typeof(DiffuseMaterial)},
//{ "specular", typeof(SpecularMaterial)},
//   { "reflective", typeof(SpecularMaterial)}

