using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    [Attributes.Extension([".obj"])]
    public class Obj3DCrearor : LinesMeshCreator, IAdditionalInformation
    {
        List<AbstractMesh> models = new();

        private string mtlfile;

        private string mtlstr;

        Dictionary<string, byte[]> add;

        internal int n = 0;

        Dictionary<string, byte[]> IAdditionalInformation.Information => CreateAdd();


        internal List<float[]> Vertices { get; private set; } = new List<float[]>();
        internal List<float[]> Normals  { get; private set; } = new List<float[]>();
        internal List<float[]> Textures { get; private set; } = new List<float[]>();


        public Obj3DCrearor(string filename, Stream stream) : base(filename, stream)
        {

        }

        Dictionary<string, byte[]> CreateAdd()
        {
            if (add == null)
            {
                using (Stream stream = File.OpenRead(mtlfile))
                {
                    byte[] b = new byte[stream.Length];
                    stream.Read(b);
                    add = new Dictionary<string, byte[]>() { { mtlstr, b } };
                }
            }
            return add;
        }







        protected override IEnumerable<AbstractMesh> Get()
        {
            foreach (var line in lines)
            {
                if (line.IndexOf("v ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                    Vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                    Normals.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                    Textures.Add(f);
                    continue;
                }

            }
            List<AbstractMesh> meshes = new();

            var obj = new Tuple<List<float[]>, List<float[]>, List<float[]>>(Vertices, Textures, Normals);

            List<int[][]> indexes = null;
            string name = null;
            string mat = null;
            AbstractMesh mesh = null;
            foreach (var line in lines)
            {
                if (line == null)
                {
                    break;
                }
                if (line.StartsWith("g "))
                {
                    if (mat != null)
                    {
                        mesh = new AbsractMeshObj(name, this, mat, indexes);
                        meshes.Add(mesh);
                    }
                    name = line.Substring("g ".Length);
                    mat = null;
                    indexes = new();
                    continue;
                }
                if (line.StartsWith("usemtl "))
                {
                    mat = line.Substring("usemtl ".Length);
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
                                i[m] = int.Parse(sss[m]) - 1;
                            }
                        }
                    }
                    indexes.Add(ind);
                    continue;
                }

            }
            mesh = new AbstractMesh(name, this, mat, new List<float[]>(), new List<float[]>(),
                new List<float[]>(), indexes);
            meshes.Add(mesh);

            return meshes;
        }
        void CreateMaterials()
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("mtllib "))
                {
                    var file = line.Substring("mtllib ".Length).Trim();
                    mtlfile = Path.Combine(directory, file);
                    mtlstr = file;
                    var mtl = new MtlWrapper();
                    materials = mtl.Create(file, directory);
                    images = s.GetImages(materials.Values);
                    break;
                }

            }
        }
   
        void Create(string name = null)
        {
            string currName = null;
            List<float[]> vertices = new();
            List<float[]> normals = new();
            List<float[]> textures = new();
            List<int[][]> triangles = new();
            string material = null;

            foreach (var line in lines)
            {
                if (line == null)
                {
                    var model = new AbstractMesh(name, this, material, vertices, normals, textures, triangles);
                    models.Add(model);
                    break;
                }
                if (line.Length == 0)
                {
                    continue;
                }
                if (line == null)
                {
                    //     models[name] = 
                    break;
                }
                if (line.StartsWith("mtllib "))
                {
                    var file = line.Substring("mtllib ".Length).Trim();
                    mtlstr = file;
                    mtlfile = Path.Combine(directory, file);

                    //       file = Path.Combine(directory, file);
                    var mtl = new MtlWrapper();
                    materials = mtl.Create(file, directory);
                }
                var objs = "# object ";
                if (line.Contains(objs))
                {
                    var lt = line.Substring(objs.Length).Trim();
                    if (name == null)
                    {
                        if (currName == null)
                        {
                            currName = lt;
                            continue;
                        }
                        else
                        {
                            var mod = new AbstractMesh(currName, this, material, vertices, normals, textures, triangles);
                            models.Add(mod);
                            Create(lt);
                            continue;
                        }
                    }
                    else
                    {
                        var model = new AbstractMesh(name, this, material, vertices, normals, textures, triangles);
                        models.Add(model);
                        //models[currName] = modelVisual3D;
                        Create(lt);
                    }
                }
                if (currName == null & name == null)
                {
                    continue;
                }
                if (line.IndexOf("v ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                    vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                    normals.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                    textures.Add(f);
                    continue;
                }
                if (line.Contains("usemtl "))
                {
                    material = line.Substring("usemtl ".Length).Trim();
                }
                if (line.IndexOf("f ") == 0)
                {
                    var s = line.Substring("f ".Length).Trim();
                    var ss = s.Split(" ".ToCharArray());
                    var ind = new int[ss.Length][];
                    for (int j = 0; j < ss.Length; j++)
                    {
                        var sss = ss[j].Split("/".ToCharArray());
                        var k = new int[sss.Length];
                        for (int m = 0; m < sss.Length; m++)
                        {
                            k[m] = int.Parse(sss[m]);
                        }
                        ind[j] = k;
                    }
                    triangles.Add(ind);
                    continue;
                }
            }
        }

        protected override void CreateFromLines()
        {
            CreateMaterials();
        }
    }
}