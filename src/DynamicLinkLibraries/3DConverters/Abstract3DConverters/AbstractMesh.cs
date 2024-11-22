namespace Abstract3DConverters
{
    public class AbstractMesh
    {
        public AbstractMesh Parent { get; private set; }

        public List<AbstractMesh> Children { get; } = new ();

        public List<float[]> Vertices { get; protected set; }

        public List<float[]> Normals { get; protected set; }

        public List<float[]> Textures { get; protected set; }

        public List<int[][]> Indexes { get; protected set; }

        public string Name { get; protected set; }

        public string Material { get; protected set; }

        protected AbstractMesh(string name)
        {

        }

    
        public AbstractMesh(string name, string material, List<float[]> vertices, List<float[]> normals, 
            List<float[]> textures, List<int[][]> indexes)
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
