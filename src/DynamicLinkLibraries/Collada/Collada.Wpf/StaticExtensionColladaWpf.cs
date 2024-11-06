using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using Collada.Wpf.Classes;

namespace Collada.Wpf
{
    public static  class StaticExtensionColladaWpf
    {

 

        internal static bool Set(this DiffuseMaterial diffuseMaterial, ImageSource imageSource)
        {
            if (imageSource == null)
            {
                return false;
            }
            ImageBrush br = new ImageBrush(imageSource);
            br.ViewportUnits = BrushMappingMode.Absolute;
            br.Opacity = 1;
            return true;
        }

        internal static bool Set(this DiffuseMaterial diffuseMaterial, Surface surface)
        {
            if (surface == null)
            {
                return false;
            }
            return diffuseMaterial.Set(surface.ImageSource);
        }

        internal static bool Set(this DiffuseMaterial diffuseMaterial, Sampler2D sampler2D)
        {
            if (sampler2D == null)
            {
                return false;
            }
            return diffuseMaterial.Set(sampler2D.Surface);
        }

        internal static bool Set(this DiffuseMaterial diffuseMaterial, Texture texture)
        {
            if (texture == null)
            {
                return false;
            }
            return diffuseMaterial.Set(texture.Sample);
        }

        internal static void SetTextureByXmlElement(this Diffuse diffuse, XmlElement element)
        {
            var t = element.Get<Texture>();
            diffuse.Set(t);
        }

        internal  static void Set(this SpecularMaterial mat, Reflectivity refl)
        {
            if (refl == null)
            {
                return;
            }
            var r = refl.Value.NumberToDouble();
            mat.SpecularPower = r * 100;
        }

        internal static void Set(this EmissiveMaterial mat, Transparent transparent)
        {
            if (transparent == null)
            {
                return;
            }    
        }

        public static void Set(this SpecularMaterial mat, XmlElement e)
        {
            var t = e.Get<Reflectivity>();
            mat.Set(t);
        }

        internal static void Set(this EmissiveMaterial mat, XmlElement e)
        {
            var t = e.Get<Transparent>();
            mat.Set(t);

        }







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

        static Visual3D GetMesh(XmlElement element)
        {
            /*
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            var poly = element.GetChild("polylist");
            if (poly != null)
            {

                List<int[]> ind = poly.ToInt3Array();
             //   mat = Find<Material>(poly.GetAttribute("material").ToIdName());
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
            return mod;*/
            return null;
        }


        public static List<int[]> ToInt3Array(this XmlElement element)
        {
            List<int[]> l = new List<int[]>();
            int[] x = element.ToIntArray();
            for (int i = 0; i < x.Length; i += 3)
            {
                l.Add(new int[] { x[i], x[i + 1], x[i + 2] });
            }
            return l;
        }

        public static List<Point3D> ToPoint3DList(this XmlElement e)
        {
            return null;// e.GetAllChildren<double[]>().ToArray().ToPoint3DList();
        }
        public static void CreateElementary(this Assembly assembly, Dictionary<string, MethodInfo> methods, List<string> elementary, List<string> all)
        {
            Type[] typ = assembly.GetTypes();
            foreach (var item in typ)
            {
                FieldInfo fi = item.GetField("Tag");
                if (fi == null)
                {
                    continue;
                }
                var s = fi.GetValue(null) as string;
                if (s.Length == 0)
                {
                    continue;
                }
                MethodInfo mi = item.GetMethod("Get", new Type[] { typeof(XmlElement) });
                if (mi == null)
                {
                    throw new Exception();
                }
                methods[s] = mi;
                if (all.Contains(s))
                {
                    throw new Exception();
                }
                all.Add(s);
                fi = item.GetField("IsElementary");
                if (fi == null)
                {
                    continue;
                }
                var b = (bool)fi.GetValue(null);
                if (b)
                {
                    elementary.Add(s);
                }
            }
 
        }

        static internal readonly List<string> Unknown = new()
        {
            "author", "authoring_tool", "comments", "copyright", "contributor",
            "created", "modified", "asset", "library_materials", "COLLADA", "init_from",
            "library_images", "technique", "profile_COMMON",    "library_effects", "library_geometries" , "library_visual_scenes"
        };

        static StaticExtensionColladaWpf()
        {
        }

        static public void CheckSource(this XmlElement element)
        {
            var s = element.GetElementsByTagName("source");
            if (s.Count > 0)
            {
                throw new Exception();
            }
        }
    
        public static void Set()
        {
            try
            {
                StaticExtensionCollada.Function = Function.Instance;
                StaticExtensionCollada.Collada = ColladaObject.Instance;
            }
            catch (Exception ex)
            {

            }
        }

        public static void Load(string filenme)
        {
            StaticExtensionCollada.Load(filenme);
        }

 


