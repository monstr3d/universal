using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;


using Motion6D.Interfaces;
using Motion6D;

using WpfInterface.Interfaces;
using WpfInterface.Animated;

namespace WpfInterface
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionWpfInterface
    {

        #region Fields

        static double[] x = new double[3];
        private static Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>> dic =
               new Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>>();

        #endregion

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        /// <summary>
        /// Standard transformation
        /// </summary>
        public static Transform3D StandardTransform
        {
            get
            {
                 return new MatrixTransform3D();
            }
        }

        /// <summary>
        /// Sets standart transform to geometry
        /// </summary>
        /// <param name="geometry">Geomerty</param>
        public static void SetStandardTransform(this Visual3D geometry)
        {
            geometry.Transform = StandardTransform;
        }

        /// <summary>
        /// Loads Visual 3D object from file
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>Visual 3D object</returns>
        static public Visual3D ToVisual3D(this string filename)
        {
            string ext = System.IO.Path.GetExtension(filename).Substring(1);
            if (!dic.ContainsKey(ext))
            {
                return null;
            }
            return dic[ext](filename);
        }

        /// <summary>
        /// Sets transformation
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="transform">Transformation</param>
        public static void SetTransform(this IPosition position, MatrixTransform3D transform)
        {
            ReferenceFrame r = position.GetParentFrame();
            double[,] m = r.Matrix;
            double[] x = position.Position;
            Matrix3D matr = new Matrix3D(m[0, 0], m[1, 0], m[2, 0], 0,
                                         m[0, 1], m[1, 1], m[2, 1], 0,
                                         m[0, 2], m[1, 2], m[2, 2], 0,
                                           x[0], x[1], x[2], 1);
            transform.Matrix = matr;
       }

        /// <summary>
        /// Gets area
        /// </summary>
        /// <param name="points">Points</param>
        /// <returns>Area</returns>
        public static double GetArea(Point3D[] points)
        {
            return 0;
        }

        public static void SetTransform(this IPosition position, Visual3D visual)
        {
           
            SerializablePosition sp = position as SerializablePosition;
            IWpfVisible v = sp.Parameters as IWpfVisible;
            SetTransform(position, visual.Transform as MatrixTransform3D);
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

        /// <summary>
        /// 3D file load
        /// </summary>
        public static Dictionary<string, Func<string, System.Windows.Media.Media3D.Visual3D>> FileLoad
        {
            get
            {
                return dic;
            }
        }

  
        static public void Create(this MeshGeometry3D mesh, out double[] areas, out double[][] centers)
        {
            Point3DCollection pos = mesh.Positions;
            Vector3DCollection vcol = new Vector3DCollection();
            int n = pos.Count / 3;
            areas = new double[n];
            centers = new double[n][];
            for (int i = 0; i < n; i++)
            {
                double[] center = new double[]{0, 0, 0};
                int k = 3 * i;
                Point3D[] p = new Point3D[]{pos[k], pos[k + 1], pos[k + 2]};
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

 
        static public bool Transform(this Visual3D v3d, Func<Point3D, Point3D> pt,
            Func<System.Windows.Media.Media3D.Vector3D, System.Windows.Media.Media3D.Vector3D> vt)
        {
            if (v3d is ModelVisual3D)
            {
                ModelVisual3D m3d = v3d as ModelVisual3D;
                object ob = m3d.Content;
                if (ob != null)
                {
                    GeometryModel3D geom = null;
                    if (ob is GeometryModel3D)
                    {
                        geom = ob as GeometryModel3D;
                    }
                    else if (ob is Model3DGroup)
                    {
                        Model3DGroup gr = ob as Model3DGroup;
                        Model3DCollection ch = gr.Children;
                        foreach (object o in ch)
                        {
                            if (o is GeometryModel3D)
                            {
                                geom = o as GeometryModel3D;
                                break;
                            }
                        }
                    }
                    if (geom != null)
                    {
                        Geometry3D g3d = geom.Geometry;
                        if (g3d is MeshGeometry3D)
                        {
                            MeshGeometry3D mesh = g3d as MeshGeometry3D;
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
            v3d.Transform((Point3D p) => {return new Point3D(p.X, p.Y, -p.Z);},
                (System.Windows.Media.Media3D.Vector3D v) => { return new System.Windows.Media.Media3D.Vector3D(v.X, v.Y, -v.Z); });
        }

        static public string InvertedXXaml(this Visual3D v3d)
        {
            v3d.InvertZ();
            return XamlWriter.Save(v3d);
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

        static public bool Multiply(this Visual3D v3d, double scale)
        {
            if (v3d is ModelVisual3D)
            {
                ModelVisual3D m3d = v3d as ModelVisual3D;
                object ob = m3d.Content;
                if (ob != null)
                {
                    GeometryModel3D geom = null;
                    if (ob is GeometryModel3D)
                    {
                        geom = ob as GeometryModel3D;
                    }
                    else if (ob is Model3DGroup)
                    {
                        Model3DGroup gr = ob as Model3DGroup;
                        Model3DCollection ch = gr.Children;
                        foreach (object o in ch)
                        {
                            if (o is GeometryModel3D)
                            {
                                geom = o as GeometryModel3D;
                                break;
                            }
                        }
                    }
                    if (geom != null)
                    {
                        Geometry3D g3d = geom.Geometry;
                        if (g3d is MeshGeometry3D)
                        {
                            MeshGeometry3D mesh = g3d as MeshGeometry3D;
                            mesh.Multiply(scale);
                        }
                    }
                }
                else
                {
                    foreach (Visual3D vtd in m3d.Children)
                    {
                        if (vtd.Multiply(scale))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
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

        #endregion

        #region Private & Internal Mebmers

        /// <summary>
        /// Enqueue animated object
        /// </summary>
        /// <param name="animatedObject">Animated Object</param>
        /// <param name="timeSpan">Time Span</param>
        internal static void Enqueue(this IAnimatedObject animatedObject, TimeSpan timeSpan)
        {
            ReferenceFrame frame = animatedObject.ReferenceFrame;
            double[] position = new double[3];
            Array.Copy(frame.Position, position, 3);
            double[] quaternion = new double[4];
            Array.Copy(frame.Quaternion, quaternion, 4);
            Tuple<TimeSpan, double[], double[]> parameters =
                new Tuple<TimeSpan, double[], double[]>(timeSpan, position, quaternion);
            foreach (AnimatableWrapper wrapper in animatedObject.Children)
            {
                wrapper.Enqueue(parameters);
            }
        }


        static internal System.Drawing.Color GetColor(double alpha, double red, double green, double blue)
        {
            return System.Drawing.Color.FromArgb((byte)(alpha * 255), (byte)(red * 255), (byte)(green * 255), (byte)(blue * 255));

        }

        static void Transform(this MeshGeometry3D mesh, Func<Point3D, Point3D> pt,
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
 
   

        #endregion
    }
}
