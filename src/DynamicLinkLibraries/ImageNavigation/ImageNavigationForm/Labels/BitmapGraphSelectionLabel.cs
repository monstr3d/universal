using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;

using CategoryTheory;


using Diagram.UI.Labels;
using ImageNavigation.UserControls;
using ImageNavigation.Inrefaces;
using ImageNavigation.Forms;
using ImageNavigationForm.Properties;

namespace ImageNavigation.Labels
{
    [Serializable()]
    public class BitmapGraphSelectionLabel : UserControlBaseLabel, IPostSetArrow, IChartTable
    {
        #region Fields

        Color color;

        bool showChart = false;

        bool showTable = false;

        UserControlBitmapGraphSelection uc;

        BitmapGraphSelection selection;

        bool first = true;

        FormBitmapGraphSelection form;
   
        #endregion

        #region Ctor

        public BitmapGraphSelectionLabel()
            : base(typeof(BitmapGraphSelection), "",  Resources.BitmapGraphSelection.ToBitmap())
        {
        }

        protected BitmapGraphSelectionLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden

        protected override UserControl Control
        {
            get 
            {
                uc = new UserControlBitmapGraphSelection();
                uc.ChartTable = this;
                uc.ChangeState += (bool b, Color c) => { showChart = b; color = c; };
                return uc;
            }
        }

        protected override ICategoryObject Object
        {
            get
            {
                return selection;
            }
            set
            {
                selection = value as BitmapGraphSelection;
                uc.Selection = selection;
            }
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            color = (Color)info.GetValue("Color", typeof(Color));
            showChart = info.GetBoolean("ShowChart");
            showTable = info.GetBoolean("ShowTable");
        }

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Color", color, typeof(Color));
            info.AddValue("ShowChart", showChart);
            info.AddValue("ShowTable", showTable);
        }


        public override void CreateForm()
        {
            form = new FormBitmapGraphSelection(this, selection, this);
        }

        public override object Form
        {
            get
            {
                return form;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (!first)
            {
                return;
            }
            first = false;
            uc.Show = showChart;
            uc.Color = color;
            uc.Post();
        }

        #endregion


        #region Own Members


        #endregion

        #region IChartTable Members

        Color IChartTable.Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        bool IChartTable.ShowChart
        {
            get
            {
                return showChart;
            }
            set
            {
                showChart = value;
            }
        }

        bool IChartTable.ShowTable
        {
            get
            {
                return showTable;
            }
            set
            {
                showTable = value;
            }
        }


        DataPerformer.Series IChartTable.Series
        {
            get { return uc.DataSeries; }
        }

        #endregion
    }
}
