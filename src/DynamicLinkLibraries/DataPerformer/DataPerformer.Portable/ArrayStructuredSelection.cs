using System;
using System.Collections.Generic;
using System.Text;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Structured selection of array
    /// </summary>
    public class ArrayStructuredSelection : ConstDoubleArrayMeasure, IStructuredSelection
    {
        #region Fields

        private string selectionName;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">Selection data</param>
        /// <param name="name">Name of object</param>
        /// <param name="selectionName">Name of selection</param>
        public ArrayStructuredSelection(double[] array, string name, string selectionName)
            : base(array, name)
        {
            this.selectionName = selectionName;
        }

        #endregion

        #region IStructuredSelection Members

        int IStructuredSelection.DataDimension
        {
            get { return array.Length; }
        }

        double? IStructuredSelection.this[int n]
        {
            get { return array[n]; }
        }

        double IStructuredSelection.GetWeight(int n)
        {
            return 1;
        }

        double IStructuredSelection.GetApriorWeight(int n)
        {
            return 1;
        }

        int IStructuredSelection.GetTolerance(int n)
        {
            return 0;
        }

        void IStructuredSelection.SetTolerance(int n, int tolerance)
        {
        }

        bool IStructuredSelection.HasFixedAmount
        {
            get { return false; }
        }

        string IStructuredSelection.Name
        {
            get { return selectionName; }
        }

        #endregion
    }
}
