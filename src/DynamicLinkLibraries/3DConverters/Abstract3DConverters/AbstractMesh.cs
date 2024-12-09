namespace Abstract3DConverters
{
    public class AbstractMesh
    {
        protected AbstractMesh parent;

        protected Service s = new();

  
        public float[] TransformationMatrix { get; protected set; }

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

        public List<AbstractMesh> Children { get; } = new();

        public List<float[]> Vertices { get; protected set; }

        public List<float[]> Normals { get; protected set; }

        public List<float[]> Textures { get; protected set; }

        public List<int[][]> Indexes { get; protected set; }

        public int Count { get; private set; }

        public string Name { get; protected set; }

        public string MaterialString { get; protected set; }

        Material mat;

        public Material Material
        {
            get => mat;
            protected set
            {
                mat = value;
            }
        }



        protected AbstractMesh(string name)
        {
            Name = name;
        }


        public AbstractMesh(string name, string material, List<float[]> vertices, List<float[]> normals,
            List<float[]> textures, List<int[][]> indexes) : this(name)
        {
            MaterialString = material;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }

        public virtual object GetMaterial(Dictionary<string, object> map, IMaterialCreator creator)
        {
            if (Material != null)
            {
                return creator.Create(Material);
            }
            if (Material == null)
            {
                if (MaterialString != null)
                {
                    if (map.ContainsKey(MaterialString))
                    {
                        return map[MaterialString];
                    }
                }
            }
            return null;
        }

  
        protected void SetImage(Material mat, Image img)
        {
            if (mat is DiffuseMaterial diffuse)
            {
                diffuse.Image = img;
            }
            if (mat is MaterialGroup group)
            {
                foreach (var m in group.Children)
                {
                    SetImage(m, img);
                }
            }
        }

    }
}
