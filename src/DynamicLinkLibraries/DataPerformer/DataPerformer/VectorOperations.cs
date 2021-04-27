using System;
using System.Collections.Generic;
using System.Text;
using CategoryTheory;

namespace DataPerformer
{
    /// <summary>
    /// Vector operations
    /// </summary>
    static public class VectorOperations
    {
        /// <summary>
        /// Sum of vector transformations
        /// </summary>
        /// <param name="transformations">Transformations</param>
        /// <returns>Sum of transformations</returns>
        static public Action<double[]> Sum(Action<double[]>[] transformations)
        {
            List<Action<double[]>> l = new List<Action<double[]>>();
            foreach (Action<double[]> t in transformations)
            {
                if (t != null)
                {
                    l.Add(t);
                }
            }
            if (l.Count == 0)
            {
                return null;
            }
            if (l.Count == 1)
            {
                return l[0];
            }
            Action<double[]> tr = l[0] + l[1];
            for (int i = 2; i < l.Count; i++)
            {
                tr += l[i];
            }
            return tr;
        }

        /// <summary>
        /// Creates transformer of associated object
        /// </summary>
        /// <param name="tr">Initial transformer</param>
        /// <param name="obj">The object</param>
        /// <returns>The transformer</returns>
        static public Action<double[]> CreateTransformer(Action<double[]> tr, IAssociatedObject obj)
        {
            if (!(obj is IChildrenObject))
            {
                return tr;
            }
            IChildrenObject ch = obj as IChildrenObject;
            IAssociatedObject[] ao = ch.Children;
            List<Action<double[]>> l = new List<Action<double[]>>();
            foreach (IAssociatedObject ob in ao)
            {
                if (!(ob is IVectorTransformer))
                {
                    continue;
                }
                IVectorTransformer t = ob as IVectorTransformer;
                Action<double[]> tv = t.Transformer;
                if (tv != null)
                {
                    l.Add(tv);
                }
            }
            if (l.Count == 0)
            {
                return tr;
            }
            Action<double[]> trv = Sum(l.ToArray());
            Action<double[]> tvr = tr + trv;
            return tvr;
        }
    }

    /// <summary>
    /// Transformer of vector
    /// </summary>
    public interface IVectorTransformer
    {
        /// <summary>
        /// Vector transformer
        /// </summary>
        Action<double[]> Transformer
        {
            get;
        }
    }

    /// <summary>
    /// Vector provider
    /// </summary>
    public interface IVectorProvider
    {
        /// <summary>
        /// Vector function
        /// </summary>
        Func<double[]> Provider
        {
            get;
        }
    }
        
}
