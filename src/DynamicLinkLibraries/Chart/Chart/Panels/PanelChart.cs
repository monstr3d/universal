using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Chart.Forms;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Series;
using Diagram.UI;
using ErrorHandler;

namespace Chart.Panels
{
    /// <summary>
    /// Panel with chart
    /// </summary>
    public partial class PanelChart : Panel
    {
 
        /// <summary>
        /// Performer for chart drawing
        /// </summary>
        protected ChartPerformer performer;

        private ISeriesSetter setter;

        private ISeriesGetter getter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="insets">Insets</param>
        public PanelChart(int[,] insets)
        {
            InitializeComponent();
            performer = new ChartPerformer(this, insets, true);
            Paint += new PaintEventHandler(onPaint);
            Resize += new EventHandler(onResize);
            BackColor = Color.White;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            copySeriesToolStripMenuItem.Click += copySeriesToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            formatToolStripMenuItem.Click += formatToolStripMenuItem_Click;
            contextMenuStripChart.Opening +=
               (object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                bool visible = (!performer.IsMoved & (performer.LastPressed == MouseButtons.Right));
                foreach (ToolStripItem it in contextMenuStripChart.Items)
                {
                    if (it.Visible != visible)
                    {
                        it.Visible = visible;
                    }
                }
            };
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PanelChart()
        {

        }

        /// <summary>
        /// Performer of chart drawing
        /// </summary>
        public ChartPerformer Performer
        {
            get
            {
                return performer;
            }
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
        /// On paint event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        protected void onPaint(object sender, PaintEventArgs e)
        {
            if (performer.IsBlocked)
            {
                return;
            }
            performer.Paint(e.Graphics);
        }

        /// <summary>
        /// On resize event handler
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        protected void onResize(object sender, EventArgs e)
        {
            if (performer.IsBlocked)
            {
                return;
            }
            performer.Resize();
            performer.RefreshAll();
        }

        private void copy(object sender, EventArgs e)
        {
            copy();
        }

        private void copy()
        {
            Image im = performer.Image;
            if (im != null)
            {
                Clipboard.SetImage(im);
            }
        }

        #region Event Handlers

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
            try
            {
                ISeries s = getter.Series;
                if (s == null)
                {
                    return;
                }
                PureSeries ps = new PureSeries();
                ps.Copy(s);
                Clipboard.SetDataObject(ps);
            }
            catch (Exception ex) 
            {
                ex.HandleException();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setter.LoadFromClipboard();
        }

        #endregion
    }
}
