using System.IO;

using NamedTree;

namespace Common.UI
{
    /// <summary>
    /// Creator of stream
    /// </summary>
    public interface IStreamCreator
    {
        /// <summary>
        /// Stream
        /// </summary>
        Stream Stream
        {
            get;
        }

        /// <summary>
        /// Data async
        /// </summary>
        IDataAsync DataAsync { get; }

    }
}
