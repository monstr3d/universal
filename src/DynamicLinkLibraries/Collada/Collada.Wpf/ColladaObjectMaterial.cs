using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf
{
    partial class ColladaObject
    {

        #region Functions



        private  Dictionary<string, Type> materialTypes = new Dictionary<string, Type>()
        {
                 {"diffuse", typeof(DiffuseMaterial)},
                 {"specular", typeof(SpecularMaterial)},
    {"reflective", typeof(EmissiveMaterial)}
   // {"transparent",  typeof(DiffuseMaterial}*/
      };

        private Dictionary<string, Func<XmlElement, Material>> materialCalc;


        private  Material GetPhong(XmlElement e)
        {
            if (materials.ContainsKey(e))
            {
                return materials[e];
            }
            List<Material> l = new List<Material>();
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n is XmlElement el)
                {
                    Material mat = null; ;
                    if (materials.ContainsKey(el))
                    {
                        mat = materials[el];
                    }
                    else
                    {
                        string tag = e.Name;
                        if (materialTypes.ContainsKey(tag))
                        {
                            Type t = materialTypes[tag];
                            ConstructorInfo c = t.GetConstructor([]);
                            mat = c.Invoke([]) as Material;
                            materials[e] = mat;
                            Color color = el.GetColor();
                            PropertyInfo pi = t.GetProperty("Color");
                            pi.SetValue(mat, color, null);
                            if (mat is SpecularMaterial)
                            {
                                try
                                {
                                    if (e.GetAttribute("reflectivity").Length > 0)
                                    {
                                        double refl = e.ToDouble("reflectivity");
                                        SpecularMaterial sm = mat as SpecularMaterial;
                                        sm.SpecularPower = refl;
                                    }
                                }
                                finally
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                    XmlElement texture = el.GetChild("texture");
                    if (texture != null)
                    {
                        ImageSource im = null;
                        string tex = texture.GetAttribute("texture");
                        XmlElement et = null;
                        var en = tex.GetXmlElement();
                        if (en != null)
                        {
                            et = en.ChildNodes[0] as XmlElement;
                            if (et.Name.Equals("sampler2D"))
                            {
                                string si = et.GetChild("source").InnerText;
                                var ess = si.GetXmlElement();
                                if (ess != null)
                                {
                                    im = ess.InnerText.Find<ImageSource>();
                                    if (im == null)
                                    {
                                        return null;
                                    }
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

                        }
                        else
                        {
                        }
                        if (et.Name.Equals("surface"))
                        {
                        }
                    }
                    if (mat == null)
                    {
                        return null;
                    }
                    l.Add(mat);
                }
            }
            if (l.Count == 1)
            {
                return l[0];
            }
            MaterialGroup gr = new MaterialGroup();
            foreach (Material m in l)
            {
                gr.Children.Add(m);
            }
            return gr;
        }

        Material GetMaterial(string matName)
        {
            var x = matName.GetXmlElement();
            if (materials.ContainsKey(x))
            {
                return materials[x];
            }
            return null;
        }

        private  Material GetInstanceEffect(XmlElement element)
        {
            var url = element.GetAttribute("url").Substring(1);
            var mat = GetMaterial(url);
            if (mat != null)
            {
                return mat;
            }

            var xml = url.GetXmlElement();
            List<Material> l = new List<Material>();
            var nl = xml.GetElementsByTagName("phong")[0];
            Material material = null;
            foreach (XmlElement e in nl.ChildNodes)
            {
                var nm = e.Name;
                if (materialTypes.ContainsKey(nm))
                {
                    var t = materialTypes[nm];
                    var ct = t.GetConstructor([]);
                    material = ct.Invoke(null) as Material;
                    l.Add(material);
                    foreach (XmlElement ee in e.ChildNodes)
                    {
                        var sn = ee.Name;
                        if (sn == "color")
                        {
                            var color = ee.GetColor();
                            var cp = t.GetProperty("Color") as PropertyInfo;
                            cp.SetValue(material, color);
                        }
                        else if (sn == "reflectivity")
                        {
                            var d = ee.ToDouble();
                            var cr = t.GetProperty("SpecularPower");
                            cr.SetValue(material, d);

                        }
                        else if (sn == "texture")
                        {
                            var coord = ee.GetAttribute("texcoord");
                            var cg = coord.ToIdName();


                            var txtr = ee.GetAttribute("texture");
                            var ttxt = txtr.ToIdName();
                        }
                    }
                }
            }
            if (l.Count == 1)
            {
                materials[element] = material;
                return material;
            }
            var mc = new MaterialCollection(l);
            var mg = new MaterialGroup();
            mg.Children = mc;
            materials[element] = mg;
            return mg;
        }




        #endregion



    }
}
