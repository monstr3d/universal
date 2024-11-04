using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Reflection;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using Collada.Wpf.Classes;

namespace Collada.Wpf
{
    partial class Function
    {
        #region Combined functions

        #region Combine Members
        
        object GetParam(XmlElement element)
        {
            return null;// return new Param(element);
        }

  

        object GetBlur(XmlElement element, object o)
        {
            return null;
        }

        object GetTexture(XmlElement element)
        {
            return new Texture(element);
        }
        object GetArray(XmlElement element, object o)
        {
            Array arr = o as Array;
            return o;
        }

        object GetScene(XmlElement element, object o)
        {
            var scene = o as Scene;
            var xml = scene.Xml;

            return o;
        }

        object GetSample2D(XmlElement element)
        {
            var s = Sid.Get(element);
            if (s != null)
            {
                return s;
            }
            return new Sampler2D(element);
        }

        internal object Get(string name)
        {
            if (elementList.ContainsKey(name))
            {
                var s = elementList[name];
                if (s.Count == 1)
                {
                    return s[0].Get();
                }
            }
            throw new Exception();
        }

        static public object FromCollada(string name)
        {
            return Instance.Get(name);
        }


  


    
        object GetVisual3D(XmlElement element, object o)
        {
            var visual3D = o as Visual3D;
            if (visual3D is ModelVisual3D mod)
            {
                var c = mod.Content;
                if (c is GeometryModel3D g3d)
                {
                    var g = g3d.Geometry;
                    if (g is MeshGeometry3D m3d)
                    {
                        element.Set(m3d);
                    }
                }
            }

            return visual3D;
        }


        #endregion

        #endregion

        object GetVetrices<T>(XmlElement element) where T : struct
        {
            T[] x = element.FindSourceChild<T[]>();
            return x;
        }
        object GetScenes(XmlElement element)
        {
            return new Scene(element);
        }
        static object GetP(XmlElement element)
        {
            return element.ToRealArray<int>();
        }

        object GetFloatArray(XmlElement element)
        {
            return element.ToRealArray<float>();
        }

        object GetGeometry(XmlElement element)
        {
            XmlElement e = element.FirstChild as XmlElement;
            string type = e.Name;
            if (visualDic.ContainsKey(type))
            {
                Visual3D v3d = visualDic[type](e);
                return v3d;
            }
            return null;
        }


        Visual3D GetMesh(XmlElement element)
        {
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var poly = element.GetChild("polylist");
            if (poly != null)
            {

                List<int[]> ind = poly.ToInt3Array();
                mat = poly.GetAttribute("material").Find<Material>();
                if (mat == null)
                {
                    return null;
                }
                XmlNodeList nl = poly.GetElementsByTagName("input");
                Dictionary<string, object> d = poly.FindInputs();
                List<Point3D> vertices = (d["VERTEX"] as double[]).ToPoint3DList();
                List<Vector3D> norm = (d["NORMAL"] as double[]).ToVector3DList();
                List<System.Windows.Point> textures = (d["TEXCOORD"] as double[]).ToPointList();
                Point3DCollection vert = new Point3DCollection();
                PointCollection textc = new PointCollection();
                Int32Collection index = new Int32Collection();
                Vector3DCollection norms = new Vector3DCollection();
                Vector3D[] nt = new Vector3D[ind.Count];
                var pt = new System.Windows.Point[ind.Count];
                for (int i = 0; i < ind.Count; i++)
                {
                    norms.Add(norm[i]);
                    textc.Add(textures[i]);
                    vert.Add(vertices[ind[i][0]]);
                }
                mesh.Positions = vert;
                mesh.Normals = norms;
                mesh.TextureCoordinates = textc;
                mesh.TriangleIndices = index;
                GeometryModel3D geom = new GeometryModel3D();
                geom.Geometry = mesh;
                geom.Material = mat;
                mod.Content = geom;
            }
            else
            {
                GeometryModel3D geom = new GeometryModel3D();
                geom.Geometry = mesh;
                mod.Content = geom;
            }
            var ss = element.GetElementsByTagName("source");
            foreach (XmlElement s in ss)
            {
                if (s.ParentNode != element)
                {
                    continue;
                }

            }
            ss = element.GetElementsByTagName("triangles");
            if (ss.Count == 1)
            {
                var tringles = ss[0] as XmlElement;

            }
            return mod;
        }


        private object GetEffect(XmlElement element)
        {
            var effect = new BlurEffect();
            return effect;
        }

        private object CalculateMaterialObject(XmlElement e)
        {
            var l = CalculateMaterial(e);
            return l.SimplifyMaterial();
        }


        private List<Material> CalculateMaterial(XmlElement element)
        {
            var materials = new List<Material>();
            foreach (string key in materialCalc.Keys)
            {
                XmlNodeList nlp = element.GetElementsByTagName(key);
                foreach (XmlElement xmlElement in nlp)
                {
                    var o = xmlElement.Get();
                    if (o is Material mm)
                    {
                        materials.Add(mm);
                        continue;
                    }
                    var mat = materialCalc[key](xmlElement);
                    if (mat != null)
                    {

                        if (o != null)
                        {
                            if (o != mat)
                            {
                                throw new Exception();
                            }
                        }
                        o = xmlElement.Get();
                        if (o != null)
                        {
                            if (o != mat)
                            {
                                throw new Exception();
                            }
                            xmlElement.Set(mat);
                        }
                        if (mat is MaterialGroup mg)
                        {
                            foreach (Material mmt in mg.Children)
                            {
                                materials.Add(mmt);
                                continue;
                            }
                        }
                        else
                        {
                            materials.Add(mat);
                        }

                    }
                }
            }
            return materials;
        }

