﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes;

namespace Chart.Drawing.TextPainters
{
    public class TimeTextPainter : SimpleCoordTextPainter
    {

        bool utc;

        #region Ctor

        public TimeTextPainter(bool utc)
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
                return dt.TimeOfDay + "";
            }
            return dt.ToLocalTime().TimeOfDay + "";
        }

        #endregion
    }
}
