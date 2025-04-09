
namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Collection of objects
    /// </summary>
    public interface IObjectCollection : IComponentCollection
    {

        /// <summary>
        /// Names of objects
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Access to objet by name
        /// </summary>
        /// <param name="name">Name of object</param>
        /// <returns></returns>
        object this[string name]
        {
            get;
        }

    }
}
