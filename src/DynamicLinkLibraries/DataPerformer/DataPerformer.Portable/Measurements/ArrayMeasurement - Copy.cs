using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Measurements
{
    class ArrayMeasurement : Measurement
    {
        #region Fields

        object[][] obj;

        int i;

        #endregion

        #region Ctor

        internal ArrayMeasurement(object[][] obj, object type, int number, string name) : base(type, null, name)
        {
            i = number;
            this.obj = obj;
            parameter = () => { return obj[0][i]; };
        }

        #endregion
    }
}
