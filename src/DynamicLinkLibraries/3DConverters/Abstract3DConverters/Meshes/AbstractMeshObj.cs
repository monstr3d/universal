
using Abstract3DConverters.Creators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Meshes
{
    /*
    class AbstractMeshObj : AbstractMesh
    {
        internal int Shift
        {
            get;
            private set;
        }

        internal int ShiftTexture
        {
            get;
            private set;
        }

        internal int ShiftNormal
        {
            get;
            private set;
        }

        internal AbstractMeshObj(int number, Obj3DCreator creator) : base(null, creator)
        {
            Material = creator.MaterialList[number];
            Name = creator.Names[number];
            Points = new();
            Polygons = new();
            var indexes = creator.Indexes[number];
            var direct = new Dictionary<int, int>();
            foreach (var idx in indexes)
            {
                var pp = new List<PointTexture>();
                foreach (var item in idx)
                {
                    float[] norm = null;
                    int nv = -1;
                    int nn = -1;
                    int nt = -1;
                    var iv = item[0] - 1;
                    var it = item[1] - 1;
                    var ino = -1;
                    if (item.Length > 2)
                    {
                        ino = item[2] - 1;
                    }
                    if (direct.ContainsKey(iv))
                    {
                        nv = direct[iv];
                    }
                    else
                    {
                        nv = Points.Count;
                        direct[iv] = nv;
                        if (ino >= 0)
                        {
                            norm = creator.Normals[ino];
                        }
                        var point = new Point(creator.Vertices[iv], norm);
                        Points.Add(point);
                    }
                    var txt = new PointTexture(nv, creator.Textures[it], norm);
                    pp.Add(txt);
                }
                Polygons.Add(new Polygon(pp.ToArray(), Material));
            }
           
        }



        internal AbstractMeshObj(string name, Obj3DCreator crearor, int begin, out int end, out string nextName, int[] shift, List<string> lines) : base(name, crearor)
        {
            Shift = shift[0];
            ShiftTexture = shift[1];
            ShiftNormal = shift[2];
            end = 0;
            nextName = null;
            var vertices = new List<float[]>();
            var textures = new List<float[]>();
            var normals = new List<float[]>();
            var indexes = new List<int[][]>();
            Material material = null;
            var textureVertex = new Dictionary<int, int>();
            var vertexTexture = new Dictionary<int, int>();
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
                        if (i.Length == 3)
                        {
                            textureVertex[i[1]] = i[0];
                        }
                        else
                        {
                            textureVertex[i[1]] = i[0];
                        }
                        vertexTexture[i[0]] = i[1];
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
            Normals = normals;
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
                    float[] norm = null;
                    var idn = -1;
                    if (item.Length > 2)
                    {
                        idn = item[2];
                        norm = null;
                        if (idn >= 0)
                        {
                            if (idn <= normals.Count)
                            {
                                norm = normals[idn];
                            }
                        }
                    }
                    var point = new Point(vert, norm);
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
            Polygons = new();
            foreach (var ind in indexes)
            {
                var li = new List<PointTexture>();
                foreach (var item in ind)
                {
                    var idn = -1;
                    if (Normals != null)
                    {
                        if (Normals.Count > 0)
                        {
                            if (item.Length > 2)
                            {
                                idn = item[2];
                            }
                        }
                    }
                    var pt = new PointTexture(item[0], textures[item[1]]);
                    li.Add(pt);

                }
                // li.Add(dp[item[0]]);
                var pl = new Polygon(li.ToArray(), Material);
                Polygons.Add(pl);
            }
        }
    }
    */
}