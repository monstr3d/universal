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
        /// <param name="index">Index</param>
        /// <param name="texture">Texture</param>
        public PointTexture(int index, float[] texture)
        {
            Texture = texture;
            Index = index;
        }

        #endregion

        #region Properties



        /// <summary>
        /// Vertex
        /// </summary>
        public float[] Texture
        {
            get;
            private set;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public int Index
        {
            get;
            private set;
        }


        #endregion

    }
}