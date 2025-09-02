using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedTree
{
    /// <summary>
    /// Comparer of nodes
    /// </summary>
    /// <typeparam name="T">Node Type</typeparam>
    public class Comparer<T> : IComparer<T>, IComparer<INode<T>> where T : class
    {
        Performer performer = new Performer();

        Func<INode<T>?, INode<T>? , int> func;

        public Comparer(bool direct = true)
        {
            if (direct)
            {
                func = CompareDirect;
            }
            else
            {
                func = (INode<T>? x, INode<T> ? y) => -1 * CompareDirect(x, y);
            }
        }

        // Func<INode<T>?, INode<T>?> direct = 

        int IComparer<T>.Compare(T? x, T? y)
        {
            var xx = x as INode<T>;
            var yy = y as INode<T>;
            return func(xx, yy);
        }

        /// <summary>
        /// Sorting list
        /// </summary>
        /// <param name="list">The list</param>
        public void Sort(List<INode<T>> list)
        {
            list.Sort(this);
        }

        /// <summary>
        /// Sorting list
        /// </summary>
        /// <param name="list">The list</param>
        public void Sort(List<T> list)
        {
            list.Sort(this);
        }


        int CompareDirect(INode<T>? x, INode<T>? y)
        {
            if (x == y) return 0;
            if (performer.IsParent(x, y))
            {
                return 1;
            }
            else if (performer.IsParent(y, x))
            {
                return -1;
            }
            return 0;

        }

        int IComparer<INode<T>>.Compare(INode<T>? x, INode<T>? y)
        {
            return func(x, y);
        }
    }
}
