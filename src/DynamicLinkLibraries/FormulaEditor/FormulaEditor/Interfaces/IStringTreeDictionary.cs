using System.Collections.Generic;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Dictionary of trees
    /// </summary>
    public interface IStringTreeDictionary
    {
        /// <summary>
        /// The dictionary
        /// </summary>
        Dictionary<string, ObjectFormulaTree> Dictionary { get; }
    }
}
