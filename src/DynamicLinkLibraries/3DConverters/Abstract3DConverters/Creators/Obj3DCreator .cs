using System;
using System.Linq.Expressions;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;


namespace Abstract3DConverters.Creators
{
    
    [Attributes.Extension([".obj"])]
    public class Obj3DCreator : LinesMeshCreator, IAdditionalInformation, ISeparateTextures
    {
        #region Ctor

        public Obj3DCreator(string filename, string directory, params object[] objects) : base(filename, directory, objects)
        {

        }

        #endregion


        #region Fields

        internal bool Separate
        {
            get;
            private set;
        } = false;

        int mn = -1;

        bool MatExists
        {
            get;
            set;
        } = false;

        internal string MeshName
        {
            get
            {
                ++mn;
                return "Mesh_" + mn;
            }
        }

        internal Effect Default
        {
            get;
            set;
        }

        List<AbstractMesh> models = new();

        private string mtlfile;

        private string mtlstr;

        Dictionary<string, byte[]> add;

        internal int n = 0;

        #endregion

        private byte[] MaterialBytes
        {
            get;
            set;
        }
   
        protected override void CreateAdditional(object additional)
        {
            switch (additional)
            {
                case byte[] bytes:
                    MaterialBytes = bytes;
                    break;
                case Tuple<string, byte[]> tuple:
                    Process(tuple);
                    break;

            }
              CreateAll();
        }

        void Process(Tuple<string, byte[]> tuple)
        {
            var ext = Path.GetExtension(tuple.Item1);
            if (ext == ".mtl")
            {
                MaterialBytes = tuple.Item2;
                return;
            }
            Default = CreateEffectFromImage(Path.Combine(creator.Directory, tuple.Item1));
        }

        public List<string> UsedMaterials
        {
            get;
        } = new();

        Dictionary<string, byte[]> IAdditionalInformation.Information => CreateAdd();

        internal List<float[]> Vertices { get; private set; } = new List<float[]>();
        internal List<float[]> Normals  { get; private set; } = new List<float[]>();
        internal List<float[]> Textures { get; private set; } = new List<float[]>();

        internal List<List<Tuple<Effect,List<int[][]>>>> Indexes 
        { 
            get; 
        } = new();


        internal List<List<List<int[][]>>> PureIndexes
        {
            get;
        } = new();

        internal List<string> Names 
        {   
            get; 
            private set; 
        } = new();
        internal int[] Shifts { get; private set; } = [1, 1, 1];

        internal List<Effect> EffectList { get; private set; } = new();

        protected override IEnumerable<IMesh> Meshes
        {
            get
            {
                if (EffectList == null)
                {
                    yield return new AbstractMeshObj(0, this);
                    yield break;
                }
                if (EffectList.Count == 0)
                {
                    yield return new AbstractMeshObj(0, this);
                    yield break;
                }
                for (var i = 0; i < Indexes.Count; i++)
                {
                    var ind = Indexes[i];
                    if (ind.Count > 0)
                    {
                        yield return new AbstractMeshObj(i, this);
                    }
                }
                yield break;

            }
        }

        string GetObjectName(string line)
        {
            if (line.Contains(objs))
            {
               return line.Substring(objs.Length).Trim();
            }
            return null;
        }

        string GetgName(string line)
        {
            return s.ToString(line, "g");
        }

        const string Fiction = "rrg5dvmg.bil";

        string GetInitial(string line)
        {
            var n = s.ToString(line, objs);
            if (line.StartsWith("usemtl "))
            {
                var mat = line.Substring("usemtl ".Length);
                var effect = Detect(mat);
                EffectList.Add(effect);
                if (!UsedMaterials.Contains(mat))
                {
                    UsedMaterials.Add(mat);
                }
                return MeshName;
            }
            /*             if (MatExists)
                         {
                             return MeshName;
                         }
                   //      MatExists = true;
                         return Fiction;
                     /*        if (line.Contains(objs) | line.StartsWith("g "))
                             {
                                 var name = s.ToString(line, "g");
                                 if (name == null)
                                 {
                                     name = s.ToString(line, objs);
                                 }
                                 MatExists = false;
                                 return name;
                             }*/
            if (line.StartsWith("g "))
            {
                var name = s.ToString(line, "g");
                MatExists = false;
                return name;
            }
            return null;
        }

