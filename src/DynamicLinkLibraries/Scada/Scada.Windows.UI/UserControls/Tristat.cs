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
    public partial class Tristat : UserControl
    {
        public Tristat()
        {
            InitializeComponent();
            _val = 0;
        }
  
        private int _val;

        public void Set(int val)
        {
            if (base.Enabled)
            {
                int temp = _val;
                if (val < 0) val = 0;
                if (val > 2) val = 2;
                _val = val;
                if (temp != _val)
                {
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
            }
        }

        public int Val
        {
            get
            {
                return _val;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                int temp = _val;
                if (temp == 0)
                {
                    if (e.X < 30) _val = 1;
                    else _val = 2;
                }
                if (temp == 1)
                {
                    if (e.X < 30) _val = 1;
                    else _val = 0;
                }
                if (temp == 2)
                {
                    if (e.X < 30) _val = 0;
                    else _val = 2;
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
            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 60, 60);
            if (base.Enabled)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), 0, 59, 59, 59);
                e.Graphics.DrawLine(new Pen(Color.Black), 0, 58, 59, 58);
                e.Graphics.DrawLine(new Pen(Color.Black), 59, 0, 59, 59);
                e.Graphics.DrawLine(new Pen(Color.Black), 58, 0, 58, 59);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 59, 0);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 58, 1);
                e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, 59);
                e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, 58);
                e.Graphics.FillPie(new SolidBrush(Color.Black), 20, 20, 22, 22, 0, 360);
                e.Graphics.DrawString("0", new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 27F, 4F);
                e.Graphics.DrawString("1", new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 10F, 10F);
                e.Graphics.DrawString("2", new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 44F, 10F);
                if (_val == 0)
                {
                    for (int l = -2; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 30 + l, 18, 30 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Blue, 2), 31, 18, 31, 50);
                }
                if (_val == 1)
                {
                    for (int l = -3; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 20 + l, 20, 50 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Blue, 2), 20, 20, 50, 50);
                }
                if (_val == 2)
                {
                    for (int l = -3; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 40 + l, 20, 10 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Blue, 2), 40, 20, 10, 50);
                }
            }
            else
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 59, 59, 59);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 58, 59, 58);
                e.Graphics.DrawLine(new Pen(Color.Gray), 59, 0, 59, 59);
                e.Graphics.DrawLine(new Pen(Color.Gray), 58, 0, 58, 59);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 59, 0);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 58, 1);
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, 59);
                e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, 58);
                e.Graphics.FillPie(new SolidBrush(Color.Gray), 20, 20, 22, 22, 0, 360);
                e.Graphics.DrawString("0", new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 27F, 4F);
                e.Graphics.DrawString("1", new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 10F, 10F);
                e.Graphics.DrawString("2", new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 44F, 10F);
                if (_val == 0)
                {
                    for (int l = -2; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 30 + l, 18, 30 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Gray, 2), 31, 18, 31, 50);
                }
                if (_val == 1)
                {
                    for (int l = -3; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 20 + l, 20, 50 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Gray, 2), 20, 20, 50, 50);
                }
                if (_val == 2)
                {
                    for (int l = -3; l < 4; l++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.LightGray), 40 + l, 20, 10 + l, 50);
                    }
                    e.Graphics.DrawLine(new Pen(Color.Gray, 2), 40, 20, 10, 50);
                }
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.Width = 60;
            base.Height = 60;
            base.OnLoad(e);
        }
    }
}