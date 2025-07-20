using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using BaseTypes.Interfaces;

using FormulaEditor;

namespace DataPerformer.Formula
{
    public class FormulaMeasurementDerivationDistribution : FormulaMeasurementDerivation, IDistribution
    {
        #region Ctor


        public FormulaMeasurementDerivationDistribution(ObjectFormulaTree tree, 
            FormulaMeasurement derivation,
            string name, AssociatedAddition associated, object obj)
            : base(tree, derivation, name, associated, obj)
        {
        }
        
        public FormulaMeasurementDerivationDistribution(ObjectFormulaTree tree,
            string name, AssociatedAddition associated, object obj)
            : base(tree, name, associated, obj)
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
