using System.Windows.Media.Media3D;
using System;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Diffuse : MaterialColor
    {
        static public readonly string Tag = "diffuse";

        private Diffuse(XmlElement element) : base(element)
        {

        }

        protected override Type Type => typeof(DiffuseMaterial);


        public static object Get(XmlElement element)
        {
            var a = new Diffuse(element);
            return a.Get();
        }
    }
}
