namespace BaseTypes.Interfaces
{
    /// <summary>
    /// Creator of types
    /// </summary>
    public interface ITypeCreator
    {
        /// <summary>
        /// String representation of type
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>String representation of type</returns>
        string GetType(object o);

        /// <summary>
        /// Gets default value
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns>String representation of value</returns>
        string GetDefaultValue(object o);
    }
}
