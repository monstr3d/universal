using System;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Proxy of tree collection
    /// </summary>
    public interface ITreeCollectionProxy
    {
        /// <summary>
        /// Proxy parameter of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The proxy parameter</returns>
        Func<object> this[ObjectFormulaTree tree]
        {
            get;
        }

        /// <summary>
        /// Update function
        /// </summary>
        void Update();

        /// <summary>
        /// The success sign
        /// </summary>
        bool Success {  get; }


    }
 
}
