using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsExtensions.MouseOperations
{
    internal class MouseWheelResizer
    {
        private Control parent;

        private Dictionary<Control, MouseWheel> resizers = new Dictionary<Control, MouseWheel>();

        float step;
        
        internal MouseWheelResizer(Control control, float step = 0.1f)
        {
            parent = control;
            control.Tag = this;
            this.step = step;
        }

        internal void Set(bool value) 
        {
            var mouse = new MouseWheel(parent, null, step);

 /*           foreach (var item in parent.GetAllChildren())
            {
                MouseWheel mouse = null;
                if (resizers.ContainsKey(item))
                {
                    mouse = resizers[item];
                } 
                else 
                { 
                    mouse = new MouseWheel(parent, item, step);
                    resizers[item] = mouse;
                }
                mouse.Set(value);
            }
        */
        }

        class MouseWheel
        {
            private Control parent;

            private Control control;

            float zoom = 1f;

            float step = 1f;

           Point zero = new Point(0, 0);

            

            internal MouseWheel(Control parent, Control control, float step = 0.1f)
            {
                this.parent = parent;
                this.control = control;
                parent.MouseWheel += Control_MouseWheel;
                this.step = step;
            }

            internal void Set(bool value) 
            { 
                if (value)
                {
                   parent.MouseWheel += Control_MouseWheel;
                }
                else
                {
                    parent.MouseWheel -= Control_MouseWheel;
                }
            }

            private void Control_MouseWheel(object sender, MouseEventArgs e)
            {
               ((HandledMouseEventArgs)e).Handled = false;
               if (e.Delta > 0)
                {
                    zoom += step;
                }
                else if (zoom > 1f)
                {
                    zoom -= step;
                }                
                if (zoom == 1f) { return; }
                if (parent.Parent != null)
                {
                    Control p = parent.Parent;
                    parent.Width = (int)(zoom * p.Width);
                    parent.Height = (int)(zoom * p.Height);
                    var lp = p.PointToScreen(e.Location);
                    var l = parent.PointToScreen(zero);
                    var offX = lp.X - l.X;
                    var offY = lp.Y - l.Y;
                    Panel panel = p as Panel;
                    panel.HorizontalScroll.Value = offX;
                    ((HandledMouseEventArgs)e).Handled = true;
                    panel.VerticalScroll.Value = offY;
                    ((HandledMouseEventArgs)e).Handled = true;
                 }
            }
        }
    }
}
