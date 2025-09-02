
namespace NamedTree
{
    /// <summary>
    /// Children object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IChildren<T> where T : class
    {
        /// <summary>
        /// Children
        /// </summary>
        IEnumerable<T> Children { get; }

        /// <summary>
        /// Adds child
        /// </summary>
        /// <param name="child">The child to add</param>
        void AddChild(T child);

        /// <summary>
        /// Remove child
        /// </summary>
        /// <param name="child"></param>
        void RemoveChild(T child);

        /// <summary>
        /// Add event
        /// </summary>
        event Action<T> OnAdd;

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<T> OnRemove;
    }
}
