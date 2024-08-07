//
// ScadaForms.cs v0.1.1
// part of scada-tgz v0.1.1
// license: LGPL
// web: scada-tgz.sourceforge.net
//

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScadaForms
{

// -------------- Switch Control --------------

	public class Switch : UserControl
	{
		private bool _val;

		public Switch()
		{
			_val=false;
		}

		public void Set(bool val)
		{
			if (base.Enabled)
			{
				bool temp=_val;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public bool Val
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
				int l=Convert.ToInt32(e.Y);
				if (l<30 && _val)
				{
					_val=false;
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
				if (l>=30 && !_val)
				{
					_val=true;
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			System.Reflection.Assembly asm=System.Reflection.Assembly.GetExecutingAssembly();
			System.IO.Stream switch0=asm.GetManifestResourceStream("switch0.png");
			System.IO.Stream switch1=asm.GetManifestResourceStream("switch1.png");
			System.IO.Stream switchn0=asm.GetManifestResourceStream("switchn0.png");
			System.IO.Stream switchn1=asm.GetManifestResourceStream("switchn1.png");
			if (base.Enabled)
			{
				if (!_val) e.Graphics.DrawImageUnscaled(Image.FromStream(switch0), 0, 0);
				if (_val) e.Graphics.DrawImageUnscaled(Image.FromStream(switch1), 0, 0);
			}
			else
			{
				if (!_val) e.Graphics.DrawImageUnscaled(Image.FromStream(switchn0), 0, 0);
				if (_val) e.Graphics.DrawImageUnscaled(Image.FromStream(switchn1), 0, 0);
			}
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.Width=40;
			base.Height=60;
			base.OnLoad(e);
		}
	}

// -------------- Tristat Control --------------

	public class Tristat : UserControl
	{
		private int _val;

		public Tristat()
		{
			_val=0;
		}

		public void Set(int val)
		{
			if (base.Enabled)
			{
				int temp=_val;
				if (val<0) val=0;
				if (val>2) val=2;
				_val=val;
				if (temp!=_val)
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
				int temp=_val;
				if (temp==0)
				{
					if (e.X<30) _val=1;
					else _val=2;
				}
				if (temp==1)
				{
					if (e.X<30) _val=1;
					else _val=0;
				}
				if (temp==2)
				{
					if (e.X<30) _val=0;
					else _val=2;
				}
				if (temp!=_val)
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
				if (_val==0)
				{
					for (int l=-2; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 30+l, 18, 30+l, 50);
					}
					e.Graphics.DrawLine(new Pen(Color.Blue, 2), 31, 18, 31, 50);
				}
				if (_val==1)
				{
					for (int l=-3; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 20+l, 20, 50+l, 50);
					}
					e.Graphics.DrawLine(new Pen(Color.Blue, 2), 20, 20, 50, 50);
				}
				if (_val==2)
				{
					for (int l=-3; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 40+l, 20, 10+l, 50);
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
				if (_val==0)
				{
					for (int l=-2; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 30+l, 18, 30+l, 50);
					}
					e.Graphics.DrawLine(new Pen(Color.Gray, 2), 31, 18, 31, 50);
				}
				if (_val==1)
				{
					for (int l=-3; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 20+l, 20, 50+l, 50);
					}
					e.Graphics.DrawLine(new Pen(Color.Gray, 2), 20, 20, 50, 50);
				}
				if (_val==2)
				{
					for (int l=-3; l<4; l++)
					{
						e.Graphics.DrawLine(new Pen(Color.LightGray), 40+l, 20, 10+l, 50);
					}
					e.Graphics.DrawLine(new Pen(Color.Gray, 2), 40, 20, 10, 50);
				}
			}
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.Width=60;
			base.Height=60;
			base.OnLoad(e);
		}
	}

// -------------- Slider Control --------------

	public class Slider : UserControl
	{
		private float _val,_max,_min,_step;

		public Slider()
		{
			_val=0;
			_max=100;
			_min=0;
			_step=1;
		}

		public void Set(float val)
		{
			if (base.Enabled)
			{
				float temp=_val;
				if (val>_max) val=_max;
				if (val<_min) val=_min;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public void Reset(float max, float min)
		{
			if (max<min) max=min+100;
			_val=min;
			_max=max;
			_min=min;
			_step=(max-min)/100;
			resize();
		}

		public void Reset(float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			_val=min;
			_max=max;
			_min=min;
			_step=step;
			resize();
		}

		public void Reset(float val, float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			if (val>max) val=max;
			if (val<min) val=min;
			_val=val;
			_max=max;
			_min=min;
			_step=step;
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

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		private void resize()
		{
			base.Width=90;
			base.Height=40+Convert.ToInt32((_max-_min)/_step);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (base.Enabled)
			{
				float temp=_val;
				int l=e.Y;
				if (l<20) l=20;
				int size=Convert.ToInt32((_max-_min)/_step);
				if (l>(20+size)) l=20+size;
				_val=_min+((20+size-l)*_step);
				if (temp!=_val)
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
				if (e.Button==MouseButtons.Left)
				{
					float temp=_val;
					int l=e.Y;
					if (l<20) l=20;
					int size=Convert.ToInt32((_max-_min)/_step);
					if (l>(20+size)) l=20+size;
					_val=_min+((20+size-l)*_step);
					if (temp!=_val)
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
				float temp=_val;
				if (e.Delta>0)
				{
					_val=_val+_step;
					if (_val>_max) _val=_max;
				}
				if (e.Delta<0)
				{
					_val=_val-_step;
					if (_val<_min) _val=_min;
				}
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int size=Convert.ToInt32((_max-_min)/_step);
			int suw=Convert.ToInt32((_val-_min)/_step);
			e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 90, size+40);
			if (base.Enabled)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+39, 89, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+38, 89, size+38);
				e.Graphics.DrawLine(new Pen(Color.Black), 89, 0, 89, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 88, 0, 88, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 89, 0);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 88, 1);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size+38);
				e.Graphics.DrawLine(new Pen(Color.White), 25, 20, 25, 20+size);
				e.Graphics.DrawLine(new Pen(Color.White), 15, 20+size, 25, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 15, 20, 15, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 15, 20, 25, 20);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 10, 20+size-suw-4, 20, 9);
				e.Graphics.DrawLine(new Pen(Color.Black), 10, 20+size-suw+4, 30, 20+size-suw+4);
				e.Graphics.DrawLine(new Pen(Color.Black), 30, 20+size-suw+4, 30, 20+size-suw-4);
				e.Graphics.DrawLine(new Pen(Color.White), 10, 20+size-suw-4, 30, 20+size-suw-4);
				e.Graphics.DrawLine(new Pen(Color.White), 10, 20+size-suw-4, 10, 20+size-suw+4);
				e.Graphics.DrawLine(new Pen(Color.Red), 20, 20+size-suw, 30, 20+size-suw);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Black), 35, 20+size-l, 40, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 45, (20+size-l-6));
				}
			}
			else
			{
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+39, 89, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+38, 89, size+38);
				e.Graphics.DrawLine(new Pen(Color.Gray), 89, 0, 89, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 88, 0, 88, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 89, 0);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 88, 1);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size+38);
				e.Graphics.DrawLine(new Pen(Color.Gray), 25, 20, 25, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20+size, 25, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20, 15, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 15, 20, 25, 20);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 10, 20+size-suw-4, 20, 9);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20+size-suw+4, 30, 20+size-suw+4);
				e.Graphics.DrawLine(new Pen(Color.Gray), 30, 20+size-suw+4, 30, 20+size-suw-4);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20+size-suw-4, 30, 20+size-suw-4);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20+size-suw-4, 10, 20+size-suw+4);
				e.Graphics.DrawLine(new Pen(Color.Gray), 20, 20+size-suw, 30, 20+size-suw);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Gray), 35, 20+size-l, 40, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 45, (20+size-l-6));
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			resize();
			base.OnLoad(e);
		}
	}

