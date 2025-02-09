using System.ComponentModel.DataAnnotations;

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
        /// <param name="normal">Normal</param>
        public PointTexture(int index, float[] texture, float[] normal = null)
        {
            Texture = texture;
            Index = index;
            Normal = normal;
        }

        #endregion

        #region Properties



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
        public int Index
        {
            get;
            protected set;
        }

        /// <summary>
        /// Normal index
        /// </summary>
        public float[] Normal
        {
            get;
            protected set;
        }


        #endregion

    }
}