        //Func<string, string> GetName;

        string  objs = "# object ";

        void CreateGeometry()
        {
            var l = (from line in lines where line.StartsWith("usemtl") select line).ToList().Count;
            if (l > 0)
            {
                CreateNamedGeometry();
                return;
            }
            if (EffectList.Count == 0 & Default != null)
            {
                CreateDefaultGeometry();
                return;
            }
            CreateUnNamedGeometry();
        }

        void CreateDefaultGeometry()
        {
            try
            {
                var effect = Default;
                List<Tuple<Effect, List<int[][]>>> indexes = new();
                Indexes.Add(indexes);
                Tuple = new 
                    Tuple<Effect, List<int[][]>>(effect, new List<int[][]>());
                indexes.Add(Tuple);

                foreach (var line in lines)
                {
                    if (line.IndexOf("v ") == 0)
                    {
                        var f = s.ToRealArray<float>(line.Substring("v ".Length).Trim());
                        Vertices.Add(f);
                        continue;
                    }
                    if (line.IndexOf("vt ") == 0)
                    {
                        var f = s.ToRealArray<float>(line.Substring("vt ".Length).Trim());
                        s.AddTexture(Textures, f);
                        continue;
                    }
                    if (line.IndexOf("vn ") == 0)
                    {
                        var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                        Normals.Add(f);
                        continue;
                    }
                    if (line.IndexOf("f ") == 0)
                    {
                        var s = line.Substring("f ".Length).Trim();
                        var ss = s.Split(" ".ToCharArray());
                        if (ss.Length != 3)
                        {

                        }
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
                        Tuple.Item2.Add(ind);
                        continue;
                    }

                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Create defualt geometry Obj creator");
            }
        }

        Tuple<Effect, List<int[][]>> Tuple
        {
            get;
            set;
        }


        private Dictionary<string, Effect> EffectsPrivate
        {
            get;
        } = new Dictionary<string, Effect>();


        Effect Detect(string st)
        {
            if (EffectsPrivate.ContainsKey(st))
            {
                return EffectsPrivate[st];
            }
            var s = st.Replace("_", " ");
            if (EffectsPrivate.ContainsKey(s))
            {
                return EffectsPrivate[s];
            }
              foreach (var ee in EffectsPrivate)
            {
                var fn = Path.GetFileNameWithoutExtension(ee.Key);
                if (fn == st)
                {
                    return  ee.Value;
                }
            }
            return null;
        }

        void CreateUnNamedGeometry()
        {
            try
            {
                List<Tuple<Effect, List<int[][]>>> indexes = new();
                Indexes.Add(indexes);

                foreach (var line in lines)
                {
                    if (line.StartsWith("usemtl"))
                    {
                        var mat = line.Substring("usemtl ".Length);
                        if (mat != null)
                        {
                            if (mat == "_default_")
                            {
                                continue;
                            }
                            var effect = Detect(mat);
                            if (!UsedMaterials.Contains(mat))
                            {
                                UsedMaterials.Add(mat);
                            }
                            Tuple = new Tuple<Effect, List<int[][]>>(effect, new List<int[][]>());
                            indexes.Add(Tuple);
                            continue;
                        }
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
                        s.AddTexture(Textures, f);
                        continue;
                    }
                    if (line.IndexOf("vn ") == 0)
                    {
                        var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                        Normals.Add(f);
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
                        Tuple.Item2.Add(ind);
                        continue;
                    }

                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Create unnamed geometry Obj creator");
            }
        }


        void CreateNamedGeometry()
        {
            // GetName = GetInititial;
            try
            {
                List<Tuple<Effect, List<int[][]>>> indexes = new List<Tuple<Effect, List<int[][]>>>();
                for (int k = 0; k < lines.Count; k++)
                {
                    var line = lines[k];   
                    var name = GetInitial(line);
                    if (name != null)
                    {
                        if (name != Fiction)
                        {
                            Names.Add(name);
                            indexes = new();
                            Indexes.Add(indexes);
                            if (line.StartsWith("usemtl "))
                            {
                                var mat = line.Substring("usemtl ".Length);
                                if (mat == "_default_")
                                {
                                    continue;
                                }
                                var effect = Detect(mat);
                                EffectList.Add(effect);
                                if (!UsedMaterials.Contains(mat))
                                {
                                    UsedMaterials.Add(mat);
                                }
                                Tuple = new Tuple<Effect, List<int[][]>>(effect, new List<int[][]>());
                                indexes.Add(Tuple);
                                continue;
                            }
                            continue;
                        }
                        else
                        {
                        }
                    }
                    if (line.StartsWith("usemtl "))
                    {
                        var mat = line.Substring("usemtl ".Length);
                        if (mat == "_default_")
                        {
                            continue;
                        }
                        var effect = EffectsPrivate[mat];
                        EffectList.Add(effect);
                        if (!UsedMaterials.Contains(mat))
                        {
                            UsedMaterials.Add(mat);
                        }
                        Tuple = new Tuple<Effect, List<int[][]>>(effect, new List<int[][]>());
                        indexes.Add(Tuple);
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
                        s.AddTexture(Textures, f);
                        continue;
                    }
                    if (line.IndexOf("vn ") == 0)
                    {
                        var f = s.ToRealArray<float>(line.Substring("vn ".Length).Trim());
                        Normals.Add(f);
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
                        Tuple.Item2.Add(ind);
                        continue;
                    }

                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Create named geometry Obj creator");
            }
        }

        Dictionary<string, byte[]> CreateAdd()
        {
            if (MaterialBytes != null)
            {
                add = new Dictionary<string, byte[]>() { { mtlstr, MaterialBytes } };
            }
            else
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
                        stream.ReadExactly(b);
                        add = new Dictionary<string, byte[]>() { { mtlstr, b } };
                    }
                }
            }
            return add;
        }

