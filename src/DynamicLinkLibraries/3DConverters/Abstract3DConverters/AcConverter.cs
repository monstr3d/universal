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
            var meshes = Create(lines).ToArray();

            return new Tuple<object, List<AbstractMesh>>(null, new List<AbstractMesh>());
        }


        public IEnumerable<AbstractMesh> Create(List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var l = lines[i];
                if (l.StartsWith("OBJECT"))
                {
                    int kids = 0;
                    string name = "";
                    if (l == "OBJECT world")
                    {
                       kids = l[i + 1].Su 
                    }
                    var name = lines[i +  1].Substring("name ".Length);
                }
            }
            yield return null;
        }
    }
}
