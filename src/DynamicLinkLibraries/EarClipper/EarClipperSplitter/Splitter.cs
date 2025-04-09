using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

using EarClipperLib;

namespace EarClipperSplitter
{
    internal class Splitter : IPolygonSplitter, IPolygonSplitterFactory, IEqualityComparer<Vector3m>
    {

        internal static readonly IPolygonSplitterFactory Instance = new Splitter();

        IEqualityComparer<Vector3m> c = null;

        private Splitter() 
        {
            c = this;
        }
        Polygon[] IPolygonSplitter.this[Polygon polygon] => GetPolygons(polygon);

        EarClipping clipping = new EarClipping();
     
        private Polygon[] GetPolygons(Polygon polygon)
        {
            var dic = new Dictionary<Vector3m, int>();
            var dd = new Dictionary<int, float[]>();
            var d1 = new Dictionary<float[], int>();
            var d2 = new Dictionary<float[], int>();
            var d3 = new Dictionary<float[], int>();
            var di = new Dictionary<int, int[]>();
            var mesh = polygon.Mesh;
            Effect effect = null;
            if (polygon != null)
            {
                if (polygon.Effect != null)
                {
                    effect = polygon.Effect.Clone() as Effect;
                }
            }
            if (polygon.Points.Length >= 3)
            {
                var points = new List<Vector3m>();
                foreach (var point in polygon.Points)
                {
                    var p = point.Texture;

                    var v = new Vector3m(p[0], p[1], 0);
                    foreach (var py in points)
                    {
                        if (c.Equals(py, v))
                        {
                            return [];
                        }
                    }
                    var ind = point.VertexIndex;
                    dic[v] = ind;
                    dd[ind] = p;
                    di[ind] = [point.TextureIndex, point.NormalIndex];
                    points.Add(v);
                }
                clipping.SetPoints(points);
                try
                {
                    if (!clipping.Triangulate())
                    {
                        return [];
                    }
                }
                catch (Exception ex)
                {
                    ex.HandleException();
                    return [];
                }
                var res = clipping.Result;
                var l = new List<int>();
                foreach (var p in res)
                {
                    foreach (var pt in dic.Keys)
                    {
                        if (c.Equals(p, pt))
                        {
                            l.Add(dic[pt]);
                            break;
                        }
                    }
                }
                if (l.Count != res.Count)
                {
                    throw new ErrorHandler.OwnException("Splitter count");
                }
                var pp = new List<Polygon>();

                for (var i = 0; i < res.Count; i += 3)
                {
                    var t = new List<PointTexture>();
                    for (var j = 0; j < 3; j++)
                    {
                        var k = i + j;
                        var r = res[k];
                        var ind = dic[r];
                        if (!dd.ContainsKey(ind))
                        {

                        }
                        var pt = dd[ind];
                        var ii = di[ind];
                        var point = new PointTexture(mesh, ind, ii[0], ii[1]);
                        t.Add(point);

                    }
                    pp.Add(new Polygon(mesh, t.ToArray(), effect));
                }
                return pp.ToArray();
            }


            return [polygon];
        }

        IPolygonSplitter IPolygonSplitterFactory.CreatePolygonSplitter()
        {
            return new Splitter();
        }

        bool IEqualityComparer<Vector3m>.Equals(Vector3m? x, Vector3m? y)
        {
            return ((x.X == y.X) & (x.Y == y.Y) & (x.Z == y.Z));
        }

        int IEqualityComparer<Vector3m>.GetHashCode(Vector3m obj)
        {
            return obj.GetHashCode();
        }
    }


}