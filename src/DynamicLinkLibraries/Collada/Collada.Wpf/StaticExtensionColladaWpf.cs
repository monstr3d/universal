using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Xml.Linq;
using Collada.Wpf.Classes;
using Collada;
using Abstract3DConverters;

namespace Collada.Wpf
{
    public static  class StaticExtensionColladaWpf
    {

    

        static public Dictionary<string, System.Windows.Media.Media3D.Material> Mtl { 
            get; 
            set; 
        }



        internal static System.Windows.Media.Media3D.Material GetMaterial(this string name)
        {
            if (Mtl == null)
            {
                return null;
            }
            if (Mtl.ContainsKey(name))
            {
                return Mtl[name];
            }
            return null;
        }

        static List<Point3D> ToPoint3DList(this double[] x)
        {
            List<Point3D> c = new List<Point3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Point3D p = new Point3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }

        static public ModelVisual3D Result => Node.GetAll();


        public static List<int[]> ToInt3Array(this int[] x)
        {
            List<int[]> l = new List<int[]>();
            for (int i = 0; i < x.Length; i += 3)
            {
                l.Add(new int[] { x[i], x[i + 1], x[i + 2] });
            }
            return l;
        }

        static public List<int[]> ToInt3Array(this XmlElement element)
        {
            return element.ToIntArray().ToInt3Array();
            List<int[]> l = new List<int[]>();
            int[] x = element.ToIntArray();
            for (int i = 0; i < x.Length; i += 3)
            {
                l.Add(new int[] { x[i], x[i + 1], x[i + 2] });
            }
            return l;
        }


        public static List<Point3D> ToPoint3DList(this Source s)
        {
             return s.Array.ToPoint3DList();
        }




        public static List<Point3D> ToPoint3DList(this KeyValuePair<string, object> pair)
        {
            if (pair.Key == "POSITION")
            {
                if (pair.Value is Source source)
                {
                    return source.ToPoint3DList();
                }
            }

            throw new NotImplementedException();
        }

        public static List<Point3D> ToPoint3DList(this Vertices vertices)
        {
            return vertices.Input.Semantic.Value.ToPoint3DList();
        }

        public static Point3DCollection ToPoint3DCollection(this List<Point3D> list)
        {
           Point3DCollection vert = new Point3DCollection();
            foreach (Point3D p in list)
            {
                vert.Add(p);
            }
            return vert;
        }

        public static List<Point3D> ToPoint3DList(this object obj)
        {
            List<Point3D> points = null;
            switch (obj)
            {
                case Vertices vertices:
                    points = vertices.ToPoint3DList(); ;

                    break;
                case OffSet offSet:
                    points = offSet.Value.ToPoint3DList();
                    break;
                case Source source:
                    points = source.ToPoint3DList();
                    break;
                        
            }
            if (points == null)
            {
                throw new NotImplementedException();
            }
            return points;
        }

        public static List<Vector3D> ToVector3DList(this Source source)
        {
            return source.Array.ToVector3DList();

        }


        public static List<Vector3D> ToVector3DList(this object obj)
        {
            List<Vector3D> l = null;
            switch (obj)
            {
                case Source source:
                   l = source.ToVector3DList();

                    break;
            }
            if (l != null)
            {
                return l;
            }

            throw new NotImplementedException();
        }

        public static List<Point> ToPointList(this Source source)
        {
            return source.Array.ToPointList();
        }

        public static List<Point> ToPointList(this object obj, bool invert)
        {
            List<Point> l = null;
            switch (obj)
            {
                case Source source:
                    l = source.ToPointList();

                    break;
                case   float[] fl:
                    l = fl.Convert(x => (double)x).ToArray().ToPointList();
                    break;
            }
            if (obj is int[]  ints)
            {
                l = new List<Point>();
                for (int i = 0; i < ints.Length; i+=2)
                {
                    if (invert)
                    {
                        l.Add(new Point(ints[i], 1- ints[i + 1]));
                    }
                    else
                    {
                        l.Add(new Point(ints[i], ints[i + 1]));

                    }
                }
            }
            if (l != null)
            {
                return l;
            }

            throw new NotImplementedException();
        }

        public static System.Windows.Media.Media3D.Material DefaultMaterial { get; set; }

        internal static System.Windows.Media.Media3D.Material GetMaterial(this XmlElement element)
        {
            var mat = element.GetAttribute("material");
            if (mat == "default")
            {
                return null;
            }
            return MaterialObject.Get(mat);
        }

        internal static T Get<T>(this string id, Dictionary<string, T> d) where T : class
        {
            if (d.ContainsKey(id))
                return d[id];
            return null;
        }


        internal static void  Put<T>(this XmlElement element, T value, Dictionary<string, T> d) where T : class
        {
            var id = element.GetAttribute("id");
            if (id.Length == 0)
            {
                return;
            }
            if (d.ContainsKey(id))
            {
                throw new Exception();
            }
            d[id] = value;
        }

        static List<System.Windows.Media.Media3D.DiffuseMaterial> abscentImage = new List<System.Windows.Media.Media3D.DiffuseMaterial>();

