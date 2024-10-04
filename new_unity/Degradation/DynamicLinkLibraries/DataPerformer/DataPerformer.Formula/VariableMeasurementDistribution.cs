using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

using DataPerformer.Interfaces;


namespace DataPerformer.Formula
{
    class VariableMeasurementDistribution : VariableMeasurement, IDistribution
    {
        #region Fields

        IDistribution distribution;

        #endregion

        #region Ctor

        internal VariableMeasurementDistribution(string symbol, IMeasurement measure,
            IDistribution distribution, IVariableDetector detector, object obj)
            : base(symbol, measure, detector, obj)
        {
            this.distribution = distribution;
        }

        #endregion

        #region IDistribution Members

        void IDistribution.Reset()
        {
            distribution.Reset();
        }

        double IDistribution.Integral
        {
            get { return distribution.Integral; }
        }

        #endregion
    }
}
