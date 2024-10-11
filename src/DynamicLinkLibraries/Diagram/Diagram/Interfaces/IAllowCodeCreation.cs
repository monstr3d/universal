namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Checks whether code creation is allowed
    /// </summary>
    public interface IAllowCodeCreation
    {
        /// <summary>
        /// True if code creation is allowed
        /// </summary>
        bool AllowCodeCreation { get; }
    }
}