// -------------- Knob Control --------------

	public class Knob : UserControl
	{
		private float _val,_max,_min,_step;

		public Knob()
		{
			_val=0;
			_max=270;
			_min=0;
			_step=1;
		}

		public void Set(float val)
		{
			if (base.Enabled)
			{
				float temp=_val;
				if (val>_max) val=_max;
				if (val<_min) val=_min;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public void Reset(float max, float min)
		{
			if (max<min) max=min+100;
			_val=min;
			_max=max;
			_min=min;
			_step=(max-min)/270;
		}

		public void Reset(float val, float max, float min)
		{
			if (max<min) max=min+100;
			if (val>max) val=max;
			if (val<min) val=min;
			_val=val;
			_val=min;
			_max=max;
			_min=min;
			_step=(max-min)/270;
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
				float temp=_val;
				double x=e.X-50;
				double y=100-e.Y-50;
				double t=Math.Atan2(y, x);
				if (t<(-Math.PI*0.25) && t>(-Math.PI*0.5)) t=-Math.PI*0.25;
				if (t<=(-Math.PI*0.5) && t>(-Math.PI*0.75)) t=-Math.PI*0.75;
				int k=Convert.ToInt32((t*180)/Math.PI);
				if (k<-90) k=k+360;
				k=270-(k+45);
				_val=_min+(k*_step);
				if (temp!=_val)
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
				if (e.Button==MouseButtons.Left)
				{
					float temp=_val;
					double x=e.X-50;
					double y=100-e.Y-50;
					double t=Math.Atan2(y, x);
					if (t<(-Math.PI*0.25) && t>(-Math.PI*0.5)) t=-Math.PI*0.25;
					if (t<=(-Math.PI*0.5) && t>(-Math.PI*0.75)) t=-Math.PI*0.75;
					int k=Convert.ToInt32((t*180)/Math.PI);
					if (k<-90) k=k+360;
					k=270-(k+45);
					_val=_min+(k*_step);
					if (temp!=_val)
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
				float temp=_val;
				if (e.Delta>0)
				{
					_val=_val+_step;
					if (_val>_max) _val=_max;
				}
				if (e.Delta<0)
				{
					_val=_val-_step;
					if (_val<_min) _val=_min;
				}
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int k=Convert.ToInt32((_val-_min)/_step);
			k=(270-k)-45;
			double t=(k*Math.PI)/180;
			int y=Convert.ToInt32(34*Math.Sin(t));
			int x=Convert.ToInt32(34*Math.Cos(t));
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
				e.Graphics.DrawLine(new Pen(Color.Red, 2), 50, 50, 50+x, 50-y);
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
				e.Graphics.DrawLine(new Pen(Color.Gray, 2), 50, 50, 50+x, 50-y);
				e.Graphics.DrawString(_min.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 10F, 85F);
				e.Graphics.DrawString(_max.ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 60F, 85F);
			}
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.Width=100;
			base.Height=100;
			base.OnLoad(e);
		}
	}

// -------------- Lamp Control --------------

	public class Lamp : UserControl
	{
		private bool _val;
		private int _size;

		public Lamp()
		{
			_val=false;
			_size=80;
		}

		public void Set(bool val)
		{
			if (base.Enabled)
			{
				bool temp=_val;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public void Reset(bool val, int size)
		{
			_val=val;
			if (size<20) size=20;
			_size=size;
			resize();
			OnValueChanged();
			base.Invalidate();
			base.Update();
		}

		public bool Val
		{
			get
			{
				return _val;
			}
		}

		public int Sizze
		{
			get
			{
				return _size;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.Enabled)
			{
				e.Graphics.FillPie(new SolidBrush(Color.Black), 0, 0, _size, _size, 0, 360);
				e.Graphics.FillPie(new SolidBrush(Color.Gray), 2, 2, _size-4, _size-4, 0, 360);
				e.Graphics.FillPie(new SolidBrush(Color.Black), 6, 6, _size-12, _size-12, 0, 360);
				if (!_val) e.Graphics.FillPie(new SolidBrush(Color.Red), 8, 8, _size-16, _size-16, 0, 360);
				if (_val) e.Graphics.FillPie(new SolidBrush(Color.FromArgb(0, 255, 0)), 8, 8, _size-16, _size-16, 0, 360);
			}
			else
			{
				e.Graphics.FillPie(new SolidBrush(Color.Gray), 0, 0, _size, _size, 0, 360);
				e.Graphics.FillPie(new SolidBrush(Color.LightGray), 2, 2, _size-4, _size-4, 0, 360);
				e.Graphics.FillPie(new SolidBrush(Color.Gray), 6, 6, _size-12, _size-12, 0, 360);
				if (!_val) e.Graphics.FillPie(new SolidBrush(Color.DarkGray), 8, 8, _size-16, _size-16, 0, 360);
				if (_val) e.Graphics.FillPie(new SolidBrush(Color.LightGray), 8, 8, _size-16, _size-16, 0, 360);
			}
		}

		private void resize()
		{
			base.Width=_size;
			base.Height=_size;
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			resize();
			base.OnLoad(e);
		}
	}

// -------------- Term Control --------------

	public class Term : UserControl
	{
		private float _val,_max,_min,_step;

		public Term()
		{
			_val=0;
			_max=100;
			_min=0;
			_step=1;
		}

		public void Set(float val)
		{
			if (base.Enabled)
			{
				float temp=_val;
				if (val>_max) val=_max;
				if (val<_min) val=_min;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public void Reset(float max, float min)
		{
			if (max<min) max=min+100;
			_val=min;
			_max=max;
			_min=min;
			_step=(max-min)/100;
			resize();
		}

		public void Reset(float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			_val=min;
			_max=max;
			_min=min;
			_step=step;
			resize();
		}

		public void Reset(float val, float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			if (val>max) val=max;
			if (val<min) val=min;
			_val=val;
			_max=max;
			_min=min;
			_step=step;
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
			int size=Convert.ToInt32((_max-_min)/_step);
			int bar=Convert.ToInt32((_val-_min)/_step);
			e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 80, size+40);
			if (base.Enabled)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+39, 79, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+38, 79, size+38);
				e.Graphics.DrawLine(new Pen(Color.Black), 79, 0, 79, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 78, 0, 78, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 79, 0);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 78, 1);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size+38);
				e.Graphics.FillPie(new SolidBrush(Color.Black), 10, 15, 10, 10, 180, 180);
				e.Graphics.FillPie(new SolidBrush(Color.LightBlue), 11, 16, 8, 8, 180, 180);
				e.Graphics.DrawLine(new Pen(Color.Black), 10, 20, 10, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 19, 20, 19, 20+size);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), 11, 20, 8, size);
				e.Graphics.FillPie(new SolidBrush(Color.Black), 10, 15+size, 10, 10, 0, 180);
				e.Graphics.FillPie(new SolidBrush(Color.Red), 11, 16+size, 8, 8, 0, 180);
				e.Graphics.FillRectangle(new SolidBrush(Color.Red), 11, 20+size-bar, 8, bar);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Black), 25, 20+size-l, 30, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 35, (20+size-l-6));
				}
			}
			else
			{
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+39, 79, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+38, 79, size+38);
				e.Graphics.DrawLine(new Pen(Color.Gray), 79, 0, 79, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 78, 0, 78, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 79, 0);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 78, 1);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size+38);
				e.Graphics.FillPie(new SolidBrush(Color.Gray), 10, 15, 10, 10, 180, 180);
				e.Graphics.FillPie(new SolidBrush(Color.LightGray), 11, 16, 8, 8, 180, 180);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20, 10, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 19, 20, 19, 20+size);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 11, 20, 8, size);
				e.Graphics.FillPie(new SolidBrush(Color.Gray), 10, 15+size, 10, 10, 0, 180);
				e.Graphics.FillPie(new SolidBrush(Color.DarkGray), 11, 16+size, 8, 8, 0, 180);
				e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), 11, 20+size-bar, 8, bar);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Gray), 25, 20+size-l, 30, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 35, (20+size-l-6));
				}
			}
		}

		private void resize()
		{
			base.Width=80;
			base.Height=40+Convert.ToInt32((_max-_min)/_step);
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			resize();
			base.OnLoad(e);
		}
	}

