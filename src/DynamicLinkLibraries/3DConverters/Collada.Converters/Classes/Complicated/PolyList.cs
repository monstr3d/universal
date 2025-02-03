using System.Xml;
using Collada;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Abstract3DConverters.Creators;
using Collada.Converters.Classes.Elementary;
using ErrorHandler;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abstract3DConverters.Points;

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

        public float[] Vertices { get; private set; }

        public List<Polygon> Polygons 
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
                if (meshCreator.Materials.ContainsKey(c))
                {
                    Material = meshCreator.Materials[c];
                }
     
                float[] textures = null;
                var children = element.GetAllChildren<Input>().ToArray();
                int[] offs = new int[] { 0, 0, 0 };
                foreach (var item in children)
                {
                    var t = item.Semantic.Key;
                    if (t == "VERTEX")
                    {
                        var ofs = item.Semantic.Value;
                        offs[0] = ofs.Offset;
                        var tt = ofs.Value as Vertices;
                        Vertices = tt.Array;
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
                var nn = 0;
                if (textures == null)
                {
                    return;
                }
                var txt = s.ToRealArray<float>(textures, 2);

                var k = 0;
                var pp = p.Value;
                foreach (var item in vcount)
                {
                    var points = new List<PointAC>();
                    for (var i = 0; i < item; i++)
                    {
                        var point = new PointAC(k, pp[k], -1, txt[k]);
                        ++k;
                        points.Add(point);
                    }
              ///      var polygon = new Polygon(points, Material);
              //      Polygons.Add(polygon);
                }
            }
            catch (Exception exception)
            {
                exception.ShowError("PolyList");
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