        public class MtlWrapper : IEffectDictionary
        {

            

            public MtlWrapper(string directory)
            {
                Directory = directory;
                dict = new Dictionary<string, Effect>();
            }

            Dictionary<string, Effect> dict;

            private string Directory
            {
                get;
                set;
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

            internal Dictionary<string, Effect> Create(List<string> lines, int start, out Effect defaulEffect)
            {
                try
                {
                    defaulEffect = null;
                    var name = "";
                    var i = start;
                    for (; i < lines.Count; i++)
                    {
                        var line = lines[i];
                        if (line.Contains("newmtl"))
                        {
                            var ss = line.Split(" ".ToCharArray());
                            name = ss[ss.Length - 1];
                            break;
                        }

                    }
                    new MtlWrapper(name, i + 1, lines, dict, Directory);
                    return dict;
                }
                catch (Exception e)
                {
                    e.HandleExceptionDouble("Create OBJ material");
                }
                defaulEffect = null;
                return null;
            }

            public Dictionary<string, Effect> Create(string filename, string directory, out Effect defaultEffect)
            {
                defaultEffect = null;
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

            public Color Emissive { get; private set; }


            public Color Diffuse { get; private set; }

            public Color Specular { get; private set; }


            public float Ns { get; private set; }
            public float Ni { get; private set; }
            public float d { get; private set; } = 1;
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
                    Diffuse = new Color(new float[] { 1, 1, 1 });
                }
                MaterialGroup mat = new PhongMaterial(Name, null);
                var children = mat.Children;
                if (Diffuse != null)
                {
                    if (Ambient == null)
                    {
                        Ambient = new Color(new float[] { 1, 1, 1 });
                    }
                    var diffuse = new DiffuseMaterial(Diffuse, Ambient, d);
                    //diffuse.Texture = Kd;
                    children.Add(diffuse);
                }
                if (Emissive == null)
                {
                    Emissive = new Color(new float[] { 1, 1, 1 });
                }
                if (Emissive != null)
                {
                    var emissive = new EmissiveMaterial(Emissive, Ka);
                    children.Add(emissive);
                }
                if (Specular != null)
                {
                    var specular = new SpecularMaterial(Specular, Ns);
                    children.Add(specular);
                }
                Dictionary<string, Effect> dn = null;
                effect = new Effect(dn, Name, mat, Kd);
            }


