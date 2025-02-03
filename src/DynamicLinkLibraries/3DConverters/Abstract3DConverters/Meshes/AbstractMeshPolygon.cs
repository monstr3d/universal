using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using System.Xml.Linq;

namespace Abstract3DConverters.Meshes
{
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
        /// <param name="material">The material</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, string material, IMeshCreator creator) :
            this(name, parent, matrix, creator)
        {
            MaterialString = material;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="parent">Parent</param>
        /// <param name="matrix">Transformation matrix</param>
        /// <param name="material">The material</param>
        /// <param name="polygons">Polygons</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, string material, IMeshCreator creator, List<PolygonLocal> polygons) :
            this(name, parent, matrix, material, creator)
        {
            foreach (var p in polygons)
            {
              //  Polygons.Add(p);
            }
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, Material material, List<PolygonLocal> polygons, IMeshCreator creator) :
      this(name, parent, null, creator)
        {
            Material = material;
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
        /// <param name="material">The material</param>
        /// <param name="polygons">Polygons</param>
        /// <param name="vertices">vertices</param>
        /// <param name="normals">Normals</param>
        /// <param name="creator">The creator of mesh</param>
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, Material material, 
            List<PolygonLocal> polygons, List<float[]> vertices, List<float[]> normals, IMeshCreator creator) :
            this(name, parent, matrix, material, polygons, creator)
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
            base.CreateTriangles();
            trianglesCreated = false;
            CreateFromPolygons();
            trianglesCreated = true;
        }

        /// <summary>
        /// Creates from polygons
        /// </summary>
        protected void CreateFromPolygons()
        {

            if (Polygons == null | trianglesCreated | Points == null)
            {
                return;
            }
            if (Polygons.Count == 0 | Points.Count == 0)
            {
                return;
            }
            var l = new List<int[]>();
    /*        foreach (var item in PolygonIndexes)
            {
                if (item.Length <= 3)
                {
                    l.Add(item);
                    continue;
                }
                var pp = splitter[item, Points];
                foreach (var p in pp)
                {
                    l.Add(p);
                }
            }
            PolygonIndexes = l;*/

        }

        #endregion
    }
}