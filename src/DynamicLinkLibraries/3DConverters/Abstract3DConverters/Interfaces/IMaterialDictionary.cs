using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    public interface IMaterialDictionary
    {
        Dictionary<string, Material> Materials { get; }
    }
}
