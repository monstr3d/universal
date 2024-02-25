using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using BaseTypes.Attributes;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Portable.Runtime
{
    class RealtimeProviderAnalysis :  RealtimeProvider
    {

        DateTime zero = new DateTime(0);

        DateTime start;

        DateTime dt = new DateTime(0);


        Action<DateTime> act;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isAbsolute">True in case of relative time</param>
        /// <param name="timeUnit">Time unit</param>
        internal RealtimeProviderAnalysis(bool isAbsolute, TimeType timeUnit) 
        {
            if (timeUnit.Equals(TimeType.Day))
            {
                time = () =>
                {
                    return (dt - new DateTime(0)).TotalDays;
                };
            }
            else
            {
                double coeff = TimeType.Day.Coefficient<TimeType>(timeUnit);
                if (!isAbsolute)
                {
                    time = () =>
                    {
                        return coeff * (dt - start).TotalDays;
                    };
                }
                else
                {
                    time = () =>
                    {
                        return coeff * (dt - new DateTime(0)).TotalDays;
                    };
                }
                if (isAbsolute)
                {
                    act = (DateTime dt) => { };
                }
                else
                {
                    act = (DateTime dt) =>
                    {
                         start = dt;
                         act = (DateTime tt) => { };
                    };
                }
            }

            Func<object> mea = () =>
            {
                double t = time();
                return t;
            };
            timeMeasurement = new TimeMeasurement(mea);
        }


        /// <summary>
        /// Current Date Time
        /// </summary>
        public override DateTime DateTime
        {
            get
            {
               return dt;
            }
            set
            {
                act(value);
                dt = value;
            }
        }

    }
}
