using System;
using System.Reflection;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    public abstract class MaterialColor : XmlHolder
    {

        protected Material Material {  get; private set; }

    //    public Texture Texture { get; private set; }

        protected  MaterialColor(XmlElement element) : base(element)
        {
            var ou = element.OuterXml;
             
            Material = GetMaterialColor(element);
            if (Material == null)
            {
                throw new Exception();
            }
        }

        protected double Reflectivity { get; private set; } = -1;

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
            Material = mat;
            var rf = xml.GetAttribute("reflectivity");
            if (rf.Length > 0)
            {
               Reflectivity = xml.ToDouble("reflectivity");
            }
            return mat;
    /*        if (mat is SpecularMaterial sm)
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
                Surface s = Texture.Sample.Surface;
                if (s != null)
                {
                    var im = s.ImageSource;
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
            }*/
            return mat;
        }

        protected override object Get()
        {
            return Material;
        }


    }
}