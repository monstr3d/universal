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

        string directory;

        List<string> l;

        public Image Image { get; private set; }

        List<Polygon> polygons;

        public Material Material { get; private set; }

        public AbstractMeshAC(string name, int count, List<string> l, Material material, string directory) : base(name)
        {
            this.directory = directory;
            Material = material.Clone() as Material;
            this.count = count;
            this.l = l;
            for(int i = 0; i < l.Count; i++)
            {
                var line = l[i];
                var texture = ToString(line, "texture ");
                if (texture != null)
                {
                    Image = new Image(texture, directory);
                    SetImage(Material, Image);
                }
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

        public override object GetMaterial(Dictionary<string, object> map, IMaterialCreator creator)
        {
            var o = base.GetMaterial(map, creator);
            if (o != null)
            {
                return o;
            }
            return creator.Create(Material);
        }



    }
}
