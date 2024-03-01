using System;
using System.Drawing;
using System.Windows.Forms;

using Chart.Drawing.Interfaces;


namespace Chart.UserControls
{
    /// <summary>
    /// Filled Chart
    /// </summary>
    public partial class UserControlFilledChart : UserControl
    {
       
        /// <summary>
        /// Construcror
        /// </summary>
        public UserControlFilledChart()
        {
            InitializeComponent();
            userControlChart.Prepare();
        }

        /// <summary>
        /// The "is blocked" sign
        /// </summary>
        public bool IsBlocked
        {
            get => userControlChart.Performer.IsBlocked;
            set => userControlChart.Performer.IsBlocked = value;
        }

        /// <summary>
        /// Coordinator
        /// </summary>
        public ICoordPainter Coordinator
        {
            get => userControlChart.Coordinator;
            set => userControlChart.Coordinator = value;
          }

        /// <summary>
        /// Performer
        /// </summary>
        public ChartPerformer Performer
        {
            get
            {
                return userControlChart.Performer;
            }
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="series">Series to add</param>
        /// <param name="color">Color</param>
        public void AddSeries(ISeries series, Color color)
        {
            userControlChart.AddSeries(series, color);
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="series">Series to add</param>
        /// <param name="painter">Painter</param>
        public void AddSeries(ISeries series, ISeriesPainter painter)
        {
            userControlChart.AddSeries(series, painter);
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="s">Series to add</param>
        /// <param name="color">Color</param>
        /// <param name="additional">Additional object</param>
        public void AddSeries(ISeries s, Color color, object additional = null)
        {
            userControlChart.AddSeries(s, color, additional);
        }


        /// <summary>
        /// Removes series
        /// </summary>
        /// <param name="series">Series to remove</param>
        public void RemoveSeries(ISeries series)
        {
            userControlChart.RemoveSeries(series);
        }

        /// <summary>
        /// Removes all series
        /// </summary>
        public void RemoveAll()
        {
            userControlChart.RemoveAll();
        }

        /// <summary>
        /// Sets object
        /// </summary>
        /// <param name="o">The object</param>
        public void SetObject(object o)
        {
            userControlChart.SetObject(o);
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            userControlChart.Performer.RemoveAll();
        }

        /// <summary>
        /// Refresh
        /// </summary>
        public void RefreshAll()
        {
            try
            {
                userControlChart.Performer.RefreshAll();
                userControlChart.Refresh();
            }
            catch (Exception)
            {
            }
        }

    }
}
