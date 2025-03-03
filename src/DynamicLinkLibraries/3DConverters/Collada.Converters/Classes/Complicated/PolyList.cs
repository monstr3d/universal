using System.Xml;

using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Abstract3DConverters.Points;

using Collada.Converters.Classes.Elementary;

using ErrorHandler;



namespace Collada.Converters.Classes.Complicated
{
    [Tag("polylist")]
    internal partial class PolyList : XmlHolder, IMesh
    {
        Service s = new();

        public Abstract3DConverters.Materials.Effect Effect { get; private set; }

        public Dictionary<string, OffSet> Inputs { get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public float[] Vertices { get; private set; }

        public List<Point> Points { get; private set; } = new();

        protected List<float[]> ProtectedVertices { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedTextures { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedNormals { get; set; } = new List<float[]>();



        protected List<Polygon> Polygons
        {
            get;
            private set;
        } = new List<Polygon>();

        public float[] Normals { get; private set; }

        public int[] Triangles
        {
            get;
            private set;
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<PolyList>();

     
        private PolyList(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            try
            {
                var p = element.Get<P>();
                var vc = element.Get<VCount>();
                var vcount = vc.Value;
                var arr = p.Value;
                var c = element.GetAttribute("material");
                if (meshCreator.Effects.ContainsKey(c))
                {
                    Effect = meshCreator.Effects[c];
                }
                float[] textures = null;
                var children = element.GetAllChildren<Input>().ToArray();
                int count = 0;
                int[] offs = new int[] { -1, -1, -1 };
                foreach (var item in children)
                {
                    var t = item.Semantic.Key;
                    if (t == "VERTEX")
                    {
                        var ofs = item.Semantic.Value;
                        offs[0] = ofs.Offset;
                        var tt = ofs.Value as Vertices;
                        Vertices = tt.Array;
                        ProtectedVertices = s.ToRealArray(Vertices, 3);
                        ++count;
                        continue;
                    }
                    if (t == "NORMAL")
                    {
                        var ofs = item.Semantic.Value;
                        offs[2] = ofs.Offset;
                        var tt = ofs.Value as Source;
                        Normals = tt.Array;
                        ProtectedNormals = s.ToRealArray(Normals, 3);
                        ++count;
                        continue;
                    }
                    if (t == "TEXCOORD")
                    {
                        var ofs = item.Semantic.Value;
                        offs[1] = ofs.Offset;
                        var v = ofs.Value;
                        if (v is float[] vt)
                        {
                            textures = vt;
                        }
                        if (v is Source tt)
                        {
                            textures = tt.Array;
                        }
                        ProtectedTextures = s.ToRealArray(textures, 2);
                        ++count;
                        continue;
                    }
                }
                var nn = 0;
                if (textures == null)
                {
                    return;
                }
                var txt = s.ToRealArray<float>(textures, 2);
                List<float[]> norms = null;
                if (offs[2] >= 0)
                {
                    norms = s.ToRealArray(Normals, 3);
                }
                var k = 0;
                var pp = p.Value;
                int tn = 0;
                foreach (var item in vcount)
                {
                    var points = new List<PointTexture>();
                    for (var i = 0; i < item; i++)
                    {
                        var idx = arr[tn + offs[0]];
                        var idt = arr[tn + offs[1]];
                        
                        PointTexture point = null;
                        if (offs[2] >= 0)
                        {
                            point = new PointTexture(this, idx, idt, arr[tn + offs[2]]);
                        }
                        else
                        {
                            point = new PointTexture(this, idx, idt);

                        }
                        tn += count;
                        points.Add(point);
                    }
                    var polygon = new Polygon(this, points.ToArray(), Effect);
                    if (Polygons == null)
                    {
                        Polygons = new();
                    }
                    Polygons.Add(polygon);
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("PolyList");
                throw new IncludedException(exception, "PolyList");

            }
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new PolyList(element, meshCreator);
            return a.Get();
        }


    }
}