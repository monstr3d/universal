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
        public string Name { get;  set; }

        /// <summary>
        /// New name
        /// </summary>
        public string NewName { get; set; }
    }
}