using System.Collections.Generic;

namespace FormulaEditor.Interfaces
{
    /// <summary>
    /// Creates code
    /// </summary>
    public interface ITreeCollectionCodeCreator
    {
        /// <summary>
        /// Tree calculator code
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <param name="className">Class name</param>
        /// <param name="constructorModifier">Modifier of constructor</param>
        /// <param name="checkValue">Check value</param>
        /// <returns>Code</returns>
        List<string> CreateCode(object obj, ObjectFormulaTree[] trees, string className,
            string constructorModifier = "internal ", bool checkValue = false);
    }
}
