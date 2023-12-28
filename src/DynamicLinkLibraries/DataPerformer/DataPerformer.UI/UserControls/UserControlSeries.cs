using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer;

using DataPerformer.UI.Labels;

using ToolBox;

using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;

using Chart;
using Chart.Panels;
using Chart.Interfaces;
using Chart.Utils;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control for series
    /// </summary>
    public partial class UserControlSeries : UserControl, ISeriesGetter, ISeriesSetter,
        IEnabled
    {

        #region Fields

        /// <summary>
        /// Series
        /// </summary>
        protected DataPerformer.Series series;

        /// <summary>
        /// Desktop
        /// </summary>
        protected IDesktop desktop;

        /// <summary>
        /// Chart performer
        /// </summary>
        protected ChartPerformer performer;


        private SeriesPainterControlPovider painterProvider;

        private ISeriesPainterPovider painterInreface;



        private Action<bool> upatateTable = (bool b) => { };

        #endregion

        #region Ctor
     
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlSeries()
        {
            InitializeComponent();
            PreInit();
            toolStripLabelCoord.Text = "";
        }

        #endregion

        #region ISeriesGetter Members

        ISeries ISeriesGetter.Series
        {
            get
            {
                return DrawSeries;
            }
        }

        #endregion

        #region ISeriesSetter Members

        ISeries ISeriesSetter.Series
        {
            set
            {
                series.Clear();
                IList<IPoint> l = value.Points;
                foreach (IPoint p in l)
                {
                    series.AddXY(p.X, p.Y[0]);
                }
                Show();
            }
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
                    Show();
                }
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Provider of painter
        /// </summary>
        public SeriesPainterControlPovider PainterProvider
        {
            get
            {
                return painterProvider;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                painterProvider = value;
                painterInreface = value;
            }
        }


        /// <summary>
        /// Post operation
        /// </summary>
        public virtual void Post()
        {
            if (series != null)
            {
                ArrayList graphControls = series.Comments;
                ControlPanel.LoadControls(panelGraph, graphControls);
            }
            Show();
            panelGraph.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// Series
        /// </summary>
        protected virtual ISeries DrawSeries
        {
            get
            {
                Chart.Drawing.Series.PureSeries ps = new Chart.Drawing.Series.PureSeries();
                for (int i = 0; i < series.Count; i++)
                {
                    ps.AddXY(series[i, 0], series[i, 1]);
                }
                return ps;
            }
        }

        /// <summary>
        /// Comments
        /// </summary>
        public virtual ICollection[] Comments
        {
            get
            {
                if (painterProvider == null)
                {
                    return new ICollection[0];
                }
                return painterProvider.Array.GetComments();
            }
            set
            {
                if (painterProvider != null)
                {
                    painterProvider.Array.SetComments(value);
                }
                //return;
                /*if (panelBottom.Height < 2)
                {
                    panelBottom.Height = 50;
                    panelLeft.Width = 50;
                }
                userControlCommentsLeft.Comments = value[0];
                userControlCommentsBottom.Comments = value[1];*/
            }
        }

        /// <summary>
        /// Shows all series
        /// </summary>
        public void ShowAll()
        {
            Show();
        }


        /// <summary>
        /// Pre initialization
        /// </summary>
        protected virtual void PreInit()
        {
            pic.Text = ResourceService.Resources.GetControlResource("Color", DataPerformer.UI.Utils.ControlUtilites.Resources);
            PanelChart panel = new PanelChart(new int[,] { { 80, 30 }, { 10, 40 } });
            panel.SetObject(this);
            panelGraph.DragEnter += fileDragEnter;
            panelGraph.DragDrop += fileDragDrop;
            performer = panel.Performer;
            panelGraph.Controls.Add(panel);
            panel.LoadResources();
            panel.Dock = DockStyle.Fill;
            performer.Resize();
            SimpleCoordinator coordinator = new SimpleCoordinator(5, 5, performer);
            performer.Coordinator = coordinator;
            EditorReceiver.AddEditorDrag(panelGraph);
            PictureReceiver.AddImageDrag(panelGraph);
        }

        /// <summary>
        /// Shows itself
        /// </summary>
        new protected virtual void Show()
        {
            ShowInternal();
        }

        #endregion

        #region Private and Internal Members


        internal void ShowInternal()
        {
            performer.RemoveAll();
            if (painterInreface != null)
            {
                ISeriesPainter sp = painterInreface.Painter;
                if (sp != null)
                {
                    SeriesGraph ser = new SeriesGraph(series);
                    performer.AddSeries(ser, sp);
                }
                performer.RefreshAll();
            }
        }

        internal ChartPerformer Performer
        {
            get
            {
                return performer;
            }
        }


        internal virtual DataPerformer.Series Series
        {
            get
            {
                return series;
            }
            set
            {
                series = value;
            }
        }

        internal void ShowStrip(bool show, object[] array = null)
        {
            if (show)
            {
                object[] arr = array;
                if (arr == null)
                {
                    arr = StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray;
                }
                performer.SetMouseIndicator(toolStripLabelCoord);
                painterProvider =
                new SeriesPainterControlPovider(toolStripButtonType,
                    pic, arr);
                painterInreface = painterProvider;

            }
            else
            {
                toolStripMain.Visible = false;
            }
        }





        internal object[] Array
        {
            set
            {
                painterProvider.Array = value;
            }
            get
            {
                return painterProvider.Array;
            }
        }


 
        internal void Save()
        {
            try
            {
                StaticExtensionDataPerformerUI.Save(series, this);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        internal void Open()
        {
            try
            {
                StaticExtensionDataPerformerUI.Load(this, series);
                Show();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }


         private void fileDragEnter(object sender, DragEventArgs e)
        {
            IDataObject d = e.Data;
            if (d.GetDataPresent("FileNameW"))
            {
                object[] o = d.GetData("FileNameW") as object[];
                string fn = o[0] as string;
                string ex = System.IO.Path.GetExtension(fn);
                if (ex.ToLower().Equals(".gra"))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void fileDragDrop(object sender, DragEventArgs e)
        {
            IDataObject d = e.Data;
            if (d.GetDataPresent("FileNameW"))
            {
                object[] o = d.GetData("FileNameW") as object[];
                string fn = o[0] as string;
                string ex = System.IO.Path.GetExtension(fn);
                if (ex.ToLower().Equals(".gra"))
                {
                    series.Load(fn);
                    ShowAll();
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }


        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        #endregion

    }
}
