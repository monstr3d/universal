using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Measure AND Distribution
    /// </summary>
    public class MeasurmentDistribution : Measurement, IDistribution
    {
        IDistribution distribution;

        public MeasurmentDistribution(Func<object> parameter,
            string name, IDistribution distribution)
            : base(parameter, name)
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
