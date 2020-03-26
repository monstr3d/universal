using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;

namespace DataPerformer.Portable.Measurements
{
    /// <summary>
    /// Measure with replaced parameter
    /// </summary>
    public class ReplacedParameterMeasurement : Measurement, IReplacedMeasurementParameter
    {

        #region Fields

        Func<object> ownParameter;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of parameter</param>
        /// <param name="parameter">Measurement parameter</param>
        /// <param name="name">Measurement name</param>
        public ReplacedParameterMeasurement(object type, Func<object> parameter, string name) : base(type, parameter, name)
        {

        }

        #endregion

        #region IReplacedMeasureParameter Members

        void IReplacedMeasurementParameter.Replace(Func<object> parameter)
        {
            if (ownParameter != null)
            {
                throw new Exception();
            }
            ownParameter = base.parameter;
            base.parameter = parameter;
        }

        void IReplacedMeasurementParameter.Reset()
        {
            if (ownParameter == null)
            {
                throw new Exception();
            }
            base.parameter = ownParameter;
            ownParameter = null;
        }

        #endregion
    }
}