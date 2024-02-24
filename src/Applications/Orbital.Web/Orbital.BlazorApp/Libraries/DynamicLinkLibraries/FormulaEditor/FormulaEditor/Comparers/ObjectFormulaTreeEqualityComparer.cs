using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

namespace FormulaEditor.Comparers
{
    /// <summary>
    /// Comparer of trees
    /// </summary>
    public class ObjectFormulaTreeEqualityComparer : IEqualityComparer<ObjectFormulaTree>
    {
        #region Fields

        /// <summary>
        /// Comparer of operations
        /// </summary>
        IEqualityComparer<IObjectOperation> comparer;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">Comparer of operations</param>
        public ObjectFormulaTreeEqualityComparer(IEqualityComparer<IObjectOperation> comparer)
        {
            this.comparer = comparer;
        }

        #endregion

        #region IEqualityComparer<ObjectFormulaTree> Members


        bool IEqualityComparer<ObjectFormulaTree>.Equals(ObjectFormulaTree x, ObjectFormulaTree y)
        {
            if ((x == null) & (y == null))
            {
                return true;
            }

            if ((x != null) & (y == null))
            {
                return false;
            }

            if ((x == null) & (y != null))
            {
                return false;
            }
            if (!comparer.Equals(x.Operation, y.Operation))
            {
                return false;
            }
            int n = x.Count;
            if (n != y.Count)
            {
                return false;
            }
            IEqualityComparer<ObjectFormulaTree> c = this;
            for (int i = 0; i < n; i++)
            {
                if (!c.Equals(x[i], y[i]))
                {
                    return false;
                }
            }
            return true;
        }
               

        int IEqualityComparer<ObjectFormulaTree>.GetHashCode(ObjectFormulaTree obj)
        {
            return obj.Operation.GetHashCode();
        }

        #endregion
    }
}
