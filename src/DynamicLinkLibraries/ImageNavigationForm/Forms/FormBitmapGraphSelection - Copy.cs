using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using ImageNavigation.Inrefaces;


namespace ImageNavigation.Forms
{
    public partial class FormBitmapGraphSelection : Form, IUpdatableForm
    {
        private BitmapGraphSelection selection;
        
        private IObjectLabel label;

        private FormBitmapGraphSelection()
        {
            InitializeComponent();
        }


        public FormBitmapGraphSelection(IObjectLabel label)
            : this(label, label.Object as BitmapGraphSelection, new ChartTable(label.Object as BitmapGraphSelection))
        {
        }

        internal FormBitmapGraphSelection(IObjectLabel label, BitmapGraphSelection selection, IChartTable ct)
            : this()
        {
            this.label = label;
            UpdateFormUI();
            this.selection = selection;
            userControlBitmapGraphSelectionTab.Selection = selection;
            userControlBitmapGraphSelectionTab.ChartTable = ct;
        }


        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion

 



        class ChartTable : IChartTable
        {
            DataPerformer.Series series;
            internal ChartTable(BitmapGraphSelection chart)
            {
                series = CreateSeries(chart);
            }

            Color IChartTable.Color
            {
                get
                {
                    return Color.Red;
                }
                set
                {
                }
            }

            bool IChartTable.ShowChart
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            bool IChartTable.ShowTable
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            DataPerformer.Series IChartTable.Series
            {
                get { return series; }
            }

            DataPerformer.Series CreateSeries(BitmapGraphSelection selection)
            {
                IMeasurements m = selection;
                if (m.Count < 2)
                {
                    return null;
                }
                double[][] d = new double[][] { (double[])m[0].Parameter(), (double[])m[1].Parameter() };
                DataPerformer.Series series = new DataPerformer.Series();
                Chart.Drawing.Series.SimpleSeries ser = new Chart.Drawing.Series.SimpleSeries();
                int n = d[0].Length;
                for (int i = 0; i < n; i++)
                {
                    double x = d[0][i];
                    double y = d[1][i];
                    series.AddXY(x, y);
                    ser.AddXY(x, y);
                }
                return series;
            }

        }
    }
}
