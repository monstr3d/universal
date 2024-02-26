using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Comparers
{
    /// <summary>
    /// Comparer of elementary operations
    /// </summary>
    public class ElementaryOperationComparer : IEqualityComparer<IObjectOperation>
    {
        bool IEqualityComparer<IObjectOperation>.Equals(IObjectOperation x, IObjectOperation y)
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
            if (!x.GetType().Equals(y.GetType()))
            {
                return false;
            }
            if (!(x is IString))
            {
                return false;
            }
            IString sx = x as IString;
            IString sy = y as IString;
            return sx.String.Equals(sy.String);
        }

        int IEqualityComparer<IObjectOperation>.GetHashCode(IObjectOperation obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.GetType().GetHashCode();
        }
    }
}
