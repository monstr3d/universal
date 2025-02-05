using Abstract3DConverters.Points;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Splitter of polygon
    /// </summary>
    public interface IPolygonSplitter
    {
        /// <summary>
        /// Splits Polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <returns>The split result</returns>
        Polygon[] this[Polygon polygon] { get; }

    }
}
