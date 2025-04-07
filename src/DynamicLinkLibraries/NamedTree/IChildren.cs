
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
    }
}
