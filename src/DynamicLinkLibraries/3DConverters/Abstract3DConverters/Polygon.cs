using Abstract3DConverters.Materials;

namespace Abstract3DConverters
{
    /// <summary>
    /// Polygon
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// Points
        /// </summary>
        public List<Point> Points {  get; private set; }

        /// <summary>
        /// Material
        /// </summary>
        public Material Material { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="material">Material</param>
        public Polygon(List<Point> points, Material material)
        {
            if (material == null)
            {

            }
            foreach (var p in points)
            {
                if (p.Vertex < 0)
                {

                }
            }
            Material = material;
            Points = points;
        }

        /// <summary>
        /// Name of material
        /// </summary>
        public string MaterialName => Material.Name;
    }

    /// <summary>
    /// Point
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertex">Vertex</param>
        /// <param name="texture">Texture</param>
        /// <param name="normal">Normal</param>
        /// <param name="data">Data</param>
        public Point(int vertex, int texture, int normal, float[] data)
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
