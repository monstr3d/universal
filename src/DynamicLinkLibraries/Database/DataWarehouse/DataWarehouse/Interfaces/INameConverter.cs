
using System.Xml;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Converter of names
    /// </summary>
    public interface INameConverter
    {
        /// <summary>
        /// Creates name from Xml element
        /// </summary>
        /// <param name="e">Xml element</param>
        /// <returns>The name</returns>
        string CreateName(XmlElement e);
    }
}
