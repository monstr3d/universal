
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
        /// Adds child node
        /// </summary>
        /// <param name="node">The child node</param>
        void Add(INode<T> node);


        /// <summary>
        /// Removes child node
        /// </summary>
        /// <param name="node">The child node</param>
        void Remove(INode<T> node);

        /// <summary>
        /// Add event
        /// </summary>
        event Action<T> OnAdd;

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<T> OnRemove;


        /// <summary>
        /// Value
        /// </summary>
        T Value { get; }

    }


}
