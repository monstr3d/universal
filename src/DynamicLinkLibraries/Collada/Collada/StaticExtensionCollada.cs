using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System;
using System.Windows.Media.Effects;
using System.Windows.Markup;




namespace Collada
{
    /// <summary>
    /// Collada converter
    /// </summary>
    public static class StaticExtensionCollada
    {

        #region Fields

        static string fileName;

        static private XmlDocument doc;

        static string directory;

        private static readonly char[] sep = "\r\n ".ToCharArray();

        private static event Action<Exception> onError = (Exception e) => { };

        private static event Action<Exception> onWarning = (Exception e) => { };

        private static Dictionary<string, XmlElement> parameters = new Dictionary<string, XmlElement>();


        #endregion

        #region Dictionary


        private static Dictionary<IdName, XmlElement> nameElement = new();

        private static Dictionary<IdName, double[]> arrays = new ();

        private static Dictionary<IdName, MeshGeometry3D> meshes = new ();
        
        private static Dictionary<IdName, ImageSource> images = new ();

        private static Dictionary<IdName, Material> materials = new ();

        private static Dictionary<IdName, Visual3D> visuals = new ();

        private static Dictionary<IdName, Effect> effects = new();
      
        private static Dictionary<IdName, object> sources = new ();

        private static Dictionary<string, XmlElement> names = new ();

       

        private static Dictionary<string, Func<XmlElement,  Material>> materialCalc
            = new ()
            {
               { "phong", GetPhong} 
            };

  
        private static readonly Dictionary<string, Type> materialTypes = new Dictionary<string, Type>()
        {
                 {"diffuse", typeof(DiffuseMaterial)},
                 {"specular", typeof(SpecularMaterial)},
    {"reflective", typeof(SpecularMaterial)}
   // {"transparent",  typeof(DiffuseMaterial}*/
      };

        private static readonly Dictionary<string, object[]> actions
     = new ()
            {
{"float_array", new object[] {new Action<IdName, XmlElement>(GetArray), arrays}},
{"geometry", new object[]{new Action<IdName, XmlElement>(GetGeometry), visuals}},
{"effect", new object[]{new Action<IdName, XmlElement>(GetEffect), effects}},

{"material", new object[]{new Action<IdName, XmlElement>(GetMaterial), materials}},
{"image", new object[]{new Action<IdName, XmlElement>(GetImage), images}},
{"source", new object[] {new Action<IdName, XmlElement>(GetSource), sources}},
{"vertices", new object[] {new Action<IdName, XmlElement>(GetVetrices), sources}}
            };

       private static readonly Dictionary<string, Func<XmlElement, object>> sourceDic = new ()
       {
 {"float_array", GetFloatArray}
       };

       private static readonly Dictionary<string, Func<XmlElement, Visual3D>> visualDic = new ()
       {
 {"mesh", GetMesh}
       };

        #endregion

        #region Common

       public static void ColladaToXaml(this string fileName)
       {
            StaticExtensionCollada.fileName = fileName;
           directory = System.IO.Path.GetDirectoryName(fileName) +
               System.IO.Path.DirectorySeparatorChar;
           XmlDocument doc = new XmlDocument();
           doc.Load(fileName);
       }


       public static Dictionary<string, Visual3D> ColladaToVisual3D(this string fileName)
       {
           StaticExtensionCollada.fileName = fileName;
           directory = System.IO.Path.GetDirectoryName(fileName) +
               System.IO.Path.DirectorySeparatorChar;
           XmlDocument doc = new XmlDocument();
           doc.Load(fileName);
           doc.ColladaToXaml();
           return doc.ColladaToVisual3D();
       }

        private static void Clear()
        {
            names.Clear();
            nameElement.Clear();
            foreach (object[] o in actions.Values)
            {
                (o[1] as IDictionary).Clear();
            }
            parameters.Clear();
        }

        private static object GetSource<T>(this XmlElement e)
        {
            return null;
        }

        private static XmlElement FindByName(string tag, string name)
        {
            XmlNodeList nl = doc.DocumentElement.GetElementsByTagName(tag);
            foreach (XmlElement e in nl)
            {
                if (e.GetAttribute("name").Equals(name))
                {
                    return e;
                }
            }
            return null;
        }

