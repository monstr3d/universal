using System.ComponentModel;
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


        internal int[] Shift { get; private set; } = [0, 0, 0];

        private Dictionary<string, MaterialGroup> matGroup = new();

        public AcCreator(string filename, Stream stream) : base(filename, stream)
        {

        }

        #region AbstractMeshCreator Members

        protected override IEnumerable<AbstractMesh> Get()
        {
            return Create(null, lines).ToList();
        }
     
       

        public Tuple<object, List<AbstractMesh>> Create()
        {
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
                        images[txt] = im;
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
                    image = images[imstr];
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
            if (current == 0)
            {
                yield break;
            }
            for (var i = start; i < lines.Count; i++)
            {
                var line = lines[i];
                string name = start == 0 ? "" : null;
                var counter = 0;
                if (line.StartsWith("OBJECT"))
                {
                    var nl = new List<string>();
                    for (var j = i; j < lines.Count; j++)
                    {
                        i = j;
                        var l = lines[j];
                        nl.Add(l);
                        if (name == null)
                        {
                            name = s.ToString(l, "name ");
                            continue;
                        }
                        var cnt = s.ToReal<int>(l, "kids ");
                        if (cnt != null)
                        {
                            var count = cnt.Value;
                            var am = new AbstractMeshAC(parent, name, this, count, nl, MaterialsP, directory);
                            name = null;
                            nl = new();
                            i = j + 1;
                            yield return am;
                            counter++;
                            if (counter == current)
                            {
                                yield break;
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