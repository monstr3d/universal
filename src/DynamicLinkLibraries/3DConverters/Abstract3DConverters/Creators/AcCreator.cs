﻿using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using NamedTree;



namespace Abstract3DConverters.Creators
{
   
    [Attributes.Extension([".ac", ".ac3d"])]
    public class AcCreator : LinesMeshCreator
    {
        #region Fields

        List<Material> MaterialsPP { get; } = new();

        Service s = new();

        internal static   string[] Colstr = ["rgb", "amb", "emis", "spec", "shi", "trans"];


        internal int Position
        {
            get;
            set;
        } = 0;


        private Dictionary<string, MaterialGroup> matGroup = new();

        private List<IMesh> meshes;

        #endregion

        #region Cror

        public AcCreator(string filename, string directory, params object[] objects) : base(filename, directory, objects)
        {
            try
            {
                meshes = Create(null, lines).ToList();
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("AcCreator constructor");
            }
        }

        #endregion

        #region AbstractMeshCreator Members

        protected override IEnumerable<IMesh> Meshes => meshes;
      
     
        #endregion

        internal Effect GetEffect(int i, Image image)
        {
            try
            {
                var mn = GetMaterialName(i);
                if (image != null)
                {
                    mn += "-" + image.Name;
                }
                if (Effects.ContainsKey(mn))
                {
                    return Effects[mn];
                }
                return new Effect(this, mn, MaterialsPP[i], image);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("GetEffect AC");
            }
            return null;
        }

        protected override void CreateAdditional(object additional)
        {

        }


        internal int GertMaterialNumber(Effect effect)
        {
            return MaterialsPP.IndexOf(effect.Material);
        }


       


        internal string GetMaterialName(int k)
        {
            return "Material_" + k;

        }

        void CreateMaterials(List<string> lines)
        {
            foreach (var line in lines)
            {
                var txt = s.ToString(line, "texture ");
                
                if (txt != null)
                {
                    if (!Images.ContainsKey(txt))
                    {
                        var im = new Image(txt, Directory);
                        if (im.Name != null)
                        {
                            Images[txt] = im;
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
                var group = new PhongMaterial(l[0], null);
                MaterialsPP.Add(group);
                Materials[l[0]] = group;
                var d = new Dictionary<int, string>();
                for (int i = 0; i < l.Count; i++)
                {
                    if (Colstr.Contains(l[i]))
                    {
                        d[i] = l[i];
                    }
                }
                var arr = d.Keys.ToArray();
                DiffuseMaterial diff = null;
                EmissiveMaterial emi = null;
                SpecularMaterial spe = null;

                IChildren<SimpleMaterial> children = group;
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
                            diff = new DiffuseMaterial(diffcolor, ambcolor, tr);
                            break;
                        default: break;
                    }

                }
                children.AddChild(diff);
                children.AddChild(emi);
                children.AddChild(spe);
            }
            Material mt = null;
            string imstr = null;
            Image image = null;
            foreach (var line in lines)
            {
                var st = s.ToString(line, "texture ");
                if (st != null)
                {
                    imstr = s.Trim(st);
                    if (Images.ContainsKey(imstr))
                    {
                        image = Images[imstr];
                    }
                }
                else
                {

                }
                var st1 = s.ToString(line, "mat ");
                if (st1 != null)
                {
                    var k = s.ToReal<int>(st1);
                    if (k < 0)
                    {

                    }
                    else
                    {
                        mt = MaterialsPP[k];
                        var mat = mt;
                        var name = GetMaterialName(k);
                        Effect effect = null;
                        if (image != null)
                        {
                            name += "-" + image.Name;
                        }
                        else
                        {
                            effect = new Effect(this, name, mat);
                        }
                        if (Effects.ContainsKey(name))
                        {
                            effect = Effects[name];
                        }
                        else
                        {

                        }
                    }
                 }
            }
        }


        public IEnumerable<IMesh> Create(IMesh parent, List<string> lines, int start = 0, int current = -1)
        {
                for (var i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    if (line.StartsWith("OBJECT"))
                    {
                        Position = i;
                        if (line.Equals("OBJECT world"))
                        {
                            continue;
                        }
                        do
                        {
                            yield return new AbstractMeshAC(null, MaterialsPP, lines, this);
                        }
                        while (Position <= lines.Count - 1);
                        yield break;
                    }
                }
                yield break;
                //new AbstractMeshAC(parent, name, this, count, lines, MaterialsP, directory);


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
                                var amm = new AbstractMesh(null, null, null);
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