        public static void ColladaToXaml(this XmlDocument doc)
        {
            StaticExtensionCollada.doc = doc;
            Clear();
            SetDictionaryId(doc.DocumentElement);
            XmlNodeList p = doc.DocumentElement.GetElementsByTagName("newparam");
            foreach (XmlElement e in p)
            {
                parameters[e.GetAttribute("sid")] = e;
            }
            foreach (IdName n in nameElement.Keys)
            {
                XmlElement e = nameElement[n];
                string tag = e.Name;
                object[] o = actions[tag];
                IDictionary d = o[1] as IDictionary;
                (actions[tag][0] as Action<IdName, XmlElement>)(n, e);
            }
        }


        static void SetLight(this Visual3D v3d)
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

        public static Dictionary<string, Visual3D> ColladaToVisual3D(this XmlDocument doc)
        {
            doc.ColladaToXaml();
            XmlElement e =  doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
            XmlNodeList nl = e.GetElementsByTagName("visual_scene");
            Dictionary<string, Visual3D> d = new Dictionary<string, Visual3D>();
            foreach (XmlElement el in nl)
            {
                Visual3D v = el.ToVisual3D();
                if (v != null)
                {
                    v.SetLight();
                    d[el.GetAttribute("id")] = v;
                }
            }
            return d;
        }


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
            if (l.Count > 0)
            {
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
            string name = element.GetAttribute("name");
            XmlElement et = FindByName("geometry", name);
            if (et == null)
            {
                return null;
            }
            Visual3D vi = et.ToIdName().Find<Visual3D>();
            return vi;
        }




        private static void SetDictionaryId(XmlElement element)
        {
            IdName id = element.ToIdName();
            if (id != null)
            {
                if (!nameElement.ContainsKey(id))
                {
                    nameElement[id] = element;
                }                
                var name = element.GetAttribute("name");
                if (name.Length > 0)
                {
                    names[name] = element;
                }
            }
            XmlNodeList nl = element.ChildNodes;
            foreach (XmlNode n in nl)
            {
                if (n is XmlElement)
                {
                    SetDictionaryId(n as XmlElement);
                }
            }
        }

        

        #endregion

        #region Events

        public static event Action<Exception> OnError
        {
            add { onError += value; }
            remove { onError -= value; }
        }
        
        public static event Action<Exception> OnWarning
        {
            add { onError += value; }
            remove { onError -= value; }
        }


        #endregion

        #region Convert

        static int[] ToIntArray(this XmlElement element)
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

 
        static List<int[]> ToInt3Array(this XmlElement element)
        {
            List<int[]> l = new List<int[]>();
            int[] x = element.ToIntArray();
            for (int i = 0; i < x.Length; i += 3)
            {
                l.Add(new int[] {x[i], x[i + 1], x[i + 2]});
            }
            return l;
        }

        static XmlElement Find(this IdName idName)
        {
            if (nameElement.ContainsKey(idName))
            {
                return nameElement[idName];
            }
            IdName id = idName.Double();
            if (nameElement.ContainsKey(id))
            {
                return nameElement[id];
            }
            return null;
        }

        static XmlElement Find(this string name)
        {
            return name.ToIdName().Find();
        }



        static IdName ToIdName(this XmlElement element)
        {
            string att = element.GetAttribute("id");
            if (att.Length > 0)
            {
                return new IdName(att, element.GetAttribute("name"));
            }
            return  null;
        }

        static string[] Separate(this string str)
        {
            return str.Split(sep);
        }

        static string ToFileName(this string str)
        {
            return directory + str.Substring(str.LastIndexOf("/") + 1);
        }

        static ImageSource ToImage(this string str)
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


        static byte ToColor(this double x)
        {
            double y = Math.Floor(x * 255);
            return (byte)y;
        }

        static Dictionary<string, XmlElement> GetParameters(this XmlElement element)
        {
            Dictionary<string, XmlElement> d = new Dictionary<string, XmlElement>();
            XmlNodeList nl = element.GetElementsByTagName("newparam");
            foreach (XmlElement e in nl)
            {
                d[e.GetAttribute("sid")] = e;
            }
            return d;
        }

        static Color GetColor(this XmlElement e)
        {
            if (e.Name.Equals("color"))
            {
                double[] d = e.ToDoubleArray();
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

        static double[] ToDoubleArray(this XmlNode node)
        {
            string str = node.InnerText;
            string[] ss = str.Split(sep);

            List<double> l = new List<double>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    l.Add(s.ToDouble());
                }
            }
            return l.ToArray();
        }

