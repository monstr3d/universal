using Abstract3DConverters.Materials;

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
        IEnumerable<IMesh> Meshes { get; }

        /// <summary>
        /// Effects
        /// </summary>
        Dictionary<string, Effect> Effects { get; }

        /// <summary>
        /// Name of file
        /// </summary>
        string Filename { get; }
    }
}
