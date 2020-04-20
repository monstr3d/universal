using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes;

namespace Chart.Drawing.TextPainters
{
    /// <summary>
    /// Painter of date time
    /// </summary>
    public class DateTimeTextPainter : SimpleCoordTextPainter
    {

        bool utc;


        #region Ctor

        public DateTimeTextPainter(bool utc)
        {
            this.utc = utc;
        }

        #endregion


        #region Overriden Members

        protected override string transformString(double d, double sc)
        {
            DateTime dt = d.DayToDateTime();
            if (utc)
            {
                return dt + "";
            }
            return dt.ToLocalTime() + "";
        }

        #endregion
    }
}
