namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Creates suffix
    /// </summary>
    public interface ICreateSuffix
    {
        /// <summary>
        /// Creates suffix of the object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>The suffix</returns>
        string CreateSuffix(object o);
    }
}
