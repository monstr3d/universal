using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Derivation & distribution
    /// </summary>
    public class MeasurementDistributionDerivation : MeasurementDerivation, IDistribution
    {
        IDistribution distribution;
        internal MeasurementDistributionDerivation(object type,
            Func<object> parameter, Func<object> derivation, string name,
            IDistribution distribution)
            : base(type, parameter, new Measurement(derivation, ""), name)
        {
            this.distribution = distribution;
        }

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
