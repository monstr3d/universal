namespace Event.Interfaces
{
    /// <summary>
    /// Creator of action factory
    /// </summary>
    public interface IActionFactoryCreator
    {
        /// <summary>
        /// Creates action from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The action</returns>
        IActionFactory this[object obj]
        {
            get;
        }

    }
}
