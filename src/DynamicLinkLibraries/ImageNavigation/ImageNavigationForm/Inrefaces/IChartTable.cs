using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageNavigation.Inrefaces
{
    interface IChartTable
    {
        Color Color
        {
            get;
            set;
        }

        bool ShowChart
        {
            get;
            set;
        }

        bool ShowTable
        {
            get;
            set;
        }

        DataPerformer.Series Series
        {
            get;
        }
    }
}
