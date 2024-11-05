using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Controls;
using System.Net.Http.Headers;
using Collada.Wpf.Classes;

namespace Collada.Wpf
{
    partial class StaticExtensionColladaOld
    {

        #region Fields

        #region Combine
        /*
                private static Dictionary<Type, Func<IdName, object, Dictionary<IdName, object>, object>> combine = new()
                {
                    { typeof(BlurEffect), GetBlur }
                };
        */


        #endregion


        #region Dictionary

        private static Dictionary<IdName, object> allObjects = new();

        private static Dictionary<IdName, object> arrays = new();

        private static Dictionary<IdName, MeshGeometry3D> meshes = new();

        private static Dictionary<IdName, ImageSource> images = new();

        private static Dictionary<IdName, Scene> scenes = new();

        private static Dictionary<IdName, Material> materials = new();

        private static Dictionary<IdName, Visual3D> visuals = new();

        private static Dictionary<IdName, Effect> effects = new();

        static Dictionary<IdName, int[]> intp = new();


        private static Dictionary<IdName, object> sources = new();

        private static Dictionary<string, IdName> sourcesId = new();


        #endregion



        #region


        private static readonly Dictionary<string, object[]> functions
     = new()
            {
{"float_array", new object[] {new Func<IdName, XmlElement, object>(GetArray<float>), arrays}},
{"geometry", new object[]{new Func<IdName, XmlElement, object>(GetGeometry), visuals}},
{"effect", new object[]{new Func<IdName, XmlElement, object>(GetEffect), effects}},

{"material", new object[]{new Func<IdName, XmlElement, object>(GetMaterial), materials}},
{"image", new object[]{new Func<IdName, XmlElement, object>(GetImage), images}},
{"source", new object[] {new Func<IdName, XmlElement, object>(GetSource), sources}},
{"vertices", new object[] {new Func<IdName, XmlElement, object>(GetVetrices<float>), sources}},
{"p", new object[] {new Func<IdName, XmlElement, object>(GetP), intp}},
         { "library_visual_scenes", new object[] {new Func<IdName, XmlElement, object>(GetScenes), scenes} },
  };




        private static readonly Dictionary<string, Func<XmlElement, object>> sourceDic = new()
       {
 {"float_array", GetFloatArray}
       };

        private static readonly Dictionary<string, Func<XmlElement, Visual3D>> visualDic = new()
       {
 {"mesh", GetMesh}
       };

        #endregion

        private static Dictionary<Type, Func<IdName, object, List<KeyValuePair<IdName, object>>, object>> combine = new()
        {
            { typeof(BlurEffect), GetBlur },
            {typeof(Array), GetArray },
            {typeof(Visual3D), GetVisual3D},
            {typeof(Scene), GetScene}
        };


        #endregion

        #region Common


        private static readonly Dictionary<string, Type> materialTypes = new Dictionary<string, Type>()
        {
                 {"diffuse", typeof(DiffuseMaterial)},
                 {"specular", typeof(SpecularMaterial)},
    {"reflective", typeof(SpecularMaterial)}
   // {"transparent",  typeof(DiffuseMaterial}*/
      };




        #region Combines

        static object GetBlur(IdName name, object o, Dictionary<IdName, object> l)
        {
            return null;
        }



        #endregion



        #endregion

        #region Convert

