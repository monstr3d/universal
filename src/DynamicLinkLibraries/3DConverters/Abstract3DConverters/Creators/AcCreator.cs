using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Creators
{
    [Attributes.Extension([".ac", ".ac3d"])]
    public class AcCreator : LinesMeshCreator
    {
        List<Material> MaterialsP { get; } = new();

        Service s = new();

        internal static   string[] Colstr = ["rgb", "amb", "emis", "spec", "shi", "trans"];


        internal int Position
        {
            get;
            set;
        } = 0;


        internal int[] Shift { get; private set; } = [0, 0, 0];

        private Dictionary<string, MaterialGroup> matGroup = new();

        public AcCreator(string filename, byte[] bytes) : base(filename, bytes)
        {

        }

        #region AbstractMeshCreator Members

        protected override IEnumerable<AbstractMesh> Get()
        {
            int last = 0;
            return Create(null, lines).ToList();
        }
     
       

        public Tuple<object, List<AbstractMesh>> Create()
        {
            int last = 0;
            var l = Create(null, lines).ToList();
            return new Tuple<object, List<AbstractMesh>>(null, l);
        }


        #endregion

 
        void CreateMaterials(List<string> lines)
        {
            foreach (var line in lines)
            {
                var txt = s.ToString(line, "texture ");
                if (txt != null)
                {
                    if (!images.ContainsKey(txt))
                    {
                        var im = new Image(txt, directory);
                        if (im.Name != null)
                        {
                            images[txt] = im;
                        }
                        else
                        {

                        }
                    }
                }
                var mat = s.ToString(line, "MATERIAL ");
                if (mat == null)
                {
                    continue;
                }
                var ss = s.Split(mat);
                var l = new List<string>();
                foreach (var str in ss)
                {
                    if (str.Length > 0)
                    {
                        l.Add(s.Trim(str));
                    }
                }
                var group = new MaterialGroup(l[0]);
                MaterialsP.Add(group);
                materials[l[0]] = group;
                var d = new Dictionary<int, string>();
                for (int i = 0; i < l.Count; i++)
                {
                    if (Colstr.Contains(l[i]))
                        d[i] = l[i];
                }
                var arr = d.Keys.ToArray();
                DiffuseMaterial diff = null;
                EmissiveMaterial emi = null;
                SpecularMaterial spe = null;


                Color diffcolor = null;
                Color specolor = null;
                Color ambcolor = null;
                for (var j = 0; j < arr.Length; j++)
                {
                    var k = arr[j];
                    string key = d[k];
                    switch (key)
                    {
                        case "rgb":
                            diffcolor = new Color(l.GetRange(k + 1, arr[j + 1] - k - 1).ToArray());
                            break;

                        case "amb":
                            ambcolor = new Color(l.GetRange(k + 1, arr[j + 1] - k - 1).ToArray());
                            break;
                        case "emis":
                            var color = new Color(l.GetRange(k + 1, arr[j + 1] - k - 1).ToArray());
                            emi = new EmissiveMaterial(color);
                            break;
                        case "spec":
                            specolor = new Color(l.GetRange(k + 1, arr[j + 1] - k - 1).ToArray());
                            break;
                        case "shi":
                            var sp = s.ToReal<float>(l[k + 1]);
                            spe = new SpecularMaterial(specolor, sp);
                            break;
                        case "trans":
                            var tr = 1 - s.ToReal<float>(l[k + 1]);
                            diff = new DiffuseMaterial(diffcolor, ambcolor, null, tr);
                            break;
                        default: break;
                    }

                }
                group.Children.Add(diff);
                group.Children.Add(emi);
                group.Children.Add(spe);
            }
            Material mt = null;
            string imstr = null;
            Image image = null;
            foreach (var line in lines)
            {
                var st = s.ToString(line, "texture");
                if (st != null)
                {
                    imstr = s.Trim(st);
                    if (images.ContainsKey(imstr))
                    {
                        image = images[imstr];
                    }
                }
                var st1 = s.ToString(line, "mat");
                if (st1 != null)
                {
                    var k = s.ToReal<int>(st1);
                    mt = MaterialsP[k];
                    var mat = mt.SetImage(image);
                    var key = mat.Name;
                    if (!materials.ContainsKey(key))
                    {
                        materials[key] = mat;
                    }
                }
            }
        }


        public IEnumerable<AbstractMesh> Create(AbstractMesh parent, List<string> lines, int start = 0, int current = -1)
        {
            for (var i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if (line.StartsWith("OBJECT"))
                {
                    Position = i;
                    do
                    {
                        yield return new AbstractMeshAC(null, MaterialsP, lines, this);
                    }
                    while (Position <= lines.Count -1);
                }
                //new AbstractMeshAC(parent, name, this, count, lines, MaterialsP, directory);
            }
            
            if (Position >= lines.Count)
            {
                yield break;
            }

            if (current == 0)
            {
                yield break;
            }
            var st = Math.Max(start, Position);
            if (st >= lines.Count)
            {
                yield break;
            }
            string name = null;
             for (var i = st; i < lines.Count; i++)
            {
                var line = lines[i];
                var counter = 0;
                if (line.StartsWith("OBJECT"))
                {
                    var j = i + 1;
                    if (j >= lines.Count)
                    {
                        yield break;
                    }
                    var n = s.ToString(lines[j + 1], "name");
                    if (n != null)
                    {
                        name = n;
                        ++j;

                    }
                    else
                    {
                        name = "";
                    }
                    Position = j;
                    AbstractMeshAC am = null;// var am = new  AbstractMeshAC(null, name, this, 0, lines, MaterialsP, directory);
                    for (; j < lines.Count; j++)
                    {
                        var l = lines[j];
                        var cnt = s.ToReal<int>(l, "kids ");
                        if (cnt != null)
                        {
                            var count = cnt.Value;
                            if (Position >= lines.Count)
                            {
                                yield break;
                            }
                            Position = j;
                            //var am = new AbstractMeshAC(parent, name, this, count, lines, MaterialsP, directory);
                            name = null;
                            i = j + 1;
                            var amm = new AbstractMesh(null, null);
                            yield return amm; 
                            if (Position >= lines.Count)
                            {
                                yield break;
                            }
                           counter++;
                            if (counter == current)
                            {
                                yield break;
                            }

                            if (count == 0)
                            {
                                continue;
                            }
                            var enu = Create(am, lines, j, count).ToArray();
                            foreach (var a in enu)
                            {
                                a.Parent = am;
                            }
                        }
                    }
                }
            }
        }

        protected override void CreateFromLines()
        {
            CreateMaterials(lines);
        }
    }
}