// -------------- Tank Control --------------

	public class Tank : UserControl
	{
		private float _val,_max,_min,_step;

		public Tank()
		{
			_val=0;
			_max=100;
			_min=0;
			_step=1;
		}

		public void Set(float val)
		{
			if (base.Enabled)
			{
				float temp=_val;
				if (val>_max) val=_max;
				if (val<_min) val=_min;
				_val=val;
				if (temp!=_val)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		public void Reset(float max, float min)
		{
			if (max<min) max=min+100;
			_val=min;
			_max=max;
			_min=min;
			_step=(max-min)/100;
			resize();
		}

		public void Reset(float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			_val=min;
			_max=max;
			_min=min;
			_step=step;
			resize();
		}

		public void Reset(float val, float max, float min, float step)
		{
			if (max<min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			if (val>max) val=max;
			if (val<min) val=min;
			_val=val;
			_max=max;
			_min=min;
			_step=step;
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
			int size=Convert.ToInt32((_max-_min)/_step);
			int lev=Convert.ToInt32((_val-_min)/_step);
			e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, 140, size+40);
			if (base.Enabled)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+39, 139, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+38, 139, size+38);
				e.Graphics.DrawLine(new Pen(Color.Black), 139, 0, 139, size+39);
				e.Graphics.DrawLine(new Pen(Color.Black), 138, 0, 138, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 139, 0);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 1, 138, 1);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size+38);
				e.Graphics.DrawLine(new Pen(Color.Black), 10, 20, 10, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 9, 20, 9, 21+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 79, 20, 79, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 80, 20, 80, 21+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 10, 20+size, 79, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Black), 10, 21+size, 79, 21+size);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), 11, 20, 68, size);
				e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 11, 20+size-lev, 68, lev);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Black), 85, 20+size-l, 90, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 95, (20+size-l-6));
				}
			}
			else
			{
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+39, 139, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+38, 139, size+38);
				e.Graphics.DrawLine(new Pen(Color.Gray), 139, 0, 139, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 138, 0, 138, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 139, 0);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, 138, 1);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size+39);
				e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size+38);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20, 10, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 9, 20, 9, 21+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 79, 20, 79, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 80, 20, 80, 21+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 20+size, 79, 20+size);
				e.Graphics.DrawLine(new Pen(Color.Gray), 10, 21+size, 79, 21+size);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 11, 20, 68, size);
				e.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), 11, 20+size-lev, 68, lev);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Gray), 85, 20+size-l, 90, 20+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 95, (20+size-l-6));
				}
			}
		}

		private void resize()
		{
			base.Width=140;
			base.Height=40+Convert.ToInt32((_max-_min)/_step);
		}

		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged()
		{
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			resize();
			base.OnLoad(e);
		}
	}

