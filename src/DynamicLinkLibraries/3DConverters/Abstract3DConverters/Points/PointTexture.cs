using System.Net.Http.Headers;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Points
{
    /// <summary>
    /// Point of texture
    /// </summary>
    public class PointTexture
    {
 


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="index">vertex</param>
        /// <param name="texture">Texture</param>
        /// <param name="normal">Normal</param>
        public PointTexture(IMesh mesh,int vertex, int texture, int normal = -1)
        {
            Mesh = mesh;
             VertexIndex = vertex;
            TextureIndex = texture;
            NormalIndex = normal;
            Vertex = mesh.Vertices[vertex];
            Texture = mesh.Textures[texture];
            if (mesh.Normals == null)
            {
                NormalIndex = -1;
            }
            else if (normal >= 0)
            {
                Normal = mesh.Normals[normal];
            }
            
        }
       

        #endregion

        #region Properties

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
        public float[] Normal
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
        public IMesh Mesh
        {
            get;
            protected set;
        }

  





        #endregion

    }
}