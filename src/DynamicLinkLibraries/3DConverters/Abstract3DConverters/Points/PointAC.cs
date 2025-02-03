using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Points
{
    /// <summary>
    /// Point
    /// </summary>
    public class PointAC
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertex">Vertex</param>
        /// <param name="texture">Texture</param>
        /// <param name="normal">Normal</param>
        /// <param name="data">Data</param>
        public PointAC(int vertex, int texture, int normal, float[] data)
        {
            Vertex = vertex;
            Textrure = texture;
            Normal = normal;
            Data = data;
        }

        /// <summary>
        /// Vertex
        /// </summary>
        public int Vertex
        {
            get;
            private set;
        }

        /// <summary>
        /// Texture
        /// </summary>
        public int Textrure
        {
            get;
            private set;
        }

        /// <summary>
        /// Normal
        /// </summary>
        public int Normal
        {
            get;
            private set;
        }

        /// <summary>
        /// Data
        /// </summary>
        public float[] Data
        {
            get;
            private set;
        }

    }
}
