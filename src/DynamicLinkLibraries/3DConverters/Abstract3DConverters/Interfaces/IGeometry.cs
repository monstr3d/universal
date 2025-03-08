namespace Abstract3DConverters.Interfaces
{
    public interface IGeometry
    {
        /// <summary>
        /// Vertices
        /// </summary>
        List<float[]> Vertices { get; }

        /// <summary>
        /// Normals
        /// </summary>
        List<float[]> Normals { get; }

        /// <summary>
        /// Textures
        /// </summary>
        List<float[]> Textures { get; }

        /// <summary>
        /// Transformation matrix
        /// </summary>
        float[] TransformationMatrix { get; }

    }
}
