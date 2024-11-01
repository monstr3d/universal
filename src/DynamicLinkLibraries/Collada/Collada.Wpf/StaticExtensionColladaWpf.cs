using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    public static  class StaticExtensionColladaWpf
    {
        static StaticExtensionColladaWpf()
        {
        }

        public static void Set()
        {
            StaticExtensionCollada.Function = Function.Instance;
            StaticExtensionCollada.Collada = ColladaObject.Instance;
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



        public static List<Point3D> ToPoint3DList(this XmlElement e)
        {
            return e.FindSourceChild<double[]>().ToPoint3DList();
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