        internal static bool Check(this System.Windows.Media.Media3D.Material material)
        {
            if (material is System.Windows.Media.Media3D.DiffuseMaterial diff)
            {
                return true;
                var brush = diff.Brush as ImageBrush;
                if (brush == null)
                {
                    return abscentImage.Contains(diff);
                }
                return true;

            }
            if (material is System.Windows.Media.Media3D.MaterialGroup group)
            {
                if (group.Children.Count != 3)
                { 
                    return false; 
                }
                System.Windows.Media.Media3D.EmissiveMaterial emissive = null;
                System.Windows.Media.Media3D.SpecularMaterial specular = null;
                System.Windows.Media.Media3D.DiffuseMaterial diffuse = null; 
                foreach ( var child in group.Children )
                {
                    switch (child)
                    {
                        case System.Windows.Media.Media3D.EmissiveMaterial emissiveMaterial:
                            emissive = emissiveMaterial;
                            break;
                        case System.Windows.Media.Media3D.SpecularMaterial sMaterial:
                            specular = sMaterial;
                            break;
                        case System.Windows.Media.Media3D.DiffuseMaterial diffuseMaterial:
                            if (!diffuseMaterial.Check())
                            {
                                return false;
                            }
                            diffuse = diffuseMaterial;
                            break;
                        default:
                            break;
                    }
                }
                return (diffuse != null) & (specular != null) & (emissive != null);
            }
            return true;
        }

