namespace Motion6D.Interfaces
{
    /// <summary>
    /// Visible 3D object
    /// </summary>
    public interface IVisible : IPositionObject
    {
        /// <summary>
        /// The size
        /// </summary>
        double[,] Size { get; }
    }
}
