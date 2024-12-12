using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
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

            if (polygon.Points.Count >= 3)
            {
                var points = new List<Vector3m>();
                foreach (var point in polygon.Points)
                {
                    var p = point.Item4;
                    d1[p] = point.Item1;
                    d2[p] = point.Item2;
                    d3[p] = point.Item3;
                    dd[point.Item1] = p;
                    var v = new Vector3m(p[0], p[1], 0);
                    foreach (var py in points)
                    {
                        if (c.Equals(py, v))
                        {
                            return [];
                        }
                    }
                    dic[v] = point.Item1;
                    points.Add(v);
                }
                clipping.SetPoints(points);
                try
                {
                    clipping.Triangulate();
                }
                catch (Exception ex)
                {
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
                    throw new Exception();
                }
                var pp = new List<Polygon>();
                
                for (var i = 0; i < res.Count; i+= 3)
                {
                    var t = new List<Tuple<int, int, int, float[]>>();
                   for (var j = 0; j < 3; j++) 
                    {
                        var k = i + j;
                        var ind = l[k];
                        var pt = dd[ind];
                        t.Add(new Tuple<int, int, int, float[]>(d1[pt], d2[pt], d3[pt], pt));

                    }
                   pp.Add(new Polygon(t));
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