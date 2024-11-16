using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collada.Wpf
{
    public class AbstractMesh
    {

        public List<float[]> Vertices { get; private set; }

        public List<float[]> Normals { get; private set; }

        public List<float[]> Textures { get; private set; }

        public List<int[][]> Indexes { get; private set; }

        public string Name { get; private set; }

        public string Material { get; private set; }

        public AbstractMesh(string name, string material, List<float[]> vertixes, List<float[]> normals, List<float[]> textures, List<int[][]> indexes)
        {
            Name = name;
            Material = material;
            Vertices = vertixes;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }

    }
}
