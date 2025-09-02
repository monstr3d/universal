using System.IO;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using Abstract3DConverters;
using ErrorHandler;

namespace Wpf.Loader
{
    public static class StaticExtensionWpfLoader
    {
        static  IFilenameGenerator FilenameGenerator 
        { 
            get;  
            set; 
        }

        /// <summary>
        /// Sets generator of a name of file
        /// </summary>
        /// <param name="filenameGenerator">The generator to set</param>
        public static void Set(this IFilenameGenerator filenameGenerator)
        {
            FilenameGenerator = filenameGenerator;
        }

        /// <summary>
        /// Generates a name of file
        /// </summary>
        /// <param name="ext">The extension</param>
        /// <param name="path">The path</param>
        /// <returns>The name of file</returns>
        static public string GenerateFileName(string ext, out string path)
        {
            return FilenameGenerator.GenerateFileName(ext, out path);
        }

        static public void Add(this Func<string, Tuple<object, Dictionary<string, byte[]>>> t, string extension)
        {
            FileLoad[extension] = t;
        }

        static StaticExtensionWpfLoader()
        {
            FileLoad[".xaml"] = Load;
            StaticExtensionAbstract3DConverters.CheckFile = CheckFile.Check;
        }


        static public void DeleteTextures()
        {
            FilenameGenerator.Clean();
        }


        static Tuple<object, Dictionary<string, byte[]>> Load(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                var s = reader.ReadToEnd();
                return new Tuple<object, Dictionary<string, byte[]>>(s, new Dictionary<string, byte[]>());
            }
        }


        static public double GetArea(this Point3D[] points, out System.Windows.Media.Media3D.Vector3D normal)
        {
            System.Windows.Media.Media3D.Vector3D v1 = points[1] - points[0];
            System.Windows.Media.Media3D.Vector3D v2 = points[2] - points[0];
            System.Windows.Media.Media3D.Vector3D n = System.Windows.Media.Media3D.Vector3D.CrossProduct(v1, v2);
            double a = n.Length / 2;
            n.Normalize();
            normal = n;
            return a;
        }

        // static Dictionary<string, Func<string, Visual3D>> dic = new();

        /// <summary>
        /// 3D file load
        /// </summary>
        public static Dictionary<string, Func<string, Tuple<object, Dictionary<string, byte[]>>>> FileLoad
        {
            get;
        } = new();


