using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

using DataPerformer.Interfaces;


namespace DataPerformer.Formula
{
    class VariableMeasureDistribution : VariableMeasurement, IDistribution
    {
        #region Fields

        IDistribution distribution;

        #endregion

        #region Ctor

        internal VariableMeasureDistribution(string symbol, IMeasurement measure,
            IDistribution distribution, IVariableDetector detector)
            : base(symbol, measure, detector)
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
