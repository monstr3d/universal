using NamedTree.Interfaces;


namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode : INamed, INode<INode>, IDescription
    {
        /// <summary>
        /// Id
        /// </summary>
        object Id
        {
            get;
        }


        /// <summary>
        /// Extension
        /// </summary>
        string Extension
        {
            get;
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void RemoveItself();
        
    }
}
