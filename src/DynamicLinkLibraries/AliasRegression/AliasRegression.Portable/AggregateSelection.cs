using System;
using System.Collections.Generic;
using System.Text;

using DataPerformer;
using DataPerformer.Interfaces;

namespace Regression
{
    /// <summary>
    /// Selection - aggregate
    /// </summary>
    public class AggregateSelection : IStructuredSelection
    {
        #region Fields
        private Dictionary<int, IStructuredSelection> selections = new Dictionary<int, IStructuredSelection>();
        private string name = "";
        #endregion

        #region IStructuredSelection Members

        /// <summary>
        /// Dimension of data
        /// </summary>
        public int DataDimension
        {
            get
            {
                int dim = 0;
                foreach (IStructuredSelection s in selections.Values)
                {
                    dim += s.DataDimension;
                }
                return dim;
            }
        }

        /// <summary>
        /// Access to n - th element
        /// </summary>
        public double? this[int n]
        {
            get
            {
                int m;
                IStructuredSelection s = chooseSelection(n, out m);
                return s[m];
            }
        }

        /// <summary>
        /// Weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetWeight(int n)
        {
            int m;
            IStructuredSelection s = chooseSelection(n, out m);
            return s.GetWeight(m);
        }

        /// <summary>
        /// Aprior weight of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>The weight</returns>
        public double GetApriorWeight(int n)
        {
            int m;
            IStructuredSelection s = chooseSelection(n, out m);
            return s.GetApriorWeight(m);
        }

        /// <summary>
        /// Tolerance of it - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <returns>Tolerance</returns>
        public int GetTolerance(int n)
        {
            int m;
            IStructuredSelection s = chooseSelection(n, out m);
            return s.GetTolerance(m);
        }

        /// <summary>
        /// Sets tolerance of n - th element
        /// </summary>
        /// <param name="n">Element number</param>
        /// <param name="tolerance">Tolerance to set</param>
        public void SetTolerance(int n, int tolerance)
        {
            int m;
            IStructuredSelection s = chooseSelection(n, out m);
            s.SetTolerance(m, tolerance);
        }

        /// <summary>
        /// The "is fixed amount" sign
        /// </summary>
        public bool HasFixedAmount
        {
            get
            {
                foreach (IStructuredSelection s in selections.Values)
                {
                    if (!s.HasFixedAmount)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Selection name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        #endregion

        #region Specific members

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            selections.Clear();
        }

        /// <summary>
        /// Dictionary of selections
        /// </summary>
        public Dictionary<int, IStructuredSelection> Selections
        {
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    if (!value.ContainsKey(i))
                    {
                        throw new Exception("Illegal selection number");
                    }
                    if (!(value[i] is IStructuredSelection))
                    {
                        throw new Exception("Component is not a selection");
                    }
                }
                selections = value;
            }
        }

        private IStructuredSelection chooseSelection(int n, out int m)
        {
            int k = 0;
            for (int i = 0; i < selections.Count; i++)
            {
                IStructuredSelection s = selections[i];
                int d = s.DataDimension;
                if (n < k + d)
                {
                    m = n - k;
                    return s;
                }
                k += d;
            }
            m = -1;
            return null;
        }
        #endregion
    }
}
