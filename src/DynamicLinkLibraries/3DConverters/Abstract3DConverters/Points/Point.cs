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
        /// <param name="texture">Texture</param>
        /// <param name="normal">Normal</param>
        public Point(float[] vertex, float[] texture, float[] normal)
        {
            Vertex = vertex;
            Texture = texture;
            Normal = normal;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Vertex
        {
            get;
            private set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Normal
        {
            get;
            private set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Texture
        {
            get;
            private set;
        }

        #endregion

    }
}
