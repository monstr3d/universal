namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Provider of desktop end task
    /// </summary>
    public interface IDesktopTaskProvider
    {
        /// <summary>
        /// Desktop by name
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Desktop</returns>
        IDesktop this[string name]
        {
            get;
        }

        /// <summary>
        /// Task by name
        /// </summary>
        /// <param name="name">Task name</param>
        /// <returns>Gets task</returns>
        string GetTask(string name);

    }
}
