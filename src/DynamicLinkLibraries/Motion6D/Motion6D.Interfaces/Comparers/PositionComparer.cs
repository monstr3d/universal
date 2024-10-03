using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion6D.Interfaces.Comparers
{
    class PositionComparer : IComparer<IPosition>
    {
        #region Fields

        static internal readonly PositionComparer Singleton = new PositionComparer();

        #endregion

        #region IComparer<IPosition> Members

        int IComparer<IPosition>.Compare(IPosition x, IPosition y)
        {
            if (IsSource(x, y))
            {
                return -1;
            }
            if (IsSource(y, x))
            {
                return 1;
            }
            return 0;
        }

        #endregion

        #region Private Members

        bool IsSource(IPosition source, IPosition target)
        {
            if (target.Parent == null)
            {
                return false;
            }
            if (target.Parent == source)
            {
                return true;
            }
            if (IsSource(source, target.Parent))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
