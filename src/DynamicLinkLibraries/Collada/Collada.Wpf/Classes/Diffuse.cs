using System.Windows.Media.Media3D;
using System;
using System.Xml;
using System.Windows.Media;
using System.Linq;

namespace Collada.Wpf.Classes
{
    [Tag("diffuse")]
    internal class Diffuse : MaterialColor
    {
        static public readonly string Tag = "diffuse";

        public Texture Texture { get; internal set; }

 
        public DiffuseMaterial DiffuseMaterial { get; private set; }

        internal void Set(Texture texture)
        {
            if (texture == null)
            {
                return;
            }
            if (DiffuseMaterial.Set(texture))
            {
                Texture = texture;
            }
        }

        private Diffuse(XmlElement element) : base(element)
        {
            var el = element.GetElements().Where(e => e != Xml & e.Name != "texture" & e.Name != "color").ToArray();
            if (el.Length > 0)
            {
                NewMethod();
                return;
            }

            DiffuseMaterial = Material as DiffuseMaterial;
            if (DiffuseMaterial == null)
            {
                throw new Exception();
            }
            this.SetTextureByXmlElement(element);
        }

        private static void NewMethod()
        {
            throw new Exception();
        }

        protected override Type Type => typeof(DiffuseMaterial);


        public static object Get(XmlElement element)
        {
            var a = new Diffuse(element);
            return a.Get();
        }
    }
}
