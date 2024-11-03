using System;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Specular : MaterialColor
    {
        static public readonly string Tag = "specular";

        private Specular(XmlElement element) : base(element)
        {

        }

        protected override Type Type => typeof(SpecularMaterial);


        public static object Get(XmlElement element)
        {
            var a = new Specular(element);
            return a.Get();
        }
    }
}
//                 {"diffuse", typeof(DiffuseMaterial)},
//{ "specular", typeof(SpecularMaterial)},
 //   { "reflective", typeof(SpecularMaterial)}
