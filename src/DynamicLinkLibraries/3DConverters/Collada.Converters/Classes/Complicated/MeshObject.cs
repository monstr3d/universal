using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;

using Collada.Converters.Classes.Elementary;



namespace Collada.Converters.Classes.Complicated
{
    [Tag("mesh")]
    internal partial class MeshObject : Collada.XmlHolder, IMesh
    {
        Service s = new();

        public Triangles[] Triangles 
        { 
            get; 
            private set; 
        }

        public PolyList[] PolyList 
        { 
            get; 
            private set; 
        }

        IMeshCreator meshCreator;

        public static IClear Clear => StaticExtensionCollada.GetClear<MeshObject>();

        IParent IParent.Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private MeshObject(XmlElement xmlElement, IMeshCreator meshCreator) : base(xmlElement)
        {
            this.meshCreator = meshCreator;
            Triangles = xmlElement.GetAllChildren<Triangles>().ToArray();
            PolyList = xmlElement.GetAllChildren<PolyList>().ToArray();
            if (PolyList != null)
            {
                return;
            }
            if (!s.IsEmpty(Triangles))
            {
                return;
            }
            try
            {
                var element = xmlElement;
                var p = element.Get<P>();
                var vc = element.Get<VCount>();
                int[] vcount = (vc == null) ? null : vc.Value;
                int[] arr = (p == null) ? null : p.Value;
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
                        var v = tt.Array;
                        ProtectedVertices = s.ToRealArray(v, 3);
                        ++count;
                        continue;
                    }
                    if (t == "NORMAL")
                    {
                        var ofs = item.Semantic.Value;
                        offs[2] = ofs.Offset;
                        var tt = ofs.Value as Source;
                        var norm = tt.Array;
                        ProtectedNormals = s.ToRealArray(norm, 3);
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
                if (textures != null)
                {
                    var txt = s.ToRealArray<float>(textures, 2);
                    List<float[]> norms = null;
                    if (offs[2] >= 0)
                    {
                        norms = ProtectedNormals;
                    }
                    var k = 0;
                    var pp = p.Value;
                    int tn = 0;
                    if (vcount == null)
                    {
                        var cc = ProtectedTextures.Count / 2;
                        vcount = new int[cc];
                        for (var ic = 0; ic < vcount.Length; ic++)
                        {
                            vcount[ic] = 3;
                        }
                    }
                    if (arr == null)
                    {
                        var la = new List<int>();
                        var cc = ProtectedTextures.Count / 2;
                        for (var ic = 0; ic < cc; ic++)
                        {
                            for (var icc = 0; icc < count; icc++)
                            {
                                la.Add(ic);
                            }
                        }
                        arr = la.ToArray();
                    }
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
                                point = s.CreatePointTexture(this, idx, idt, arr[tn + offs[2]]);
                            }
                            else
                            {
                                point = s.CreatePointTexture(this, idx, idt);
                            }
                            if (point == null)
                            {
                                throw new Exception("MeshObject");
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
                else
                {
                    var sources = element.GetAllChildren<Source>().ToArray();
                    var arrs = new List<float[]>();
                    foreach (var so in sources)
                    {
                        arrs.Add(so.Array);
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Mesh Object constructor");
            }

        }

        static public object Get(XmlElement xmlElement, IMeshCreator meshCreator)
        {
            return new MeshObject(xmlElement, meshCreator);
        }
     }
}