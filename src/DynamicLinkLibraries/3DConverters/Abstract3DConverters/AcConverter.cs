using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Abstract3DConverters
{
    public class AcConverter : AbstractMeshCreator
    {

        public AcConverter() : base("ac")
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
            var end = new int[] { 0 };
            var meshes = Create(lines, end).ToArray();

            return new Tuple<object, List<AbstractMesh>>(null, new List<AbstractMesh>());
        }

        public IEnumerable<AbstractMesh> Create(List<string> lines, int[] end, int start = 0, int current = -1)
        {
            if (current == 0)
            {
                yield break;
            }
            for (var i = start; i < lines.Count; i++)
            {
                var line = lines[i];
                var name = "";
                var counter = 0;
                if (line.StartsWith("OBJECT"))
                {
                    var nl = new List<string>();
                    nl.Add(line);
                    for(var j = i; j < lines.Count; j++)
                    {
                        var l = lines[j];
                        nl.Add(l);
                        if (l.StartsWith("name "))
                        {
                            name = l.Substring("name ".Length).Replace("\"", "");
                        }
                        if (l.StartsWith("kids "))
                        {
                            var count = int.Parse(l.Substring("kids ".Length));
                            var am = new AbstractMesh(name, count, nl);
                            end[0] = j;                            
                            yield return am;
                            counter++;
                            if (counter == current)
                            {
                                yield break;
                            }
                            var enu = Create(lines, end, j, count).ToArray();
                            foreach (var a in enu)
                            {
                                a.Parent = am;
                            }
                        }

                    }
                    i = end[0];
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
