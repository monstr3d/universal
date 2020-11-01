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
    public partial class Graph : UserControl
    {
        private float _max, _min, _step;
        private float[] _val;
        private ushort _cur, _chns, _size;

        public Graph()
        {
            InitializeComponent();
            _val = new float[100];
            _max = 100;
            _min = 0;
            _step = 1;
            _cur = 50;
            _chns = 1;
            _size = 100;
        }

        public void Set(float ch1)
        {
            if (base.Enabled)
            {
                if (ch1 > _max) ch1 = _max;
                if (ch1 < _min) ch1 = _min;
                for (int l = 1; l < (_size); l++) _val[l - 1] = _val[l];
                _val[_size - 1] = ch1;
                OnValueChanged();
                base.Invalidate();
                base.Update();
            }
        }

        public void Set(float ch1, float ch2)
        {
            if (base.Enabled)
            {
                if (ch1 > _max) ch1 = _max;
                if (ch1 < _min) ch1 = _min;
                for (int l = 1; l < _size; l++) _val[l - 1] = _val[l];
                _val[_size - 1] = ch1;
                if (_chns > 1)
                {
                    if (ch2 > _max) ch2 = _max;
                    if (ch2 < _min) ch2 = _min;
                    for (int l = _size + 1; l < (_size * 2); l++) _val[l - 1] = _val[l];
                    _val[(_size * 2) - 1] = ch2;
                }
                OnValueChanged();
                base.Invalidate();
                base.Update();
            }
        }

        public void Set(float ch1, float ch2, float ch3)
        {
            if (base.Enabled)
            {
                if (ch1 > _max) ch1 = _max;
                if (ch1 < _min) ch1 = _min;
                for (int l = 1; l < _size; l++) _val[l - 1] = _val[l];
                _val[_size - 1] = ch1;
                if (_chns > 1)
                {
                    if (ch2 > _max) ch2 = _max;
                    if (ch2 < _min) ch2 = _min;
                    for (int l = _size + 1; l < (_size * 2); l++) _val[l - 1] = _val[l];
                    _val[(_size * 2) - 1] = ch2;
                }
                if (_chns > 2)
                {
                    if (ch3 > _max) ch3 = _max;
                    if (ch3 < _min) ch3 = _min;
                    for (int l = (_size * 2) + 1; l < (_size * 3); l++) _val[l - 1] = _val[l];
                    _val[(_size * 3) - 1] = ch3;
                }
                OnValueChanged();
                base.Invalidate();
                base.Update();
            }
        }

        public void Set(float ch1, float ch2, float ch3, float ch4)
        {
            if (base.Enabled)
            {
                if (ch1 > _max) ch1 = _max;
                if (ch1 < _min) ch1 = _min;
                for (int l = 1; l < _size; l++) _val[l - 1] = _val[l];
                _val[_size - 1] = ch1;
                if (_chns > 1)
                {
                    if (ch2 > _max) ch2 = _max;
                    if (ch2 < _min) ch2 = _min;
                    for (int l = _size + 1; l < (_size * 2); l++) _val[l - 1] = _val[l];
                    _val[(_size * 2) - 1] = ch2;
                }
                if (_chns > 2)
                {
                    if (ch3 > _max) ch3 = _max;
                    if (ch3 < _min) ch3 = _min;
                    for (int l = (_size * 2) + 1; l < (_size * 3); l++) _val[l - 1] = _val[l];
                    _val[(_size * 3) - 1] = ch3;
                }
                if (_chns > 3)
                {
                    if (ch4 > _max) ch4 = _max;
                    if (ch4 < _min) ch4 = _min;
                    for (int l = (_size * 3) + 1; l < (_size * 4); l++) _val[l - 1] = _val[l];
                    _val[(_size * 4) - 1] = ch4;
                }
                OnValueChanged();
                base.Invalidate();
                base.Update();
            }
        }

        public void Reset(float max, float min)
        {
            if (max <= min) max = min + 100;
            _val = new float[100];
            for (int l = 0; l < 100; l++) _val[l] = min;
            _max = max;
            _min = min;
            _step = (max - min) / 100;
            _cur = 50;
            _chns = 1;
            _size = 100;
            resize();
        }

        public void Reset(float max, float min, float step)
        {
            if (max <= min) max = min + 100;
            if (step > ((max - min) / 10)) step = (max - min) / 10;
            _val = new float[100];
            for (int l = 0; l < 100; l++) _val[l] = min;
            _max = max;
            _min = min;
            _step = step;
            _cur = 50;
            _chns = 1;
            _size = 100;
            resize();
        }

        public void Reset(ushort chns, ushort size)
        {
            if (chns < 1) chns = 1;
            if (chns > 4) chns = 4;
            if (size < 100) size = 100;
            if (size > 2000) size = 2000;
            _val = new float[chns * size];
            _max = 100;
            _min = 0;
            _step = 1;
            _cur = (ushort)(size / 2);
            _chns = chns;
            _size = size;
            resize();
        }

        public void Reset(float max, float min, ushort chns, ushort size)
        {
            if (max <= min) max = min + 100;
            if (chns < 1) chns = 1;
            if (chns > 4) chns = 4;
            if (size < 100) size = 100;
            if (size > 2000) size = 2000;
            _val = new float[chns * size];
            for (int l = 0; l < (chns * size); l++) _val[l] = min;
            _max = max;
            _min = min;
            _step = (max - min) / 100;
            _cur = (ushort)(size / 2);
            _chns = chns;
            _size = size;
            resize();
        }

        public void Reset(float max, float min, float step, ushort chns, ushort size)
        {
            if (max <= min) max = min + 100;
            if (step > ((max - min) / 10)) step = (max - min) / 10;
            if (chns < 1) chns = 1;
            if (chns > 4) chns = 4;
            if (size < 100) size = 100;
            if (size > 2000) size = 2000;
            _val = new float[chns * size];
            for (int l = 0; l < (chns * size); l++) _val[l] = min;
            _max = max;
            _min = min;
            _step = step;
            _cur = (ushort)(size / 2);
            _chns = chns;
            _size = size;
            resize();
        }

        public float[] Val
        {
            get
            {
                float[] ret = new float[_chns];
                for (int l = 0; l < _chns; l++) ret[l] = _val[(l * _size) + _cur];
                return ret;
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

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        private void resize()
        {
            base.Width = _size + 20;
            base.Height = Convert.ToInt32((_max - _min) / _step) + 20;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                ushort temp = _cur;
                int l = Convert.ToInt32(e.X);
                if (l < 10) l = 10;
                if (l > (_size + 9)) l = _size + 9;
                _cur = (ushort)(l - 10);
                if (temp != _cur)
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
                    ushort temp = _cur;
                    int l = Convert.ToInt32(e.X);
                    if (l < 10) l = 10;
                    if (l > (_size + 9)) l = _size + 9;
                    _cur = (ushort)(l - 10);
                    if (temp != _cur)
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
                ushort temp = _cur;
                if (e.Delta > 0)
                {
                    _cur--;
                    if (_cur > (_size - 1)) _cur = 0;
                }
                if (e.Delta < 0)
                {
                    _cur++;
                    if (_cur > (_size - 1)) _cur = (ushort)(_size - 1);
                }
                if (temp != _cur)
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
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, _size + 20, size + 20);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 19, _size + 19, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, size + 18, _size + 19, size + 18);
                e.Graphics.DrawLine(new Pen(Color.Black), _size + 19, 0, _size + 19, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Black), _size + 18, 0, _size + 18, size + 19);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, _size + 19, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, _size + 18, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size + 19);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size + 18);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), 10, 10 + size - l, 9 + _size, 10 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 15, (10 + size - l - 6));
                }
                for (int l = 0; l < (_size - 1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10 + l, 10 + size - Convert.ToInt32((_val[l] - _min) / _step), 11 + l, 10 + size - Convert.ToInt32((_val[l + 1] - _min) / _step));
                if (_chns > 1) for (int l = 0; l < (_size - 1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10 + l, 10 + size - Convert.ToInt32((_val[l + _size] - _min) / _step), 11 + l, 10 + size - Convert.ToInt32((_val[l + 1 + _size] - _min) / _step));
                if (_chns > 2) for (int l = 0; l < (_size - 1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10 + l, 10 + size - Convert.ToInt32((_val[l + (2 * _size)] - _min) / _step), 11 + l, 10 + size - Convert.ToInt32((_val[l + 1 + (2 * _size)] - _min) / _step));
                if (_chns > 3) for (int l = 0; l < (_size - 1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10 + l, 10 + size - Convert.ToInt32((_val[l + (3 * _size)] - _min) / _step), 11 + l, 10 + size - Convert.ToInt32((_val[l + 1 + (3 * _size)] - _min) / _step));
                e.Graphics.DrawLine(new Pen(Color.Black), 10 + _cur, 10, 10 + _cur, 10 + size);
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 19, _size + 19, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, size + 18, _size + 19, size + 18);
                e.Graphics.DrawLine(new Pen(Color.Gray), _size + 19, 0, _size + 19, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Gray), _size + 18, 0, _size + 18, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, _size + 19, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, _size + 18, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size + 19);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size + 18);
                for (int l = 0; l <= size; l = l + 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray), 10, 10 + size - l, 9 + _size, 10 + size - l);
                    e.Graphics.DrawString((_min + (l * _step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 15, (10 + size - l - 6));
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            resize();
            base.OnLoad(e);
        }
    }

}