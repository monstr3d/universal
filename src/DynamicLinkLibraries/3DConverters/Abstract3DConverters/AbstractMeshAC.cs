using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json;
using Collada;

namespace Abstract3DConverters
{
    public class AbstractMeshAC :  AbstractMeshPolygon
    {

        int count;

        bool disitegrate = false;

        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();


        List<string> l;

        public Image Image 
        { 
            get; 
            private set; 
        }

   
        public AbstractMeshAC(string name, int count, List<string> l, List<Material> materials,  string directory) :
            base(name)
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
 //                   if (Material)
 //                   SetImage(Material, Image);
 //                   continue;
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
                    int mt = -1;
                    var mats = new List<int>();
                    var nc = numsurf.Value;
                    var k = i + 1;
                    for (;  k < l.Count; k++)
                    {
  
                        var mp = s.ToReal<int>(l[k], "mat ");
                        {
                            if (mp != null)
                            {
                                mt = mp.Value - 1;
                                if (!mats.Contains(mt))
                                {
                                    mats.Add(mt);
                                }
      /*                         if (Material == null)
                               {
                                    var mat = materials[mp.Value];
                                    mat = mat.Clone() as Material;
                                    Material = mat;
                                    SetImage(Material, Image);
                                }*/
                                continue;
                            }
                        }

                        var refs = s.ToReal<int>(l[k], "refs ");
                        if (refs != null)
                        {
                            var rf = refs.Value;
                            var p = k + 1;
                            var pp = new List<Tuple<int, int, float[]>>();
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = s.Split(il);
                                var t = new Tuple<int, int, float[]>(s.ToReal<int>(ss[0].Trim()), -1, new float[] { s.ToReal<float>(ss[1].Trim()), 
                                    s.ToReal< float >(ss[2].Trim()) });
                                pp.Add(t);
                                if (pp.Count == refs)
                                {
                                    break;
                                }

                            }
                            var polygon = new Polygon(pp);
                            dp[polygon] = mt;
                            Polygons.Add(polygon);
                        }
                        if (mats.Count == 1)
                        {
                            var mat = materials[dp.Values.ToArray()[0]];
                            Material = mat.Clone() as Material;
                            SetImage(Material, Image);
                        }
                        else if (mats.Count > 1)
                        {
                            if (Vertices.Count > 0)
                            {
                                foreach (Polygon p in Polygons)
                                {
                                    var mat = materials[dp[p]];
                                    new AbstractMeshAC(this, p, mat, Image);
                                }
                                Vertices = new List<float[]>();
                                Polygons.Clear();
                                Image = null;
                            }
                        }
                    }
                    i = k;
                    continue;
                }
            }
        }

        private AbstractMeshAC(AbstractMeshAC parent, Polygon polygon, Material material, Image image) : base("")
        {
            Vertices = new List<float[]>();
            var d = new Dictionary<int, int>();
            int i = 0;
            foreach (var p in polygon.Points)
            {
                var k = p.Item1;
                if (!d.ContainsKey(k))
                {
                    d[k] = i;
                    ++i;
                }
            }
            foreach (var key in d.Keys)
            {
                Vertices.Add(parent.Vertices[key]);
            }
            var l =  new List<Tuple<int, int, float[]>> ();
            foreach (var p in polygon.Points)
            {
                var t = new Tuple<int, int, float[]>(d[p.Item1], p.Item2, p.Item3);
                l.Add(t);
            }
            var pol = new Polygon(l);
            Polygons.Add(pol);
            Parent = parent;
            TransformationMatrix = parent.TransformationMatrix;
            Material = material.Clone() as Material;
            if (image != null)
            {
                Image = image.Clone() as Image;
                SetImage(Material, Image);
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
