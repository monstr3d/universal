using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class AcConverter : AbstractMeshCreator
    {

        public Material DefaultMaterial { get;  private set; }

        Service s = new();

        public AcConverter(Material defaultMaterial) : base("ac")
        {
            DefaultMaterial = defaultMaterial;
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
            var end = new int[] { 0 };
            var meshes = Create(lines).ToArray();
            return new Tuple<object, List<AbstractMesh>>(null, new List<AbstractMesh>(meshes));
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
                            var am = new AbstractMeshAC(name, count, nl, DefaultMaterial, directory);
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


   /*     public IEnumerable<AbstractMesh> Create(List<string> lines)
        {
            Queue<AbstractMesh> queue = new Queue<AbstractMesh>();
            for (int i = 0; i < lines.Count; i++)
            {
                var l = lines[i];
                if (l.StartsWith("OBJECT"))
                {
                    for (int j = 1; j < l.Length; j++)
                    {
                        
                    }
                }
                yield return null;
            }
        }*/
    }
}
