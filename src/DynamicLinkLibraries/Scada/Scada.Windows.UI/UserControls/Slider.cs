using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomControls.ComboBox;
using CustomControls.Data;

using Scada.Windows.UI.Converters;
using Scada.Interfaces;


namespace Scada.Windows.UI.UserControls
{

    public partial class Slider : UserControl, IScadaConsumer
    {

        private float _val, _max, _min, _step;

        #region Scada Input Fields

  

        string inputString;

        Action<float> input;

        IScadaInterface scada;

        private bool isEnabled;


        #endregion

        public Slider()
        {
            InitializeComponent();
            _val = 0;
            _max = 100;
            _min = 0;
            _step = 1;
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

        public void Reset(float max, float min)
        {
            if (max < min) max = min + 100;
            _val = min;
            _max = max;
            _min = min;
            _step = (max - min) / 100;
            resize();
        }

        [DefaultValue("")]
        [Editor(typeof(ListGridComboBox), typeof(UITypeEditor))]
        [DataList("GetInputs")]
        [TypeConverter(typeof(ListExpandableConverter))]
        [Category("SCADA"), Description("Input name"), DisplayName("Input")]
        public string Output
        {
            get
            {
                return inputString;
            }
            set
            {
                inputString = value;
            }
        }

        private List<string> GetInputs()
        {
            return StaticExtensionWindowsUI.Scada.GetRealList(true);
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

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        private void resize()
        {
            base.Width = 90;
            base.Height = 40 + Convert.ToInt32((_max - _min) / _step);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                float temp = _val;
                int l = e.Y;
                if (l < 20) l = 20;
                int size = Convert.ToInt32((_max - _min) / _step);
                if (l > (20 + size)) l = 20 + size;
                _val = _min + ((20 + size - l) * _step);
                if (temp != _val)
                {
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    float temp = _val;
                    int l = e.Y;
                    if (l < 20) l = 20;
                    int size = Convert.ToInt32((_max - _min) / _step);
                    if (l > (20 + size)) l = 20 + size;
                    _val = _min + ((20 + size - l) * _step);
                    if (temp != _val)
                    {
                        OnValueChanged();
                        base.Invalidate();
                        base.Update();
                    }
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                float temp = _val;
                if (e.Delta > 0)
                {
                    _val = _val + _step;
                    if (_val > _max) _val = _max;
                }
                if (e.Delta < 0)
                {
                    _val = _val - _step;
                    if (_val < _min) _val = _min;
                }
                if (temp != _val)
                {
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int size = Convert.ToInt32((_max - _min) / _step);
            int suw = Convert.ToInt32((_val - _min) / _step);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 90, size + 40);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 39, 89, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 38, 89, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Black), 89, 0, 89, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 88, 0, 88, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 89, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 88, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size + 38);
                e.Graphics.DrawLine(new Pen(Color.White), 25, 20, 25, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.White), 15, 20 + size, 25, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 15, 20, 15, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 15, 20, 25, 20);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 10, 20 + size - suw - 4, 20, 9);
                e.Graphics.DrawLine(new Pen(Color.Black), 10, 20 + size - suw + 4, 30, 20 + size - suw + 4);
                e.Graphics.DrawLine(new Pen(Color.Black), 30, 20 + size - suw + 4, 30, 20 + size - suw - 4);
                e.Graphics.DrawLine(new Pen(Color.White), 10, 20 + size - suw - 4, 30, 20 + size - suw - 4);
                e.Graphics.DrawLine(new Pen(Color.White), 10, 20 + size - suw - 4, 10, 20 + size - suw + 4);
                e.Graphics.DrawLine(new Pen(Color.Red), 20, 20 + size - suw, 30, 20 + size - suw);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), 35, 20 + size - l, 40, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 45, (20 + size - l - 6));
                }
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 39, 89, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 38, 89, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Gray), 89, 0, 89, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 88, 0, 88, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 89, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 88, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Gray), 25, 20, 25, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20 + size, 25, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20, 15, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20, 25, 20);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 10, 20 + size - suw - 4, 20, 9);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20 + size - suw + 4, 30, 20 + size - suw + 4);
                e.Graphics.DrawLine(new Pen(Color.Gray), 30, 20 + size - suw + 4, 30, 20 + size - suw - 4);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20 + size - suw - 4, 30, 20 + size - suw - 4);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20 + size - suw - 4, 10, 20 + size - suw + 4);
                e.Graphics.DrawLine(new Pen(Color.Gray), 20, 20 + size - suw, 30, 20 + size - suw);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), 35, 20 + size - l, 40, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 45, (20 + size - l - 6));
                }
            }
        }
/*
        private void Update()
        {
           input(_val);
        }
*/
        void Slider_ValueChanged(object sender, EventArgs e)
        {
            input(_val);
        }


        protected override void OnLoad(EventArgs e)
        {
            resize();
            base.OnLoad(e);
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
                input = scada.GetFloatInput(inputString);
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
                    this.ValueChanged += Slider_ValueChanged;
                }
                else
                {
                    this.ValueChanged += Slider_ValueChanged;
                }
            }
        }

        #endregion

    }
}