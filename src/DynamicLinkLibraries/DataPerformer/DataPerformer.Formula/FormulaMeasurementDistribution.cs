using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using BaseTypes.Interfaces;


using FormulaEditor.Interfaces;
using FormulaEditor;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Distribution measure
    /// </summary>
    public class FormulaMeasurementDistribution : FormulaMeasurement, IDistribution
    {
        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="name">Name</param>
        /// <param name="addition">Addition</param>
        /// <param name="obj">Associated object</param>
        public FormulaMeasurementDistribution(ObjectFormulaTree tree, 
            string name, AssociatedAddition addition, object obj)
            : base(tree, name, addition, obj)
        {
        }

        #endregion


        #region IDistribution Members

        void IDistribution.Reset()
        {
            DeltaFunction.Reset(Tree);
        }

        double IDistribution.Integral
        {
            get { return DeltaFunction.Integral(Tree); }
        }

        #endregion
    }
}
