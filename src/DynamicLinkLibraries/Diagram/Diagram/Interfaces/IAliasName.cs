namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Alias name interface
    /// </summary>
    public interface IAliasName
    {
        /// <summary>
        /// Value
        /// </summary>
        object Value
        {
            get;
            set;
        }

        /// <summary>
        /// Alias
        /// </summary>
        IAliasBase Alias
        {
            get;
        }

        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }
            
    }
}
