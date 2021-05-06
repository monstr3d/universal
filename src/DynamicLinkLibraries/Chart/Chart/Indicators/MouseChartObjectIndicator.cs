using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


using Chart.Interfaces;
using Chart.UserControls;

namespace Chart.Indicators
{
    /// <summary>
    /// Object indicator
    /// </summary>
    public class MouseChartObjectIndicator : IMouseChartIndicator
    {
        #region Fields

        object control;

        private bool enabled;

        private static readonly string[] texts = { "X = ", " Y = " };


        private PropertyInfo pi;
        
        private PropertyInfo pv;

        #endregion

        #region Ctor

        internal MouseChartObjectIndicator(object control)
        {
            this.control = control;
            Type t = control.GetType();
            pi = t.GetProperty("Text");
            pv = t.GetProperty("Visible");
        }

        #endregion

        #region IMouseChartIndicator Members

        void IMouseChartIndicator.Indicate(double x, double y)
        {
            if (!enabled)
            {
                return;
            }
            string s = "X = " + x + "; Y = " + y + ";";
            pi.SetValue(control, s, null);
        }

        bool IMouseChartIndicator.IsEnabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
                if (!value)
                {
                    pi.SetValue(control, "", null);
                }
            }
        }
 
        #endregion

    }
}
