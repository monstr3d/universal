using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters
{
    /// <summary>
    /// Polygon
    /// </summary>
    public class PolygonLocal
    {
        /// <summary>
        /// Points
        /// </summary>
        public List<PointAC> Points {  get; private set; }

        /// <summary>
        /// Material
        /// </summary>
        public Material Material { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="material">Material</param>
        public PolygonLocal(List<PointAC> points, Material material)
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

}
