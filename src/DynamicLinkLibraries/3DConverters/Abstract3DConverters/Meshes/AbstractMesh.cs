using System.Net.Http.Headers;
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

        protected float[,] relative;

        protected float[,] absolute;

        protected List<Point> absolutePoints;

        Func<List<Point>> GetAbsolute;

        Func<float[,]> GetRelativeMatrix;

        Func<float[,]> GetAbsoluteMatrix;

        protected List<Polygon> absolutePolygons;

        Func<List<Polygon>> GetAbsolutePolygons;




        Material mat;

        #endregion


        #region Ctor

        private AbstractMesh()
        {
            GetAbsolute = GetStart;
            GetRelativeMatrix = GetRelativeMatrixStart;
            GetAbsoluteMatrix = GetAbsoluteMatrixStart;
            GetAbsolutePolygons = GetPolygonStart;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        public AbstractMesh(string name, IMeshCreator creator) : this()
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

        /// <summary>
        /// Absolute points
        /// </summary>
        public List<Point> AbsolutePoints => GetAbsolute();

        /// <summary>
        /// Absolute polygons
        /// </summary>
        public List<Polygon> AbsolutePolygons => GetAbsolutePolygons();

        /// <summary>
        /// Relative matrix
        /// </summary>
        public float[,] RelativeMatrix => GetRelativeMatrix();

        /// <summary>
        /// Absolute matrix
        /// </summary>
        public float[,] AbsoluteMatrix => GetAbsoluteMatrix();

        /// <summary>
        /// Zero
        /// </summary>
        protected void Zero()
        {
            if (Polygons == null)
            {
                Points = null;
                return;
            }
            if (Polygons.Count == 0)
            {
                Points = null;
                Polygons = null;
                return;
            }
            if (Points == null)
            {
                Polygons = null;
                return;
            }
            if (Polygons.Count == 0)
            {
                Points = null;
                Polygons = null;
                return;
            }
        }

        #endregion

        #region Private

        void CalculateAbsolutePolygons()
        {
            if (Polygons != null)
            {
                if (Polygons.Count > 0)
                {
                    absolutePolygons = new();
                    var m = AbsoluteMatrix;
                    foreach (var polygon in Polygons)
                    {
                        var l = new List<PointTexture>();
                        foreach (var point in polygon.Points)
                        {
                            l.Add(s.Product(m, point));
                        }
                        absolutePolygons.Add(new Polygon(l.ToArray(), polygon.Material));
                    }

                }
            }

        }

        void CalculateAbsolute()
        {
            if (Points != null)
            {
                if (Points.Count > 0)
                {
                    var m = AbsoluteMatrix;
                    absolutePoints = new();
                    foreach (var p in Points)
                    {
                        absolutePoints.Add(s.Product(m, p));
                    }    
                }
            }
        }


        List<Polygon> GetPolygonStart()
        {
            CalculateAbsolutePolygons();
            GetAbsolutePolygons = GetPolygonFinish;
            return absolutePolygons;

        }

        List<Polygon> GetPolygonFinish()
        {
            return absolutePolygons;
        }

        List<Point> GetStart()
        {
            CalculateAbsolute();
            GetAbsolute = GetFinish;
            return absolutePoints;

        }
        
        List<Point> GetFinish()
        {
            return absolutePoints;
        }

        float[,] GetRelativeMatrixStart()
        {
            var tr = TransformationMatrix;
            if (tr == null)
            {
                relative = new float[,] {
                    { 1f, 0f, 0f, 0f },  { 0f, 1f, 0f, 0f },
                  { 0f, 0f, 1f, 0f },  { 0f, 0f, 0f, 1f }
                };
            }
            else
            {
                relative = new float[,] {
                    { tr[0], tr[1],tr[2], tr[3] },  { tr[4], tr[5],tr[6], tr[7] },
                  { tr[8], tr[9],tr[10], tr[11] },  { tr[12], tr[13],tr[14], tr[15] }
                };
            }
            GetRelativeMatrix = GetRelativeMatrixFinish;
            return relative;
        }

        float[,] GetRelativeMatrixFinish()
        {
             return relative;
        }

        float[,] GetAbsoluteMatrixStart()
        {
            if (parent == null)
            {
                absolute = RelativeMatrix;
            }
            else
            {
                absolute = s.MatrixProduct(parent.AbsoluteMatrix, RelativeMatrix);
            }
            GetAbsoluteMatrix = GetAbsoluteMatrixFinish;
            return absolute;
        }

        float[,] GetAbsoluteMatrixFinish()
        {
            return absolute;
        }


        #endregion
    }
}
