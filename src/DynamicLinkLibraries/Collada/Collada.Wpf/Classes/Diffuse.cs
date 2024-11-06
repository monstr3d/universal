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

        public Texture Texture { get; private set; }

 
        public DiffuseMaterial DiffuseMaterial { get; private set; }

        private Diffuse(XmlElement element) : base(element)
        {
            DiffuseMaterial = Material as DiffuseMaterial;
            if (DiffuseMaterial == null)
            {
                throw new Exception();
            }
            XmlElement texture = element.GetChild("texture");
            if (texture != null)
            {
                string tex = texture.GetAttribute("texture");
                var txt = texture.Get() as Texture;
                Surface s = txt.Sample.Surface;
                if (s != null)
                {
                    var im = s.ImageSource;
                    if (im != null)
                    {
                        Texture = txt;
                        ImageBrush br = new ImageBrush(im);
                        br.ViewportUnits = BrushMappingMode.Absolute;
                        br.Opacity = 1;
                        DiffuseMaterial.Brush = br;
                        return;
                    }
                }
            }
            var el = element.GetElements().Where(e => e != Xml & e.Name != "texture" & e.Name != "color").ToArray();
            if (el.Length > 0)
            {
                throw new Exception();
            }
        }

        protected override Type Type => typeof(DiffuseMaterial);


        public static object Get(XmlElement element)
        {
            var a = new Diffuse(element);
            return a.DiffuseMaterial;
        }
    }
}
