using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creator of code from tree
    /// </summary>
    public interface ICodeCreator
    {
        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code</returns>
        IList<string> CreateCode(ObjectFormulaTree tree, string ret, string[] parameters,
            out IList<string> variables, out IList<string> initializers);

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
        ICodeCreator Create(ObjectFormulaTree[] trees);


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
     
    }
}
