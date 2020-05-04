using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Dictionary variable of double type
    /// </summary>
    public class DoubleDictionaryVariable : DictionaryVariable, IDerivationOperation
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of variable</param>
        /// <param name="dictionary">Dictionary</param>
        public DoubleDictionaryVariable(string name, IDictionary<string, object> dictionary)
            : base(name, dictionary, (Double)0)
        {
        }

        #endregion

        #region IDerivationOperation Members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
        {
            double val = 0;
            bool zero = true;
            if (s.Equals(name))
            {
                val = 1;
                zero = false;
            }
            if (zero)
            {
                return ElementaryRealConstant.RealZero;
            }
            ElementaryRealConstant op = new ElementaryRealConstant(val);
            return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());
        }

        #endregion
    }
}
