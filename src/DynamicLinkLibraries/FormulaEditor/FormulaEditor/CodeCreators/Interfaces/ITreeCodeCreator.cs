using System.Collections.Generic;

namespace FormulaEditor.CodeCreators.Interfaces
{
    /// <summary>
    /// Creator of code from tree
    /// </summary>
    public interface ITreeCodeCreator
    {
        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>List of code</returns>
       Dictionary<string, List<string>> CreateCode(object obj, ObjectFormulaTree tree, string ret, 
          params string[] parameters);

        /// <summary>
        /// Identifier of tree
        /// </summary>
        string this[ObjectFormulaTree tree]
        {
            get;
        }

        /// <summary>
        /// Creates Creator
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <returns>Creator</returns>
        ITreeCodeCreator Create(object obj, ObjectFormulaTree[] trees);


        /// <summary>
        /// Trees
        /// </summary>
        ObjectFormulaTree[] Trees
        {
            get;
        }

        /// <summary>
        /// Optional trees
        /// </summary>
        List<ObjectFormulaTree> Optional
        {
            get;
        }

        /// <summary>
        /// Gets constant string representation of value of tree 
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>String representation</returns>
        string GetConstValue(ObjectFormulaTree tree);

        /// <summary>
        /// Gets number of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>The number</returns>
        int GetNumber(ObjectFormulaTree tree);

        /// <summary>
        /// Associated object
        /// </summary>
        object Object { get; set; }
     
    }
}