        private static IdName ToIdName(this string str)
        {
            return new IdName(str, "");
        }

        private static double ToDouble(this string str)
        {
            return Double.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }

        private static XmlElement Find(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return nl[0] as XmlElement;
            }
            return null;
        }

        private static double ToDouble(this XmlElement element)
        {
            if (element.Name.Equals("float"))
            {
                return element.InnerText.ToDouble();
            }
            XmlNodeList nl = element.GetElementsByTagName("float");
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
            throw new Exception();
        }

        private static double ToDouble(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
             throw new Exception();
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

        static List<Vector3D> ToVector3DList(this double[] x)
        {
            List<Vector3D> c = new List<Vector3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Vector3D p = new Vector3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }
        



        private static List<Point3D> ToPoint3DList(this XmlElement e)
        {
            return e.FindSource<double[]>().ToPoint3DList();
        }

        private static int ToInt(this string str)
        {
            return Int32.Parse(str);
        }


        private static int GetCount(this XmlElement e)
        {
            return e.GetAttribute("count").ToInt();
        }

        static XmlElement GetChild(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return nl[0] as XmlElement;
            }
            return null;
        }

        private static double[] FindArray(IdName name)
        {
            if (!arrays.ContainsKey(name))
            {
                GetArray(name, nameElement[name]);
            }
            return arrays[name];
        }

        public static T FindSource<T>(this XmlElement element) where T : class
        {
            XmlElement e = element.GetChild("input");
            string s = e.GetAttribute("source").Substring(1);
            return Find<T>(new IdName(s, ""));
        }
        static Dictionary<string, object> FindInputs(this XmlElement element)
        {
            XmlNodeList nl = element.GetElementsByTagName("input");
            if (nl.Count == 0)
            {
                return null;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (XmlElement e in nl)
            {
                string key = e.GetAttribute("semantic");
                XmlElement el = e.GetAttribute("source").Substring(1).Find();
                object o = e.GetAttribute("source").Substring(1).ToIdName().Find<object>();
                d[key] = o;
            }
            return d;
        }

        private static T Find<T>(this IdName name) where T : class
        {
            IdName n = name.Double();
            if (sources.ContainsKey(name))
            {
                return sources[name] as T;
            }
            if (n != null)
            {
                if (sources.ContainsKey(n))
                {
                    return sources[n] as T;
                }
            }
            XmlElement e = name.Find();
            object[] o = actions[e.Name];
            if (o[1] is Dictionary<IdName, object>)
            {
                Dictionary<IdName, object> dd = o[1] as Dictionary<IdName, object>;
                if (!dd.ContainsKey(name))
                {
                    (o[0] as Action<IdName, XmlElement>)(name, e);
                }
                return dd[name] as T;
            }
            Dictionary<IdName, T> d = o[1] as Dictionary<IdName, T>;
            if (!d.ContainsKey(name))
            {
                (o[0] as Action<IdName, XmlElement>)(name, e);
            }
            return d[name];
        }

 
        #endregion
 
        #region Action<IdName, XmlElement>

        private static void GetSource(IdName name, XmlElement element)
        {
            if (sources.ContainsKey(name))
            {
                return;
            }
            foreach (string key in sourceDic.Keys)
            {
                XmlElement e = element.GetChild(key);
                if (e != null)
                {
                    object o = sourceDic[key](e);
                    element.Add<object>(o, sources);
                    return;
                }
             }
        }

        private static void GetVetrices(IdName name, XmlElement element)
        {
            double[] x = element.FindSource<double[]>();
            element.Add<object>(x, sources);
            element.Add<double[]>(x, arrays);
        }

        
  

        private static void GetImage(IdName name, XmlElement element)
        {
            ImageSource im = element.InnerText.ToImage();
            images[name] = im;
        }




        private static void GetEffect(IdName name, XmlElement element)
        {
            var effect = new BlurEffect();
            effects[name] = effect;
        }

        private static void GetGeometry(IdName name, XmlElement element)
        {
            XmlElement e = element.FirstChild as XmlElement;
            string type = e.Name;
            
  ///!!!===============================
         /*   if (!element.GetAttribute("name").Equals("rudder"))
            {
                visuals[name] = null;
                return;
            }
            //*/
            //!!!!=====================
            if (visualDic.ContainsKey(type))
            {
                Visual3D v3d = visualDic[type](e);
                visuals[name] = v3d;
            }
        }

        private static void GetMaterial(IdName name, XmlElement element)
        {
            Material mat = null;
            XmlElement e = element.GetElementsByTagName("instance_effect")[0] as XmlElement;
            Dictionary<string, XmlElement> par = e.GetParameters();
            string s = e.GetAttribute("url").Substring(1);
            IdName n = new IdName(s, s);
            if (nameElement.ContainsKey(n))
            {
                e = nameElement[n];
                foreach (string key in materialCalc.Keys)
                {
                    XmlNodeList nl = e.GetElementsByTagName(key);
                    if (nl.Count == 1)
                    {
                        mat = materialCalc[key](nl[0] as XmlElement);
                    }
                }
            }
            if (mat == null)
            {

            }
            materials[name] = mat;
            IdName nd = name.Double();
            if (nd != null)
            {
                materials[nd] = mat;
            }
        }

        private static void GetArray(IdName name, XmlElement element)
        {
            if (arrays.ContainsKey(name))
            {
                return;
            }
            double[] x;
            if (sources.ContainsKey(name))
            {
                x = sources[name] as double[];
            }
            else
            {
                x = element.ToDoubleArray();
            }
            arrays[name] = x;
        }

        #endregion

        #region Func<Xmlement, object>

        static object GetFloatArray(XmlElement element)
        {
            double[] x = element.ToDoubleArray();
            element.Add<double[]>(x, arrays);
            return x;
        }

        #endregion

        #region Models

        static Visual3D GetMesh(XmlElement element)
        {
            ModelVisual3D mod = new ModelVisual3D();
            MeshGeometry3D mesh = new MeshGeometry3D();
            Material mat = null;
            //mesh.Positions = e.GetChild("vertices").ToPoint3DCollection();
            XmlElement poly = element.GetChild("polylist");
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
               /* foreach (Point3D p in vertices)
                {
                    vert.Add(p);
                }*/
                Vector3D[] nt = new Vector3D[ind.Count];
               var  pt = new System.Windows.Point[ind.Count];
              /* foreach (int[] i in ind)
                {
                    index.Add(i[0]);
                    norms.Add(norm[i[1]]);
                    textc.Add(textures[i[2]]);
                }
                */
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
            }
            GeometryModel3D geom = new GeometryModel3D();
            geom.Geometry = mesh;
            geom.Material = mat;
            mod.Content = geom;
            return mod;
        }

