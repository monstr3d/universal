using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Chart.Interfaces;
using Chart.Forms;
using Chart.Classes;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Series;

namespace Chart.UserControls
{
    /// <summary>
    /// Chart user control
    /// </summary>
    public partial class UserControlChart : UserControl
    {
        #region Fields

        private ChartPerformer performer;

        private ISeriesSetter setter;

        private ISeriesGetter getter;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlChart()
        {
            InitializeComponent();
        }

        #endregion

        #region Members

   
        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="insets">Insets</param>
        /// <param name="hasStandardHandlers">The has standard handlers sign</param>
        public void Prepare(int[,] insets, bool hasStandardHandlers)
        {
            if (performer != null)
            {
                throw new Exception("Double initialization");
            }
            performer = new ChartPerformer(this, insets, hasStandardHandlers);
            Coordinator = new Drawing.Coordinators.EmptyCoordinator();
            Paint += new PaintEventHandler(OnPaint);
            Resize += new EventHandler(OnResize);
            BackColor = Color.White;
        }

        /// <summary>
        /// The "is blocked" sign
        /// </summary>
        public bool IsBlocked
        {
            get
            {
                if (performer == null)
                {
                    return true;
                }
                return performer.IsBlocked;
            }
            set
            {
                if (performer == null)
                {
                    return;
                }
                performer.IsBlocked = value;
            }
        }

        /// <summary>
        /// Coordinator
        /// </summary>
        public ICoordPainter Coordinator
        {
            get
            {
                if (performer == null)
                {
                    return null;
                }
                return performer.Coordinator;
            }
            set
            {
                if (performer == null)
                {
                    return;
                }
                performer.Coordinator = value;
                RefreshAll();
            }
        }

        /// <summary>
        /// Performer
        /// </summary>
        public ChartPerformer Performer
        {
            get
            {
                return performer;
            }
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="series">Series to add</param>
        /// <param name="color">Color</param>
        public void AddSeries(ISeries series, Color color)
        {
            performer.AddSeries(series, color);
            RefreshAll();
        }
        
        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="series">Series to add</param>
        /// <param name="painter">Painter</param>
        public void AddSeries(ISeries series, ISeriesPainter painter)
        {
            performer.AddSeries(series, painter);
            RefreshAll();
        }

        /// <summary>
        /// Removes series
        /// </summary>
        /// <param name="series">Series to remove</param>
        public void RemoveSeries(ISeries series)
        {
            performer.Remove(series);
            RefreshAll();
        }

        /// <summary>
        /// Removes all series
        /// </summary>
        public void RemoveAll()
        {
            performer.RemoveAll();
            RefreshAll();
        }

        /// <summary>
        /// Sets object
        /// </summary>
        /// <param name="o">The object</param>
        public void SetObject(object o)
        {
            if (o is ISeriesSetter)
            {
                setter = o as ISeriesSetter;
                pasteToolStripMenuItem.Visible = true;
            }
            if (o is ISeriesGetter)
            {
                getter = o as ISeriesGetter;
                copySeriesToolStripMenuItem.Visible = true;
            }
        }

        /// <summary>
        /// The OnPaint event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        protected void OnPaint(object sender, PaintEventArgs e)
        {
            if (performer.IsBlocked)
            {
                return;
            }
            performer.Paint(e.Graphics);
        }

        /// <summary>
        /// The OnResize Event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        protected void OnResize(object sender, EventArgs e)
        {
            if (performer.IsBlocked)
            {
                return;
            }
            try
            {
                performer.Resize();
                RefreshAll();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Refresh
        /// </summary>
        protected void RefreshAll()
        {
            try
            {
                performer.RefreshAll();
                Refresh();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Event handlers

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image im = performer.Image;
            if (im != null)
            {
                Clipboard.SetImage(im);
            }
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTextStyleEditor f = new FormTextStyleEditor();
            f.Performer = performer;
            f.ShowDialog();
        }

        private void copySeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getter.CopyToClipboard();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject dob = Clipboard.GetDataObject();
            string[] f = dob.GetFormats();
        }

        #endregion
    }
}
