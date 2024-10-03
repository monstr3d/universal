using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Enums;
using Chart.Drawing.TextPainters;

namespace Chart.Drawing
{
    /// <summary>
    /// Performer of chart operations
    /// </summary>
    public class StaticChartPerformer
    {
  

        #region Members

        public static DataTextStyles GetStyle(ICoordTextPainter painter)
        {
            if (painter is SimpleCoordTextPainter)
            {
                return DataTextStyles.Number;
            }
            if (painter is DateTimeTextPainter)
            {
                return DataTextStyles.DateTime;
            }
            if (painter is DateTextPainter)
            {
                return DataTextStyles.Date;
            }
            //if (painter is TimeTextPainter)
            //{
            return DataTextStyles.Time;
            //}
        }

        public static ICoordTextPainter Create(DataTextStyles style)
        {
            if (style == DataTextStyles.Number)
            {
                return new SimpleCoordTextPainter();
            }
            if (style == DataTextStyles.DateTimeUTC)
            {
                return new DateTimeTextPainter(true);
            }
            if (style == DataTextStyles.DateTime)
            {
                return new DateTimeTextPainter(false);
            }
            if (style == DataTextStyles.DateUTC)
            {
                return new DateTextPainter(true);
            }
            if (style == DataTextStyles.Date)
            {
                return new DateTextPainter(false);
            }
            if (style == DataTextStyles.TimeUTC)
            {
                return new TimeTextPainter(true);
            }
            return new TimeTextPainter(false);
        }


        public static Dictionary<DataTextStyles, object> CreateDictionary(object[] o)
        {
            Dictionary<DataTextStyles, object> d = new Dictionary<DataTextStyles, object>();
            d[DataTextStyles.Number] = o[0];
            d[DataTextStyles.DateTime] = o[1];
            d[DataTextStyles.Date] = o[2];
            d[DataTextStyles.Time] = o[3];
            d[DataTextStyles.DateTimeUTC] = o[4];
            d[DataTextStyles.DateUTC] = o[5];
            d[DataTextStyles.TimeUTC] = o[6];
            return d;
        }

        public static Dictionary<object, DataTextStyles> CreateInvertDictionary(object[] o)
        {
            Dictionary<object, DataTextStyles> d = new Dictionary<object, DataTextStyles>();
            d[o[0]] = DataTextStyles.Number;
            d[o[1]] = DataTextStyles.DateTime;
            d[o[2]] = DataTextStyles.Date;
            d[o[3]] = DataTextStyles.Time;
            d[o[4]] = DataTextStyles.DateTimeUTC;
            d[o[5]] = DataTextStyles.DateUTC;
            d[o[6]] = DataTextStyles.TimeUTC;
            return d;
        }

        public static ICoordTextPainter GetPainter(DataTextStyles style)
        {
            if (style == DataTextStyles.Number)
            {
                return new SimpleCoordTextPainter();
            }
            if (style == DataTextStyles.DateTimeUTC)
            {
                return new DateTimeTextPainter(true);
            }
            if (style == DataTextStyles.DateTime)
            {
                return new DateTimeTextPainter(false);
            }
            if (style == DataTextStyles.DateUTC)
            {
                return new DateTextPainter(true);
            }
            if (style == DataTextStyles.Date)
            {
                return new DateTextPainter(false);
            }
            if (style == DataTextStyles.TimeUTC)
            {
                return new TimeTextPainter(true);
            }
            return new TimeTextPainter(false);
        }

 

        #endregion

    }
}
