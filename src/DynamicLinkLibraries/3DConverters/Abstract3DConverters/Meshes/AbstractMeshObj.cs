using Abstract3DConverters.Attributes;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Meshes
{
    [CommonVetrices]
    class AbstractMeshObj : AbstractMeshPolygon
    {
        Dictionary<int, int[]> Global
        {
            get;
        } = new();

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

        List<Tuple<Effect, List<int[][]>>> Indexes
        {
            get;
            set;
        }

        internal List<float[]> IntVertices { get; private set; }
        internal List<float[]> IntTextures { get; private set; }
        internal List<float[]> IntNormals { get; private set; }

        private AbstractMeshObj(AbstractMeshObj parent, Tuple<Effect, List<int[][]>> tuple, Obj3DCreator creator) : base(creator.MeshName, parent, null, creator)
        {
            try
            {
                Vertices = new();
                Textures = new();
                Normals = new();
                IntVertices = creator.Vertices;
                IntTextures = creator.Textures;
                IntNormals = creator.Normals;
                Polygons = new();
                var indx = tuple.Item2;
                foreach (var ii in indx)
                {
                    foreach (var i in ii)
                    {
                        Vertices.Add(IntVertices[i[0]]);
                        Textures.Add(IntTextures[i[1]]);
                        if (i.Length > 2)
                        {
                            if (i[2] >= 0)
                            {
                                Normals.Add(IntNormals[i[2]]);
                            }
                        }
                    }
                }
                if (s.IsEmpty(Normals))
                {
                    Normals = null;
                }
                int np = 0;
                Effect = tuple.Item1;
                var idx = tuple.Item2;
                foreach (var ind in idx)
                {
                    var l = new List<PointTexture>();
                    for (int i = 0; i < ind.Length; i++)
                    {
                        var ik = (Normals == null) ? -1 : np;
                        var point = s.CreatePointTexture(this, np, np, ik);
                        ++np;
                        if (point == null)
                        {
                            throw new Exception("AbstractMeshObj POINT ERROR SINLE");
                        }
                        l.Add(point);
                    }
                    if (l.Count != 3)
                    {

                    }
                    var polygon = new Polygon(this, l, null);
                    Polygons.Add(polygon);
                }
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("ABSOBJ SINGLE 1");
            }
        }

        internal AbstractMeshObj(int number, Obj3DCreator creator) : 
            base("", null, null, creator)
        {
            try
            {
                Effect = creator.Default;
                var el = creator.EffectList;
                if (el != null)
                {
                    if (number < el.Count)
                    {
                        Effect = el[number];
                    }
                }
                IntVertices = creator.Vertices;
                IntTextures = creator.Textures;
                IntNormals = creator.Normals;
                Polygons = new();
                Indexes = creator.Indexes[number];
                if (creator.Names.Count > number)
                {
                    Name = creator.Names[number];
                }
                else
                {
                    Name = creator.MeshName;
                }
                if (Indexes.Count > 0)
                {
                    foreach (var tuple in Indexes)
                    {
                        new AbstractMeshObj(this, tuple, creator);
                    }
                    return;
                }
                Vertices = new();
                Textures = new();
                Normals = new();

                foreach (var tuple in Indexes)
                {
                    var ind = tuple.Item2;
                    foreach (var ii in ind)
                    {
                        foreach (var i in ii)
                        {
                            Vertices.Add(IntVertices[i[0]]);
                            Textures.Add(IntTextures[i[1]]);
                            if (i.Length > 2)
                            {
                                if (i[2] >= 0)
                                {
                                    Normals.Add(IntNormals[i[2]]);
                                }
                            }
                        }
                    }
                }
                if (s.IsEmpty(Normals))
                {
                    Normals = null;
                }
                int np = 0;
                foreach (var tuple in Indexes)
                {
                    var effect = tuple.Item1;
                    var idx = tuple.Item2;
                    foreach (var ind in idx)
                    {
                        var l = new List<PointTexture>();
                        for (int i = 0; i < ind.Length; i++)
                        {
                            var ik = (Normals == null) ? -1 : np;
                            var point = s.CreatePointTexture(this, np, np, ik);
                            ++np;
                            if (point == null)
                            {
                                throw new Exception("AbstractMeshObj POINT ERROR");
                            }
                            l.Add(point);
                        }
                        var polygon = new Polygon(this, l, effect);
                        Polygons.Add(polygon);
                    }
                }
            }
            catch (Exception e)
            {
                e.HandleExceptionDouble("ABSOBJ SINGLE 2");
            }
        }



        internal AbstractMeshObj(string name, Obj3DCreator objCreator, int begin, out int end, out string nextName, int[] shift, List<string> lines) : base(name, null, null, objCreator)
        {
            nextName = "";
            end = 0;
            try
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
                        Effect = Creator.Effects[mat];
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
                        var tt = new int[2] { -1, -1 };
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
                        throw new Exception();
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
                var dic = new Dictionary<int, int[]>();
                Normals = normals;
                foreach (var ind in indexes)
                {
                    foreach (var item in ind)
                    {
                        int id = item[0];
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
                      }
                }

                var dp = new Dictionary<int, int>();
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
                        var nv = item[0];
                        var k = Global[nv];
                        var pt = s.CreatePointTexture(this, nv, k[0], k[1]);
                        if (pt == null)
                        {
                            throw new Exception("AbstractMeshObj");
                        }
                       
                        li.Add(pt);

                    }
                    // li.Add(dp[item[0]]);
                    var pl = new Polygon(this, li.ToArray(), Effect);
                    Polygons.Add(pl);
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("AbstractMeshObj 2");
            }
        }
    }
}