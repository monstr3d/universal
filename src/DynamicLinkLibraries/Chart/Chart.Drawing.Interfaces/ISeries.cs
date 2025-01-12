namespace Chart.Drawing.Interfaces
{
    /// <summary>
    /// Common interfase of all series
    /// </summary>
    public interface ISeries
    {
        /// <summary>
        /// Size of series
        /// </summary>
        double[,] Size
        {
            get;
        }

        /// <summary>
        /// Points of series
        /// </summary>
        IList<IPoint> Points
        {
            get;
        }

        /// <summary>
        /// Dimension of y - coordinate
        /// </summary>
        int YCount
        {  get; }

        /// <summary>
        /// Adds a point
        /// </summary>
        /// <param name="point">The point to add</param>
        void Add(IPoint point);
    }
}
