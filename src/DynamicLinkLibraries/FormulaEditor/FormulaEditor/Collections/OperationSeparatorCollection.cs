using System.Collections.Generic;

using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Collections
{
    /// <summary>
    /// Collection of separators
    /// </summary>
    public class OperationSeparatorCollection : IOperationSeparator
    {
        #region Fields

        List<IOperationSeparator> separators = new List<IOperationSeparator>();

        #endregion

        #region IOperationSeparator Members

        string[] IOperationSeparator.this[IObjectOperation operation]
        {
            get
            {
                foreach (IOperationSeparator separator in separators)
                {
                    string[] sep = separator[operation];
                    if (sep != null)
                    {
                        return sep;
                    }
                }
                return null;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Adds a separator
        /// </summary>
        /// <param name="separator">The separator</param>
        public void Add(IOperationSeparator separator)
        {
            separators.Add(separator);
        }

        #endregion

    }
}
