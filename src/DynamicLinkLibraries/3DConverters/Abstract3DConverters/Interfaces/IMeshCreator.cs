using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Creator of meshes
    /// </summary>
    public interface IMeshCreator
    {
        /// <summary>
        /// Directory
        /// </summary>
        string Directory { get; }

        /// <summary>
        /// Loads itself
        /// </summary>
        /// <param name="bytes">Bytes</param>
        void Load(byte[] bytes);

        /// <summary>
        /// Meshes
        /// </summary>
        IEnumerable<AbstractMesh> Meshes { get; }

        /// <summary>
        /// Materials
        /// </summary>
        Dictionary<string, Material> Materials { get; }

        /// <summary>
        /// Images
        /// </summary>
        Dictionary<string, Image> Images { get; }

        /// <summary>
        /// Effects
        /// </summary>
        Dictionary<string, Effect> Effects { get; }
    }
}
