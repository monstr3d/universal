using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Attributes;

namespace DataPerformer.Portable.Runtime
{
    class RealtimeProviderRealtime : RealtimeProvider
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isAbsolute">True in case of relative time</param>
        /// <param name="timeUnit">Time unit</param>
        internal RealtimeProviderRealtime(bool isAbsolute, TimeType timeUnit) : base(isAbsolute, timeUnit)
        {

        }

        /// <summary>
        /// Current Date Time
        /// </summary>
        public override DateTime DateTime
        {
            get
            {
                return DateTime.Now;
            }
            set
            {

            }
        }
    }
}
