using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Dictionary of materials
    /// </summary>
    public interface IEffectDictionary
    {
        /// <summary>
        /// Dictionary of effects
        /// </summary>
        Dictionary<string, Effect> Effects { get; }
    }
}
