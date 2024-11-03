using System;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal abstract class MaterialColor : XmlHolder
    {

        public Material Material { get; private set; }

        public Texture Texture { get; private set; }

        protected  MaterialColor(XmlElement element) : base(element)
        {
            Material = GetMaterialColor(element);
        }

        protected Material Get()
        {
            return Material;
        }

        abstract protected Type Type {  get; }

        Material GetMaterialColor(XmlElement xml)
        {
            var t = Type;
            ConstructorInfo c = t.GetConstructor([]);
            var mat = c.Invoke([]) as Material;
            var xc = xml.GetColorXml();
            var color = xc.Get();
            // Color color = el.GetColor();
            PropertyInfo pi = t.GetProperty("Color");
            pi.SetValue(mat, color, null);
            if (mat is SpecularMaterial sm)
            {
                try
                {
                    var rf = xml.GetAttribute("reflectivity");
                    if (rf.Length > 0)
                    {
                        double refl = xml.ToDouble("reflectivity");
                        sm.SpecularPower = refl;
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception();
                }
            }
            XmlElement texture = xml.GetChild("texture");
            if (texture != null)
            {
                string tex = texture.GetAttribute("texture");
                Texture = texture.Get() as Texture;
                var im = Texture.ImageSource;
                if (im != null)
                {
                    if (mat is DiffuseMaterial)
                    {
                        ImageBrush br = new ImageBrush(im);
                        br.ViewportUnits = BrushMappingMode.Absolute;
                        br.Opacity = 1;
                        DiffuseMaterial dm = mat as DiffuseMaterial;
                        dm.Brush = br;
                    }
                    else
                    {
                        PropertyInfo pib = mat.GetType().GetProperty("Brush");
                        if (pib != null)
                        {
                            ImageBrush br = new ImageBrush(im);
                            br.Opacity = 1;
                            pib.SetValue(mat, br, null);
                        }
                    }
                }
            }
            return mat;
        }


    }
}