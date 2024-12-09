using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class AcConverter : AbstractMeshCreator
    {
        List<Material> Materials { get; } = new ();

        Service s = new();

        protected  string[] colstr = ["rgb", "amb", "emis", "spec", "shi", "trans"];

        public AcConverter() : base(".ac")
        {
        }

        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                do
                {
                    lines.Add(reader.ReadLine());
                }
                while (!reader.EndOfStream);
            }
            CreateMaterials(lines);
            var meshes = Create(lines).ToArray();
            return new Tuple<object, List<AbstractMesh>>(null, new List<AbstractMesh>(meshes));
        }



        void CreateMaterials(List<string> lines)
        {
            foreach (var line in lines)
            {
                var mat  = s.ToString(line, "MATERIAL ");
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
                    Materials.Add(group);
                var d = new Dictionary<int, string>();
                for (int i = 0; i < l.Count; i++) 
                {
                    if (colstr.Contains(l[i]))
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
                    string  key = d[k];
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
        }

        private Color GetColor(List<string> l, int b, int e)
        {
            var str = "";
            for (var i = b; i < e; i++)
            {
                str += l[i] + " ";
            }
            return new Color(str.Trim());

        }


        public IEnumerable<AbstractMesh> Create(List<string> lines,  int start = 0, int current = -1)
        {
            if (current == 0)
            {
                yield break;
            }
            for (var i = start; i < lines.Count; i++)
            {
                var line = lines[i];
                string name = start == 0 ? "": null;
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
                            var am = new AbstractMeshAC(name, count, nl, Materials, directory);
                            name = null;
                            nl = new();
                            i = j;
                            yield return am;
                            counter++;
                            if (counter == current)
                            {
                                yield break;
                            }
                            var enu = Create(lines, j, count).ToArray();
                            foreach (var a in enu)
                            {
                                a.Parent = am;
                            }
                        }

                    }
                }
            }
        }


    }
}
