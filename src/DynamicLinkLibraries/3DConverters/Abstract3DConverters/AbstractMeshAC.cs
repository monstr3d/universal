using System.ComponentModel.DataAnnotations;
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

        public Image Image 
        { 
            get; 
            private set; 
        }

        private List<Polygon> polygons;

  
        public AbstractMeshAC(string name, int count, List<string> l, List<Material> materials, string directory) : base(name)
        {
           // Material = material.Clone() as Material;
            this.count = count;
            this.l = l;
            for(int i = 0; i < l.Count; i++)
            {
                var line = l[i];
  /*
                if (line.StartsWith("OBJECT "))
                {
                    continue;
                }
                if (line.StartsWith("kids "))
                {
                    continue;
                }
                if (line.StartsWith("name "))
                {
                    continue;
                }
                if (line.StartsWith("data "))
                {
                    continue;
                }
                if (line.StartsWith("Mesh."))
                {
                    continue;
                }
                if (line.StartsWith("Mesh"))
                {
                    continue;
                }
                if (line.StartsWith("texrep 1 1"))
                {
                    continue;
                }
                if (line.StartsWith("crease "))
                {
                    continue;
                }*/
                var loc = s.ToString(line, "loc ");
                if (loc != null)
                {
                    var location = s.ToRealArray<float>(loc);
                    TransformationMatrix = [ 1, 0, 0, 0, 
                                             0, 1, 0, 0,
                                             0, 0, 0, 1, 
                                            location[0], location[1], location[2], 0 ];
                }
                var texture = s.ToString(line, "texture ");
                if (texture != null)
                {
                    Image = new Image(texture, directory);
                    SetImage(Material, Image);
                    continue;
                }
                var numvert = s.ToReal<int>(line, "numvert ");
                if (numvert != null)
                {
                    var v = new List<float[]>();
                    Vertices = v;
                    var j = i + 1;
                    int nv = numvert.Value;
                    for (; j < nv + i + 1; j++)
                    {
                        v.Add(s.ToRealArray<float>(l[j]));
                    }
                    i = j - 1;
                    continue;
                }
                var numsurf = s.ToReal<int>(line, "numsurf ");
                if (numsurf != null)
                {
                    polygons = new();
                    var nc = numsurf.Value;
                    var k = i + 1;
                    for (;  k < l.Count; k++)
                    {
                        var mp = s.ToReal<int>(l[k], "mat ");
                        {
                            if (mp != null)
                            {
                                if (Material == null)
                                {
                                    var mat = materials[mp.Value];
                                    mat = mat.Clone() as Material;
                                    Material = mat;
                                    SetImage(Material, Image);
                                }
                                continue;
                            }
                        }

                        var refs = s.ToReal<int>(l[k], "refs ");
                        if (refs != null)
                        {
                            var rf = refs.Value;
                            var p = k + 1;
                            var pp = new List<Tuple<int, float[]>>();
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = s.Split(il);
                                var t = new Tuple<int, float[]>(s.ToReal<int>(ss[0].Trim()), new float[] { s.ToReal<float>(ss[1].Trim()), 
                                    s.ToReal< float >(ss[2].Trim()) });
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
                    i = k;
                    continue;
                }
            }
        }

        public void CreatePolygons()
        {
            if (polygons == null)
            {
                return;
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
        }
        

        public override object GetMaterial(Dictionary<string, object> map, IMaterialCreator creator)
        {
            var o = base.GetMaterial(map, creator);
            if (o != null)
            {
                return o;
            }
            if (Material == null)
            {
                if (count == 0)
                {
                    return null;
                }
            }
            return creator.Create(Material);
        }

    }
}
