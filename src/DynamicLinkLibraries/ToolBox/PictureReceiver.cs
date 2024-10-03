using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace ToolBox
{
    /// <summary>
    /// Receiver of picture
    /// </summary>
    public class PictureReceiver
    {

        private Control control;
        private PictureReceiver(Control control)
        {
            this.control = control;
        }
        private void dragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Text"))
            {
                return;
            }
            string str = e.Data.GetData("Text") as string;
            if (!str.Equals("MovedPicture"))
            {
                return;
            }
            e.Effect = DragDropEffects.Copy;
        }
        private void dragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Text"))
            {
                return;
            }
            string str = e.Data.GetData("Text") as string;
            if (!str.Equals("MovedPicture"))
            {
                return;
            }
            PictureBox box = new MovedPictureBox();
            int x = 0, y = 0;
            FormTools.GetCoordinates(control, ref x, ref y);
            box.Left = e.X - x;
            box.Top = e.Y - y;
            box.Image = ResourceImage.CommentPicture.ToBitmap();
            control.Controls.Add(box);
        }

        private void dragLeave(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Text"))
            {
                return;
            }
            string str = e.Data.GetData("Text") as string;
            if (str.Equals("MovedPicture"))
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Adds image drag to control
        /// </summary>
        /// <param name="control">The control</param>
        public static void AddImageDrag(Control control)
        {
            PictureReceiver r = new PictureReceiver(control);
            control.AllowDrop = true;
            control.DragEnter += new DragEventHandler(r.dragEnter);
            control.DragDrop += new DragEventHandler(r.dragDrop);
        }
    }
}
