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
    public partial class Switch : UserControl
    {
        public Switch()
        {
            InitializeComponent();
            _val = false;
        }
        private bool _val;

        public void Set(bool val)
        {
            if (base.Enabled)
            {
                bool temp = _val;
                _val = val;
                if (temp != _val)
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
                int l = Convert.ToInt32(e.Y);
                if (l < 30 && _val)
                {
                    _val = false;
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
                if (l >= 30 && !_val)
                {
                    _val = true;
                    OnValueChanged();
                    base.Invalidate();
                    base.Update();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /*	System.Reflection.Assembly asm=System.Reflection.Assembly.GetExecutingAssembly();
                System.IO.Stream switch0=asm.GetManifestResourceStream("switch0.png");
                System.IO.Stream switch1=asm.GetManifestResourceStream("switch1.png");
                System.IO.Stream switchn0=asm.GetManifestResourceStream("switchn0.png");
                System.IO.Stream switchn1=asm.GetManifestResourceStream("switchn1.png");*/
            if (base.Enabled)
            {
                if (!_val) e.Graphics.DrawImageUnscaled(Properties.Resources.switch0, 0, 0);
                if (_val) e.Graphics.DrawImageUnscaled(Properties.Resources.switch1, 0, 0);
            }
            else
            {
                if (!_val) e.Graphics.DrawImageUnscaled(Properties.Resources.switchn0, 0, 0);
                if (_val) e.Graphics.DrawImageUnscaled(Properties.Resources.switchn1, 0, 0);
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.Width = 40;
            base.Height = 60;
            base.OnLoad(e);
        }
    }
}