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
        /// <param name="normal">Normal</param>
        public Point(float[] vertex, float[] normal = null)
        {
            Vertex = vertex;
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

  
        #endregion

    }
}
