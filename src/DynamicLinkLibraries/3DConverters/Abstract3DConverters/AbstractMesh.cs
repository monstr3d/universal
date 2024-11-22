namespace Abstract3DConverters
{
    public class AbstractMesh
    {
        protected AbstractMesh parent;

        public AbstractMesh Parent
        {
            get => parent;
            set
            {
                parent = value;
                if (!parent.Children.Contains(this))
                {
                    parent.Children.Add(this);
                }
            }
        }

        public List<AbstractMesh> Children { get; } = new ();

        public List<float[]> Vertices { get; protected set; }

        public List<float[]> Normals { get; protected set; }

        public List<float[]> Textures { get; protected set; }

        public List<int[][]> Indexes { get; protected set; }

        public int Count { get; private set; }

        public string Name { get; protected set; }

        public string Material { get; protected set; }

        public object Value { get; private set; } = null;

        public  AbstractMesh(string name, int count, object value)
        {
            Name = name;
            Count = count;
            Value = value;
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
