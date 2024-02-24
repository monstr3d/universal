using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Comparers
{
    /// <summary>
    /// Comparer of category objects
    /// </summary>
    public class CategoryObjectComparer : IComparer<ICategoryObject>
    {


        #region IComparer<ICategoryObject> Members

        int IComparer<ICategoryObject>.Compare(ICategoryObject x, ICategoryObject y)
        {
            return 0;
        }

        #endregion




        private bool IsSource(ICategoryObject s, ICategoryObject t,
            IEnumerable<ICategoryArrow> arrows, Func<ICategoryObject, bool> condition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            return IsSource(s, arrows, t, condition, l);
        }

       private bool IsSource(ICategoryObject obj, IEnumerable<ICategoryArrow> arrows, 
            ICategoryObject target, Func<ICategoryObject, bool> condition, List<ICategoryObject> co)
        {
            foreach (ICategoryArrow a in arrows)
            {
                if (a.Source != obj)
                {
                    continue;
                }
                ICategoryObject t = a.Target;
                if (!condition(t))
                {
                    continue;
                }
                if (t == target)
                {
                    return true;
                }
                if (co.Contains(t))
                {
                    continue;
                }
                co.Add(t);
                if (IsSource(t, arrows, target, condition, co))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
