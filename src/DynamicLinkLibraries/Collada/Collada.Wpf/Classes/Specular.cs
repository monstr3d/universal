using System;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("specular")]
    public class Specular : MaterialColor
    {
        static public readonly string Tag = "specular";

       public SpecularMaterial SpecularMaterial { get; private set; }

        private Specular(XmlElement element) : base(element)
        {
            SpecularMaterial = Material as SpecularMaterial;
            var rf = Xml.GetAttribute("reflectivity");
            if (rf.Length > 0)
            {
                double refl = Xml.ToDouble("reflectivity");
                SpecularMaterial.SpecularPower = refl;
            }
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
