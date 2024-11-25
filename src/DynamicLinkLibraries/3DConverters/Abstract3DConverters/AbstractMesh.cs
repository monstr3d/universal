using Collada;

namespace Abstract3DConverters
{
    public class AbstractMesh
    {
        protected AbstractMesh parent;

        protected static readonly char[] sep = "\r\n ".ToCharArray();

        public float[] TransformationMatrix { get; protected set; }

        public AbstractMesh Parent
        {
            get => parent;
            set
            {
                parent = value;
                if (!parent.Children.Contains(this))
                {
                    parent.Children.Add(this);
                }
            }
        }

        public List<AbstractMesh> Children { get; } = new();

        public List<float[]> Vertices { get; protected set; }

        public List<float[]> Normals { get; protected set; }

        public List<float[]> Textures { get; protected set; }

        public List<int[][]> Indexes { get; protected set; }

        public int Count { get; private set; }

        public string Name { get; protected set; }

        public string Material { get; protected set; }


        protected AbstractMesh(string name)
        {
            Name = name;
        }


        public AbstractMesh(string name, string material, List<float[]> vertices, List<float[]> normals,
            List<float[]> textures, List<int[][]> indexes) : this(name)
        {
            Material = material;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }

        public virtual object GetMaterial(Dictionary<string, object> map, IMaterialCreator creator)
        {
            if (Material != null)
            {
                if (map.ContainsKey(Material))
                {
                    return map[Material];
                }
            }
            return null;
        }


        protected string ToString(string str, string shift)
        {
            if (str.StartsWith(shift))
            {
               return str.Substring(shift.Length).Replace("\"", "").Trim();
            }
            return null;
        }



        protected T? ToReal<T>(string str, string shift) where T : struct
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
                    T a = s.ToReal<T>();
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

        protected void SetImage(Material mat, Image img)
        {
            if (mat is DiffuseMaterial diffuse)
            {
                diffuse.Image = img;
            }
            if (mat is MaterialGroup group)
            {
                foreach (var m in group.Children)
                {
                    SetImage(m, img);
                }
            }
        }

    }
}
