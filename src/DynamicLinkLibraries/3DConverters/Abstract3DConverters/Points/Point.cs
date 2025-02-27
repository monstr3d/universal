using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Points
{
    /// <summary>
    /// Point
    /// </summary>
    public class Point
    {

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertex">Vertex</param>
        /// <param name="texture">Textue</param>
        /// <param name="normal">Normal</param>
        public Point(float[] vertex, float[] texture, float[] normal = null)
        {
            Vertex = vertex;
            Texture = texture;
            Normal = normal;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mesh">Mesh</param>
        /// <param name="point">Point</param>
        public Point(IMesh mesh, PointTexture point)
        {
            Vertex = mesh.Vertices[point.VertexIndex];
            Texture = mesh.Textures[point.TextureIndex];
            if (mesh.Normals != null)
            {
                if (point.NormalIndex >= 0)
                {
                    Normal = mesh.Normals[point.NormalIndex];
                }
            }
        }


        #endregion

        #region Properties

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Vertex
        {
            get;
            protected set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public  float[] Normal
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




        #endregion

    }
}
