using System.Linq;
using System.Linq.Expressions;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using ErrorHandler;

namespace Abstract3DConverters.Creators
{
    
    [Attributes.Extension([".obj"])]
    public class Obj3DCreator : LinesMeshCreator, IAdditionalInformation
    {
        #region Fields

        List<AbstractMesh> models = new();

        private string mtlfile;

        private string mtlstr;

        Dictionary<string, byte[]> add;

        internal int n = 0;

        #endregion

        #region Ctor

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Obj3DCreator(string filename, byte[] bytes) : base(filename, bytes)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {

        }


        #endregion

        Dictionary<string, byte[]> IAdditionalInformation.Information => CreateAdd();

        internal List<float[]> Vertices { get; private set; } = new List<float[]>();
        internal List<float[]> Normals  { get; private set; } = new List<float[]>();
        internal List<float[]> Textures { get; private set; } = new List<float[]>();

        internal List<List<int[][]>> Indexes { get; private set; } = new();

        internal List<string> Names 
        {   
            get; 
            private set; 
        } = new();
        internal int[] Shifts { get; private set; } = [1, 1, 1];

        internal List<Effect> EffectList { get; private set; } = new();

        protected override IEnumerable<AbstractMesh> Meshes
        {
            get
            {
                for (var i = 0; i < EffectList.Count; i++)
                {
                    yield return new AbstractMeshObj(i, this);
                }
                yield break;

            }
        }

        void CreateGeometry()
        {
            try
            {
                List<int[][]> indexes = null;

                foreach (var line in lines)
                {
                    var objs = "# object ";
                    
                    if (line.Contains(objs)  | line.StartsWith("g "))
                    {
                        var name = s.ToString(line, "g");
                        if (name == null)
                        {
                            name = line.Substring(objs.Length).Trim();
                        }
                        Names.Add(name);
                        indexes = new();
                        Indexes.Add(indexes);
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
                        var effect = Effects[mat];
                        EffectList.Add(effect);
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
                            var i = new int[3] { -1, -1, -1 };
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
                                    i[m] = int.Parse(sss[m]) - 1;// Shifts[m];
                                }
                            }
                        }
                        indexes.Add(ind);
                        continue;
                    }

                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Create geometry Obj creator");
            }
        }

        Dictionary<string, byte[]> CreateAdd()
        {
            if (mtlfile == null)
            {
                add = null;
                return null;
            }
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

        public class MtlWrapper : IEffectDictionary
        {
            Dictionary<string, Effect> dict;


            public MtlWrapper()
            {
                dict = new Dictionary<string, Effect>();
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

            public Dictionary<string, Effect> Create(string filename, string directory)
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

            public Dictionary<string, Effect> Create(string filename)
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


            private Effect effect;
            public Effect Effect
            {
                get
                {
                    Create();
                    return effect;
                }
            }

            Dictionary<string, Effect> IEffectDictionary.Effects => throw new NotImplementedException();

            void Create()
            {
                if (effect != null)
                {
                    return;
                }
                if (Diffuse == null)
                {
                    return;
                }
                MaterialGroup mat = new PhongMaterial(Name, null);
                var children = mat.Children;
                if (Diffuse != null)
                {
                    var diffuse = new DiffuseMaterial(Diffuse, Ambient, d);
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
                effect = new Effect(null, Name, mat, Kd);
            }


            private MtlWrapper(string str, string directory, StreamReader reader, Dictionary<string, Effect> effects)
            {
                Name = str;
                string newName = "";

                List<string> list = new List<string>();
                do
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
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
                }
                while (!reader.EndOfStream);

                Finalize(list, directory);
                Create();
                var mat = Effect;
                if (mat != null)
                {
                    effects[Name] = Effect;
                }

                if (!reader.EndOfStream)
                {
                    new MtlWrapper(newName, directory, reader, effects);
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
                    var value = t.Substring(n + 1);
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
                            // # optical density Values can range from 0.001 to 10
                            Ni = ToFloat(value);
                            break;
                        case "d":
                            // some implementations use 'd' d 0.9 # others use 'Tr' (inverted: Tr = 1 - d) Tr 0.1
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
                        Effects[mat.Key] = mat.Value;
                    }
                    break;
                }
            }
            if (Effects.Count == 0)
            {
                var l = (from line in lines
                         where s.ToString(line, "usemtl") != null
                         select
                         CreateEffect(line)).ToArray();
               //          var l = lines.Select(str => s.ToString(str)); ;
            }
        }


        string[] ext = [".png", ".jpg"];

        string Exists(string file)
        {
            var d = creator.Directory;
            var filename = Path.Combine(d, file);
            if (File.Exists(filename))
            {
                return filename;
            }
            foreach (var e in ext)
            {
                var fn = filename + e;
                if (File.Exists(fn))
                {
                    return fn;
                }
            }
            var f = file.Replace("_", " ");
            f = Path.Combine(d, f);
            if (File.Exists(f))
            {
                return f;
            }
            foreach (var e in ext)
            {
                var fn = f + e;
                if (File.Exists(fn))
                {
                    return fn;
                }
            }
            return null;
        }

        Effect CreateEffect(string str)
        {
            var f = s.ToString(str, "usemtl");
            var file = Exists(f);
            Image image = null;
            if (file != null)
            {
                var inm = Path.GetFileName(file);
                image = new Image(inm, creator.Directory);
            }
            var ff = new float[] { 1f, 1f, 1f, 1f };
            var d = new DiffuseMaterial(new Color(ff), new Color(ff), 1f);
            var mat = new MaterialGroup(f);
            mat.Children.Add(d);
            return new Effect(this, f, mat, image);
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
                        Effects[mat.Key] = mat.Value;
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
