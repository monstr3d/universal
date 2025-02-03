using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;
using EarClipperLib;
using ErrorHandler;

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
        List<Polygon> IPolygonSplitter.this[Polygon polygon, List<Point> points] => Get(polygon, points);

        EarClipping clipping = new EarClipping();

        List<Polygon> Get(Polygon polygon, List<Point> pts)
        {
            try
            {
                var material = polygon.Material;
                var p = polygon.Indexes;
                var dic = new Dictionary<Vector3m, int>();
                var dd = new Dictionary<int, float[]>();
                var d1 = new Dictionary<float[], int>();
                var d2 = new Dictionary<float[], int>();
                var d3 = new Dictionary<float[], int>();
                if (p.Length <= 3)
                {
                    return [polygon];
                }
                var points = new List<Vector3m>();
                foreach (var i in p)
                {
                    var txt = pts[i].Texture;
                    var v = new Vector3m(txt[0], txt[1], 0);
                    foreach (var py in points)
                    {
                        if (c.Equals(py, v))
                        {
                            return [];
                        }
                    }
                    dic[v] = i;
                    points.Add(v);

                }
                var d = new Dictionary<Vector3m, int>();
                for (var i = 0; i < points.Count; i++)
                {
                    d[points[i]] = i;
                }
                clipping.SetPoints(points);
                if (!clipping.Triangulate())
                {
                    return [];
                }
                var res = clipping.Result;
                var lr = new List<Polygon>();
                for (var i = 0; i < res.Count; i += 3)
                {
                    int[] kk = new int[3];
                    var pp = new Polygon(kk, material);
                    lr.Add(pp);
                    for (var lt = 0; lt < 3; lt++)
                    {
                        kk[lt] = d[res[i + lt]];
                    }
                }
                return lr;
            }
            catch (Exception ex)
            {
                ex.ShowError(-1);
            }
            return [];
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