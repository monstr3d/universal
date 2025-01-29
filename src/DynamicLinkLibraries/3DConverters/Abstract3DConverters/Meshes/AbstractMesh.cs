using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using ErrorHandler;

namespace Abstract3DConverters.Meshes
{
    public class AbstractMesh : IParent
    {
        #region Fields

        protected AbstractMesh parent;

        protected Service s = new();

        protected IMeshCreator creator;

        protected bool trianlesCreared = false;
    
        Material mat;

        #endregion

        #region Properties

        public float[] TransformationMatrix
        {
            get;
            protected set;
        }


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


        public Material Material
        {
            get => mat;
            protected set
            {
                mat = value;
            }
        }

        IParent IParent.Parent
        {
            get => parent;
            set => Parent = value as AbstractMesh;
        }

        #endregion

        #region Ctor
        public AbstractMesh(string name, IMeshCreator creator)
        {
            if (creator == null)
            {
                throw new Exception();
            }
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
            var mt = creator.Materials;
            if (mt.ContainsKey(MaterialString))
            {
                Material = mt[MaterialString];
            }
        }

        public AbstractMesh(string name, IMeshCreator creator, Material material = null, 
            List<float[]> vertices = null, List<float[]> textures = null, List<float[]> normals = null,
       List<int[][]> indexes = null) : this(name, creator)
        {
            Material = material;
            Vertices = vertices;
            Textures = textures;
            Normals = normals;
            Indexes = indexes;
        }

        public AbstractMesh(string name, IMeshCreator creator, Material material = null,
         List<float[]> vertices = null, List<float[]> textures = null, List<float[]> normals = null,
     List<int[][]> indexes = null, float[] matrix = null) :
            this(name, creator, material, vertices, normals,
        textures, indexes)
        {
            TransformationMatrix = matrix;
        }

        #endregion


        public virtual object GetMaterial(IMaterialCreator creator)
        {
            try
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
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return null;
        }

        public virtual void CreateTriangles()
        {
            if (trianlesCreared)
            {
                return;
            }
            trianlesCreared = true;
            foreach (var t in Children)
            {
                t.CreateTriangles();
            }
        }
    }
}
