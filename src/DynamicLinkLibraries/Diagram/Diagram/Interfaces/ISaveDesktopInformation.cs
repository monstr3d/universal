
namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Saves desctop information
    /// </summary>
    public interface ISaveDesktopInformation
    {
        /// <summary>
        /// Saves an object
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="url">The url</param>
        /// <returns>True in success</returns>
        bool Save(object o, string url);
    }
}
