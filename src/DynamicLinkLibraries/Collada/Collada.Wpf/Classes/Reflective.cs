using System;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("reflective")]
    internal class Reflective : MaterialColor
    {
        static public readonly string Tag = "reflective";

        private Reflective(XmlElement element) : base(element)
        {

        }

        protected override Type Type => typeof(SpecularMaterial);

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

