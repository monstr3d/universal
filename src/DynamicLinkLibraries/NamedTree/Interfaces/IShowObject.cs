namespace NamedTree.Interfaces
{
    /// <summary>
    /// Shows object
    /// </summary>
    public interface IShowObject
    {
        /// <summary>
        /// Shows object
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">Arguments</param>
        /// <returns>Result</returns>
        bool Show(object sender, params object[] args);
    }
}
