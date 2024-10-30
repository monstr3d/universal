using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf
{
    partial class ColladaObject
    {
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
                l.Add(new int[] { x[i], x[i + 1], x[i + 2] });
            }
            return l;
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



        static byte ToColor(this double x)
        {
            double y = Math.Floor(x * 255);
            return (byte)y;
        }


        static Color GetColor(this XmlElement e)
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
        static List<Point3D> ToPoint3DList(this float[] x)
        {
            List<Point3D> c = new List<Point3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                Point3D p = new Point3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }

        static List<Vector3D> ToVector3DList(this float[] x)
        {
            var c = new List<Vector3D>();
            for (int i = 0; i < x.Length; i += 3)
            {
                var p = new Vector3D(x[i], x[i + 1], x[i + 2]);
                c.Add(p);
            }
            return c;
        }



        private static List<Point3D> ToPoint3DList(this XmlElement e)
        {
            return e.FindSourceChild<double[]>().ToPoint3DList();
        }


        public static Func<int, Material> GetDefaultMaterial
        {
            get;
            set;
        }

        public static object GetMaterial(this string mat, int materialIndex)
        {
            if (mat == "default")
            {
                if (GetDefaultMaterial != null)
                {
                    return GetDefaultMaterial(materialIndex);
                }
                else
                {
                    return null;
                }
            }
            throw new NotImplementedException();
        }


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

        static List<System.Windows.Point> ToPointList(this float[] x)
        {
            List<System.Windows.Point> c = new();
            for (int i = 0; i < x.Length; i += 2)
            {
                var p = new System.Windows.Point(x[i], 1 - x[i + 1]);
                c.Add(p);
            }
            return c;
        }



        #endregion

        #region NEW


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




        #endregion

        #region Convert



        #endregion


        #region


    }
}
