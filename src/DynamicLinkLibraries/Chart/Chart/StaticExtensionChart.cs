﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Chart.Drawing.Series;
using Chart.Drawing.Interfaces;
using Chart.UserControls;
using Chart.Indicators;

namespace Chart
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionChart
    {
        /// <summary>
        /// Copies series to clipboard
        /// </summary>
        /// <param name="getter">Getter of series</param>
        public static void CopyToClipboard(this ISeriesGetter getter)
        {
            ISeries s = getter.Series;
            if (s == null)
            {
                return;
            }
            PureSeries ps = new PureSeries();
            ps.Copy(s);
            Clipboard.SetDataObject(ps, false);
        }

        /// <summary>
        /// Loads from clipboard
        /// </summary>
        /// <param name="setter">Setter</param>
        public static void LoadFromClipboard(this ISeriesSetter setter)
        {
            IDataObject dob = Clipboard.GetDataObject();
            string[] form = dob.GetFormats();
            foreach (string f in form)
            {
                Type type = Type.GetType(f + ",Chart.Drawing", false);
                if (type == null)
                {
                    continue;
                }
                if (type.GetInterface(typeof(ISeries).Name) == null)
                {
                    continue;
                }
                ISeries s = dob.GetData(f) as ISeries;
                if (s != null)
                {
                    setter.Series = s;
                    break;
                }
            }
        }

  
        /// <summary>
        /// Sets mouse indicator to control
        /// </summary>
        /// <param name="chart">Chart</param>
        /// <param name="control">Control</param>
        public static void SetMouseIndicator(this UserControlChart chart, object control)
        {
            chart.Performer.SetMouseIndicator(control);
        }

        /// <summary>
        /// Sets mouse indicator to control
        /// </summary>
        /// <param name="performer">Chart performer</param>
        /// <param name="control">Control</param>
        public static void SetMouseIndicator(this ChartPerformer performer, object control)
        {
            MouseChartObjectIndicator ind = new MouseChartObjectIndicator(control);
            performer.Add(ind);
        }


   

    }
}