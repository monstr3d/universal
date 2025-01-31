using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Dictionary of materials
    /// </summary>
    public interface IMaterialDictionary
    {
        /// <summary>
        /// Dictionary of materials
        /// </summary>
        Dictionary<string, Material> Materials { get; }
    }
}
