using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;


using CustomControls.ComboBox;
using CustomControls.Data;

using Scada.Windows.UI.Converters;
using Scada.Interfaces;


namespace Scada.Windows.UI.UserControls
{

    /// <summary>
    /// Term Control
    /// </summary>
    public partial class Term : UserControl, IScadaConsumer
    {
        private float _val, _max, _min, _step;

        #region Scada Input Fields

        string eventString;

        string outputString;

        Func<float> output;

        IScadaInterface scada;

        IEvent eventObject;
       
        bool isEnabled = false;
  
        #endregion

        public Term()
        {
            InitializeComponent();
            _val = 0;
            _max = 100;
            _min = 0;
            _step = 1;
        }

        #region IScadaConsumer Members

        IScadaInterface IScadaConsumer.Scada
        {
            get
            {
                return scada;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                scada = value;
                eventObject = scada[eventString];
                output = scada.GetFloatOutput(outputString);
                scada.AddEventOutput(eventString, outputString);
            }
        }

        bool IScadaConsumer.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                if (value)
                {
                    eventObject.Event += Set;
                }
                else
                {
                    eventObject.Event -= Set;
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event string
        /// </summary>
        [DefaultValue("")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [DataList("GetEvents")]
        [TypeConverter(typeof(ListExpandableConverter))]
        [Category("SCADA"), Description("Event name"), DisplayName("Event")]
        public string Event
        {
            get
            {
                return eventString;
            }
            set
            {
                eventString = value;
            }
        }

        /// <summary>
        /// Output string
        /// </summary>
        [DefaultValue("")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [DataList("GetOutputs")]
        [TypeConverter(typeof(ListExpandableConverter))]
        [Category("SCADA"), Description("Output name"), DisplayName("Output")]
        public string Output
        {
            get
            {
                return outputString;
            }
            set
            {
                outputString = value;
            }
        }

        #endregion

        private List<string> GetOutputs()
        {
            return StaticExtensionWindowsUI.Scada.GetRealList(false);
        }



        private List<string> GetEvents()
        {
            return StaticExtensionWindowsUI.Scada.Events;
        }

        
        public void Set(float val)
        {
            if (base.Enabled)
            {
                float temp = _val;
                if (val > _max) val = _max;
                if (val < _min) val = _min;
                _val = val;
                if (temp != _val)
                {
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
            }
        }

        void Set()
        {
            Set(output());
        }

        public void Reset(float max, float min)
        {
            if (max < min) max = min + 100;
            _val = min;
            _max = max;
            _min = min;
            _step = (max - min) / 100;
            resize();
        }

        public void Reset(float max, float min, float step)
        {
            if (max < min) max = min + 100;
            if (step > ((max - min) / 10)) step = (max - min) / 10;
            _val = min;
            _max = max;
            _min = min;
            _step = step;
            resize();
        }

        public void Reset(float val, float max, float min, float step)
        {
            if (max < min) max = min + 100;
            if (step > ((max - min) / 10)) step = (max - min) / 10;
            if (val > max) val = max;
            if (val < min) val = min;
            _val = val;
            _max = max;
            _min = min;
            _step = step;
            resize();
        }

        public float Val
        {
            get
            {
                return _val;
            }
        }

        public float Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }

        public float Min
        {
            get
            {
                return _min;
            }
            set
            {
                _min = value;
            }
        }

        public float Step
        {
            get
            {
                return _step;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int size = Convert.ToInt32((_max - _min) / _step);
            int bar = Convert.ToInt32((_val - _min) / _step);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 80, size + 40);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 39, 79, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 38, 79, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Black), 79, 0, 79, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 78, 0, 78, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 79, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 78, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size + 38);
                e.Graphics.FillPie(new SolidBrush(Color.Black), 10, 15, 10, 10, 180, 180);
                e.Graphics.FillPie(new SolidBrush(Color.LightBlue), 11, 16, 8, 8, 180, 180);
                e.Graphics.DrawLine(new Pen(Color.Black), 10, 20, 10, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 19, 20, 19, 20 + size);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), 11, 20, 8, size);
                e.Graphics.FillPie(new SolidBrush(Color.Black), 10, 15 + size, 10, 10, 0, 180);
                e.Graphics.FillPie(new SolidBrush(Color.Red), 11, 16 + size, 8, 8, 0, 180);
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), 11, 20 + size - bar, 8, bar);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), 25, 20 + size - l, 30, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 35, (20 + size - l - 6));
                }
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 39, 79, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 38, 79, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Gray), 79, 0, 79, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 78, 0, 78, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 79, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 78, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size + 38);
                e.Graphics.FillPie(new SolidBrush(Color.Gray), 10, 15, 10, 10, 180, 180);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 11, 16, 8, 8, 180, 180);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20, 10, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 19, 20, 19, 20 + size);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 11, 20, 8, size);
                e.Graphics.FillPie(new SolidBrush(Color.Gray), 10, 15 + size, 10, 10, 0, 180);
                e.Graphics.FillPie(new SolidBrush(Color.DarkGray), 11, 16 + size, 8, 8, 0, 180);
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), 11, 20 + size - bar, 8, bar);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), 25, 20 + size - l, 30, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 35, (20 + size - l - 6));
                }
            }
        }

        private void resize()
        {
            base.Width = 80;
            base.Height = 40 + Convert.ToInt32((_max - _min) / _step);
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            resize();
            base.OnLoad(e);
        }

     }
}