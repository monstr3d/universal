using System.Xml;
using Collada;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Abstract3DConverters.Creators;
using Collada.Converters.Classes.Elementary;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {
        Service s = new();

        public Abstract3DConverters.Materials.Material Material { get; private set; }

        public Dictionary<string, OffSet> Inputs { get; private set; } = new();

        public List<int[]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public Polygon Polygon { get; private set; }

        public float[] Normals { get; private set; }

        public int[] Triangles
        {
            get;
            private set;
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<PolyList>();


        private PolyList(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var p = element.Get<P>();
            var vc = element.Get<VCount>();
            var vcount = vc.Value;
            var arr = p.Value;
            var c = element.GetAttribute("material");
            if (meshCreator.Materials.ContainsKey(c))
            {
                Material = meshCreator.Materials[c];
            }
            float[] vertices = null;

            float[] textures = null;
            var children = element.GetAllChildren<Input>().ToArray();
            int[] offs = new int[] { -1, -1, -1 };
            foreach (var item in children)
            {
                var t = item.Semantic.Key;
                if (t == "VERTEX")
                {
                    var ofs = item.Semantic.Value;
                    offs[0] = ofs.Offset;
                    var tt = ofs.Value as Vertices;
                    vertices = tt.Array;
                    continue;
                }
                if (t == "NORMAL")
                {
                    var ofs = item.Semantic.Value;
                    offs[2] = ofs.Offset;
                    var tt = ofs.Value as Source;
                    Normals = tt.Array;
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
                    continue;
                }
            }
            List<int[]> ind = null;
            int cc = 0;
            foreach (var it in vcount)
            {
                cc += it;
            }
            if (arr.Length == 3 * cc)
            {
                ind = s.ToRealArray<int>(arr, 3);
            }
            else if (arr.Length == 2 * cc)
            {
                ind = s.ToRealArray<int>(arr, 2);
            }
            else
            {
                throw new Exception();
            }
            var j = 0;
            foreach (var vcc in vcount)
            {
                var l = new List<Tuple<int, int, int, float[]>>();
                for (int i = 0; i < vcc; i++)
                {
                    var ii = ind[j];
                    if (ii[0] > vertices.Length)
                    {

                    }
                    if (ii[1] > textures.Length)
                    {

                    }
                    if (ii[2] > Normals.Length)
                    {

                    }
                    if (ii.Length == 3)
                    {
                        if (ii[0] != j)
                        {
                            //     throw new Exception();
                        }
                    }
                    var txt = s.ToRealArray(textures, 2);
                    var tt = new Tuple<int, int, int, float[]>(ii[offs[0]], ii[offs[1]], ii[offs[2]], txt[ii[1]]);
                    l.Add(tt);
                    ++j;
                }


                Polygon = new Polygon(l, Material);

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