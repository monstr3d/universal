namespace Abstract3DConverters
{
    public class AbstractMesh
    {
        public AbstractMesh Parent { get; private set; }

        public List<AbstractMesh> Children { get; } = new ();

        public List<float[]> Vertices { get; private set; }

        public List<float[]> Normals { get; private set; }

        public List<float[]> Textures { get; private set; }

        public List<int[][]> Indexes { get; private set; }

        public string Name { get; private set; }

        public string Material { get; private set; }

    
        public AbstractMesh(string name, string material, List<float[]> vertices, List<float[]> normals, List<float[]> textures, List<int[][]> indexes)
        {
            Name = name;
            Material = material;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }

    }
}
