using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Net.Http.Headers;
using System.Windows.Media.TextFormatting;

namespace Collada.Wpf
{
    partial class ColladaObject
    {

        Dictionary<XmlElement, Material> materials; 


        #region Functions





        private Dictionary<string, Type> materialTypes; 

        private Dictionary<string, Func<XmlElement, Material>> materialCalc;


        object GetInstanceEffect(XmlElement element)
        {
            return GetInstanceEffectMaterial(element);
        }

        object GetEffectMaterialObject(XmlElement element)
        {
            return GeEffectMaterial(element);
        }


        object GetColorObject(XmlElement e)
        {
            return e.GetColor();
        }



        private Material GeEffectMaterial(XmlElement element)
        {
            var url = element.GetAttribute("url");
            if (url.Length < 2)
            {
                return element.FromXml("phong");
            }
            var mat = GetMaterial(url.Substring(1));
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
                    var color = e.GetColorXml().Get(); ;
                    var cp = t.GetProperty("Color") as PropertyInfo;
                    cp.SetValue(material, color);
                    foreach (XmlElement ee in e.ChildNodes)
                    {
                        var sn = ee.Name;
                        if (sn == "reflectivity")
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
            return l.ToMaterial();
         }

        object GetPhongObject(XmlElement e)
        {
            return GetPhong(e);
        }

        XmlElement GetImageXml(string tex)
        {
            XmlElement et = null;
            if (parametersNew.ContainsKey(tex))
            {
                var par = parametersNew[tex];
                var s = paramSource[par];
                var ss = s.InnerText;
                par = parametersNew[ss];
                var imgt = par.InnerText;
                XmlElement imXml = null;
                if (elementList.ContainsKey(imgt))
                {
                    return elementList[imgt][0];
                }
            }
            return null;
        }


        private Material GetPhong(XmlElement e)
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
                        string tag = el.Name;
                        if (materialTypes.ContainsKey(tag))
                        {
                            Type t = materialTypes[tag];
                            ConstructorInfo c = t.GetConstructor([]);
                            mat = c.Invoke([]) as Material;
                            materials[el] = mat;
                            var xc = el.GetColorXml();
                            var color = xc.Get();
                           // Color color = el.GetColor();
                            PropertyInfo pi = t.GetProperty("Color");
                            pi.SetValue(mat, color, null);
                            if (mat is SpecularMaterial sm)
                            {
                                try
                                {
                                    var rf = el.GetAttribute("reflectivity");
                                    if (rf.Length > 0)
                                    {
                                        double refl = el.ToDouble("reflectivity");
                                        sm.SpecularPower = refl;
                                    }
                                }
                                catch (Exception exception)
                                {
                                    throw new Exception();
                                }
                            }
                            XmlElement texture = el.GetChild("texture");
                            if (texture != null)
                            {
                                ImageSource im = null;
                                string tex = texture.GetAttribute("texture");
                                var imXml = GetImageXml(tex);
                                if (imXml != null)
                                {
                                    var x = imXml.Get();
                                    if (x is ImageSource iso)
                                    {
                                        im = iso;
                                    }
                                }
                                if (im == null)
                                {
                                    continue;
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

                            if (mat != null)
                            {
                                l.Add(mat);
                            }
                        }
                    }
                }
            }
            return l.SimplifyMaterial();
          }



        Material GetMaterial(string matName)
        {
            var x = elementList[matName];
            if (x == null)
            {
                return null;
            }
            var l = new List<Material>();
            foreach (var m in x)
            {
                if (materials.ContainsKey(m))
                {
                    l.Add(materials[m]);
                }
                else
                {
                    if (m.Name  == "effect")
                    {
                        Material mat = GetEffect(m) as Material;
                    }
                }
            }
            if (l.Count == 0)
            {
                return null;
            }
            if (l.Count == 1)
            {
                return l[0];
            }
            return l.ToMaterial();
    
        }


        private Material GetInsanceEffect(XmlElement element)
        {
            var m = element.Get();
            if (m != null)
            {
                if (m is Material mater)
                {
                    return mater;
                }
            }
            var url = element.GetAttribute("url");
            if (url.Length > 1)
            {
                var mat = GetMaterial(url.Substring(1));
                if (mat != null)
                {
                    return mat;
                }
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
            return l.ToMaterial();
        }




        #endregion



    }
}
