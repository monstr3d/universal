using System.Linq.Expressions;
using Collada;

namespace Abstract3DConverters
{
    public class AbstractMeshAC : AbstractMesh
    {

        int count;

        float[] coord;

        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;

        List<string> l;

        List<Polygon> polygons;

        public AbstractMeshAC(string name, int count, List<string> l) : base(name)
        {
            this.count = count;
            this.l = l;
            for(int i = 0; i < l.Count; i++)
            {
                var line = l[i];
                var numvert = ToReal<int>(line, "numvert ");
                if (numvert != null)
                {
                    var v = new List<float[]>();
                    Vertices = v;
                    var j = i + 1;
                    int nv = numvert.Value;
                    for (; j < nv + i + 1; j++)
                    {
                        v.Add(ToRealArray<float>(l[j]));
                    }
                    i = j - 1;
                    continue;
                }
                var numsurf = ToReal<int>(line, "numsurf ");
                if (numsurf != null)
                {
                    polygons = new();
                    var nc = numsurf.Value;
                    var k = i + 1;
                    for (;  k < l.Count; k++)
                    {
                        var refs = ToReal<int>(l[k], "refs ");
                        if (refs != null)
                        {
                            var rf = refs.Value;
                            var p = k + 1;
                            var pp = new List<Tuple<int, float[]>>();
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = il.Split(sep);
                                var t = new Tuple<int, float[]>(ToReal<int>(ss[0].Trim()), new float[] { ToReal<float>(ss[1].Trim()), ToReal<float>(ss[2].Trim()) });
                                pp.Add(t);
                                if (pp.Count == refs)
                                {
                                    break;
                                }

                            }
                            var polygon = new Polygon(pp);
                            var polygo = splitter[polygon];
                            polygons.AddRange(polygo);
                        }    
                    }
                }
            }
        }


        
    }
}
