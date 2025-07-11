﻿using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

using ErrorHandler;
using NamedTree;



namespace Abstract3DConverters.Meshes
{

    /// <summary>
    /// Abstract mesh
    /// </summary>
    public class AbstractMesh :  IMesh
    {
 
        #region Ctor

        private AbstractMesh()
        {
            mesh = this;
            //GetAbsolute = GetStart;
            GetRelativeMatrix = GetRelativeMatrixStart;
            GetAbsoluteMatrix = GetAbsoluteMatrixStart;
         //   GetAbsolutePolygons = GetPolygonStart;
         }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        public AbstractMesh(IMesh parent, string name, IMeshCreator creator) : this()
        {
            if (parent != null)
            {
                Parent = parent;
            }
            if (creator == null)
            {
                throw new OwnException("Abstract creator null");
            }
            Creator = creator;
            Name = name;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="creator">Mesh creator</param>
        /// <param name="effect">Effect</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
        public AbstractMesh(IMesh parent, string name, IMeshCreator creator, string effect, List<float[]> vertices, List<float[]> normals,
           List<float[]> textures, List<int[][]> indexes) : this(parent, name, creator)
        {
            EffectString = effect;
            Vertices = vertices;
            Normals = normals;
            Textures = textures;
            Indexes = indexes;
            var mt = creator.Effects;
            if (mt.ContainsKey(EffectString))
            {
                Effect = mt[EffectString];
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="creator">Mesh creator</param>
        /// <param name="effect">Effect</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
        public AbstractMesh(IMesh parent, string name, IMeshCreator creator, Effect effect = null,
            List<float[]> vertices = null, List<float[]> textures = null, List<float[]> normals = null,
       List<int[][]> indexes = null) : this(parent, name, creator)
        {
            Effect = effect;
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
        /// <param name="effect">Effect</param>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="normals">Normals</param>
        /// <param name="indexes">Indexes</param>
        /// <param name="matrix">The transformation matrix</param>
        public AbstractMesh(IMesh parent,string name, IMeshCreator creator, Effect effect = null,
         List<float[]> vertices = null, List<float[]> textures = null, List<float[]> normals = null,
     List<int[][]> indexes = null, float[] matrix = null) :
            this(parent, name, creator, effect, vertices, normals,
        textures, indexes)
        {
            TransformationMatrix = matrix;
        }

        event Action<IMesh> INode<IMesh>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMesh> INode<IMesh>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region Fields

        protected IMesh parent;

        IMesh temp;

        /// <summary>
        /// Parent
        /// </summary>
        protected virtual INode<IMesh> Parent
        {
            get => parent;
            set
            {
                if (parent != null)
                {
                    return;
                }
                if (value == null)
                {
                    return;
                }
                if (temp != null)
                {
                    parent = temp;
                    return;
                }
                temp = value as IMesh;
                performer.AddChildNode(value, this, false);
            }
        }

        protected AbstractMesh ParentMesh => Parent as AbstractMesh;

      //  protected virtual IMesh ParentMesh => Parent;

        protected NamedTree.Performer performer = new NamedTree.Performer();
        /// <summary>
        /// Service
        /// </summary>
        protected Service s = new();


        /// <summary>
        /// The "triangles created@ sign
        /// </summary>
        protected bool trianglesCreated = false;

        protected float[,] relative;

        protected float[,] absolute;


        Func<float[,]> GetRelativeMatrix;

        Func<float[,]> GetAbsoluteMatrix;

        //   protected List<Polygon> absolutePolygons;

        Func<List<Polygon>> GetAbsolutePolygons;

        protected IMesh mesh;


        #endregion


        #region  INode<IMesh> Implementation
        INode<IMesh> INode<IMesh>.Parent { get => Parent; set => Parent = value; }
        IEnumerable<INode<IMesh>> INode<IMesh>.Nodes 
        { 
            get => Nodes; 
            set => throw new IllegalSetPropetryException("MESH SET CHILDREN PROHIBITED");
        }

        IMesh INode<IMesh>.Value => this;

        void INode<IMesh>.Add(INode<IMesh> node)
        {
            Nodes.Add(node as IMesh);
        }

        string INamed.Name {  get => Name; set => Name = value; }

        #endregion

   
        #region IMesh Implementation

        float[] IGeometry.TransformationMatrix => TransformationMatrix;


        List<float[]> IGeometry.Vertices => Vertices;

        List<float[]> IGeometry.Normals => Normals;

        List<float[]> IGeometry.Textures => Textures;

        Effect IMesh.Effect => Effect;

        List<int[][]> IMesh.Indexes => Indexes;
  
   
        List<float[]> IMesh.AbsoluteVertices => AbsoluteVertices;

     
      
        List<Polygon> IMesh.Polygons => Polygons;


        Effect IMesh.GetEffect(IMaterialCreator creator)
        {
            return GetEffectEffect(creator);
        }

        IMeshCreator IMesh.Creator => Creator;

      
        void IMesh.CalculateAbsolute()
        {
            CalculateAbsolute();
        }

        #endregion

        #region Properties

        protected virtual IMesh ProtectedParent
        {
            set
            {
                performer.AddChildNode(value, this);
            }
        }

        /// <summary>
        /// The "has polygons" sign
        /// </summary>
        protected bool HasPolygons
        {
            get
            {
                if (Polygons != null)
                {
                    return Polygons.Count > 0;
                }
                return false;
            }
        }

        /// <summary>
        /// Transformation matrix
        /// </summary>
        protected float[] TransformationMatrix
        {
            get;
            set;
        }

        /// <summary>
        /// Parent
        /// </summary>
/*        public AbstractMesh Parent
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
                if (!value.Children.Contains(this))
                {
                    parent = value;
                    value.Children.Add(this);
                }
            }
        }*/

        /// <summary>
        /// Children
        /// </summary>
        protected virtual List<IMesh> Nodes { get; } = new();

        /// <summary>
        /// Vertices
        /// </summary>
        protected List<float[]> Vertices { get;  set; }

        /// <summary>
        /// Absolute Verices
        /// </summary>
        public List<float[]> AbsoluteVertices { get; protected set; }


        /// <summary>
        /// Absolute Normals
        /// </summary>
        public List<float[]> AbsoluteNormals { get; protected set; }


        /// <summary>
        /// Normals
        /// </summary>
        protected List<float[]> Normals { get; set; }

        /// <summary>
        /// Textures
        /// </summary>
        protected List<float[]> Textures { get;  set; }
        
        /// <summary>
        /// Indexes
        /// </summary>
        protected List<int[][]> Indexes { get;  set; }
        

        /// <summary>
        /// Polygons
        /// </summary>
        protected List<Polygon> Polygons { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        protected virtual string Name { get;  set; }

        /// <summary>
        /// String representation of material
        /// </summary>
        public string EffectString { get; protected set; }

        /// <summary>
        /// Effect
        /// </summary>
        protected virtual Effect Effect
        {
            get;
            set;
        }

        public object  GetEffect(IMaterialCreator creator)
        {
            try
            {
                if (Effect != null)
                {
                    return creator.Create(Effect);
                }
                var mt = Creator.Effects;
                if (EffectString != null)
                {
                    if (mt.ContainsKey(EffectString))
                    {
                        var mm = mt[EffectString];
                        return creator.Create(mm);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;

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
                if (Effect != null)
                {
                    return creator.Create(Effect.Material);
                }
                var mt = Creator.Effects;
                if (EffectString != null)
                {
                    if (mt.ContainsKey(EffectString))
                    {
                        var mm = mt[EffectString];
                        return creator.Create(mm.Material);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }


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
                return;
            }
            if (Polygons.Count == 0)
            {
                Polygons = null;
                return;
            }
        }

        #endregion

        #region Private

        /*
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
                        absolutePolygons.Add(new Polygon(this, l.ToArray(), polygon.Effect));
                    }

                }
            }

        }
        */
        protected virtual void CalculateAbsolute()
        {
            try
            {
                if (!s.HasVertices(this))
                {
                    return;
                }
                var matrix = AbsoluteMatrix;
                AbsoluteVertices = new();
                foreach (var vertex in Vertices)
                {
                    var vt = s.ProductVertex(matrix, vertex);
                    AbsoluteVertices.Add(vt);
                }
                AbsoluteNormals = new();
                if (Polygons == null)
                {
                    return;
                }
                foreach (var polygon in Polygons)
                {
                    polygon.SetNormals();
                    foreach (var point in polygon.Points)
                    {
                        var f = s.ProductNormal(matrix, point.Normal);
                        AbsoluteNormals.Add(f);
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("CalculateAbsolute Mesh");
            }
        }


/*
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
*/


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
            if (ParentMesh == null)
            {
                absolute = RelativeMatrix;
            }
            else
            {
                absolute = s.MatrixProduct(ParentMesh.AbsoluteMatrix, RelativeMatrix);
            }
            GetAbsoluteMatrix = GetAbsoluteMatrixFinish;
            return absolute;
        }

        float[,] GetAbsoluteMatrixFinish()
        {
            return absolute;
        }


        #endregion

        #region Abstract and vitrual members

        protected virtual Effect GetEffectEffect(IMaterialCreator creator)
        {
            return null;
        }

        void INode<IMesh>.Remove(INode<IMesh> node)
        {
            throw new IllegalSetPropetryException("Remove of mesh is prohibited");
        }

        protected virtual IMeshCreator Creator { get; set; }
       

        #endregion


    }
}

