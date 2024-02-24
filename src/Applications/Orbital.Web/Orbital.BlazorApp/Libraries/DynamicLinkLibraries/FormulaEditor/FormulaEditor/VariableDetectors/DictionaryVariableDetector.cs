using System;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor.VariableDetectors
{
    /// <summary>
    /// Variable detector of dictionary
    /// </summary>
    public class DictionaryVariableDetector : IVariableDetector
    {
        #region Fields

        /// <summary>
        /// Dictionary
        /// </summary>
        protected Dictionary<string, IOperationAcceptor> dictionary; 

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dictionary"></param>
        public DictionaryVariableDetector(Dictionary<string, IOperationAcceptor> dictionary)
        {
            this.dictionary = dictionary;
        }

 
        #endregion

        #region  IVariableDetector   Members

        IOperationAcceptor IVariableDetector.Detect(Symbols.MathSymbol symbol)
        {
            if (!(symbol is Symbols.SimpleSymbol))
            {
                return null;
            }
            string s = symbol.String;
            if (dictionary.ContainsKey(s))
            {
                return dictionary[s];
            }
            return null;
        }

        #endregion
    }
}
