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
    public partial class Tank : UserControl
    {
        private float _val, _max, _min, _step;

        public Tank()
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

        protected override void OnPaint(PaintEventArgs e)
        {
            int size = Convert.ToInt32((_max - _min) / _step);
            int lev = Convert.ToInt32((_val - _min) / _step);
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 140, size + 40);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 39, 139, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 38, 139, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Black), 139, 0, 139, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Black), 138, 0, 138, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 139, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 138, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Black), 10, 20, 10, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 9, 20, 9, 21 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 79, 20, 79, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 80, 20, 80, 21 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 10, 20 + size, 79, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Black), 10, 21 + size, 79, 21 + size);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), 11, 20, 68, size);
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 11, 20 + size - lev, 68, lev);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), 85, 20 + size - l, 90, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 95, (20 + size - l - 6));
                }
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 39, 139, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 38, 139, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Gray), 139, 0, 139, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 138, 0, 138, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 139, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 138, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size + 39);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size + 38);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20, 10, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 9, 20, 9, 21 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 79, 20, 79, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 80, 20, 80, 21 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20 + size, 79, 20 + size);
                e.Graphics.DrawLine(new Pen(Color.Gray), 10, 21 + size, 79, 21 + size);
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 11, 20, 68, size);
                e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), 11, 20 + size - lev, 68, lev);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), 85, 20 + size - l, 90, 20 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 95, (20 + size - l - 6));
                }
            }
        }

        private void resize()
        {
            base.Width = 140;
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