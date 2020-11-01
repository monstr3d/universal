using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Windows.UI.UserControls
{
    public partial class Knob : UserControl
    {
        public Knob()
        {
            InitializeComponent();
            _val = 0;
            _max = 270;
            _min = 0;
            _step = 1;
        }

        private float _val, _max, _min, _step;

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
            _step = (max - min) / 270;
        }

        public void Reset(float val, float max, float min)
        {
            if (max < min) max = min + 100;
            if (val > max) val = max;
            if (val < min) val = min;
            _val = val;
            _val = min;
            _max = max;
            _min = min;
            _step = (max - min) / 270;
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
        }

        public float Min
        {
            get
            {
                return _min;
            }
        }

        public float Step
        {
            get
            {
                return _step;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                float temp = _val;
                double x = e.X - 50;
                double y = 100 - e.Y - 50;
                double t = Math.Atan2(y, x);
                if (t < (-Math.PI * 0.25) && t > (-Math.PI * 0.5)) t = -Math.PI * 0.25;
                if (t <= (-Math.PI * 0.5) && t > (-Math.PI * 0.75)) t = -Math.PI * 0.75;
                int k = Convert.ToInt32((t * 180) / Math.PI);
                if (k < -90) k = k + 360;
                k = 270 - (k + 45);
                _val = _min + (k * _step);
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
                    double x = e.X - 50;
                    double y = 100 - e.Y - 50;
                    double t = Math.Atan2(y, x);
                    if (t < (-Math.PI * 0.25) && t > (-Math.PI * 0.5)) t = -Math.PI * 0.25;
                    if (t <= (-Math.PI * 0.5) && t > (-Math.PI * 0.75)) t = -Math.PI * 0.75;
                    int k = Convert.ToInt32((t * 180) / Math.PI);
                    if (k < -90) k = k + 360;
                    k = 270 - (k + 45);
                    _val = _min + (k * _step);
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
            int k = Convert.ToInt32((_val - _min) / _step);
            k = (270 - k) - 45;
            double t = (k * Math.PI) / 180;
            int y = Convert.ToInt32(34 * Math.Sin(t));
            int x = Convert.ToInt32(34 * Math.Cos(t));
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 100, 100);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, 99, 99, 99);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, 98, 99, 98);
                e.Graphics.DrawLine(new Pen(Color.Black), 99, 0, 99, 99);
                e.Graphics.DrawLine(new Pen(Color.Black), 98, 0, 98, 99);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 99, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 98, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, 99);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, 98);
                e.Graphics.DrawLine(new Pen(Color.Black), 17, 17, 83, 83);
                e.Graphics.DrawLine(new Pen(Color.Black), 83, 17, 17, 83);
                e.Graphics.DrawLine(new Pen(Color.Black), 5, 50, 95, 50);
                e.Graphics.DrawLine(new Pen(Color.Black), 50, 5, 50, 50);
                e.Graphics.FillPie(new SolidBrush(Color.Black), 10, 10, 80, 80, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 12, 12, 76, 76, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 10, 10, 80, 80, 45, 90);
                e.Graphics.FillPie(new SolidBrush(Color.Black), 14, 14, 72, 72, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 16, 16, 68, 68, 0, 360);
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 50, 50, 50 + x, 50 - y);
                e.Graphics.DrawString(_min.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 10F, 85F);
                e.Graphics.DrawString(_max.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 60F, 85F);
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 99, 99, 99);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 98, 99, 98);
                e.Graphics.DrawLine(new Pen(Color.Gray), 99, 0, 99, 99);
                e.Graphics.DrawLine(new Pen(Color.Gray), 98, 0, 98, 99);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 99, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 98, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, 99);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, 98);
                e.Graphics.DrawLine(new Pen(Color.Gray), 17, 17, 83, 83);
                e.Graphics.DrawLine(new Pen(Color.Gray), 83, 17, 17, 83);
                e.Graphics.DrawLine(new Pen(Color.Gray), 5, 50, 95, 50);
                e.Graphics.DrawLine(new Pen(Color.Gray), 50, 5, 50, 50);
                e.Graphics.FillPie(new SolidBrush(Color.Gray), 10, 10, 80, 80, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 12, 12, 76, 76, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 10, 10, 80, 80, 45, 90);
                e.Graphics.FillPie(new SolidBrush(Color.Gray), 14, 14, 72, 72, 0, 360);
                e.Graphics.FillPie(new SolidBrush(Color.LightGray), 16, 16, 68, 68, 0, 360);
                e.Graphics.DrawLine(new Pen(Color.Gray, 2), 50, 50, 50 + x, 50 - y);
                e.Graphics.DrawString(_min.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 10F, 85F);
                e.Graphics.DrawString(_max.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 60F, 85F);
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.Width = 100;
            base.Height = 100;
            base.OnLoad(e);
        }
    }
}