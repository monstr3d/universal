using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

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
            try
            {
                switch (ResizeType)
                {
                    case ResizeType.Horizontal:
                        control.Width = (int)(Width * zoom);
                        ///             HorizontalScroll.Maximum = control.Width + 40;
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
            }
            catch { }

        }

        /// <summary>
        /// Step
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Step
        /// </summary>
        public float Step
        { get; set; } = 0.1f;

        /// <summary>
        /// Type of resize
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Type of resize
        /// </summary>
        public ResizeType ResizeType { get; set; } = ResizeType.Both;
    }
}
