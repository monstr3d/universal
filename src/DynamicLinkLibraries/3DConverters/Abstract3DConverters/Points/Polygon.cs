using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Points
{
    public class Polygon
    {
        /// <summary>
        /// Indexes
        /// </summary>
        public int[] Indexes 
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
        /// <param name="indexes">Points</param>
        /// <param name="material">Material</param>
        public Polygon(int[] indexes, Material material)
        {
            Indexes = indexes;
            Material = material;
        }
    }
}
