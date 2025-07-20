using GeneralNode;

namespace CommonControls.Interfaces
{
    /// <summary>
    /// Operations of tree
    /// </summary>
    interface ITreeOperations
    {
        /// <summary>
        /// Adds directory
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="name">Node name</param>
        /// <param name="description">Node description</param>
        /// <returns>New directory</returns>
        INode AddDirectory(INode parent, string name, string description);

        /// <summary>
        /// Renames node
        /// </summary>
        /// <param name="node">Node to rename</param>
        /// <param name="newName">New name of node</param>
        void Rename(INode node, string newName);
    }
}
