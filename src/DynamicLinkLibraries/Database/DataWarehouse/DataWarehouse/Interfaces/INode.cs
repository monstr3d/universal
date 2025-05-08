using NamedTree;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode : INamed, NamedTree.INode<INode>, IDescription
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
