using System.Drawing;

using System.Windows.Forms;

using CategoryTheory;

namespace Diagram.UI
{
    /// <summary>
    /// Converter of dragdrop
    /// </summary>
    class DragDropConverter
    {
        #region Field

        ICategoryObjectConverter converter;
        PanelDesktop desktop;

        #endregion

        #region Ctor

        internal DragDropConverter(ICategoryObjectConverter converter, PanelDesktop desktop)
        {
            this.converter = converter;
            this.desktop = desktop;
            desktop.AllowDrop = true;
            desktop.DragEnter += dragEnter;
            desktop.DragDrop += dragDrop;
        }

        #endregion

        private void dragEnter(object sender, DragEventArgs e)
        {
            string[] s = e.Data.GetFormats();
            if (s == null)
            {
                return;
            }
            if (s.Length != 1)
            {
                return;
            }
            object o = e.Data.GetData(s[0]);
            if (!converter.Accept(o))
            {
                return;
            }
            e.Effect = DragDropEffects.Copy;
        }


        private void dragDrop(object sender, DragEventArgs e)
        {
            string[] s = e.Data.GetFormats();
            if (s == null)
            {
                return;
            }
            if (s.Length != 1)
            {
                return;
            }
            object o = e.Data.GetData(s[0]);
            if (!converter.Accept(o))
            {
                return;
            }
            ICategoryObject ob = converter.Convert(o);
            int x = e.X;
            int y = e.Y;
            Point p = desktop.PointToClient(new Point(x, y));
            desktop.Add(ob, p.X, p.Y);
        }

        private void dragLeave(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Text"))
            {
                return;
            }
            string str = e.Data.GetData("Text") as string;
            if (str.Equals("MovedEditor"))
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public static void GetCoordinates(Control c, out int x, out int y)
        {
            x = c.Left;
            y = c.Top;
            Control p = c.Parent;
            if (p == null)
            {
                return;
            }
            int xp = 0;
            int yp = 0;
            GetCoordinates(p, out xp, out yp);
            x += xp;
            y += yp;
        }


        public static void GetCoordinates(Control s, Control t, int xi, int yi, out int x, out int y)
        {
            int xs = 0, ys = 0, xt = 0, yt = 0;
            GetCoordinates(s, out xs, out ys);
            GetCoordinates(t, out xt, out yt);
            x = xi + xs - xt;
            y = yi + xs - xt;
        }
    }
}