namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Object having a parent
    /// </summary>
    public interface IParent
    {
        /// <summary>
        /// The parent
        /// </summary>
        IParent Parent { get; set; }
    }
}