        #endregion

        #region Materials

        static List<System.Windows.Point> ToPointList(this double[] x)
        {
            List<System.Windows.Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new System.Windows.Point(x[i], 1 - x[i + 1]);
                c.Add(p);
            }
            return c;
        }


        private static Material GetPhong(XmlElement e)
        {
             List<Material> l = new List<Material>();
             foreach (XmlNode n in e.ChildNodes)
             {
                 string tag = n.Name;
                 XmlElement el = n as XmlElement;
                 if (materialTypes.ContainsKey(tag))
                 {
                     Type t = materialTypes[tag];
                     ConstructorInfo c = t.GetConstructor(new Type[0]);
                     Material mat = c.Invoke(new object[0]) as Material;
                     Color color = el.GetColor();
                     PropertyInfo pi = t.GetProperty("Color");
                     pi.SetValue(mat, color, null);
                     if (mat is SpecularMaterial)
                     {
                         try
                         {
                             double refl = e.ToDouble("reflectivity");
                             SpecularMaterial sm = mat as SpecularMaterial;
                             sm.SpecularPower = refl;
                         }
                         finally
                         {
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

        #region Local Materials
/*
       private static Material GetDiffuse(XmlElement e)
        {
            DiffuseMaterial mat;
              return null;
        }

       private static Material GetSpecular(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }

       private static Material GetReflective(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }

       private static Material GetTransparent(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }
        */
        /*
                 <diffuse>
              <color>0.235294 0.337255 0.239216 1.000000</color>
            </diffuse>
            <specular>
              <color>0.235294 0.337255 0.239216 1.000000</color>
            </specular>
            <reflective>
              <color>1.000000 1.000000 1.000000 1.000000</color>
            </reflective>
            <reflectivity>
         
              <float>1.000000</float>
            </reflectivity>
            <transparent opaque="A_ONE">
              <color>0.000000 0.000000 0.000000 1.000000</color>
            </transparent>*/


        #endregion

        #endregion

    }
}