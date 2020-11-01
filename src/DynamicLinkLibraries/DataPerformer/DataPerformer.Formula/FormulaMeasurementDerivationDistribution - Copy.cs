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
            string name, AssociatedAddition associated)
            : base(tree, derivation, name, associated)
        {
        }
        
        public FormulaMeasurementDerivationDistribution(ObjectFormulaTree tree,
            string name, AssociatedAddition associated)
            : base(tree, name, associated)
        {
        }

        #endregion


        #region IDistribution Members

        void IDistribution.Reset()
        {
            DeltaFunction.Reset(tree);
        }

        double IDistribution.Integral
        {
            get { return DeltaFunction.Integral(tree); }
        }

        #endregion
    }
}
