namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Object with visual representation
    /// </summary>
    public interface IStringRepresentation
    {
        /// <summary>
        /// Transformation to the string representation
        /// </summary>
        /// <param name="obj">The transformed object</param>
        /// <returns>The transformation result</returns>
        string ToString(object obj);
    }
}
