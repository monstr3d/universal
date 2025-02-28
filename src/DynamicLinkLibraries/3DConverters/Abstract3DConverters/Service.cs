using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Abstract3DConverters
{
    /// <summary>
    /// Service
    /// </summary>
    public class Service
    {

        protected static readonly char[] sep = "\r\n ".ToCharArray();

 
        /// <summary>
        /// Constructor
        /// </summary>
        public Service() 
        { 
        
        }


        #region Service

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="obj">the object</param>
        /// <returns>The arribute</returns>
        public T GetAttribute<T>(object obj) where T : Attribute
        {
            var t = obj.GetType();
            return CustomAttributeExtensions
                .GetCustomAttribute<T>(IntrospectionExtensions.GetTypeInfo(t));
        }

        /// <summary>
        /// Copy of image
        /// </summary>
        /// <param name="image">Image</param>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        public void CopyImage(Image image, string source, string target)
        {
            var f = image.GetImageFile();
            if (!File.Exists(f))
            {
                return;
            }
            var name = image.Name;
            var file = Path.Combine(source, name);
            var fout = Path.Combine(target, name);
            var dout = new DirectoryInfo(Path.GetDirectoryName(fout));
            if (!dout.Exists)
            {
                dout.Create();
            }
            FileInfo fi = new FileInfo(file);

            if (fi.Exists)
            {
                fi.CopyTo(fout, true);
            }
        }

        /// <summary>
        /// Copy of images
        /// </summary>
        /// <param name="images">Images</param>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        public void CopyImages(IEnumerable<Image> images, string source, string target)
        {
            foreach (var image in images)
            {
                CopyImage(image, source, target);
            }
        }

        /// <summary>
        /// Copy of images
        /// </summary>
        /// <param name="creator">Creator of meshes</param>
        /// <param name="source">Source directory</param>
        /// <param name="target">Target directory</param>
        public void CopyImages(IMeshCreator creator, string source, string target)
        {
            var images = GetImages(creator.Effects.Values);
            CopyImages(images.Values, source, target);
        }


        /// <summary>
        /// Color from XML element
        /// </summary>
        /// <param name="element">The XML element</param>
        /// <returns>The color</returns>
        public Color GetColor(XmlElement element)
        {
            var s = element.InnerText;
            float[] f = ToRealArray<float>(s);
            return new Color(f);

        }

        /// <summary>
        /// Sets color to XML element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="colorName">The name of color</param>
        /// <param name="color">The color</param>
        public void SetColor(XmlElement element, string colorName, Color color)
        {
            if (color == null)
            {
                return;
            }
            element.SetAttribute(colorName, "#" + color.ByteValue);
        }

   /// <summary>
   /// Sets parents for the Dictionary
   /// </summary>
   /// <param name="mehses">The dictionary</param>
        public  void SetParents(Dictionary<XmlElement, IParent> mehses)
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

        /// <summary>
        /// Transforms a list of arrays to a single array
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="t">Input</param>
        /// <returns>Output</returns>
        public IEnumerable<T> ToSingleArray<T>(List<T[]> t) where T :struct
        {
            foreach (var item in t)
            {
                foreach (var i in item)
                {
                    yield return i;
                }
            }
        }

        /// <summary>
        /// Matrix product of a and b
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>Product</returns>
        public float[,] MatrixProduct(float[,] a, float[,] b)
        {
            var r = a.GetLength(0);
            var c = b.GetLength(1);
            var l = a.GetLength(1);
            var res = new float[r, c];
            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    res[i, j] = 0f;
                    for (var k = 0; k < l; k++)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Matrix point product
        /// </summary>
        /// <param name="a">Matrix</param>
        /// <param name="point">Point</param>
        /// <returns>Product</returns>
        public Point Product(float[,] a, Point point)
        {
            return null;
            /*
            var vert = new float[3] { 0f, 0f, 0f };
            var v = point.Vertex;
            for (var i = 0; i < 3; i++)
            {
                vert[i] += a[3, i];
                for (var j = 0; j < 3; j++)
                {
                    vert[i] += a[i, j] * v[j];

                }
            }
            var n = point.Normal;
            if (n == null)
            {
              return  new Point(vert);
            }
            var norm = new float[3] { 0f, 0f, 0f };
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    norm[i] += a[i, j] * n[j];

                }
            }
            var p = new Point(vert, norm);
            return p;*/
        }

        /// <summary>
        /// Matrix point product
        /// </summary>
        /// <param name="a">Matrix</param>
        /// <param name="point">Point</param>
        /// <returns>Product</returns>
        public PointTexture Product(float[,] a, PointTexture point)
        {
            return null;
            /*
            var n = point.Normal;
            if (n == null)
            {
                return point;
            }
            var norm = new float[3] { 0f, 0f, 0f };
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    norm[i] += a[i, j] * norm[j];

                }
            }
            return new PointTexture(point.Index, point.Texture, norm);*/
        }

        /// <summary>
        ///  Sets parents for dictionary
        /// </summary>
        /// <param name="meshes">The dictionary</param>
        public void SetParents(Dictionary<IParent, XmlElement> meshes)
        {
            foreach (var mesh in meshes)
            {
                var p = mesh.Key.Parent;
                if (p != null)
                {
                    var e = meshes[p];
                    e.AppendChild(mesh.Value);
                }
            }
        }

        /// <summary>
        /// Gets roots of enumerable
        /// </summary>
        /// <param name="meshes">The enumerable</param>
        /// <returns>The roots</returns>
        public IEnumerable<IParent> GetRoots(IEnumerable<IParent> meshes)
        {
            return meshes.Where(e => e.Parent == null);
        }

        /// <summary>
        /// Gets images from materials
        /// </summary>
        /// <param name="mat">The material</param>
        /// <returns>The images</returns>
        /// <exception cref="Exception">The exception</exception>
        public Dictionary<string, Image> GetImages(IEnumerable<Effect> effects)
        {
            var d = new Dictionary<string, Image>();
            var f = (Effect effect) =>
            {
               var im = effect.Image;
                if (im != null)
                {
                    var n = im.Name;
                    if (d.ContainsKey(n))
                    {
                    }
                    else
                    {
                        d[n] = im;
                    }
                }
                return im;
            };
            effects.Select(f).ToList();
            return d;
        }


        /// <summary>
        /// Gets images of creator
        /// </summary>
        /// <param name="creator"></param>
        /// <returns>Images</returns>
        public Dictionary<string, Image> GetImages(IMeshCreator creator)
        {
            return GetImages(creator.Effects.Values);
        }


        /// <summary>
        /// String value of the array
        /// </summary>
        /// <typeparam name="T">The type of the array</typeparam>
        /// <param name="array">The array</param>
        /// <param name="sep">The separator</param>
        /// <returns>The string value</returns>
        public string StringValue<T>(T[] array, string sep = " ") where T : struct
        {
            var s = " ";
            foreach (var item in array)
            {
                s += item + sep;
            }
            s = s.Substring(0, s.Length - sep.Length);
            return s;
        }

        /// <summary>
        /// Parsing of the float enumerable
        /// </summary>
        /// <param name="f">The float enumerable</param>
        /// <returns>The parsing result</returns>
        public string Parse(IEnumerable<float> f)
        {
            var sb = new StringBuilder();
            foreach (var x in f)
            {
                var y = x;// (double)x;
                var xx = y.ToString();
                sb.Append(xx);
                sb.Append(" ");
            }
            var s = sb + "";
            return s.Substring(0, s.Length - 1);
        }

        /// <summary>
        /// Trims quoted string
        /// </summary>
        /// <param name="str">The quoted string</param>
        /// <returns>The result</returns>
        public string Trim(string str)
        {
            return str.Replace("\"", "").Trim();
        }

        /// <summary>
        /// Shrinks the string
        /// </summary>
        /// <param name="str">The string to shrink</param>
        /// <returns>The shrink result</returns>
        public string Shrink(string str)
        {
            var s = str.Replace("  ", " ");
            s = s.Replace("  ", " ");
            s = s.Replace("  ", " ");
            return s;
        }

        /// <summary>
        /// Wraps string
        /// </summary>
        /// <param name="str">The string to wrap</param>
        /// <returns>The string result</returns>
        public string Wrap(string str)
        {
            return "\"" + str + "\"";
        }

        /// <summary>
        /// To string operation
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="shift">The shift</param>
        /// <returns>The result</returns>
        public string ToString(string str, string shift)
        {
            if (str.StartsWith(shift))
            {
                return str.Substring(shift.Length).Replace("\"", "").Trim();
            }
            return null;
        }

        /// <summary>
        /// To real operation
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="str">The string</param>
        /// <param name="shift">The shift</param>
        /// <returns>The result</returns>
        public T? ToReal<T>(string str, string shift) where T : struct
        {
            var s = ToString(str, shift);
            if (s == null)
            {
                return null;
            }
            return ToReal<T>(s);
        }

        /// <summary>
        /// Converts string to real array
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="str">The string</param>
        /// <returns>The array</returns>
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

        /// <summary>
        /// Conversion to string
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="t">The object</param>
        /// <returns>The string</returns>
        public string ToString<T>(T t) where T : struct
        {
            Type type = typeof(T);
            object o = t;
            switch (type)
            {
                case var value when value == typeof(double):
                    var d = (double)o;
                    return d.ToString(System.Globalization.CultureInfo.InvariantCulture);
                case var value when value == typeof(float):
                    var f = (float)o;
                    return f.ToString(System.Globalization.CultureInfo.InvariantCulture);
                case var value when value == typeof(int):
                    var i = (int)o;
                    return i.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            return null;
        }

        /// <summary>
        /// Converts the string to real
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s">The type</param>
        /// <returns>The result</returns>
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

        /// <summary>
        /// Converts enumerable
        /// </summary>
        /// <typeparam name="S">Output type</typeparam>
        /// <typeparam name="T">Input type</typeparam>
        /// <param name="input">The input</param>
        /// <param name="func">The transformation</param>
        /// <returns>The output</returns>
        public IEnumerable<S> Convert<S, T>(IEnumerable<T> input, Func<T, S> func)
        {
            return input.Select(e => func(e));
        }

        /// <summary>
        /// Converts array
        /// </summary>
        /// <param name="array">Input</param>
        /// <returns>Output</returns>
        public double[] Convert(float[] array)
        {
            return Convert(array, x => (double)x).ToArray();
        }

        /// <summary>
        /// Converts array
        /// </summary>
        /// <param name="array">Input</param>
        /// <returns>Output</returns>
        public float[] Convert(double[] array)
        {
            return Convert(array, x => (float)x).ToArray();
        }

        /// <summary>
        /// Splits string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Splitting result</returns>
        public string[] Split(string str)
        {
            var ss = str.Split(sep);
            var l = new List<string>();
              foreach (var s in ss)
            {
                if (s.Length > 0)
                {
                    l.Add(s);
                }
            }
            return l.ToArray();
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

        public List<T[]> ToRealArray<T>(string s, int n) where T : struct
        {
            T[] t = ToRealArray<T>(s);
            return ToRealArray<T>(t, n);
        }

        public List<T[]> ToRealArray<T>(T[] x, int n) where T : struct
        {
            var l = new List<T[]>();
            for (int i = 0; i < x.Length; i += n)
            {
                T[] y = new T[n];
                for (int j = 0; j < n; j++)
                {
                    var a = i + j;
                    if (a >= x.Length)
                    {
                        throw new Exception("Service ToRealArray");
                    }
                    y[j] = x[a];
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
            return ToRealArray(ToRealArray<T>(str), 3);
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

        /// <summary>
        /// Conversion
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="en">Collection</param>
        /// <returns>Conversion result</returns>
        public IEnumerable<T> ToSigleArray<T>(IEnumerable<T[]> en) where T: struct
        {
            foreach (var item in en)
            {
                foreach (var i in item)
                {
                    yield return i;
                }
            }
        }

        #endregion

        #region Private members


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


        #endregion

    }
}
