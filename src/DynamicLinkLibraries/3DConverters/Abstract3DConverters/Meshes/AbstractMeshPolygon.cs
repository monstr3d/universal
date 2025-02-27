using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;


namespace Abstract3DConverters.Meshes
{

    /// <summary>
    /// Mesh wih polygon
    /// </summary>
    public  class AbstractMeshPolygon : AbstractMesh
    {
  
        #region Fields

        /// <summary>
        /// Splitter
        /// </summary>
        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="parent">Parent</param>
        /// <param name="matrix">Transformation matrix</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix,  IMeshCreator creator) :
            base(name, creator)
        {
            TransformationMatrix = matrix;
            if (parent != null)
            {
                Parent = parent;
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="parent">Parent</param>
        /// <param name="matrix">Transformation matrix</param>
        /// <param name="effect">The effect</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, string effect, IMeshCreator creator) :
            this(name, parent, matrix, creator)
        {
            EffectString = effect;
        }


        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, Effect effect, List<Polygon> polygons, IMeshCreator creator) :
               this(name, parent, null, creator)
        {
            Effect = effect;
            foreach (var p in polygons)
            {
                //Polygons.Add(p);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="parent">Parent</param>
        /// <param name="matrix">Transformation matrix</param>
        /// <param name="effect">The material</param>
        /// <param name="polygons">Polygons</param>
        /// <param name="vertices">vertices</param>
        /// <param name="normals">Normals</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, Effect effect, 
            List<Polygon> polygons, List<float[]> vertices, List<float[]> normals, IMeshCreator creator) :
            this(name, parent, matrix, effect, polygons, creator)
        {
            Vertices = vertices;
            Normals = normals;
        }

        #endregion

        #region Members

        /// <summary>
        /// Creates triangles
        /// </summary>
        public override void CreateTriangles()
        {
            CreateFromPolygons();
        }

        /// <summary>
        /// Creates from polygons
        /// </summary>
        protected virtual void CreateFromPolygons()
        {

            if (Polygons == null | trianglesCreated | Points == null)
            {
                return;
            }
            if (Polygons.Count == 0 | Points.Count == 0)
            {
                return;
            }
            var l = new List<Polygon>();
            foreach (var item in Polygons)
            {
                var idx = item.Points;
                if (idx.Length <= 3)
                {
                    if (idx.Length == 2)
                    {

                    }
                    l.Add(item);
                    continue;
                }
                var pp = splitter[item];
                if (pp.Length == 0)
                {
                    pp = GetEmpty(item);
                }
                foreach (var p in pp)
                {
                    l.Add(p);
                }
            }
            Polygons.Clear();
            Polygons = null;
            Polygons = l;
        }

        Polygon[] GetEmpty(Polygon polygon)
        {
            var p = new List<Polygon>();
            var pt = polygon.Points;
            for (var i = 1; i < pt.Length - 1; i++)
            {
                var l = new List<PointTexture>();
                l.Add(pt[0]);
                l.Add(pt[i]);
                l.Add(pt[i + 1]);
                p.Add(new Polygon(this, l.ToArray(), polygon.Effect));
            }
            if (pt.Length < 3)
            {
                var l = new List<PointTexture>();
                for (var i = 0; i < pt.Length; i++)
                {
                    for (var j = 0; i < 3; j++)
                    {
                        l.Add(pt[i]);
                    }
                    p.Add(new Polygon(this, l.ToArray(), polygon.Effect));
                }

            }
            return p.ToArray();
        }

        #endregion
    }
}
