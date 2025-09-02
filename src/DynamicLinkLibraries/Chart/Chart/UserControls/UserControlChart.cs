using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Chart.Forms;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Painters;
using Chart.Drawing;

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
        public void Prepare(int[,] insets, bool hasStandardHandlers = true)
        {
            if (performer != null)
            {
                throw new ErrorHandler.OwnException("Double initialization");
            }
            performer = new ChartPerformer(this, insets, hasStandardHandlers);
            Coordinator = new Drawing.Coordinators.SimpleCoordinator();
            Paint += new PaintEventHandler(OnPaint);
            Resize += new EventHandler(OnResize);
            BackColor = Color.White;
        }

        /// <summary>
        /// Preparation
        /// </summary>
        public void Prepare()
        {
            Prepare(new int[,] { { 50, 5 }, { 5, 50 } });
        }

        /// <summary>
        /// The "is blocked" sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBlocked
        {
            get => (performer == null) ? false : performer.IsBlocked;
            set
            {
                if (performer != null) performer.IsBlocked = value;
            }
        }

        /// <summary>
        /// Coordinator
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
                if (value == null)
                {
                    return;
                }
                if (performer == null)
                {
                    return;
                }
                performer.Coordinator = value;
                RefreshAll();
            }
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            performer.RemoveAll();
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
            if (painter.Performer == null) 
            {
                painter.Performer = performer;
            }
            performer.AddSeries(series, painter);
            RefreshAll();
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="s">Series to add</param>
        /// <param name="color">Color</param>
        /// <param name="additional">Additional object</param>
        public void AddSeries(ISeries s, Color color, object additional = null)
        {
            var t = new Tuple<ISeries, Color[], Drawing.ChartPerformer, object>(s, [color], performer, additional);
            var p = t.ToSeriesPainter();
            if (p == null)
            {
                p = new SimpleSeriesPainter([color]);
            }
            AddSeries(s, p);
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