        static public ColladaObject Instance => ColladaObject.Instance;

 
        public static  List<Material> ToList(this Material material)
        {
            List<Material> list = new List<Material>();
            if (material is MaterialGroup group)
            {
                foreach (var mat in group.Children)
                {
                    list.AddRange(mat.ToList());
                }
            }
            else
            {
                if (!list.Contains(material))
                {
                    list.Add(material);
                }
            }
            return list;
        }

        public static Material SimplifyMaterial(this object  obj)
        {
            var mat = obj.ToMaterial();
            return mat.SimplifyMaterial();
        }

        public static Material SimplifyMaterial(this Material material)
        {
            return material.ToList().ToMaterial();
        }

        public static object GetObject(this string key)
        {
           return Function.Instance.Get(key);
        }

        public static Material FromXml(this XmlElement element, string tag)
        {
            var l = new List<Material>();
            var nl = element.GetElementsByTagName(tag);
            foreach (XmlNode node in nl)
            {
                if (node.ParentNode != element)
                {
                  //  continue;
                }
                if (node is XmlElement e)
                {
                    var o = e.Get();
                    if (o is Material m)
                    {
                        l.Add(m);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            return l.SimplifyMaterial();
        }

        public static Material ToMaterial(this object o)
        {
            if (o is Material material)
            {
                return material;
            }
            var list = new List<Material>();
            if (o is IEnumerable en)
            {
                foreach (var mpp in en)
                {
                    if (mpp is Material mp)
                    {
                        list.Add(mp);
                    }
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            if (list.Count == 1)
            {
                return list[0];
            }
            var mc = new MaterialCollection(list);
            var mg = new MaterialGroup();
            mg.Children = mc;
            return mg;
       }

        public static object GetMaterial(this string mat, int materialIndex)
        {
          /*  if (mat == "default")
            {
                if (GetDefaultMaterial != null)
                {
                    return GetDefaultMaterial(materialIndex);
                }
                else
                {
                    return null;
                }
            }*/
            throw new NotImplementedException();
        }


        static public List<System.Windows.Point> ToPointList(this double[] x)
        {
            List<System.Windows.Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new System.Windows.Point(x[i], 1 - x[i + 1]);
                c.Add(p);
            }
            return c;
        }

        static public List<System.Windows.Point> ToPointList(this float[] x)
        {
            List<System.Windows.Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new System.Windows.Point(x[i], 1 - x[i + 1]);
                c.Add(p);
            }
            return c;
        }

        static public XmlElement GetColorXml(this XmlElement e)
        {
            if (e.Name == "color")
            {
                return e;
            }
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n.Name.Equals("color"))
                {
                    return (n as XmlElement);
                }
            }
            throw new Exception();
        }

    
        static public Color GetColor(this XmlElement e)
        {
            if (e.Name.Equals("color"))
            {
                double[] d = e.ToRealArray<double>();
                if (d.Length == 3)
                {
                    return Color.FromRgb(d[0].ToColor(), d[1].ToColor(), d[2].ToColor());
                }
                else if (d.Length == 4)
                {
                    return Color.FromArgb(d[3].ToColor(), d[0].ToColor(), d[1].ToColor(), d[2].ToColor());
                }
                throw new Exception();
            }
            foreach (XmlNode n in e.ChildNodes)
            {
                if (n.Name.Equals("color"))
                {
                    return (n as XmlElement).GetColor();
                }
            }
            throw new Exception();
        }
        #region Convert



   





        public static ImageSource ToImage(this string str)
        {
            string fn = str.ToFileName();
            if (!System.IO.File.Exists(fn))
            {
                return null;
            }
            System.Windows.Media.Imaging.BitmapImage bi =
                new System.Windows.Media.Imaging.BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(fn);
            bi.EndInit();
            return bi;
        }



        public static byte ToColor(this double x)
        {
            double y = Math.Floor(x * 255);
            return (byte)y;
        }



        public static List<Vector3D> ToVector3DList(this double[] x)
        {
            List<Vector3D> c = new List<Vector3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Vector3D p = new Vector3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }








        public static List<Point3D> ToPoint3DList(this double[] x)
        {
            List<Point3D> c = new List<Point3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Point3D p = new Point3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }
        public static List<Point3D> ToPoint3DList(this float[] x)
        {
            List<Point3D> c = new List<Point3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Point3D p = new Point3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }

        public static List<Vector3D> ToVector3DList(this float[] x)
        {
            var c = new List<Vector3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                var p = new Vector3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }



     

        static public void SetLight(this Visual3D v3d)
        {
            if (v3d is ModelVisual3D)
            {
                ModelVisual3D m3d = v3d as ModelVisual3D;
                ModelVisual3D m = new ModelVisual3D();
                AmbientLight l = new AmbientLight(Color.FromRgb(255, 255, 255));
                m.Content = l;
                m3d.Children.Insert(0, m);
            }
        }


        #endregion
    }
}
