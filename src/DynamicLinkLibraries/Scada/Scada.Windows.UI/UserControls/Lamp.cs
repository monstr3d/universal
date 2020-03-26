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
    public partial class Lamp : UserControl
    {
        public Lamp()
        {
            InitializeComponent();
   			_val=false;
			_size=80;
     }
 		private bool _val;
		private int _size;


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
	
}