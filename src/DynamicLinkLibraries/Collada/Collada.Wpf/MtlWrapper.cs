using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Collada.Wpf
{
    /*
newmtl Wood
Ka 1.000000 1.000000 1.000000
Kd 0.640000 0.640000 0.640000
Ks 0.500000 0.500000 0.500000
Ns 96.078431
Ni 1.000000
d 1.000000
illum 0
map_Kd woodtexture.jpg

The example uses the following keywords:

Ka: specifies ambient color, to account for light that is scattered about the entire scene [see Wikipedia entry for Phong Reflection Model] 
using values between 0 and 1 for the RGB components.
Kd: specifies diffuse color, which typically contributes most of the color to an object [see Wikipedia entry for Diffuse Reflection]. 
In this example, Kd represents a grey color, which will get modified by a colored texture map specified in the map_Kd statement
Ks: specifies specular color, the color seen where the surface is shiny and mirror-like [see Wikipedia entry for Specular Reflection].
Ns: defines the focus of specular highlights in the material. Ns values normally range from 0 to 1000, with a high value resulting in a tight, concentrated highlight.
Ni: defines the optical density (aka index of refraction) in the current material. The values can range from 0.001 to 10. A value of 1.0 means that light does not bend as it passes through an object.
d: specifies a factor for dissolve, how much this material dissolves into the background. A factor of 1.0 is fully opaque. A factor of 0.0 is completely transparent.
illum: specifies an illumination model, using a numeric value. See Notes below for more detail on the illum keyword. 
The value 0 represents the simplest illumination model, relying on the Kd for the material modified by a texture map specified in a map_Kd statement if present. The compilers of this resource believe that the choice of illumination model is irrelevant for 3D printing use and is ignored on import by some software applications. For example, the MTL Loader in the threejs Javascript library appears to ignore illum statements. Comments welcome.
map_Kd: specifies a color texture file to be applied to the diffuse reflectivity of the material. 
During rendering, map_Kd values are multiplied by the Kd values to derive the RGB components.
 */


    public class MtlWrapper
    {

        public ImageSource Ka { get; private set; }
        public ImageSource Kd { get; private set; }

        public string Name { get; private set; }

        public Color Ambient { get; private set; }

        public Color Diffuse { get; private set; }

        public Color Specular { get; private set; }

        public double Ns { get; private set; }
        public double Ni { get; private set; }
        public double d { get; private set; }
        public double illum { get; private set; }

        private Material material;
        public Material Material
        {
            get
            {
                Create();
                return material;
            }
        }

        void Create()
        {
            if (material != null)
            {
                return;
            }
            MaterialGroup mat= new MaterialGroup();
            var children = mat.Children;
            material = mat;
            var diffuse = new DiffuseMaterial();
            diffuse.Color = Diffuse;
            ImageBrush br = new ImageBrush(Kd);
            br.ViewportUnits = BrushMappingMode.Absolute;
            br.Opacity = 1;
            diffuse.Brush = br;
            children.Add(diffuse);
            var emissive = new EmissiveMaterial();
            emissive.Color = Ambient;
            children.Add(emissive);
            var specular = new SpecularMaterial();
            specular.Color = Specular;
            children.Add(specular);

        }

        public MtlWrapper(string str, StreamReader reader)
        {
            Name = str;
            string  newName = "";
  
   
            List<string> list = new List<string>();
            do
            {
                var line = reader.ReadLine();
                if (line.Length > 0)
                {
                    list.Add(line);
                }
                if (line.Contains("newmtl"))
                {
                    var ss = line.Split(" ".ToCharArray());
                    newName = ss[ss.Length - 1];
                    break;
                }
                if (reader.EndOfStream)
                {
                    break;
                }
            }
            while (!reader.EndOfStream);
            Finalize(list);
            if (!reader.EndOfStream)
            {
                new MtlWrapper(newName, reader);
            }

        }

        

        void Finalize(List<string> list)
        {
            foreach (var s in list)
            {
                if (s.Length == 0)
                {
                    continue;
                }
                var t = s.Trim();
                int n = t.IndexOf(" ");
                var name = t.Substring(0, n);
                var value = t.Substring(n);
                switch (name)
                {
                    case "Ka":
                        Ambient = value.ToColor();
                            break;
                    case "Kd":
                        Diffuse = value.ToColor();
                        break;
                    case "Ks":
                        Specular = value.ToColor();
                        break;
                    case "map_Ka":
                        Ka = value.ToImage();
                        break;
                    case "map_Kd":
                        Kd = value.ToImage();
                        break;
                    case "Ns":
                        Ns = value.ToDouble();
                        break;
                    case "Ni":
                        Ni = value.ToDouble();
                        break;
                    case "d":
                        d = value.ToDouble();
                        break;
                    case "illum":
                        illum = value.ToDouble();
                        break;
                    default:
                        break;
                }
            }
            this.Add();
        }
    }

}