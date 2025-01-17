using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Diagram.UI;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;

using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;

using Chart;
using Chart.Panels;
using Chart.Interfaces;
using Chart.Utils;

using DataPerformer.UI;
using ImageNavigation.Inrefaces;
using ErrorHandler;

namespace ImageNavigation.UserControls
{
    public partial class UserControlBitmapGraphSelection : UserControl, Chart.Drawing.Interfaces.ISeriesGetter, IEnabled
    {

        #region Fields

        Color[] color;

        bool vis = false;


        BitmapGraphSelection selection;

        Chart.Drawing.Series.SimpleSeries ser;

        DataPerformer.Series series;

        event Action<bool, Color> changeState = (bool b, Color c) => { };

       CrossSeriesPainter painter = new Chart.Drawing.Painters.CrossSeriesPainter(new Color[] { Color.Black });


        bool enabled = true;

        IChartTable ct;
 
        #endregion


        public UserControlBitmapGraphSelection()
        {
            InitializeComponent();
            userControlChart.Prepare(new int[,] { { 80, 30 }, { 10, 40 } }, true);
            userControlChart.Coordinator = new SimpleCoordinator(5, 5);
            userControlChart.SetObject(this);
        }


        #region ISeriesGetter Members

        Chart.Drawing.Interfaces.ISeries Chart.Drawing.Interfaces.ISeriesGetter.Series
        {
            get { return Series; }
        }

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (value == enabled)
                {
                    return;
                }
                enabled = value;
                Control c = this;
                c.Enabled = enabled;
                if (enabled)
                {
                    toolStripButtonActive.CheckedChanged -= Set;
                    pic.SelectedColorChanged -= Set;
                    if (ct != null)
                    {
                        color = new Color[] { ct.Color };
                        pic.Color = color[0];
                        vis = ct.ShowChart;
                        toolStripButtonActive.Checked = vis;
                        InitEventHandles();
                        Draw();
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// The "strip visible" sign
        /// </summary>
        public bool StripVisible
        {
            get
            {
                return toolStrip.Visible;
            }
            set
            {
                toolStrip.Visible = value;
            }
        }

        /// <summary>
        /// Change state event
        /// </summary>
        public event Action<bool, Color> ChangeState
        {
            add { changeState += value; }
            remove { changeState -= value; }
        }

        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get
            {
                return color[0];
            }
            set
            {
                color = new Color[] { value };
            }
        }

        /// <summary>
        /// The "show" sign
        /// </summary>
        public new bool Show
        {
            get
            {
                return vis;
            }
            set
            {
                vis = value;
            }

        }

        internal ChartPerformer Performer
        {
            get
            {
                return userControlChart.Performer;
            }
        }

        internal IChartTable ChartTable
        {
            set
            {
                ct = value;
            }
        }

        internal DataPerformer.Series DataSeries
        {
            get
            {
                CreateSeries();
                return series;
            }
        }

        public Chart.Drawing.Series.SimpleSeries Series
        {
            get
            {
                CreateSeries();
                return ser;
            }
        }

        

        internal void UpdateCtrl()
        {
            if (!StripVisible)
            {
                return;
            }
            pic.Color = color[0];
            toolStripButtonActive.Checked = Show;
        }

        void Set(object o, EventArgs e)
        {
            vis = toolStripButtonActive.Checked;
            color = new Color[] { pic.Color };
            changeState(vis, color[0]);
            Draw();
        }

        internal void Set(Color color, bool show)
        {
            this.color = new Color[] { color };
            vis = show;
            Draw();
        }

        void InitEventHandles()
        {
            if (!StripVisible)
            {
                return;
            }
            toolStripButtonActive.CheckedChanged += Set;
            pic.SelectedColorChanged += Set;
        }

        void CreateSeries()
        {
            if (series != null)
            {
                return;
            }
            if (selection == null)
            {
                return;
            }
            IMeasurements m = selection;
            if (m.Count < 2)
            {
                return;
            }
            double[][] d = new double[][] { (double[])m[0].Parameter(), (double[])m[1].Parameter() };
            series = new DataPerformer.Series();
            ser = new Chart.Drawing.Series.SimpleSeries();
            int n = d[0].Length;
            for (int i = 0; i < n; i++)
            {
                double x = d[0][i];
                double y = d[1][i];
                series.AddXY(x, y);
                ser.AddXY(x, y);
            }
        }

        internal BitmapGraphSelection Selection
        {
            get
            {
                return selection;
            }
            set
            {
                selection = value;
            }
        }

        internal void Post()
        {
            UpdateCtrl();
            Draw();
            InitEventHandles();
        }

        internal void Save()
        {
            try
            {
                series.Save(this);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        internal void Draw()
        {
            userControlChart.Performer.RemoveAll();
            if (!Show)
            {
                userControlChart.Refresh();
                return;
            }
            
            CreateSeries();
            painter.Color = color;
            userControlChart.Performer.AddSeries(ser, painter);
            userControlChart.Performer.RefreshAll();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

    }
}