        public static int[] ToIntArray(this XmlElement element)
        {
            XmlElement e = element.GetChild("p");
            string[] ss = e.InnerText.Separate();
            List<int> l = new List<int>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    l.Add(s.ToInt());
                }
            }
            return l.ToArray();
        }


   






        public static Func<int, Material> GetDefaultMaterial
        {
            get;
            set;
        }



        #endregion

        #region Func<IdName, XmlElement, object>

        private static object GetSource(IdName name, XmlElement element)
        {
            if (sources.ContainsKey(name))
            {
                return sources[name];
            }
            var l = new List<object>();
            foreach (string key in sourceDic.Keys)
            {
                XmlElement e = element.GetChild(key);
                if (e != null)
                {
                    object o = sourceDic[key](e);
                    if (o != null)
                    {
                        element.Add<object>(o, sources);
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
                element.Add<object>(l, sources);
                return l;
            }
            throw new Exception();
        }

        static void Add<T>(this XmlElement element, T t, Dictionary<IdName, T> dic) where T : class
        {
            IdName n = element.ToIdName();
            if (n != null)
            {
                if (!dic.ContainsKey(n))
                {
                    dic[n] = t;
                }
            }
        }



        private static object GetVetrices<T>(IdName name, XmlElement element) where T : struct
        {
            T[] x = element.FindSourceChild<T[]>();
            element.Add<object>(x, sources);
            element.Add<object>(x, arrays);
            return x;
        }

        private static object GetScenes(IdName name, XmlElement element)
        {
            return null;// return new Scene(element);
        }






        private static object GetImage(IdName name, XmlElement element)
        {
            ImageSource im = element.InnerText.ToImage();
            images[name] = im;
            return im;
        }




        private static object GetEffect(IdName name, XmlElement element)
        {
            var effect = new BlurEffect();
            effects[name] = effect;
            return effect;
        }

        private static object GetGeometry(IdName name, XmlElement element)
        {
            XmlElement e = element.FirstChild as XmlElement;
            string type = e.Name;
            if (visualDic.ContainsKey(type))
            {
                Visual3D v3d = visualDic[type](e);
                visuals[name] = v3d;
                return v3d;
            }
            return null;
        }




        private static object GetMaterial(IdName name, XmlElement element)
        {
            if (materials.ContainsKey(name))
            {
                return materials[name];
            }

            Material mat = null;
            XmlElement e = element.GetElementsByTagName("instance_effect")[0] as XmlElement;
            Dictionary<string, XmlElement> par = e.GetParameters();
            string s = e.GetAttribute("url").Substring(1);
            {
   /*             e = name.Xml;
                foreach (string key in materialCalc.Keys)
                {
                    XmlNodeList nl = e.GetElementsByTagName(key);
                    if (nl.Count == 1)
                    {
                        mat = materialCalc[key](nl[0] as XmlElement);
                    }
                }*/
            }
            if (mat == null)
            {
                //   throw new Exception();
            }
            materials[name] = mat;
            return mat;
        }

        /*

                private static object GetMaterial(IdName name, XmlElement element)
                {
                    Material mat = null;
                    XmlElement e = element.GetElementsByTagName("instance_effect")[0] as XmlElement;
                    Dictionary<string, XmlElement> par = e.GetParameters();
                    string s = e.GetAttribute("url").Substring(1);
                    IdName n = s.ToIdName();
                    if (materials.ContainsKey(n))
                    {
                        return materials[n];
                    }
                    var mats = new List<Material>();
                    foreach (string key in materialCalc.Keys)
                    {
                        XmlNodeList nl = e.GetElementsByTagName(key);
                        foreach (var node in nl)
                        {
                            if (node is XmlElement el)
                            {
                                var id = e.ToIdName();
                                Material m = null;
                                if (materials.ContainsKey(id))
                                {
                                    m = materials[id];
                                }
                                else
                                {

                                    m = materialCalc[key](el);
                                    if (m != null)
                                    {
                                        materials[id] = m;
                                    }
                                    mats.Add(m);
                                }
                            }
                        }
                    }
                    if (mats.Count == 0)
                    {
                        foreach (string key in materialCalc.Keys)
                        {
                            var m = materialCalc[key](element);
                            if (m != null)
                            {
                                mat = m;
                                break;
                            }
                        }
                    }
                    else
                    {
                        var mg = new MaterialGroup();
                        mat = mg;
                        foreach (var m in mats)
                        {
                            mg.Children.Add(m);
                        }
                    }
                    if (mat == null)
                    {
                        return null;
                    }
                    materials[name] = mat;
                    return mat;
                }*/

        static object GetP(IdName idName, XmlElement element)
        {
            if (intp.ContainsKey(idName))
            {
                return intp[idName];
            }
            if (sources.ContainsKey(idName))
            {
                return sources[idName];
            }
            var x = element.ToRealArray<int>();
            intp[idName] = x;
            return x;
        }


        private static object GetArray<T>(IdName name, XmlElement element) where T : struct
        {
            if (arrays.ContainsKey(name))
            {
                return arrays[name];
            }
            object x = null;
            if (sources.ContainsKey(name))
            {
                x = sources[name];
            }
            else
            {
                x = element.ToRealArray<T>();
            }
            arrays[name] = x;
            return x;
        }

        #endregion

        #region Func<Xmlement, object>

        static object GetFloatArray(XmlElement element)
        {
            float[] x = element.ToRealArray<float>();
            element.Add<object>(x, arrays);
            return x;
        }

        #endregion

        #region Models

   
        public static Visual3D ToVisual3D(this XmlElement element)
        {
            List<Visual3D> l = new List<Visual3D>();
            foreach (XmlElement e in element.ChildNodes)
            {
                if (!e.Name.Equals("node"))
                {
                    continue;
                }
                Visual3D v = e.ToVisual3D();
                if (v != null)
                {
                    l.Add(v);
                }
            }
            if (l.Count == 1)
            {
                return l[0];
            }
            ModelVisual3D m3d = new ModelVisual3D();
            foreach (Visual3D v3d in l)
            {
                m3d.Children.Add(v3d);
            }
            return m3d;
        }


        static Visual3D GetMesh(XmlElement element)
        {
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var poly = element.GetChild("polylist");
            if (poly != null)
            {

                List<int[]> ind = poly.ToInt3Array();
                mat = Find<Material>(poly.GetAttribute("material").ToIdName());
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
                "source".Process(s);

            }
            ss = element.GetElementsByTagName("triangles");
            if (ss.Count == 1)
            {
                var tringles = ss[0] as XmlElement;

            }
            return mod;
        }

        #endregion

        #region Materials
   

        private static Dictionary<string, Type> matTypes = new()
            {
            {"diffuse", typeof(DiffuseMaterial) },
                        {"specular", typeof(SpecularMaterial) },

                        {"reflective", typeof(EmissiveMaterial) }

};
        private static Material GetInstanceEffect(XmlElement element)
        {
            var url = element.GetAttribute("url").Substring(1);
            var c = url.ToIdName();
            if (materials.ContainsKey(c))
            {
                return materials[c];
            }
            var xml = c.Xml;
            List<Material> l = new List<Material>();
            var nl = xml.GetElementsByTagName("phong")[0];
            Material material = null;
             foreach (XmlElement e in nl.ChildNodes)
            {
                var nm = e.Name;
                if (matTypes.ContainsKey(nm))
                {
                    var t = matTypes[nm];
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
                materials[c] = material;
                return material;
            }
            var mc = new MaterialCollection(l);
            var mg = new MaterialGroup();
            mg.Children = mc;
            materials[c] = mg;
            return mg;
        }


        private static Material GetPhong(XmlElement e)
        {
            IdName nd = e.ToIdName();
            if (materials.ContainsKey(nd))
            {
                return materials[nd];
            }
            List<Material> l = new List<Material>();
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n is XmlElement el)
                {
                    Material mat = null; ;
                    nd = el.ToIdName();
                    if (materials.ContainsKey(nd))
                    {
                        mat = materials[nd];
                    }
                    else
                    {
                        string tag = e.Name;
                        if (materialTypes.ContainsKey(tag))
                        {
                            Type t = materialTypes[tag];
                            ConstructorInfo c = t.GetConstructor(new Type[0]);
                            mat = c.Invoke(new object[0]) as Material;
                            materials[nd] = mat;
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
                        if (parameters.ContainsKey(tex))
                        {
                            et = parameters[tex].ChildNodes[0] as XmlElement;
                            if (et.Name.Equals("sampler2D"))
                            {
                                string si = et.GetChild("source").InnerText;
                                if (parameters.ContainsKey(si))
                                {
                                    XmlElement ess = parameters[si];
                                    im = ess.InnerText.ToIdName().Find<ImageSource>();
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

        #endregion

    }

}

