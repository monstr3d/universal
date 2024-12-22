using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters
{
    public class Service
    {

        protected static readonly char[] sep = "\r\n ".ToCharArray();

        public Service() 
        { 
        
        }


        #region Service

        public  void SetParents(Dictionary<XmlElement, AbstractMesh> mehses)
        {
            foreach (var mesh in mehses.Keys)
            {
                var a = mehses[mesh];
                var p = mesh.ParentNode;
                while (p != null)
                {
                    if (p is XmlElement e)
                    {
                        if (mehses.ContainsKey(e))
                        {
                            var b = mehses[e];
                            a.Parent = b;
                            break;
                        }
                    }
                    p = p.ParentNode;
                }
            }
        }



        public IEnumerable<AbstractMesh> GetRoots(IEnumerable<AbstractMesh> meshes)
        {
            return meshes.Where(e => e.Parent == null);
        }

        public Image GetImage(Material mat)
        {
            if (mat is DiffuseMaterial diffuse)
            {
                return diffuse.Image;
            }
            if (mat is MaterialGroup group)
            {
                foreach (var m in group.Children)
                {
                    var im = GetImage(m);
                    if (im != null)
                    {
                        return im;
                    }
                }
            }
            return null;
        }

        public string StrinValue<T>(T[] array, string sep = " ") where T : struct
        {
            var s = " ";
            foreach (var item in array)
            {
                s += item + sep;
            }
            s = s.Substring(0, s.Length - sep.Length);
            return s;
        }

        

        public string Trim(string str)
        {
            return str.Replace("\"", "").Trim();
        }

        public string Shrink(string str)
        {
            var s = str.Replace("  ", " ");
            s = s.Replace("  ", " ");
            s = s.Replace("  ", " ");
            return s;
        }

        public string Wrap(string str)
        {
            return "\"" + str + "\"";
        }

        public string ToString(string str, string shift)
        {
            if (str.StartsWith(shift))
            {
                return str.Substring(shift.Length).Replace("\"", "").Trim();
            }
            return null;
        }

        public T? ToReal<T>(string str, string shift) where T : struct
        {
            var s = ToString(str, shift);
            if (s == null)
            {
                return null;
            }
            return ToReal<T>(s);
        }

        private float ToFloat(string str)
        {
            return float.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }

        private double ToDouble(string str)
        {
            return double.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }

        private int ToInt(string str)
        {
            return int.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }


        public T[] ToRealArray<T>(string str) where T : struct
        {
            string[] ss = str.Split(sep);
            var l = new List<T>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    T a =  ToReal<T>(s);
                    l.Add(a);
                }
            }
            return l.ToArray();
        }

        public T ToReal<T>(string s) where T : struct
        {
            object obj = null;
            var t = typeof(T);
            if (t == typeof(double))
            {
                obj = ToDouble(s);
            }
            else if (t == typeof(float))
            {
                obj = ToFloat(s);
            }
            else if (t == typeof(int))
            {
                obj = ToInt(s);
            }
            return (T)obj;
        }


        public IEnumerable<S> Convert<S, T>(IEnumerable<T> input, Func<T, S> func)
        {
            foreach (var item in input)
            {
                yield return func(item);
            }
        }

        public double[] Convert(float[] array)
        {
            return Convert(array, x => (double)x).ToArray();
        }
        public float[] Convert(double[] array)
        {
            return Convert(array, x => (float)x).ToArray();
        }

        public string[] Split(string str)
        {
            return str.Split(sep);
        }

 
        public List<T[]> ToReal3Array<T>(T[] x) where T : struct
        {
            var l = new List<T[]>();
            for (int i = 0; i < x.Length; i += 3)
            {
                l.Add(new T[] { x[i], x[i + 1], x[i + 2] });
            }
            return l;
        }

        public List<T[]> ToArray<T>(List<T> x, int n) where T : class
        {
            var l = new List<T[]>();
            for (int i = 0; i < x.Count; i += n)
            {
                T[] y = new T[n];
                for (int j = 0; j < n; j++)
                {
                    y[j] = x[i + j];
                }
                l.Add(y);
            }
            return l;
        }

        public List<T[]> ToRealArray<T>(T[] x, int n) where T : struct
        {
            var l = new List<T[]>();
            for (int i = 0; i < x.Length; i += n)
            {
                T[] y = new T[n];
                for (int j = 0; j < n; j++)
                {
                    y[j] = x[i + j];
                }
                l.Add(y);
            }
            return l;
        }

        public List<T[][]> ToRealArray<T>(T[] x, int n, int m) where T : struct
        {
            var y = ToRealArray(x, n);
            return ToArray(y, m);
        }


        public List<T[]> ToReal2Array<T>(T[] x) where T : struct
        {
            var l = new List<T[]>();
            for (int i = 0; i < x.Length; i += 2)
            {
                l.Add([ x[i], x[i + 1] ]);
            }
            return l;
        }


        public List<T[]> ToReal2Array<T>(string s) where T : struct
        {
            return ToReal2Array(ToRealArray<T>(s));
        }



        public List<T[]> ToReal3Array<T>(string str) where T : struct
        {
            return ToReal3Array(ToRealArray<T>(str));
        }

        public List<int[][]> ToInt3Array(string str)
        {
            var l = ToReal3Array<int>(str);
            return ToInt3Array(l);
        }

      
        public List<int[][]> ToInt3Array(List<int[]> x)
        {
            var l = new List<int[][]>();
            for (int i = 0; i < x.Count; i += 3)
            {
                var y = new int[3][] { x[i], x[i + 1], x[i + 2] };
                l.Add(y);
            }
            return l;

        }




        #endregion

    }
}
