using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;
using ErrorHandler;

namespace Abstract3DConverters.Meshes
{
    /// <summary>
    /// Abstract mesh
    /// </summary>
    public class AbstractMesh : IParent
    {
        #region Fields

        /// <summary>
        /// Parent
        /// </summary>
        protected AbstractMesh parent;

        /// <summary>
        /// Service
        /// </summary>
        protected Service s = new();

        /// <summary>
        /// Creator
        /// </summary>
        protected IMeshCreator creator;

        /// <summary>
        /// The "triangles created@ sign
        /// </summary>
        protected bool trianglesCreated = false;
    
        Material mat;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        public AbstractMesh(string name, IMeshCreator creator)
        {
            if (creator == null)
            {
                throw new Exception();
            }
            this.creator = creator;
            Name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="creator">Mesh creator</param>
        /// <param name="material">Material</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="creator">Mesh creator</param>
        /// <param name="material">Material</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="creator">Mesh creator</param>
        /// <param name="material">Material</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
        /// <param name="matrix">The transformation matrix</param>
        public AbstractMesh(string name, IMeshCreator creator, Material material = null,
         List<float[]> vertices = null, List<float[]> textures = null, List<float[]> normals = null,
     List<int[][]> indexes = null, float[] matrix = null) :
            this(name, creator, material, vertices, normals,
        textures, indexes)
        {
            TransformationMatrix = matrix;
        }

        #endregion


        #region IParent implementation

        /// <summary>
        /// Parent
        /// </summary>
        IParent IParent.Parent
        {
            get => parent;
            set => Parent = value as AbstractMesh;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Transformation matrix
        /// </summary>
        public float[] TransformationMatrix
        {
            get;
            protected set;
        }

        /// <summary>
        /// Parent
        /// </summary>
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

        /// <summary>
        /// Points
        /// </summary>
        public List<Point> Points
        {
            get;
            protected set;
        }

        /// <summary>
        /// Children
        /// </summary>
        public List<AbstractMesh> Children { get; } = new();

        /// <summary>
        /// Vertices
        /// </summary>
        public List<float[]> Vertices { get; protected set; }

        /// <summary>
        /// Normals
        /// </summary>
        public List<float[]> Normals { get; protected set; }

        /// <summary>
        /// Textures
        /// </summary>
        public List<float[]> Textures { get; protected set; }
        
        /// <summary>
        /// Indexes
        /// </summary>
        public List<int[][]> Indexes { get; protected set; }
        

        /// <summary>
        /// Indexes of triangles;
        /// </summary>
        public List<Polygon> Polygons { get; protected set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// String representation of material
        /// </summary>
        public string MaterialString { get; protected set; }

        /// <summary>
        /// Material
        /// </summary>
        public Material Material
        {
            get => mat;
            protected set
            {
                mat = value;
            }
        }
        
        /// <summary>
        /// Gets material
        /// </summary>
        /// <param name="creator">The creator of material</param>
        /// <returns>The material</returns>
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

        /// <summary>
        /// Creates triangles
        /// </summary>
        public virtual void CreateTriangles()
        {
        
        }

        #endregion
    }
}
