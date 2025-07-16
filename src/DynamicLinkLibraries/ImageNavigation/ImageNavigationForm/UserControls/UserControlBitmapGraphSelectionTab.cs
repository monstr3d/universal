using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Chart;


using ImageNavigation.Inrefaces;

namespace ImageNavigation.UserControls
{
    public partial class UserControlBitmapGraphSelectionTab : UserControl
    {

        #region  Fields

        IChartTable ct;

        BitmapGraphSelection selection;

        #endregion


        public UserControlBitmapGraphSelectionTab()
        {
            InitializeComponent();
            userControlBitmapChartSelection.Performer.SetMouseIndicator(labelStatus);
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal BitmapGraphSelection Selection
        {
            set
            {
                selection = value;
                userControlBitmapChartSelection.Selection = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal IChartTable ChartTable
        {
            set
            {
                ct = value;
                DataPerformer.Series s = ct.Series;
                labelNumOfPoints.Text = "Number: " + s.Count;
                pic.Color = ct.Color;
                toolStripButtonActive.Checked = ct.ShowChart;
                userControlBitmapChartSelection.Set(ct.Color, ct.ShowChart);
                checkBoxShow.Checked = ct.ShowTable;
                InitEventHandlers();
            }
        }

        private void Set(object sender, EventArgs e)
        {
            userControlBitmapChartSelection.Set(pic.Color, toolStripButtonActive.Checked);
            ct.Color = pic.Color;
            ct.ShowChart = toolStripButtonActive.Checked;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            userControlBitmapChartSelection.Save();
        }

        void InitEventHandlers()
        {
            pic.SelectedColorChanged += Set;
            toolStripButtonActive.CheckedChanged += Set;
        }

        void ShowTable()
        {
            bool b = checkBoxShow.Checked;
            ct.ShowTable = b;
            if (!b)
            {
                dataGridView.Rows.Clear();
                return;
            }
            DataPerformer.Series s = ct.Series;
            for (int i = 0; i < s.Count; i++)
            {
                object[] o = new object[] { s[i, 0], s[i, 1] };
                dataGridView.Rows.Add(o);
            }
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

    }
}
