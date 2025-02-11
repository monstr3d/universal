using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    [Attributes.Extension([".obj"])]
    public class Obj3DCreator : LinesMeshCreator, IAdditionalInformation
    {
        List<AbstractMesh> models = new();

        private string mtlfile;

        private string mtlstr;

        Dictionary<string, byte[]> add;

        protected Service s = new Service();

        internal int n = 0;


        Dictionary<string, byte[]> IAdditionalInformation.Information => CreateAdd();


        internal List<float[]> Vertices { get; private set; } = new List<float[]>();
        internal List<float[]> Normals  { get; private set; } = new List<float[]>();
        internal List<float[]> Textures { get; private set; } = new List<float[]>();

        internal List<List<int[][]>> Indexes { get; private set; } = new();

        internal List<string> Names { get; private set; } = new();
        internal List<int[]> Shifts { get; private set; } = new();

        internal List<Material> MaterialList { get; private set; } = new();

        void CreateGeometry()
        {
            List<int[][]> indexes = null;

            foreach (var line in lines)
            {
                var objs = "# object ";
                if (line.Contains(objs))
                {
                    var name = line.Substring(objs.Length).Trim();
                    Names.Add(name);
                    indexes = new();
                    Indexes.Add(indexes);
                    Shifts.Add([Vertices.Count, Textures.Count, Normals.Count]);
                    continue;
                }

                if (line.IndexOf("v ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                    Vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                    Textures.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                    Normals.Add(f);
                    continue;
                }
                if (line.StartsWith("usemtl "))
                {
                    var mat = line.Substring("usemtl ".Length);
                     var material = Materials[mat];
                    MaterialList.Add(material);

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
                                i[m] = int.Parse(sss[m]);
                            }
                        }
                    }
                    indexes.Add(ind);
                    continue;
                }

            }
        }

        //      internal Dictionary<int, Tuple<List<float[]>, List<float[]>, List<float[]>>> All = new();


        public Obj3DCreator(string filename, byte[] bytes) : base(filename, bytes)
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

        public class MtlWrapper : IMaterialDictionary
        {
            Dictionary<string, Material> dict;


            public MtlWrapper()
            {
                dict = new Dictionary<string, Material>();
            }

            public Dictionary<string, object> Create(Dictionary<string, Material> keyValuePairs, 
                IMaterialCreator creator)
            {
                Dictionary<string, object> d = new Dictionary<string, object>();
                foreach (var pair in keyValuePairs)
                {
                    Material mat = pair.Value;
                    var v = creator.Create(mat);
                    d[pair.Key] = v;
                }
                return d;
            }

            public Dictionary<string, Material> Create(string filename, string directory)
            {
                using (var reader = new StreamReader(Path.Combine(directory, filename)))
                {

                    var name = "";
                    do
                    {
                        var line = reader.ReadLine();
                        if (line.Contains("newmtl"))
                        {
                            var ss = line.Split(" ".ToCharArray());
                            name = ss[ss.Length - 1];
                            break;
                        }

                    }
                    while (!reader.EndOfStream);
                    new MtlWrapper(name, directory, reader, dict);

                }
                return dict;

            }

            public Dictionary<string, Material> Create(string filename)
            {
                dict.Clear();
                using (var reader = new StreamReader(filename))
                {
                    do
                    {
                        var line = reader.ReadLine();
                        if (line.Contains("newmtl"))
                        {
                            var ss = line.Split(" ".ToCharArray());
                            var name = ss[ss.Length - 1];
                            new MtlWrapper(name, Path.GetDirectoryName(filename), reader, dict);
                        }
                    }
                    while (!reader.EndOfStream);
                }
                return dict;
            }


            public Image Ka { get; private set; }
            public Image Kd { get; private set; }
            public Image Ks { get; private set; }

            public string Name { get; private set; }

            public Color Ambient { get; private set; }

            public Color Diffuse { get; private set; }

            public Color Specular { get; private set; }


            public float Ns { get; private set; }
            public float Ni { get; private set; }
            public float d { get; private set; }
            public int illum { get; private set; }


            private Material material;
            public Material Material
            {
                get
                {
                    Create();
                    return material;
                }
            }

            Dictionary<string, Material> IMaterialDictionary.Materials => dict;

            void Create()
            {
                if (material != null)
                {
                    return;
                }
                if (Diffuse == null)
                {
                    return;
                }
                MaterialGroup mat = new MaterialGroup(Name);
                var children = mat.Children;
                material = mat;
                if (Diffuse != null)
                {
                    var diffuse = new DiffuseMaterial(Diffuse, null, Kd, d);
                    //diffuse.Texture = Kd;
                    children.Add(diffuse);
                }
                if (Ambient != null)
                {
                    var emissive = new EmissiveMaterial(Ambient, Ka);
                    children.Add(emissive);
                }
                if (Specular != null)
                {
                    var specular = new SpecularMaterial(Specular, Ns);
                    children.Add(specular);
                }
            }


            private MtlWrapper(string str, string directory, StreamReader reader, Dictionary<string, Material> materials)
            {
                Name = str;
                string newName = "";

                List<string> list = new List<string>();
                do
                {
                    var line = reader.ReadLine();
                    if (line.Length == 0)
                    {
                        continue;
                    }
                    list.Add(line);
                    if (line.Contains("newmtl"))
                    {
                        var ss = line.Split(" ".ToCharArray());
                        newName = ss[ss.Length - 1];
                        break;
                    }
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                }
                while (!reader.EndOfStream);

                Finalize(list, directory);
                Create();
                var mat = Material;
                if (mat != null)
                {
                    materials[Name] = Material;
                }

                if (!reader.EndOfStream)
                {
                    new MtlWrapper(newName, directory, reader, materials);
                }

            }

            private float ToFloat(string str)
            {
                return float.Parse(
                    str.Replace(".",
                    System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            }


            void Finalize(List<string> list, string directory)
            {
                foreach (var s in list)
                {
                    if (s.Length == 0)
                    {
                        continue;
                    }
                    var t = s.Trim();
                    int n = t.IndexOf(" ");
                    var name = t.Substring(0, n);
                    var value = t.Substring(n);
                    switch (name)
                    {
                        /// The ambient color of the material is declared using Ka. Color definitions are in RGB where each channel's 
                        /// value is between 0 and 1.

                        case "Ka":
                            Ambient = new Color(value);
                            break;
                        case "Kd":
                            //  Similarly, the diffuse color is declared using Kd.
                            Diffuse = new Color(value);
                            break;
                        case "Ks":
                            //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                            Specular = new Color(value);
                            break;
                        // the ambient texture map
                        case "map_Ka":
                            Ka = new Image(value, directory);
                            break;
                        // the diffuse texture map 
                        case "map_Kd":
                            Kd = new Image(value, directory);
                            break;

                        //# specular color texture map
                        case "map_Ks":
                            Ks = new Image(value, directory);
                            break;
                        case "Ns":
                            /// Specular exponent ranges between 0 and 1000                        Ns 10.000            
                            Ns = ToFloat(value);
                            break;
                        case "Ni":
                            // # optical density                    Values can range from 0.001 to 10
                            Ni = ToFloat(value);
                            break;
                        case "d":
                            // some implementations use 'd'        d 0.9 # others use 'Tr' (inverted: Tr = 1 - d) Tr 0.1
                            d = ToFloat(value);
                            break;
                        case "Tr":
                            d = 1 - ToFloat(value);
                            break;
                        //            illumination model
                        case "illum":
                            illum = int.Parse(value);
                            break;
                        default:
                            break;

                    }
                }
            }
        }
        protected override IEnumerable<AbstractMesh> Get()
        {
            for (var i = 0; i < MaterialList.Count; i++)
            {
                yield return new AbstractMeshObj(i, this);
            }
            yield break;
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
                    var mt = mtl.Create(file, directory);
                    foreach (var mat in mt)
                    {
                        Materials[mat.Key] = mat.Value;
                    }
                    images = s.GetImages(Materials.Values);
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

            var b = 0;

            foreach (var line in lines)
            {
                ++b;
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

                    var mtl = new MtlWrapper();

                    var mt = mtl.Create(file, directory);
                    foreach (var mat in mt)
                    {
                        Materials[mat.Key] = mat.Value;
                    }
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
            CreateGeometry();
        }

    }
}