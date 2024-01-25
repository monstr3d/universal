using CategoryTheory;
using DataPerformer.UI.Interfaces;
using Diagram.UI;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Trading.Library.Forms.UserControls;

namespace Trading.Library.Forms.Labels
{
    [Serializable()]
    public class OrderLabel : UserControlBaseLabel, IColorDictionary
    {
        UserControlOrder control = new UserControlOrder();

        Objects.Order order;

        Form form;

        public OrderLabel() :
            base(typeof(Serializable.Objects.Order), "",
                Properties.Resources.bundle.ToBitmap())
        {

        }

        protected OrderLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                colorDictionary = info.GetValue("ColorDictionary", typeof(Dictionary<string, Dictionary<string, Color>>))
                    as Dictionary<string, Dictionary<string, Color>>;
                StateOfWindow = info.GetInt32("WindowState");
                LeftSplit = info.GetInt32("LeftSplit");
                ChartSplit = info.GetInt32("ChartSplit");
            }
            catch 
            { 
            
            }
        }

        public int StateOfWindow
        {
            get;
            set;
        } = 0;

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ColorDictionary", colorDictionary, typeof(Dictionary<string, Dictionary<string, Color>>));
            info.AddValue("WindowState", StateOfWindow);
            info.AddValue("LeftSplit", LeftSplit);
            info.AddValue("ChartSplit", ChartSplit);
        }





        public override ICategoryObject Object
        {
            get => order;
            set
            {
                if (!(value is Objects.Order))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                order = value as Objects.Order;
                value.Object = this;
                control.Order = order;

            }
        }

        protected override UserControl Control => control;

        public override object Form
        {
            get
            {
                if (form == null) 
                { 
                    form = Get; 
                }
                if (form.IsDisposed) 
                { 
                    form = Get;
                }
                return form;
            }
        }

        private Form Get => new Forms.FormOrder(this, order);

        Dictionary<string, Dictionary<string, Color>> colorDictionary
        {
            get;
            set;
        } = new Dictionary<string, Dictionary<string, Color>>();
 
        public int WindowState
        {
            get;
            set;
        }

        internal int LeftSplit
        {
            get;
            set;
        } = 0;

        internal int ChartSplit
        {
            get;
            set;
        } = 0;

         Dictionary<string, Dictionary<string, Color>> IColorDictionary.ColorDictionary { get => colorDictionary; set => colorDictionary = value; }
    }
}