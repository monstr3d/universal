using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Meshes
{
    public class AbstractMesh
    {
        protected AbstractMesh parent;

        protected Service s = new();

        protected IMeshCreator creator;


        public float[] TransformationMatrix { get; protected set; }

        public AbstractMesh Parent
        {
            get => parent;
            set
            {
                if (value == null)
                {
                    if (parent != null)
                    {
                        parent.Children.Remove(this);
                    }
                    parent = null;
                    return;
                }
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



        protected AbstractMesh(string name, IMeshCreator creator)
        {
            this.creator = creator;
            Name = name;
        }


        public AbstractMesh(string name, IMeshCreator creator, string material, List<float[]> vertices, List<float[]> normals,
           List<float[]> textures, List<int[][]> indexes) : this(name, creator)
        {
            MaterialString = material;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }

        public AbstractMesh(string name, IMeshCreator creator = null, Material material = null, 
            List<float[]> vertices = null, List<float[]> normals = null,
       List<float[]> textures = null, List<int[][]> indexes = null) : this(name, creator)
        {
            Material = material;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
        }


        public virtual object GetMaterial(IMaterialCreator creator)
        {
            if (Material != null)
            {
                return creator.Create(Material);
            }
            var mt = this.creator.Materials;
            if (MaterialString != null)
            {
                if (mt.ContainsKey(MaterialString))
                {
                    var mm = mt[MaterialString];
                    return creator.Create(mm);
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
