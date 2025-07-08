using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI.Interfaces;

using Diagram.UI;
using Diagram.UI.Utils;

using DataPerformer.Interfaces;

using Chart.Drawing.Interfaces;

using Chart;
using Chart.Utils;
using Chart.Indicators;
using Chart.Drawing.Coordinators;
using Chart.Drawing;
using ErrorHandler;


namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Control for series with named coordinates
    /// </summary>
    public partial class UserControlNamedSeries : UserControl, ISeriesGetter, IEnabled
    {

        #region Fields

        INamedCoordinates nc;

        SeriesPainterControlPovider painterProvider;


        ISeriesPainterPovider painterInreface;

        ToolStripComboBox[] boxes;

        string x = null;
        string y = null;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlNamedSeries()
        {
            InitializeComponent();
            userControlChart.Prepare(new int[,] { { 80, 30 }, { 10, 40 } }, true);
            userControlChart.Coordinator = new Chart.Drawing.Coordinators.SimpleCoordinator(5, 5);
            userControlChart.SetObject(this);
            toolStripLabelCoord.Text = "";
        }

        #endregion

        #region IEnabled Members

        bool IEnabled.Enabled
        {
            get
            {
                return false;
            }
            set
            {
                if (value)
                {
                    painterProvider.Array = painterProvider.Array;
                    Fill();
                    ShowChart();
                }
            }
        }

        #endregion

        #region ISeriesGetter Members

        ISeries ISeriesGetter.Series
        {
            get { return DrawSeries; }
        }

        #endregion

        #region Public and Protected Members

        /// <summary>
        /// Provider of painter
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SeriesPainterControlPovider PainterProvider
        {
            get
            {
                return painterProvider;
            }
            set
            {
                painterProvider = value;
                painterInreface = value;
            }
        }

        /// <summary>
        /// Chart performer
        /// </summary>
        public Chart.ChartPerformer Performer
        {
            get
            {
                return userControlChart.Performer;
            }
        }

        /// <summary>
        /// Series
        /// </summary>
        protected virtual Chart.Drawing.Interfaces.ISeries DrawSeries
        {
            get
            {
                DataPerformer.Series series = nc as DataPerformer.Series;
                Chart.Drawing.Series.PureSeries ps = new Chart.Drawing.Series.PureSeries();
                for (int i = 0; i < series.Count; i++)
                {
                    ps.AddXY(series[i, 0], series[i, 1]);
                }
                return ps;
            }
        }

        #endregion

        #region Own members


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal object[] Array
        {
            get
            {
                return painterProvider.Array;
            }
            set
            {
                painterProvider.Array = value;
            }
        }

        internal void SetToolStrip(bool tool)
        {
            if (!tool)
            {
                toolStripMain.Visible = false;
                return;
            }
            painterProvider = new SeriesPainterControlPovider(toolStripButtonType, pic, StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray);
            painterInreface = painterProvider;
            userControlChart.SetMouseIndicator(toolStripLabelCoord);
            boxes = new ToolStripComboBox[] { toolStripComboBoxX, toolStripComboBoxY };
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ToolStripComboBox[] Boxes
        {
            set
            {
                boxes = value;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal INamedCoordinates NamedCoordinates
        {
            get
            {
                return nc;
            }
            set
            {
                nc = value;
            }

        }

        internal void ShowAll()
        {
            if ((boxes[0].Items.Count == 0) | (boxes[1].Items.Count == 0))
            {
                Fill();
                return;
            }
            object[] ob = new object[] { boxes[0].SelectedItem, boxes[1].SelectedItem };
            if ((ob[0] == null) | (ob[1] == null))
            {
                return;
            }
            string xx = ob[0] + "";
            string yy = ob[1] + "";
            if (!xx.Equals(x) | !yy.Equals(y))
            {
                nc.Set(xx, yy);
                x = xx;
                y = yy;
            }
            nc.Update();
            ShowChart();
        }

        void ShowChart()
        {
            Chart.ChartPerformer performer = userControlChart.Performer;
            performer.RemoveAll();
            ISeriesPainter sp = painterInreface.Painter;
            if (sp != null)
            {
                DataPerformer.Series series = nc as DataPerformer.Series;
                SeriesGraph ser = new SeriesGraph(series);
                performer.AddSeries(ser, sp);
            }
            performer.RefreshAll();
        }

        internal void Fill()
        {
            nc.Fill(boxes[0], boxes[1]);
        }

        internal void Save()
        {
            try
            {
                DataPerformer.Series s = nc as DataPerformer.Series;
                StaticExtensionDataPerformerUI.Save(s, this);
            }
            catch (Exception e)
            {
                e.HandleException(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }


        #endregion

        #region Event Handlers

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        #endregion
    }
}
