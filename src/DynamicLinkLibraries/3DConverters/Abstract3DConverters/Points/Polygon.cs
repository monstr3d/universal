using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Points
{
    public class Polygon
    {
        /// <summary>
        /// Indexes
        /// </summary>
        public PointTexture[] Points
        { 
            get; protected set; 
        }

        /// <summary>
        /// Material
        /// </summary>
        public Material Material 
        { 
            get; 
            protected set; 
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="material">Material</param>
        public Polygon(PointTexture[] points, Material material)
        {
            Points = points;
            Material = material;
        }
    }
}
