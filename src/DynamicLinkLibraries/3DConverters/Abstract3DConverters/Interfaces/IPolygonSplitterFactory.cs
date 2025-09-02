namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// Factory of polygon splitter
    /// </summary>
    public interface IPolygonSplitterFactory
    {
        /// <summary>
        /// Creates the polygon splitter
        /// </summary>
        /// <returns>The polygon splitter</returns>
        IPolygonSplitter CreatePolygonSplitter();
    }
}
