using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using DataPerformer;
using DataPerformer.Interfaces;

namespace Regression
{
    /// <summary>
    /// Combined selection
    /// </summary>
    [Serializable()]
    public class CombinedSelection : CategoryObject, ISerializable, IStructuredSelection, 
        IStructuredSelectionConsumer, IPostSetArrow, IStructuredSelectionCollection
    {

        #region Fields

        /// <summary>
        /// Selection
        /// </summary>
        protected IStructuredSelection selection;

        /// <summary>
        /// Weights
        /// </summary>
        protected IStructuredSelection weights;

        /// <summary>
        /// All selections
        /// </summary>
        protected List<IStructuredSelectionCollection> selections = new List<IStructuredSelectionCollection>();

        /// <summary>
        /// Numbers
        /// </summary>
        protected int[,] num = new int[2, 2];
        
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public CombinedSelection()
        {
        }

        /// <summary>
        /// Deserializable constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected CombinedSelection(SerializationInfo info, StreamingContext context)
        {
            num = info.GetValue("Num", num.GetType()) as int[,];
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Num", num, num.GetType());
        }

        #endregion

        #region IStructuredSelection Members

        int IStructuredSelection.DataDimension
        {
            get { return selection.DataDimension; }
        }

        double? IStructuredSelection.this[int n]
        {
            get { return selection[n]; }
        }

        double IStructuredSelection.GetWeight(int n)
        {
            if (weights.DataDimension <= n)
            {
                return 1;
            }
            double? a = weights[n];
            if (a == null)
            {
                return 1;
            }
            return (double)a;
        }

        double IStructuredSelection.GetApriorWeight(int n)
        {
            return selection.GetApriorWeight(n);
        }

        int IStructuredSelection.GetTolerance(int n)
        {
            return selection.GetTolerance(n);
        }

        void IStructuredSelection.SetTolerance(int n, int tolerance)
        {
           selection.SetTolerance(n, tolerance);
        }

        bool IStructuredSelection.HasFixedAmount
        {
            get { return selection.HasFixedAmount; }
        }

        string IStructuredSelection.Name
        {
            get { return selection.Name + "_" + weights.Name; }
        }

        #endregion

        #region IStructuredSelectionConsumer Members

        void IStructuredSelectionConsumer.Add(IStructuredSelectionCollection selection)
        {
            selections.Add(selection);
        }

        void IStructuredSelectionConsumer.Remove(IStructuredSelectionCollection selection)
        {
            selections.Remove(selection);
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            post();
        }

        #endregion

        #region IStructuredSelectionCollection Members

        int IStructuredSelectionCollection.Count
        {
            get { return 1; }
        }

        IStructuredSelection IStructuredSelectionCollection.this[int i]
        {
            get { return this; }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Selection numbers
        /// </summary>
        public int[,] Numbers
        {
            get
            {
                return num;
            }
        }

        /// <summary>
        /// Selections
        /// </summary>
        public IList<IStructuredSelectionCollection> Selections
        {
            get
            {
                return selections;
            }
        }
/*
        public void Set(IStructuredSelectionCollection selection, IStructuredSelection weight, int nSel, int nWeght)
        {
            num[0, 0] = selections.IndexOf(selection);
            num[0, 1] = nSel;
            num[1, 0] = selections.IndexOf(weight);
            num[1, 1] = nWeght;
            post();
        }
*/

        /// <summary>
        /// Sets selection
        /// </summary>
        /// <param name="selection">Selection to set</param>
        /// <param name="nSel">Selection number</param>
        /// <param name="b">Existing sign</param>
        public void Set(IStructuredSelectionCollection selection, int nSel, bool b)
        {
            int k = b ? 0 : 1;
            num[k, 0] = selections.IndexOf(selection);
            num[k, 1] = nSel;
            post();
        }


        private void post()
        {
            if (num[0, 0] < selections.Count)
            {
                if (num[0, 1] < selections[num[0, 0]].Count)
                {
                    selection = selections[num[0, 0]][num[0, 1]];
                }
            }
            if (num[1, 0] < selections.Count)
            {
                if (num[1, 1] < selections[num[1, 0]].Count)
                {
                    weights = selections[num[1, 0]][num[1, 1]];
                }
            }
        }

        #endregion
    }
}
