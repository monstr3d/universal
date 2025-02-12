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
        /// Effect
        /// </summary>
        public Effect Effect 
        { 
            get; 
            protected set; 
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="effect">Effect</param>
        public Polygon(PointTexture[] points, Effect effect)
        {
            Points = points;
            Effect = effect;
        }
    }
}
