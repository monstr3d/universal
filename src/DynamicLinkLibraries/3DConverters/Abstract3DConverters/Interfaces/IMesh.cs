using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Interfaces
{
    public interface IMesh : IGeometry
    {
        /// <summary>
        /// Effect
        /// </summary>
        Effect Effect { get; }

        /// <summary>
        /// Indexes
        /// </summary>
        List<int[][]> Indexes { get; }


 
        /// <summary>
        /// Absolute Vertices
        /// </summary>
        public List<float[]> AbsoluteVertices { get; }


 
        /// <summary>
        /// Gets effect
        /// </summary>
        /// <param name="creator">Material creator</param>
        /// <returns>The effect</returns>
        Effect GetEffect(IMaterialCreator creator);

        /// <summary>
        /// The name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Polygons
        /// </summary>
        List<Polygon> Polygons
        {
            get;

        }

        /// <summary>
        /// Children
        /// </summary>
        List<IMesh> Children { get; }

        /// <summary>
        /// Creator of meshes
        /// </summary>
        IMeshCreator Creator { get; }

        /// Calculates absolute points
        /// </summary>
        void CalculateAbsolute();

    }
}
