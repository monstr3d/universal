using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToolBox
{
    /// <summary>
    /// Receiver of text box
    /// </summary>
    public class EditorReceiver
    {
        #region Fields

        private Control control;


        #endregion

        #region Ctor

        private EditorReceiver(Control control)
        {
            this.control = control;
        }

        #endregion

        #region Members

        /// <summary>
        /// Adds editor drag
        /// </summary>
        /// <param name="control">Control to drag</param>
        public static void AddEditorDrag(Control control)
        {
            EditorReceiver r = new EditorReceiver(control);
            control.AllowDrop = true;
            control.DragEnter += new DragEventHandler(r.dragEnter);
            control.DragDrop += new DragEventHandler(r.dragDrop);
        }


        private void dragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Text"))
            {
                return;
            }
            string str = e.Data.GetData("Text") as string;
            if (!str.Equals("MovedEditor"))
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
            if (!str.Equals("MovedEditor"))
            {
                return;
            }
            TextBox tf = new MovedTextBox();
            int x = 0, y = 0;
            FormTools.GetCoordinates(control, ref x, ref y);
            tf.Left = e.X - x;
            tf.Top = e.Y - y;
            control.Controls.Add(tf);
        }

        private void dragLeave(object sender, DragEventArgs e)
        {
        }


        #endregion
    }
}
