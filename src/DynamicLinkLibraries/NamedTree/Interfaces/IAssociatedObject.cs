namespace NamedTree.Interfaces
{
    /// <summary>
    /// Object associated with another object
    /// </summary>
    public interface IAssociatedObject
    {
        /// <summary>
        /// The associated object
        /// </summary>
        object Object
        {
            get;
            set;
        }
    }
}