        static public void Create(this MeshGeometry3D mesh, out double[] areas, out double[][] centers)
        {
            Point3DCollection pos = mesh.Positions;
            Vector3DCollection vcol = new Vector3DCollection();
            int n = pos.Count / 3;
            areas = new double[n];
            centers = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] center = new double[] { 0, 0, 0 };
                int k = 3 * i;
                Point3D[] p = new Point3D[] { pos[k], pos[k + 1], pos[k + 2] };
                for (int j = 0; j < 3; j++)
                {
                    center[0] += p[j].X;
                    center[1] += p[j].Y;
                    center[2] += p[j].Z;
                }
                for (int j = 0; j < 3; j++)
                {
                    center[j] /= 3;
                }
                centers[i] = center;
                System.Windows.Media.Media3D.Vector3D ved;
                areas[i] = p.GetArea(out ved);
                vcol.Add(ved);
            }
            mesh.Normals = vcol;
        }

        static public double GetCoordinate(this Point3D p, int i)
        {
            return (i == 0) ? p.X : ((i == 1) ? p.Y : p.Z);
        }

        static public void SetCoordinate(this Point3D p, int i, double val)
        {
            if (i == 0)
            {
                p.Offset(val - p.X, 0, 0);
                return;
            }
            if (i == 1)
            {
                p.Offset(0, val - p.Y, 0);
                return;
            }
            p.Offset(0, 0, val - p.Z);
        }

        static public void Transform(this MeshGeometry3D mesh, Func<Point3D, Point3D> pt,
     Func<System.Windows.Media.Media3D.Vector3D, System.Windows.Media.Media3D.Vector3D> vt)
        {
            Point3DCollection pos = mesh.Positions;
            Point3DCollection coll = new Point3DCollection();
            foreach (Point3D p in pos)
            {
                coll.Add(pt(p));
            }
            mesh.Positions = coll;
            Vector3DCollection norm = mesh.Normals;
            Vector3DCollection vc = new Vector3DCollection();
            foreach (System.Windows.Media.Media3D.Vector3D n in norm)
            {
                vc.Add(vt(n));
            }
            mesh.Normals = vc;
        }

        static Point3D Multiply(this Point3D p, double scale)
        {
            return new Point3D(p.X * scale, p.Y * scale, p.Z * scale);
        }



        /// <summary>
        /// Loads Visual 3D object from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>Visual 3D object</returns>
        static public Visual3D ToVisual3D(this string filename)
        {
            return null;
    /*        string ext = System.IO.Path.GetExtension(filename).Substring(1);
            if (!dic.ContainsKey(ext))
            {
                return null;
            }
            return dic[ext](filename);*/
        }




        static public string InvertedXXaml(this Visual3D v3d)
        {
            v3d.InvertZ();
            return XamlWriter.Save(v3d);
        }

        /// <summary>
        /// Gets size
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        static public double[,] GetSize(this Point3DCollection pos)
        {
            var d = new double[2, 3];
            bool f = true;
            var dd = new double[3];
            foreach (var p in pos)
            {
                dd[0] = p.X;
                dd[1] = p.Y;
                dd[2] = p.Z;
                if (f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        d[0, i] = dd[i];
                        d[1, i] = dd[i];
                    }
                    f = false;
                    continue;
                }
                for (var i = 0; i < 3; i++)
                {
                    d[0, i] = Math.Min(dd[i], d[0, i]);
                    d[1, i] = Math.Max(dd[i], d[1, i]);
                }
            }
            return d;
        }
   
        static public double[,] GetSize(this Visual3D v3d)
        {
            try
            {
                double[,] d = null;
                if (v3d is ModelVisual3D)
                {
                    ModelVisual3D m3d = v3d as ModelVisual3D;
                    object ob = m3d.Content;
                    if (ob != null)
                    {
                        GeometryModel3D geom = null;
                        if (ob is GeometryModel3D g)
                        {
                            geom = g;
                        }
                        else if (ob is Model3DGroup gr)
                        {
                            Model3DCollection ch = gr.Children;
                            foreach (object o in ch)
                            {
                                if (o is GeometryModel3D ge)
                                {
                                    geom = ge;
                                    break;
                                }
                            }
                        }
                        if (geom != null)
                        {
                            Geometry3D g3d = geom.Geometry;
                            if (g3d is MeshGeometry3D mesh)
                            {
                                d = d.GetSize(mesh.Positions.GetSize());
                            }
                        }
                    }
                    else
                    {
                        foreach (Visual3D vtd in m3d.Children)
                        {
                            var dd = vtd.GetSize();
                            d = (d == null) ? dd : d.GetSize(dd);
                        }
                    }
                }
                else
                {

                }
                return d;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Get size WPF");
            }
            return null;
        }

        /// <summary>
        /// Gets size of x and y
        /// </summary>
        /// <param name="x">The x</param>
        /// <param name="y">The y</param>
        /// <returns>The size</returns>
        internal static double[,] GetSize(this double[,] x, double[,] y)
        {
            if (x == null)
            {
                if (y != null)
                {
                    return y;
                }
                return null;
            }
            else if (y == null)
            {
                return x;
            }
            var d = new double[2, x.GetLength(1)];
            for (var i = 0; i < d.GetLength(1); i++)
            {
                d[0, i] = Math.Min(x[0, i], y[0, i]);
                d[1, i] = Math.Max(x[1, i], y[1, i]);
            }
            return d;
        }

        /// <summary>
        /// Sets standard transform to geometry
        /// </summary>
        /// <param name="geometry">Geomerty</param>
        public static void SetStandardTransform(this Visual3D geometry)
        {
            geometry.Transform = StandardTransform;
        }

        /// <summary>
        /// Standard transformation
        /// </summary>
        public static Transform3D StandardTransform
        {
            get
            {
                var t = new MatrixTransform3D();
                return t;
            }
        }



        static public bool Transform(this Visual3D v3d, Func<Point3D, Point3D> pt,
            Func<System.Windows.Media.Media3D.Vector3D, System.Windows.Media.Media3D.Vector3D> vt)
        {
            if (v3d is ModelVisual3D m3d)
            {
                object ob = m3d.Content;
                if (ob != null)
                {
                    GeometryModel3D geom = null;
                    if (ob is GeometryModel3D g)
                    {
                        geom = g;
                    }
                    else if (ob is Model3DGroup gr)
                    {
                        Model3DCollection ch = gr.Children;
                        foreach (object o in ch)
                        {
                            if (o is GeometryModel3D ff)
                            {
                                geom = ff;
                                break;
                            }
                        }
                    }
                    if (geom != null)
                    {
                        Geometry3D g3d = geom.Geometry;
                        if (g3d is MeshGeometry3D mesh)
                        {
                            mesh.Transform(pt, vt);
                        }
                    }
                }
                else
                {
                    foreach (Visual3D vtd in m3d.Children)
                    {
                        if (vtd.Transform(pt, vt)) ;
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static public void InvertZ(this Visual3D v3d)
        {
            v3d.Transform((Point3D p) => { return new Point3D(p.X, p.Y, -p.Z); },
                (System.Windows.Media.Media3D.Vector3D v) => { return new System.Windows.Media.Media3D.Vector3D(v.X, v.Y, -v.Z); });
        }



 
        static public void Multiply(this MeshGeometry3D mesh, double scale)
        {
            Point3DCollection pos = mesh.Positions;
            Point3DCollection coll = new Point3DCollection();
            foreach (Point3D p in pos)
            {
                coll.Add(p.Multiply(scale));
            }
            mesh.Positions = coll;
        }

        static public void Multiply(this Visual3D v3d, double scale)
        {

            if (v3d is ModelVisual3D m3d)
            {
                foreach (Visual3D vtd in m3d.Children)
                {
                    vtd.Multiply(scale);
                }
                object ob = m3d.Content;
                if (ob is GeometryModel3D geom)
                {
                    if (geom.Geometry is MeshGeometry3D mesh)
                    {
                        mesh.Multiply(scale);
                    }
                }

                else if (ob is Model3DGroup gr)
                {
                    Model3DCollection ch = gr.Children;
                    foreach (var o in ch)
                    {
                        //  if (o is ModelVisual3D mv3d)
                        //  {
                        //     Multiply(mv3d, scale);
                        // }
                    }
                }
            }
        }


  


        static public System.Drawing.Color GetColor(double alpha, double red, double green, double blue)
        {
            return System.Drawing.Color.FromArgb((byte)(alpha * 255), (byte)(red * 255), (byte)(green * 255), (byte)(blue * 255));

        }




        /// <summary>
        /// Multiplication of XAML
        /// </summary>
        /// <param name="filename">XAML filename</param>
        /// <param name="scale">Multiplication scale</param>
        public static void Multiply(string filename, double scale)
        {
            char[] sep = " ".ToCharArray();
            char[] sep1 = ",".ToCharArray();
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(filename);
            System.Xml.XmlNodeList nl = doc.GetElementsByTagName("MeshGeometry3D");
            foreach (System.Xml.XmlElement e in nl)
            {
                string s = "";
                string pos = e.GetAttribute("Positions");
                string[] pp = pos.Split(sep);
                foreach (string spp in pp)
                {
                    if (spp.Length == 0)
                    {
                        continue;
                    }
                    string[] ppp = spp.Split(sep1);
                    int i = 0;
                    foreach (string sppp in ppp)
                    {
                        s += ((Double.Parse(sppp.Replace(".", ",")) * scale) + "").Replace(",", ".");
                        if (i < 2)
                        {
                            s += ",";
                        }
                        ++i;
                    }
                    s += " ";
                }
                e.SetAttribute("Positions", s);
            }
            System.IO.File.Delete(filename);
            doc.Save(filename);

        }
    }

}
