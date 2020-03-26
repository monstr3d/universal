using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

using Common.UI;




namespace ToolBox
{
    /// <summary>
    /// Control panel
    /// </summary>
    public class ControlPanel : Panel, ICommentsCreator
    {

        #region Fields

        private int type;
        private Control parent;
        private bool moved;
        private int mouseX;
        private int mouseY;
        private ISetBorders bord;

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ControlPanel Object = new ControlPanel();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        private ControlPanel()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">Parent control</param>
        /// <param name="type">Type</param>
        public ControlPanel(Control parent, int type)
        {
            this.parent = parent;
            this.type = type;
            bord = parent as ISetBorders;
            MouseDown += new MouseEventHandler(onMouseDownEventHandler);
            MouseUp += new MouseEventHandler(onMouseUpEventHandler);
            MouseMove += new MouseEventHandler(onMouseMoveEventHandler);
            switch (type)
            {
                case 0:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 1:
                    Cursor = Cursors.SizeNESW;
                    break;
                case 2:
                    Cursor = Cursors.SizeNWSE;
                    break;
                case 3:
                    Cursor = Cursors.SizeNESW;
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region ICommentsCreator Members

        void ICommentsCreator.CreateComments(Stream stream, Control control)
        {
            LoadControls(control, stream, null, stream.Position);
        }

        #endregion

        #region Members

        /// <summary>
        /// Clears comments
        /// </summary>
        /// <param name="control">Control of comments</param>
        public static void ClearComments(Control control)
        {
            ArrayList controls = new ArrayList();
            foreach (Control c in control.Controls)
            {
                if (c is ISetBorders)
                {
                    controls.Add(c);
                }
            }
            foreach (Control c in controls)
            {
                try
                {
                    control.Controls.Remove(c);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Adds drags to control
        /// </summary>
        /// <param name="control">The control</param>
        public static void AddDrag(Control control)
        {
            EditorReceiver.AddEditorDrag(control);
            PictureReceiver.AddImageDrag(control);
        }

        /// <summary>
        /// Gets active text box
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <returns>The active text box</returns>
        public static TextBox GetActiveTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (!(c is TextBox) & !(c is ISetBorders))
                {
                    continue;
                }
                ISetBorders s = c as ISetBorders;
                if (s.IsActive)
                {
                    return c as TextBox;
                }
            }
            return null;
        }

        /// <summary>
        /// Sets font to active control
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="font">Font to set</param>
        public static void SetFontToActive(Control control, Font font)
        {
            TextBox box = GetActiveTextBox(control);
            if (box != null)
            {
                box.Font = font;
            }
        }

        /// <summary>
        /// Loads controls from list
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="list">List of controls</param>
        public static void LoadControls(Control control,  ICollection list)
        {
            if (list == null)
            {
                return;
            }
            foreach (ICloneable c in list)
            {
                control.Controls.Add(c.Clone() as Control);
            }
        }


        /// <summary>
        /// Loads controls from list
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="list">List of controls</param>
        public static void LoadControls(Control control, List<object> list)
        {
            if (list == null)
            {
                return;
            }
            foreach (ICloneable c in list)
            {
                control.Controls.Add(c.Clone() as Control);
            }
        }

        /// <summary>
        /// Loads controls from stream
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="stream">The stream</param>
        /// <param name="binder">Serialization binder</param>
        /// <param name="position">Stream position</param>
        public static void LoadControls(Control control, Stream stream, SerializationBinder binder, long position)
        {
            try
            {
                BinaryFormatter f = new BinaryFormatter();
                if (binder != null)
                {
                    f.Binder = binder;
                }
                stream.Position = position;
                ArrayList cont = (ArrayList)f.Deserialize(stream);
                LoadControls(control, cont);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Gets controls
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <returns>List of controls</returns>
        public static ArrayList GetControls(Control control)
        {

            ArrayList list = new ArrayList();
            foreach (Control c in control.Controls)
            {
                if (!(c is ISetBorders))
                {
                    continue;
                }
                ICloneable clone = c as ICloneable;
                list.Add(clone.Clone());
            }
            return list;
        }


        /// <summary>
        /// Gets comments controls
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <returns>List of controls</returns>
        public static List<object> GetComments(Control control)
        {
            List<object> list = new List<object>();
            foreach (Control c in control.Controls)
            {
                if (!(c is ISetBorders))
                {
                    continue;
                }
                ICloneable clone = c as ICloneable;
                list.Add(clone.Clone());
            }
            return list;
        }

        /// <summary>
        /// Saves controls to stream
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="stream">The stream</param>
        public static void SaveControls(Control control, Stream stream)
        {
            ArrayList list = GetControls(control);
            BinaryFormatter f = new BinaryFormatter();
            f.Serialize(stream, list);
        }

        /// <summary>
        /// Sets panels
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="panels">Panels</param>
        public static void SetPanels(Control control, ControlPanel[] panels)
        {
            panels[0].Left = control.Left - panels[0].Width;
            panels[0].Top = control.Top - panels[0].Height;
            panels[1].Left = control.Left + control.Width + panels[1].Width;
            panels[1].Top = control.Top - panels[1].Height;
            panels[2].Left = control.Left + control.Width + panels[2].Width;
            panels[2].Top = control.Top + control.Height + panels[2].Height;
            panels[3].Left = control.Left - panels[3].Width;
            panels[3].Top = control.Top + control.Height + panels[3].Height;
            Control p = control.Parent;
            foreach (Control c in panels)
            {
                if (p.Controls.Contains(c))
                {
                    continue;
                }
                p.Controls.Add(c);
            }
        }

        /// <summary>
        /// Removes panels
        /// </summary>
        /// <param name="control">Parent control</param>
        public static void RemovePanels(Control control)
        {
            Control p = control.Parent;
            if (p == null)
            {
                return;
            }
            ISetBorders s = control as ISetBorders;
            for (int i = 0; i < 4; i++)
            {
                Control c = s[i];
                if (!p.Controls.Contains(c))
                {
                    continue;
                }
                try
                {
                    if (c != null)
                    {
                        if (!c.IsDisposed)
                        {
                            p.Controls.Remove(c);
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Removes control with children
        /// </summary>
        /// <param name="control">The control</param>
        public static void Remove(Control control)
        {
            RemovePanels(control);
            control.Parent.Controls.Remove(control);
        }

        /// <summary>
        /// Deactivates other controls
        /// </summary>
        /// <param name="control">Active ontrol</param>
        public static void DeactivateOther(Control control)
        {
            Control p = control.Parent;
            foreach (Control c in p.Controls)
            {
                if (c == control)
                {
                    continue;
                }
                if (!(c is ISetBorders))
                {
                    continue;
                }
                ISetBorders s = c as ISetBorders;
                if (s == null)
                {
                    continue;
                }
                s.Deactivate();
            }
        }

        /// <summary>
        /// Deactivates all controls
        /// </summary>
        /// <param name="control">Parent control</param>
        public static void DeactivateAll(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (!(c is ISetBorders))
                {
                    continue;
                }
                ISetBorders s = c as ISetBorders;
                if (s == null)
                {
                    continue;
                }
                s.Deactivate();
            }
        }

        /// <summary>
        /// Creates peer of comments
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="comments">Comments</param>
        public static void CreatePeer(Control control, ICollection comments)
        {
            foreach (object o in comments)
            {
                if (o is MovedTextBox)
                {
                    MovedTextBox tb = o as MovedTextBox;
                    Label l = new Label();
                    l.BackColor = Color.White;
                    l.Left = tb.Left;
                    l.Top = tb.Top;
                    l.Width = tb.Width;
                    l.Height = tb.Height;
                    l.Font = tb.Font;
                    l.Text = tb.Text;
                    control.Controls.Add(l);
                    continue;
                }
                MovedPictureBox mpb = o as MovedPictureBox;
                PictureBox p = new PictureBox();
                p.Left = mpb.Left;
                p.Top = mpb.Top;
                p.Width = mpb.Width;
                p.Height = mpb.Height;
                p.Image = mpb.Image;
                control.Controls.Add(p);
            }
        }

        /// <summary>
        /// Moves control
        /// </summary>
        /// <param name="c">The control</param>
        /// <param name="dx">The X - shift</param>
        /// <param name="dy">The Y - shift</param>
        new public static void Move(Control c, int dx, int dy)
        {
            c.Left += dx;
            c.Top += dy;
            ISetBorders s = c as ISetBorders;
            for (int i = 0; i < 4; i++)
            {
                s[i].Left += dx;
                s[i].Top += dy;
            }
        }



        /// <summary>
        /// Mouse down event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        protected void onMouseDownEventHandler(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            moved = true;
        }

        /// <summary>
        /// Mouse up event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        protected void onMouseUpEventHandler(object sender, MouseEventArgs e)
        {
            moved = false;
        }

        /// <summary>
        /// Mouse move event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event arguments</param>
        protected void onMouseMoveEventHandler(object sender, MouseEventArgs e)
        {
            if (!moved)
            {
                return;
            }
            int dx = e.X - mouseX;
            int dy = e.Y - mouseY;
            Left += dx;
            Top += dy;
            Control pict = bord.MovePicture;
            if (type == 0)
            {
                bord[3].Left += dx;
                bord[1].Top += dy;
                parent.Left += dx;
                parent.Top += dy;
                parent.Width -= dx;
                parent.Height -= dy;
                if (pict != null)
                {
                    pict.Left += dx;
                    pict.Top += dy;
                }
            }
            if (type == 1)
            {
                bord[0].Top += dy;
                bord[2].Left += dx;
                parent.Top += dy;
                parent.Height -= dy;
                parent.Width += dx;
                if (pict != null)
                {
                    pict.Top += dy;
                }
            }
            if (type == 2)
            {
                bord[1].Left += dx;
                bord[3].Top += dy;
                parent.Height += dy;
                parent.Width += dx;
            }
            if (type == 3)
            {
                bord[0].Left += dx;
                bord[2].Top += dy;
                parent.Left += dx;
                parent.Width -= dx;
                parent.Height += dy;
                if (pict != null)
                {
                    pict.Left += dx;
                }
            }
        }

        #endregion

    }
}
