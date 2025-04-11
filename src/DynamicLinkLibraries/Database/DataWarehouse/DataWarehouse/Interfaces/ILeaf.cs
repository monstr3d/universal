namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Leaf
    /// </summary>
    public interface ILeaf : INode
    {
        /// <summary>
        /// Data
        /// </summary>
        byte[] Data
        {
            get;
            set;
        }
    }
}
