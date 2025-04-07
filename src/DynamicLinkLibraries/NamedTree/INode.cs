
namespace NamedTree
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode<T> where T : class
    {
        /// <summary>
        /// Parent
        /// </summary>
        INode<T> Parent { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        IEnumerable<INode<T>> Nodes { get; protected set; }

        /// <summary>
        /// Add child node
        /// </summary>
        /// <param name="node">The child node</param>
        void Add(INode<T> node);

        /// <summary>
        /// Value
        /// </summary>
        T Value { get; }

    }


}
