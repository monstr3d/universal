﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Abstract3DConverters.Interfaces;


namespace Abstract3DConverters.Points
{
    /// <summary>
    /// Point of texture
    /// </summary>
    public class PointTexture
    {
        #region Fields

        Polygon polygon;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mesh">mesh</param>
        /// <param name="vertex">vertex</param>
        /// <param name="texture">Texture</param>
        /// <param name="normal">Normal</param>
        [SetsRequiredMembers]
        public PointTexture(IGeometry geometry, int vertex, int texture, int normal = -1)
        {
            try
            {
                Geometry = geometry;
                VertexIndex = vertex;
                TextureIndex = texture;
                NormalIndex = normal;
                Vertex = geometry.Vertices[vertex];
                Texture = geometry.Textures[texture];
                if (geometry.Normals == null)
                {
                    NormalIndex = -1;
                }
                else if (normal >= 0)
                {
                    Normal = geometry.Normals[normal];
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Point texture constructor");
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertices">Vertices</param>
        /// <param name="textures">Textures</param>
        /// <param name="vertex">Vertex index</param>
        /// <param name="texture">Texture index</param>
        /// <param name="normal">Normal index</param>
        /// <param name="normals">Normals</param>
        /// <exception cref="IncludedException"></exception>
        [SetsRequiredMembers]
        public PointTexture(List<float[]> vertices, List<float[]> textures,  int vertex, int texture, 
            int normal = -1, List<float[]> normals = null)
        {
            try
            {
                Vertex = vertices[vertex];
                Texture = textures[texture];

                if (normals == null)
                {
                    NormalIndex = -1;
                }
                else if (normal >= 0)
                {
                    Normal = normals[normal];
                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Point texture constructor");
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Copy geometry
        /// </summary>
        /// <param name="geometry"></param>
        public void Copy(IGeometry geometry)
        {
            Geometry = geometry;
        }

        public Polygon Polygon
        {
            get => polygon;
            set
            {
                if (polygon != null)
                {
                    return;
                }
                polygon = value;
                if (Normal != null)
                {
                    return;
                }
                Normal = polygon.VertexNormal;
            }
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public int TextureIndex
        {
            get;
            protected set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public int VertexIndex
        {
            get;
            protected set;
        }

        /// <summary>
        /// Normal
        /// </summary>
        public int NormalIndex
        {
            get;
            protected set;
        }



        /// <summary>
        /// Normal
        /// </summary>
        public float[] ? Normal
        {
            get;
            protected set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Texture
        {
            get;
            protected set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Vertex
        {
            get;
            protected set;
        }

        /// <summary>
        /// Mesh
        /// </summary>
        public IGeometry ? Geometry
        {
            get;
            protected set;
        }

        #endregion

    }
}