namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object with orientation
    /// </summary>
    public interface IOrientation
    {
        /// <summary>
        /// Orientation quaternion
        /// </summary>
        double[] Quaternion
        {
            get;
        }

        /// <summary>
        /// Orientation matrix
        /// </summary>
        double[,] Matrix
        {
            get;
        }
    }
}
