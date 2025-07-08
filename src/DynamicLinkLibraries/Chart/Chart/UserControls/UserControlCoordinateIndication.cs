using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Chart;
using Chart.Classes;
using Chart.Interfaces;
using Chart.Drawing.Enums;
using Chart.Drawing.Interfaces;
using Chart.Drawing;

namespace Chart.UserControls
{
    /// <summary>
    /// Coordinate indication
    /// </summary>
    public partial class UserControlCoordinateIndication : UserControl
    {
        #region Fields

        bool horizontal = true;

        ChartPerformer performer;

        Dictionary<DataTextStyles, object> dic;

        Dictionary<object, DataTextStyles> invert;

        object[] o;
        

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlCoordinateIndication()
        {
            InitializeComponent();
            o = new object[] { radioButtonNumber, radioButtonDateTime, radioButtonDate, radioButtonTime, radioButtonDateTimeUTC,
            radioButtonDateUTC, radioButtonTimeUTC};
            dic = StaticChartPerformer.CreateDictionary(o);
            invert = StaticChartPerformer.CreateInvertDictionary(o);
        }

        #endregion


        #region Members

        /// <summary>
        /// Performer of chart drawing
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ChartPerformer Performer
        {
            get
            {
                return performer;
            }
            set
            {
                performer = value;
            }
        }

        /// <summary>
        /// The "horizontal" sign
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Horizontal
        {
            get
            {
                return horizontal;
            }
            set
            {
                horizontal = value;
            }
        }

        #endregion

        /// <summary>
        /// Painter of coordinates
        /// </summary>
        ICoordTextPainter Painter
        {
            get
            {
                ICoordPainter p = performer.Coordinator;
                if (p == null)
                {
                    return null;
                }
                return (horizontal) ? p.X : p.Y;
            }
            set
            {
                ICoordPainter p = performer.Coordinator;
                if (p == null)
                {
                    return;
                }
                if (horizontal)
                {
                    p.X = value;
                }
                else
                {
                    p.Y = value;
                }
            }
        }
        

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            ICoordTextPainter p = Painter;
            if (p == null)
            {
                return;
            }
            foreach (RadioButton rb in o)
            {
                if (rb.Checked)
                {
                    DataTextStyles style = invert[rb];
                    Painter = StaticChartPerformer.Create(style);
                    performer.RefreshAll();
                    return;
                }
            }
        }

   }
}