// -------------- Graph Control --------------

	public class Graph : UserControl
	{
		private float _max,_min,_step;
		private float[] _val;
		private ushort _cur,_chns,_size;

		public Graph()
		{
			_val=new float[100];
			_max=100;
			_min=0;
			_step=1;
			_cur=50;
			_chns=1;
			_size=100;
		}

		public void Set(float ch1)
		{
			if (base.Enabled)
			{
				if (ch1>_max) ch1=_max;
				if (ch1<_min) ch1=_min;
				for (int l=1; l<(_size); l++) _val[l-1]=_val[l];
				_val[_size-1]=ch1;
				OnValueChanged();
				base.Invalidate();
				base.Update();
			}
		}

		public void Set(float ch1, float ch2)
		{
			if (base.Enabled)
			{
				if (ch1>_max) ch1=_max;
				if (ch1<_min) ch1=_min;
				for (int l=1; l<_size; l++) _val[l-1]=_val[l];
				_val[_size-1]=ch1;
				if (_chns>1)
				{
					if (ch2>_max) ch2=_max;
					if (ch2<_min) ch2=_min;
					for (int l=_size+1; l<(_size*2); l++) _val[l-1]=_val[l];
					_val[(_size*2)-1]=ch2;
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
				if (ch1>_max) ch1=_max;
				if (ch1<_min) ch1=_min;
				for (int l=1; l<_size; l++) _val[l-1]=_val[l];
				_val[_size-1]=ch1;
				if (_chns>1)
				{
					if (ch2>_max) ch2=_max;
					if (ch2<_min) ch2=_min;
					for (int l=_size+1; l<(_size*2); l++) _val[l-1]=_val[l];
					_val[(_size*2)-1]=ch2;
				}
				if (_chns>2)
				{
					if (ch3>_max) ch3=_max;
					if (ch3<_min) ch3=_min;
					for (int l=(_size*2)+1; l<(_size*3); l++) _val[l-1]=_val[l];
					_val[(_size*3)-1]=ch3;
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
				if (ch1>_max) ch1=_max;
				if (ch1<_min) ch1=_min;
				for (int l=1; l<_size; l++) _val[l-1]=_val[l];
				_val[_size-1]=ch1;
				if (_chns>1)
				{
					if (ch2>_max) ch2=_max;
					if (ch2<_min) ch2=_min;
					for (int l=_size+1; l<(_size*2); l++) _val[l-1]=_val[l];
					_val[(_size*2)-1]=ch2;
				}
				if (_chns>2)
				{
					if (ch3>_max) ch3=_max;
					if (ch3<_min) ch3=_min;
					for (int l=(_size*2)+1; l<(_size*3); l++) _val[l-1]=_val[l];
					_val[(_size*3)-1]=ch3;
				}
				if (_chns>3)
				{
					if (ch4>_max) ch4=_max;
					if (ch4<_min) ch4=_min;
					for (int l=(_size*3)+1; l<(_size*4); l++) _val[l-1]=_val[l];
					_val[(_size*4)-1]=ch4;
				}
				OnValueChanged();
				base.Invalidate();
				base.Update();
			}
		}

		public void Reset(float max, float min)
		{
			if (max<=min) max=min+100;
			_val=new float[100];
			for (int l=0; l<100; l++) _val[l]=min;
			_max=max;
			_min=min;
			_step=(max-min)/100;
			_cur=50;
			_chns=1;
			_size=100;
			resize();
		}

		public void Reset(float max, float min, float step)
		{
			if (max<=min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			_val=new float[100];
			for (int l=0; l<100; l++) _val[l]=min;
			_max=max;
			_min=min;
			_step=step;
			_cur=50;
			_chns=1;
			_size=100;
			resize();
		}

		public void Reset(ushort chns, ushort size)
		{
			if (chns<1) chns=1;
			if (chns>4) chns=4;
			if (size<100) size=100;
			if (size>2000) size=2000;
			_val=new float[chns*size];
			_max=100;
			_min=0;
			_step=1;
			_cur=(ushort)(size/2);
			_chns=chns;
			_size=size;
			resize();
		}

		public void Reset(float max, float min, ushort chns, ushort size)
		{
			if (max<=min) max=min+100;
			if (chns<1) chns=1;
			if (chns>4) chns=4;
			if (size<100) size=100;
			if (size>2000) size=2000;
			_val=new float[chns*size];
			for (int l=0; l<(chns*size); l++) _val[l]=min;
			_max=max;
			_min=min;
			_step=(max-min)/100;
			_cur=(ushort)(size/2);
			_chns=chns;
			_size=size;
			resize();
		}

		public void Reset(float max, float min, float step, ushort chns, ushort size)
		{
			if (max<=min) max=min+100;
			if (step>((max-min)/10)) step=(max-min)/10;
			if (chns<1) chns=1;
			if (chns>4) chns=4;
			if (size<100) size=100;
			if (size>2000) size=2000;
			_val=new float[chns*size];
			for (int l=0; l<(chns*size); l++) _val[l]=min;
			_max=max;
			_min=min;
			_step=step;
			_cur=(ushort)(size/2);
			_chns=chns;
			_size=size;
			resize();
		}

		public float[] Val
		{
			get
			{
				float[] ret=new float[_chns];
				for (int l=0; l<_chns; l++) ret[l]=_val[(l*_size)+_cur];
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
			if (ValueChanged!=null) ValueChanged(this, EventArgs.Empty);
		}

		private void resize()
		{
			base.Width=_size+20;
			base.Height=Convert.ToInt32((_max-_min)/_step)+20;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (base.Enabled)
			{
				ushort temp=_cur;
				int l=Convert.ToInt32(e.X);
				if (l<10) l=10;
				if (l>(_size+9)) l=_size+9;
				_cur=(ushort)(l-10);
				if (temp!=_cur)
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
				if (e.Button==MouseButtons.Left)
				{
					ushort temp=_cur;
					int l=Convert.ToInt32(e.X);
					if (l<10) l=10;
					if (l>(_size+9)) l=_size+9;
					_cur=(ushort)(l-10);
					if (temp!=_cur)
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
				ushort temp=_cur;
				if (e.Delta>0)
				{
					_cur--;
					if (_cur>(_size-1)) _cur=0;
				}
				if (e.Delta<0)
				{
					_cur++;
					if (_cur>(_size-1)) _cur=(ushort)(_size-1);
				}
				if (temp!=_cur)
				{
					OnValueChanged();
					base.Invalidate();
					base.Update();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			int size=Convert.ToInt32((_max-_min)/_step);
			e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, _size+20, size+20);
			if (base.Enabled)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+19, _size+19, size+19);
				e.Graphics.DrawLine(new Pen(Color.Black), 0, size+18, _size+19, size+18);
				e.Graphics.DrawLine(new Pen(Color.Black), _size+19, 0, _size+19, size+19);
				e.Graphics.DrawLine(new Pen(Color.Black), _size+18, 0, _size+18, size+19);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, _size+19, 0);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 1, _size+18, 1);
				e.Graphics.DrawLine(new Pen(Color.White), 0, 0, 0, size+19);
				e.Graphics.DrawLine(new Pen(Color.White), 1, 0, 1, size+18);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Gray), 10, 10+size-l, 9+_size, 10+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Black), 15, (10+size-l-6));
				}
				for (int l=0; l<(_size-1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10+l, 10+size-Convert.ToInt32((_val[l]-_min)/_step), 11+l, 10+size-Convert.ToInt32((_val[l+1]-_min)/_step));
				if (_chns>1) for (int l=0; l<(_size-1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10+l, 10+size-Convert.ToInt32((_val[l+_size]-_min)/_step), 11+l, 10+size-Convert.ToInt32((_val[l+1+_size]-_min)/_step));
				if (_chns>2) for (int l=0; l<(_size-1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10+l, 10+size-Convert.ToInt32((_val[l+(2*_size)]-_min)/_step), 11+l, 10+size-Convert.ToInt32((_val[l+1+(2*_size)]-_min)/_step));
				if (_chns>3) for (int l=0; l<(_size-1); l++) e.Graphics.DrawLine(new Pen(Color.Red), 10+l, 10+size-Convert.ToInt32((_val[l+(3*_size)]-_min)/_step), 11+l, 10+size-Convert.ToInt32((_val[l+1+(3*_size)]-_min)/_step));
				e.Graphics.DrawLine(new Pen(Color.Black), 10+_cur, 10, 10+_cur, 10+size);
			}
			else
			{
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+19, _size+19, size+19);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, size+18, _size+19, size+18);
				e.Graphics.DrawLine(new Pen(Color.Gray), _size+19, 0, _size+19, size+19);
				e.Graphics.DrawLine(new Pen(Color.Gray), _size+18, 0, _size+18, size+19);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, _size+19, 0);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 1, _size+18, 1);
				e.Graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, size+19);
				e.Graphics.DrawLine(new Pen(Color.Gray), 1, 0, 1, size+18);
				for (int l=0; l<=size; l=l+10)
				{
					e.Graphics.DrawLine(new Pen(Color.Gray), 10, 10+size-l, 9+_size, 10+size-l);
					e.Graphics.DrawString((_min+(l*_step)).ToString(), new Font("DejaVu Sans", 8), new SolidBrush(Color.Gray), 15, (10+size-l-6));
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
