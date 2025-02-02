﻿using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

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
        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, string material, IMeshCreator creator, List<Polygon> polygons) :
            this(name, parent, matrix, material, creator)
        {
            foreach (var p in polygons)
            {
                Polygons.Add(p);
            }
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, float[] matrix, Material material, List<Polygon> polygons, IMeshCreator creator) :
      this(name, parent, null, creator)
        {
            Material = material;
            foreach (var p in polygons)
            {
                Polygons.Add(p);
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
            List<Polygon> polygons, List<float[]> vertices, List<float[]> normals, IMeshCreator creator) :
            this(name, parent, matrix, material, polygons, creator)
        {
            Vertices = vertices;
            Normals = normals;
        }

        #endregion

        #region Members

        /// <summary>
        /// Polygons
        /// </summary>
        public List<Polygon> Polygons
        {
            get;
            private set;
        } = new List<Polygon>();

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
            if (Polygons.Count > 0 & !trianglesCreated)
            {
                List<Polygon> polygons = new List<Polygon>();
                foreach (var polygon in Polygons)
                {
                    if (polygon.Points.Count <= 3)
                    {
                        polygons.Add(polygon);
                    }
                    else
                    {
                        var pp = splitter[polygon];
                        foreach (var p in pp)
                        {
                            polygons.Add(p);
                        }
                    }
                }
                var idx = new List<int[][]>();
                Indexes = idx;
                var txt = new List<float[]>();
                Textures = txt;
                var k = 0;
                foreach (var p in polygons)
                {
                    var t = p.Points;
                    var ii = new int[t.Count][];
                    idx.Add(ii);
                    for (int j = 0; j < t.Count; j++)
                    {
                        var pp = t[j];
                        var iii = new int[] { pp.Vertex, k, pp.Normal };
                        ii[j] = iii;
                        txt.Add(pp.Data);
                        ++k;
                    }
                }
            }

            #endregion
        }
    }
}