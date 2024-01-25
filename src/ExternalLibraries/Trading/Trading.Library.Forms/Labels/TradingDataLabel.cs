using CategoryTheory;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trading.Library.Forms.UserControls;
using Trading.Library.Serializable.Objects;

namespace Trading.Library.Forms.Labels
{
    [Serializable()]
    public class TradingDataLabel : UserControlBaseLabel
    {
        UserControlTradingData control = new UserControlTradingData();



        DataQuery dataQuery;
        public TradingDataLabel() : 
            base(typeof(Trading.Library.Serializable.Objects.DataQuery), "", 
                Properties.Resources.ib_data.ToBitmap())
        { }

        protected TradingDataLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }



        public override ICategoryObject Object 
        { 
            get => dataQuery;
            set
            {
                if (!(value is DataQuery))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                dataQuery = value as DataQuery;
                value.Object = this;
                control.DataQuery = dataQuery;

            }
        }

        protected override UserControl Control => control;
    }
}