        internal static void Check(this Visual3D visual3D)
        {
            if (visual3D == null)
            {
                throw new Exception();
            }
            if (visual3D is ModelVisual3D m)
            {
                m.Check();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        internal static void Check(this ModelVisual3D modelVisual3D)
        {
            var m = modelVisual3D.Content as GeometryModel3D;
            if (m == null)
            {
                throw new Exception();
            }
            if (!m.Material.Check())
            {
                throw new Exception();
            }
            var ms = m.Geometry as MeshGeometry3D;
            if (ms == null)
            {
                throw new Exception();
            }
            ms.Check();
        }

        internal static void Check(this MeshGeometry3D meshGeometry3D)
        {
            if (meshGeometry3D.Positions == null)
            {
                throw new Exception();
            }
            if (meshGeometry3D.Normals == null)
            {
                throw new Exception();
            }
            if (meshGeometry3D.TextureCoordinates == null)
            {
                throw new Exception();
            }
            if (meshGeometry3D.TriangleIndices.Count == 0)
            {
               // throw new Exception();
            }    
        }

      

        internal static bool Set(this System.Windows.Media.Media3D.DiffuseMaterial diffuseMaterial, ImageSource imageSource)
        {
            if (diffuseMaterial == null)
            {
                return false;
            }
            var brush = diffuseMaterial.Brush as ImageBrush;
            if (brush != null)
            {
                return true;
            }
            if (imageSource == null)
            {
                if (!abscentImage.Contains(diffuseMaterial))
                {
                    abscentImage.Add(diffuseMaterial);
                }
                return false;
            }
            ImageBrush br = new ImageBrush(imageSource);
            br.ViewportUnits = BrushMappingMode.Absolute;
            br.Opacity = 1;
            diffuseMaterial.Brush = br;
            return true;
        }

        internal static bool Set(this System.Windows.Media.Media3D.DiffuseMaterial diffuseMaterial, Surface surface)
        {
            if (surface == null)
            {
                return false;
            }
            return diffuseMaterial.Set(surface.ImageSource);
        }

        internal static bool Set(this System.Windows.Media.Media3D.DiffuseMaterial diffuseMaterial, Sampler2D sampler2D)
        {
            if (sampler2D == null)
            {
                return false;
            }
            if (sampler2D.ImageSource != null)
            {
                return diffuseMaterial.Set(sampler2D.ImageSource);
            }
            return diffuseMaterial.Set(sampler2D.Surface);
        }

        internal static bool Set(this System.Windows.Media.Media3D.DiffuseMaterial diffuseMaterial, Texture texture)
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

        internal  static void Set(this System.Windows.Media.Media3D.SpecularMaterial mat, Reflectivity refl)
        {
            if (refl == null)
            {
                return;
            }
            var r = refl.Value.NumberToDouble();
            mat.SpecularPower = r * 100;
        }

        internal static void Set(this System.Windows.Media.Media3D.EmissiveMaterial mat, Transparent transparent)
        {
            if (transparent == null)
            {
                return;
            }    
        }

        public static void Set(this System.Windows.Media.Media3D.SpecularMaterial mat, XmlElement e)
        {
            var t = e.Get<Reflectivity>();
            mat.Set(t);
        }

        internal static void Set(this System.Windows.Media.Media3D.EmissiveMaterial mat, XmlElement e)
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

        public static List<int[]> ToTextureArray(this int[] x)
        {
            var l = new List<int[]>();
            for (int i = 0; i < x.Length; i+= 9)
            {
                var y = new int[9];
                Array.Copy(x, i, y, 0, 9);
                l.Add([y[0], y[3], y[6]]);
                l.Add([y[1], y[4], y[7]]);
                l.Add([y[2], y[5], y[8]]);
            }

            return l;
        }

        public static List<int[]> ToTextureArray(this XmlElement element)
        {
            var x = element.ToIntArray();
            return x.ToTextureArray();
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

        internal static object GetSemantic(this string semantic, string id)
        {
            if (semantic == "POSITION")
            {
                return id.Get<Source>();
            }
            if (semantic == "VERTEX")
            { 

                return  id.Get<Vertices>();
            }
            if (semantic == "NORMAL")
            {
                return id.Get<Source>();
            }
            if (semantic == "TEXCOORD")
            {
               return  id.Get<Source>().Array;
            }
            throw new Exception();
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

        public static System.Windows.Media.Color ToColor(this double[] d)
        {
            if (d.Length == 3)
            {
                return System.Windows.Media.Color.FromRgb(d[0].ToByte(), d[1].ToByte(), d[2].ToByte());
            }
            else if (d.Length == 4)
            {
                return System.Windows.Media.Color.FromArgb(d[3].ToByte(), d[0].ToByte(), d[1].ToByte(), d[2].ToByte());
            }
            throw new Exception();
        }




        public static System.Windows.Media.Color ToColor(this string str)
        {
            var ss = str.Split(" ".ToCharArray());
            var d = new List<double>();
            foreach (var s in ss)
            {
                var t = s.Trim();
                if (t.Length == 0)
                {
                    continue;
                }
                d.Add(s.ToDouble());
            }
            return d.ToArray().ToColor();
        }

        public static void Load(string filename)
        {
            StaticExtensionCollada.Load(filename);
        }

 


        static public ColladaObject Instance => ColladaObject.Instance;

 
        public static  List<System.Windows.Media.Media3D.Material> ToList(this System.Windows.Media.Media3D.Material material)
        {
            List<System.Windows.Media.Media3D.Material> list = new List<System.Windows.Media.Media3D.Material>();
            if (material is System.Windows.Media.Media3D.MaterialGroup group)
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

        public static System.Windows.Media.Media3D.Material SimplifyMaterial(this object  obj)
        {
            var mat = obj.ToMaterial();
            return mat.SimplifyMaterial();
        }

        public static System.Windows.Media.Media3D.Material SimplifyMaterial(this System.Windows.Media.Media3D.Material material)
        {
            return material.ToList().ToMaterial();
        }

        public static object GetObject(this string key)
        {
           return Function.Instance.Get(key);
        }

        public static System.Windows.Media.Media3D.Material FromXml(this XmlElement element, string tag)
        {
            var l = new List<System.Windows.Media.Media3D.Material>();
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
                    if (o is System.Windows.Media.Media3D.Material m)
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

        public static System.Windows.Media.Media3D.Material ToMaterial(this object o)
        {
            if (o is System.Windows.Media.Media3D.Material material)
            {
                return material;
            }
            var list = new List<System.Windows.Media.Media3D.Material>();
            if (o is IEnumerable en)
            {
                foreach (var mpp in en)
                {
                    if (mpp is System.Windows.Media.Media3D.Material mp)
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
            var mg = new System.Windows.Media.Media3D.MaterialGroup();
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


        static public List<Point> ToPointList(this double[] x)
        {
            List<Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new Point(x[i], x[i + 1]);
                c.Add(p);
            }
            return c;
        }

        static public List<Point> ToPointList(this float[] x)
        {
            List<Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new Point((double)x[i], 1 - (double)x[i + 1]);
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
            return null;
        }

        public static void Set(this System.Windows.Media.Media3D.Material m, Texture texture)
        {
            if (texture == null)
            {
                return;
            }
            if (m is System.Windows.Media.Media3D.DiffuseMaterial diffuse)
            {
                diffuse.Set(texture.Sample);
            }
        }

        static public System.Windows.Media.Color GetColor(this double[] d)
        {
            if (d.Length == 3)
            {
                return System.Windows.Media.Color.FromRgb(d[0].ToByte(), d[1].ToByte(), d[2].ToByte());
            }
            else if (d.Length == 4)
            {
                return System.Windows.Media.Color.FromArgb(d[3].ToByte(), d[0].ToByte(), d[1].ToByte(), d[2].ToByte());
            }
            throw new Exception();

        }


        static public System.Windows.Media.Color GetColor(this string s)
        {
            double[] d = s.ToRealArray<double>();
            return d.GetColor();
        }

        static public System.Windows.Media.Color GetColor(this XmlElement e)
        {
            if (e.Name.Equals("color"))
            {
                double[] d = e.InnerText.ToRealArray<double>();
                return d.GetColor();
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



  /*   

        static public void SetLight(this Visual3D v3d)
        {
            if (v3d is ModelVisual3D)
            {
                ModelVisual3D m3d = v3d as ModelVisual3D;
                ModelVisual3D m = new ModelVisual3D();
                AmbientLight l = new AmbientLight(  System.Windows.Media.Color.FromRgb(255, 255, 255));
                m.Content = l;
                m3d.Children.Insert(0, m);
            }
        }
  */

        #endregion
    }
}