        Material GetInstanceEffectMaterial(XmlElement xmlElement)
        {
            var materials = new List<Material>();
            var url = xmlElement.GetAttribute("url");
            var tag = url.Substring(1);
            var elp = elementList[tag];
            var el = new List<XmlElement>(elp);
            foreach (var ee in el)
            {
                var o = ee.Get();
                if (o != null)
                {
                    materials.Add(o as Material);
                }
                else
                {
                    var mms = CalculateMaterial(ee);
                    materials.AddRange(mms);
                }
            }
            return materials.SimplifyMaterial();
        }



        private object GetMaterial(XmlElement element)
        {
            var materials = new List<Material>();
            var nl = element.GetElementsByTagName("instance_effect");
            foreach (XmlElement xmlElement in nl)
            {
                if (xmlElement.ParentNode == element)
                { ///INSTANCE
                    return xmlElement.Get();
                }
            }
            return materials.ToMaterial();
        }

        Material FromEnumerable(IEnumerable<Material> materials)
        {
            var l = materials.ToArray();
            if (l.Length == 0)
            {
                return null;
            }
            if (l.Length == 1)
            {
                return l[0];
            }
            return l.ToMaterial();
        }

        XmlElement GetImageFromTexture(string textureName)
        {
            return null;
        }

   
        object GetImage(XmlElement element)
        {
            ImageSource im = element.InnerText.ToImage();
            if (im == null)
            {
                return false;
            }
            return im;
        }

        object GetSource(XmlElement element)
        {
            
            //return new Source(element);
            var l = new List<object>();
            foreach (string key in sourceDic.Keys)
            {
                XmlElement e = element.GetChild(key);
                if (e != null)
                {
                    object o = sourceDic[key](e);
                    if (o != null)
                    {
                        l.Add(o);
                    }
                }
            }
            if (l.Count > 0)
            {
                if (l.Count == 1)
                {
                    return l[0];
                }
                return l;
            }
            throw new Exception();
        }

        #region Finctions

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

        object GetFloat(XmlElement element)
        {
            return float.Parse(element.InnerText);
        }


        UpDirection Direction { get; set; }
        object SetUpAxis(XmlElement element)
        {
            var up = UpDirection.None;
            if (element.InnerText == "Y_UP")
            {
                up = UpDirection.Y;
            }
            Direction = up;
            return up;
        }


        object GetPhongObject(XmlElement e)
        {
            return GetPhong(e);
        }

        Unit MeterUnit
        {
            get;
            set;
        }

        object SetUnit(XmlElement xmlElement)
        {
            var unit = new Unit { Text = xmlElement.InnerXml };
            MeterUnit = unit;
            return unit;
        }

        /*

        ImageSource GetImageXml(string tex)
        {
            XmlElement et = null;
            var p = Parameter.Get(tex);
            ImageSource iso = null;
            foreach (var pp in p)
            {
                var v = pp.Value;
                if (v is ImageSource ss)
                {
                    if (iso == null)
                    {
                        iso = ss;
                    }
                    else if (iso != ss)
                    {
                        throw new Exception();
                    }
                    continue;
                }
                if (v is Abstract @abstract)
                {
                    var tv = @abstract.Value;
                    if (tv is ImageSource its)
                    {
                        if (iso == null)
                        {
                            iso = its;
                        }
                        else if (iso != its)
                        {
                            throw new Exception();
                        }
                    }
                    continue;

                }
            }
            return iso;
            /*   if (parametersNew.ContainsKey(tex))
               {
                   var par = Parameter.Get(tex).Xm;
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
        }
        */


        internal Material GetMaterialColor(XmlElement xml)
        {
            var n = xml.Name;
            var t = materialTypes[n];
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
                Texture text = texture.Get() as Texture;
                var s = text.Sample.Surface;
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
            }
            return mat;
        }


        private Material GetPhong(XmlElement e)
        {
            if (materials.ContainsKey(e))
            {
                return materials[e];
            }
            List<Material> l = new List<Material>();
            Transparent transparent = null;
            float reflectivity = -1;
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n is XmlElement el)
                {
                    var nm = el.Name;
                    if (nm == "transparent")
                    {
                        transparent = el.Get() as Transparent;
                        continue;
                    }
                    if (nm == "reflectivity")
                    {
                        reflectivity = (float)el.Get();
                        continue;
                    }
                    Material mat = null;
                    if (materialTypes.ContainsKey(nm))
                    {
                        var mm = el.Get();
                        if (mm is Material mmt)
                        {
                            mat = mmt;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    if (mat == null)
                    {
                        throw new Exception();
                    }

                    l.Add(mat);
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
                    if (m.Name == "effect")
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
