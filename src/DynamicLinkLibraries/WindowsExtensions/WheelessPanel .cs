using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsExtensions
{

    public enum ResizeType
    {
        Both,
        Horizontal,
        Vertical
    };

    /// <summary>
    /// Panel wihout wheel event
    /// </summary>
    public class WheelessPanel : Panel
    {
        bool first = true;


        Point zero = new Point(0, 0);



        /// <summary>
        /// Default Constructor
        /// </summary>
        public WheelessPanel()
        {
           AutoScroll = true;
        }

        float zoom = 1f;
        /// <summary>
        /// Mouse wheel event
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
 
            (e as HandledMouseEventArgs).Handled = true;
            if (e.Delta > 0)
            {
                zoom += Step;
            }
            else if (zoom > 1f)
            {
                zoom -= Step;
            }
            var c = Controls[0];
            if (first)
            {
                c.Dock = DockStyle.None;
                c.Top = 0;
                c.Left = 0;
                c.Width = Width;
                c.Height = Height;
                first = false;
            }
            ResizeChild(c, e);
        }

        void ResizeChild(Control control, MouseEventArgs e)
        {
            var d = zoom;
            switch (ResizeType)
            {
                case ResizeType.Horizontal:
                    control.Width = (int)(Width * zoom);
                    HorizontalScroll.Value = (int)(e.X * d);
                    break;
                case ResizeType.Vertical:
                    control.Height = (int)(Height * zoom);
                    VerticalScroll.Value = (int)(e.Y * d);
                    break;
                    case ResizeType.Both:
                    control.Width = (int)(Width * zoom);
                    control.Height = (int)(Height * zoom);
                    VerticalScroll.Value = (int)(e.Y * d);
                    break;
                    default: break;
            }
            var lp = PointToScreen(e.Location);
            var l = control.PointToScreen(zero);
       /*     var offX = lp.X - l.X;
            var offY = lp.Y - l.Y;*/
  

        }

        /// <summary>
        /// Step
        /// </summary>
        public float Step
        { get; set; } = 0.1f;

        /// <summary>
        /// Type of resize
        /// </summary>
        public ResizeType ResizeType { get; set; } = ResizeType.Both;
    }
}
