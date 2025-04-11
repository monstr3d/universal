using NamedTree;

namespace DataWarehouse.Interfaces
{
    /// <summary>
    /// Node
    /// </summary>
    public interface INode : INamed, NamedTree.INode<INode>
    {
        /// <summary>
        /// Id
        /// </summary>
        object Id
        {
            get;
        }

 
        /// <summary>
        /// Description
        /// </summary>
        string Description
        {
            get;
            set;
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
