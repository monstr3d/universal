using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Chart.UserControls
{
    public partial class UserControlChartDriver : UserControl
    {
        #region Fields

        UserControlExternalChart chart;

      //  ChartPerformer performer;

        #endregion

        #region Fields

        internal UserControlChartDriver(UserControlExternalChart chart)
        {
            InitializeComponent();
            this.chart = chart;
        }

        #endregion

        #region Members


        #endregion

    }
}
