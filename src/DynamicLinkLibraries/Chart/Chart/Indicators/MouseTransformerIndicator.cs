using Chart.Drawing.Interfaces;
using Chart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Indicators
{
    public class MouseTransformerIndicator : IMouseChartIndicator
    {
        bool isEnabled = true;

        string[] s = new string[2]; 

        public  MouseTransformerIndicator()
        {

        }

        bool IMouseChartIndicator.IsEnabled
        {
            get => isEnabled;

            set
            {
                isEnabled = value;
                Enabled(value);
            }
        }

        void IMouseChartIndicator.Indicate(double x, double y)
        {
            s[0] = "" + x;
            s[1] = "" + y;
            if (X != null)
            {
                s[0] = X(x) + "";

            }
            if (Y != null)
            {
                s[1] = Y(y) + "";
            }
            Action(s);
        }


        public Func<object, object> X 
        {  
            get; 
            set; 
        }

        public Func<object, object> Y 
        { 
            get; 
            set;
        }

        public Action<string[]> Action { get; set; }

        public Action<bool> Enabled { get; set; }

    }
}
