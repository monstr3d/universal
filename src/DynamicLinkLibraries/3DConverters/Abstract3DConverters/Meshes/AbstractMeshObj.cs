using System.Runtime.InteropServices;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Meshes
{
    class AbstractMeshObj : AbstractMesh
    {
        internal AbstractMeshObj(string name, Obj3DCrearor crearor, int begin, out int end, out string nextName, int[] shift, List<string> lines) : base(name, crearor)
        {
            end = 0;
            nextName = null;
            var vertices = new List<float[]>();
            var textures = new List<float[]>();
            var normals = new List<float[]>();
            var indexes = new List<int[][]>();
            Material material = null;
            for (var k = begin; k < lines.Count; k++)
            {
                var line = lines[k];
                var objs = "# object ";
                if (line.Contains(objs))
                {
                    nextName = line.Substring(objs.Length).Trim();
                    end = k + 1;
                    break;
                }

                if (line.IndexOf("v ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                    vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                    textures.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                    normals.Add(f);
                    continue;
                }
                if (line.StartsWith("usemtl "))
                {
                    var mat = line.Substring("usemtl ".Length);
                    Material = crearor.Materials[mat];
                    continue;
                }
                if (line.IndexOf("v ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                    vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                    textures.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                    normals.Add(f);
                    continue;
                }
                if (line.IndexOf("f ") == 0)
                {
                    var s = line.Substring("f ".Length).Trim();
                    var ss = s.Split(" ".ToCharArray());
                    var ind = new int[ss.Length][];
                    for (int j = 0; j < ss.Length; j++)
                    {
                        var sss = ss[j].Split("/".ToCharArray());
                        var i = new int[sss.Length];
                        ind[j] = i;
                        //var k =  new int[sss.Length];
                        for (int m = 0; m < sss.Length; m++)
                        {
                            if (sss[m].Length == 0)
                            {
                                i[m] = -1;
                            }
                            else
                            {
                                i[m] = int.Parse(sss[m]) - shift[m];
                            }
                        }
                    }
                    indexes.Add(ind);
                    continue;
                }
            }
            if (end == 0)
            {
                end = lines.Count;
            }
            shift[0] += vertices.Count;
            shift[1] += textures.Count;
            shift[2] += normals.Count;
            var points = new Dictionary<int, Point>();
            var dic = new Dictionary<int, int[]>();
            foreach (var ind in indexes)
            {
                foreach (var item in ind)
                {
                    int id = item[0];
                    if (points.ContainsKey(id))
                    {
                        continue;
                    }
                    float[] vert = null;
                    if (id < 0)
                    {
                        if (id >= vertices.Count)
                        {
                            continue;
                        }
                    }
                    vert = vertices[id];
                    float[] txt = null;
                    var idt = item[1];
                    if (idt >= 0)
                    {
                        if (idt <= textures.Count)
                        {
                            txt = textures[idt];
                        }
                    }
                    var idn = item[2];
                    float[] norm = null;
                    if (idn >= 0)
                    {
                        if (idn <= normals.Count)
                        {
                            norm = normals[idn];
                        }
                    }
                    var point = new Point(vert, txt, norm);
                    points[id] = point;
                    dic[id] = item;
                }
            }

            var l = new List<int>(points.Keys);
            l.Sort();
            Points = new List<Point>();
            var dp = new Dictionary<int, int>();
            foreach (var x in l)
            {
                dp[x] = Points.Count;
                Points.Add(points[x]);
            }
            PolygonIndexes = new();
            foreach (var ind in indexes)
            {
                var li = new List<int>();
                foreach (var item in ind)
                {
                    li.Add(dp[item[0]]);
                }
                PolygonIndexes.Add(li.ToArray());
            }
        }
    }
}