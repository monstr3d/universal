using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class AbstractMeshPolygon : AbstractMesh
    {

        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;

        public List<Polygon> Polygons
        { get; } = new List<Polygon>();
               

        public AbstractMeshPolygon(string name) : base(name)
        {

        }

        public AbstractMeshPolygon(string name, string material) : base(name)
        {
            MaterialString = material;
        }

        public void CreateFromPolygons()
        {
            List<Polygon> polygons = new List<Polygon>();
            foreach (var polygon in Polygons)
            {
                var pp = splitter[polygon];
                foreach (var p in pp)
                {
                    polygons.Add(p);
                }
            }
            var idx = new List<int[][]>();
            Indexes = idx;
            var txt = new List<float[]>();
            Textures = txt;
            var k = 0;
            foreach (var p in polygons)
            {
                var t = p.Points;
                var ii = new int[t.Count][];
                idx.Add(ii);
                for (int j = 0; j < t.Count; j++)
                {
                    var pp = t[j];
                    var iii = new int[] { pp.Item1, k, -1 };
                    ii[j] = iii;
                    ++k;
                    txt.Add(pp.Item2);
                }
            }
            foreach (var child in Children)
            {
                if (child is AbstractMeshPolygon amp)
                {
                    amp.CreateFromPolygons();
                }
            }
        }
    }
}
