using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaEditor.VariableDetectors
{
    /// <summary>
    /// Extended dictionary Variable detector
    /// </summary>
    public class ExtendedDictionaryVariableDetector : DictionaryVariableDetector
    {
        #region Fields

        Dictionary<string, Variables.Variable> dvariables = new Dictionary<string, Variables.Variable>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="types">Dictionary of types</param>
        public ExtendedDictionaryVariableDetector(Dictionary<string, object> types)
            : base(new Dictionary<string, FormulaEditor.Interfaces.IOperationAcceptor>())
        {
            foreach (string key in types.Keys)
            {
                Variables.Variable v = null;
                object t = types[key];
                if (t.Equals((double)0))
                {
                    v = new Variables.VariableDouble(key);
                }
                else
                {
                    v = new Variables.Variable(t, key);
                }
                dvariables[key] = v;
                dictionary[key] = v;
            }
        }

        #endregion

        /// <summary>
        /// Access to variables
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return dvariables[key].Value;
            }
            set
            {
                dvariables[key].Value = value;
            }
        }
    }
}
