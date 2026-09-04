namespace NamedTree.Interfaces
{
    /// <summary>
    /// Consumer of factory
    /// </summary>
    public interface IFactoryConsumer
    {
        /// <summary>
        /// The factory
        /// </summary>
        IFactory Factory { get; set; }
    }
}