            private MtlWrapper(string str, int start, List<string> lines, 
                Dictionary<string, Effect> effects, string directory) : this(directory)

            {
                try
                {
                    Name = str;
                    string newName = "";
                    var i = start;
                    var list = new List<string>();
                    for (; i < lines.Count; i++)
                    {
                        var line = lines[i];
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
                    if (list.Count == 0)
                    {
                        return;
                    }

                    Finalize(list, Directory);
                    Create();
                    var mat = Effect;
                    if (mat != null)
                    {
                        effects[Name] = Effect;
                    }

                    if (i + 1 < lines.Count)
                    {
                        new MtlWrapper(newName, i + 1, lines, effects, directory);
                    }
                }
                catch (Exception e)
                {
                    e.HandleException("MTL WRAPPER");
                }
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
                        case "Ke":
                            //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                            Emissive = new Color(value);
                            break;

                        // the ambient texture map
                        case "map_Ka":
                            Ka = new Image(value, directory, "_");
                            break;
                        // the diffuse texture map 
                        case "map_Kd":
                            Kd = new Image(value, directory, "_");
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

        void CreateMaterials(string file, out Effect def)
        {
            
            def = null;
            mtlstr = file;
            if (File.Exists(file))
            {
                mtlfile = file;
            }
            else
            {
                mtlfile = Path.Combine(Directory, file);
            }
            using var stream = File.OpenRead(mtlfile);
            var mt = FromStream(stream,  out def);
            Default = def;
            foreach (var mat in mt)
            {
                var n = mat.Key;
                var v = mat.Value;
                if (n == "_default_" | n == "Default")
                {
                    Default = v;
                }
                else
                {
                    EffectsPrivate[n] = v;
                }
            }

        }

        protected override Dictionary<string, Effect> Effects
        {
            get
            {
                var eff = EffectsPrivate;
                if (Default == null)
                {
                    return eff;
                }
                Dictionary<string, Effect> e = new Dictionary<string, Effect>(eff);
                e["Default"] = Default;
                return e;
            }
        }

        Dictionary<string, Effect> FromStream(Stream stream, out Effect eff)
        {
            var mtl = new MtlWrapper(creator.Directory);
            var lines = new List<string>();
            using var reader = new StreamReader(stream);
            do
            {
                var l = reader.ReadLine();
                if (l == null)
                {
                    break;
                }
                lines.Add(l);

            }
            while (!reader.EndOfStream);
            var mt = mtl.Create(lines, 0, out eff);
            if (mt.ContainsKey("Default"))
            {
                Default = mt["Default"];
            }
            return mt;
        }
        void CreateMaterials()
        {
            try
            {
                Effect def = null;
                Dictionary<string, Effect> mt = null;
                if (MaterialBytes != null)
                {
                    using var stream = new MemoryStream(MaterialBytes);
                    mt = FromStream(stream, out def);
                }
                else
                {
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("mtllib "))
                        {
                            Effect deff = null;
                            var file = line.Substring("mtllib ".Length).Trim();
                            CreateMaterials(file, out deff);
                        }
                    }
                    if (EffectsPrivate.Count == 0 & Default == null)
                    {
                        var l = (from line in lines
                                 where s.ToString(line, "usemtl") != null
                                 select
                                 CreateEffect(line)).ToArray();
                        //          var l = lines.Select(str => s.ToString(str)); ;
                    }
                    if (EffectsPrivate.ContainsKey("_default_"))
                    {
                        Default = EffectsPrivate["_default_"];
                    }
                    if (Default == null & EffectList.Count == 0)
                    {
                        string file = null;
                        if (StaticExtensionAbstract3DConverters.CheckFile == CheckFile.Check)
                        {
                            var files =  System.IO.Directory.GetFiles(creator.Directory);
                            foreach (var f in files)
                            {
                                if (Path.GetExtension(f) == ".mtl")
                                {
                                    CreateMaterials(f, out def);
                                    break;
                                }
                            }
                            if (EffectsPrivate.Count == 0 & Default == null)
                            {
                                if (files.Length == 2)
                                {
                                    foreach (var f in files)
                                    {
                                        if (Path.GetFileName(f) != Path.GetFileName(creator.Filename))
                                        {
                                            file = f;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (file != null)
                            {
                                if (StaticExtensionAbstract3DConverters.DetectImage(file))
                                {
                                    Default = CreateEffectFromImage(file);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.HandleException("Create materials OBJ");
            }

        }

        Effect CreateFromFile(string filename)
        {
            var image = new Image(filename, creator.Directory);
            var mat = new MaterialGroup("Default");
            var color = new Color(new float[] {  1f, 1f, 1f });
            var dm = new DiffuseMaterial(color, null, 1);
            mat.Children.Add(dm);
            var effect = new Effect(this, "Default", mat, image);
            return effect;
        }


        string[] ext = [".png", ".jpg"];

        string Exists(string file)
        {
            var d = creator.Directory;
            var filename = file.Replace("_", " ");
            filename = Path.Combine(d, filename);
            if (s.FileExists(filename))
            {
                return filename;
            }
            foreach (var e in ext)
            {
                var fn = filename + e;
                if (s.FileExists(fn))
                {
                    return fn;
                }
            }
            var f = file.Replace("_", " ");
            f = Path.Combine(d, f);
            if (s.FileExists(f))
            {
                return f;
            }
            foreach (var e in ext)
            {
                var fn = f + e;
                if (s.FileExists(fn))
                {
                    return fn;
                }
            }
            return null;
        }


        Effect CreateEffectFromImage(string f)
        {
            var image = new Image(f, creator.Directory);
            var ff = new float[] { 1f, 1f, 1f, 1f };
            var d = new DiffuseMaterial(new Color(ff), new Color(ff), 1f);
            var mat = new MaterialGroup(f);
            mat.Children.Add(d);
            return new Effect(this, f, mat, image);
        }


        Effect CreateEffect(string f)
        {
            var fd = s.ToString(f, "usemtl");
            var file = Exists(fd);
            Image image = null;
            var inm = "";
            if (file != null)
            {
                inm = Path.GetFileName(file);
                image = new Image(inm, creator.Directory);
            }
            var ff = new float[] { 1f, 1f, 1f, 1f };
            var d = new DiffuseMaterial(new Color(ff), new Color(ff), 1f);
            var mat = new MaterialGroup(f);
            mat.Children.Add(d);
            return new Effect(EffectsPrivate, inm, mat, image);
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
                    mtlfile = Path.Combine(Directory, file);

                    var mtl = new MtlWrapper(creator.Directory);
                    Effect def = null;
                    var mt = mtl.Create(file, Directory, out def);
                    Default = def;
                    foreach (var mat in mt)
                    {
                        if (mat.Key == "_default_")
                        {
                            if (Default == null)
                            {
                                Default = mat.Value;
                            }
                            continue;
                        }
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

        void ISeparateTextures.Separate()
        {
            Separate = true;
        }
    }
}
