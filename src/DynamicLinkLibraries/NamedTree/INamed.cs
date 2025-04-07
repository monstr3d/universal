namespace NamedTree
{
    /// <summary>
    /// Named object
    /// </summary>
    public interface INamed
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; protected set; }
    }
}