using System.Xml;


using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Processing of material
    /// </summary>
    public interface IProcessEffect
    {
        /// <summary>
        /// Processes material
        /// </summary>
        /// <param name="element"></param>
        /// <param name="effect"></param>
        object Process(XmlElement element, Effect effect);
    }
}
