using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using ErrorHandler;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Nonstandard label
    /// </summary>
    public class NonstandardLabel
    {
        #region Fields

        IObjectLabelUI label;

        Control[] caption;

  //      bool arrowSelected;

        private TextBox captionEditor;

        bool isMoved = false;

        int mouseX;

        int mouseY;

        //private MovedBox box;

        private ResizeBox rbox;

        bool isRemoved = false;


        private int w;

        private int h;

        private int x;

        private int y;

        Action post;

        EventHandler resize;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Associated label</param>
        /// <param name="caption">Caption control</param>
        /// <param name="captionEditor">Caption editor</param>
        /// <param name="post">The "Post" acion</param>
        /// <param name="resize">The Resize event handler</param>
        public NonstandardLabel(IObjectLabelUI label, Control[] caption, TextBox captionEditor, Action post, EventHandler resize)
        {
            this.label = label;
            this.caption = caption;
            this.captionEditor = captionEditor;
            this.post = post;
            this.resize = resize;
            x = label.X;
            y = label.Y;
            Control c = label.Control as Control;
            w = c.Width;
            h = c.Height;
            if (captionEditor != null)
            {
                captionEditor.KeyUp += KeyUp;
            }
           // box = new MovedBox(label);
            rbox = new ResizeBox(label);
            c.Paint += Paint;
        }


        #endregion

        #region Members

        /// <summary>
        /// Removes itself
        /// </summary>
        /// <param name="removeForm">The "remove form" sign</param>
        public void Remove(bool removeForm)
        {
            Control cp = Parent;
            if (cp != null)
            {
                if (cp.Controls.Contains(rbox))
                {
                    cp.Controls.Remove(rbox);
                }
            }
            if (removeForm)
            {
                if (label is IShowForm)
                {
                    IShowForm sf = label as IShowForm;
                    Form form = sf.Form as Form;
                    if (form is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                    sf.RemoveForm();
                    sf = null;
                }
            }
            if (isRemoved)
            {
                return;
            }
            isRemoved = true;
            if (label is IDisposable dp)
            {
                dp.Dispose();
            }
            Control cont = label as Control;
            Control c = Parent;
            if (c != null)
            {
                PanelDesktop pd = pDesktop;
                if (c.Controls.Contains(cont))
                {
                    pd.Remove(label);
                    if (c.Controls.Contains(cont))
                    {
                        c.Controls.Remove(cont);
                    }
                }
            }
            if (label.Object is IDisposable d)
            {
                d.Dispose();
                label.Object = null;
            }
            cont.Dispose();
            label = null;
            cont = null;
            GC.Collect();
        }

        /// <summary>
        /// The is moved sign
        /// </summary>
        public bool IsMoved
        {
            get
            {
                return isMoved;
            }
            set
            {
                isMoved = value;
                pDesktop.IsMoved = value;
                pDesktop.SetBlocking(value);
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                label.Selected = !label.Selected;
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (label is IShowForm)
                {
                    IShowForm sf = label as IShowForm;
                    sf.Show();
                    return;
                }
            }
            /*  if (EditorRectangle.Contains(e.X, e.Y))
              {
                  return;
              }*/
            PaletteButton active = pDesktop.Tools.Active;
            if (active != null)
            {
                if (active.IsArrow & (active.ReflectionType != null))
                {
                    try
                    {
                        ICategoryArrow arrow = pDesktop.Tools.Factory.CreateArrow(active);
                        arrow.Source = label.Object;
                        pDesktop.ActiveArrow = arrow;
                        pDesktop.ActiveObjectLabel = label;
                        return;
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError(10);
                        return;
                    }
                }
            }
            IsMoved = true;
            pDesktop.SetBlocking(true);
            mouseX = e.X;
            mouseY = e.Y;
        }

        /// <summary>
        /// The on mouse move event handler
        /// Draws correspond arrows
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void MouseMove(object sender, MouseEventArgs e)
        {
            if (!e.IsArrowClick())
            {
                return;
            }
            if (pDesktop.ActiveArrow == null)
            {
                return;
            }
            pDesktop.DrawArrow(label as Control, e);
        }



        private void MouseUp(object sender, MouseEventArgs e)
        {
            Control caption = sender as Control;
            IsMoved = false;
            pDesktop.SetBlocking(false);
            PanelDesktop Desktop = pDesktop;
            ICategoryArrow arrow = Desktop.ActiveArrow;
            if (!StaticExtensionDiagramUIForms.IsArrowClick(e))
            {
                return;
            }
            try
            {
                if (arrow == null)
                {
                    pDesktop.Redraw();
                    return;
                }
                int x = this.label.X + caption.Left + e.X;
                int y = this.label.Y + caption.Top + e.Y;
                for (int i = 0; i < Desktop.Controls.Count; i++)
                {
                    if (!(Desktop.Controls[i] is IChildObjectLabel) & !(Desktop.Controls[i] is IObjectLabelUI))
                    {
                        continue;
                    }
                    Control c = Desktop.Controls[i];
                    bool hor = x < c.Left | x > c.Left + c.Width;
                    bool vert = y < c.Top | y > c.Top + c.Height;
                    if (hor | vert)
                    {
                        continue;
                    }
                    IObjectLabel label = null;
                    if (Desktop.Controls[i] is IObjectLabelUI)
                    {
                        label = Desktop.Controls[i] as IObjectLabel;
                    }
                    else
                    {
                        IChildObjectLabel child = Desktop.Controls[i] as IChildObjectLabel;
                        label = child.Label;
                    }

                    arrow.Target = label.Object;
                    IArrowLabel lab = Desktop.Tools.Factory.CreateArrowLabel(Desktop.Tools.Active, arrow, this.label, label);
                    lab.Arrow.SetAssociatedObject(lab);
                    Desktop.AddArrowLabel(lab);
                    break;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                if (arrow != null)
                {
                    if (arrow is IDisposable d)
                    {
                        d.Dispose();
                    }
                }
                ex.ShowError(1);
            }
            Desktop.ActiveArrow = null;
            Desktop.Redraw();
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            IsMoved = false;
            pDesktop.SetBlocking(false);
        }

        private PanelDesktop pDesktop
        {
            get
            {
                return label.Desktop as PanelDesktop;
            }
        }

        private Control Parent
        {
            get
            {
                return pDesktop;
            }

        }

        private void MMouseDown(object sender, MouseEventArgs e)
        {
            if (!pDesktop.Tools.IsMoved)
            {
                return;
            }
            mouseX = e.X;
            mouseY = e.Y;
            IsMoved= true;
            pDesktop.SetBlocking(true);

        }

        private void MMouseUp(object sender, MouseEventArgs e)
        {
            if (!pDesktop.Tools.IsMoved)
            {
                return;
            }
            IsMoved = false;
            pDesktop.SetBlocking(false);
        }

        private void MMouseMove(object sender, MouseEventArgs e)
        {
            Control caption = sender as Control;
            if (!pDesktop.Tools.IsMoved)
            {
                return;
            }
            if (!IsMoved)
            {
                return;
            }
            Control c = caption;
            int dx = e.X - mouseX;
            int dy = e.Y - mouseY;
            //c.Left += dx;
            //c.Top += dy;
            label.X += dx;
            label.Y += dy;
            PanelDesktop d = label.Desktop as PanelDesktop;
            if (label.Selected)
            {
                foreach (Control control in pDesktop.Controls)
                {
                    if (control is IObjectLabelUI)
                    {
                        IObjectLabelUI olui = control as IObjectLabelUI;
                        if (olui.Selected)
                        {
                            if (olui != label)
                            {
                                olui.X += dx;
                                olui.Y += dy;
                            }
                        }
                    }
                }
            }
            d.Redraw();
        }


        private void Paint(object sender, PaintEventArgs e)
        {
            if (Parent == null)
            {
                return;
            }
            Control c = label.Control as Control;
            if (Parent.Controls.Contains(rbox))
            {
                return;
            }
            c.Paint -= Paint;
            /* box.Left = c.Left - box.Width;
               box.Top = c.Top - box.Height;
               Parent.Controls.Add(box);
               */
            Parent.Controls.Add(rbox);
            label.X = label.X;
            label.Y = label.Y;
            try
            {
                c.Width = w;
                c.Height = h;
                rbox.Left = c.Left + c.Width;
                rbox.Top = c.Top + c.Height;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            if (post != null)
            {
              // !!! POST DELETE !!!  post();
            }
            init();
            if (resize != null)
            {
                c.Resize += resize;
            }
        }



        private void init()
        {
            foreach (Control c in caption)
            {
                c.MouseDown += MouseDown;
                c.MouseUp += MouseUp;
                c.MouseMove += MouseMove;
                c.MouseLeave += MouseLeave;
                c.MouseDown += MMouseDown;
                c.MouseUp += MMouseUp;
                c.MouseMove += MMouseMove;
            }
            Control cont = label.Control as Control;
            cont.LocationChanged += LocationChanged;

        }

        private void LocationChanged(object sender, EventArgs e)
        {
      /*      if (block != null)
            {
                block[0] = true;
            }*/
            Control c = label as Control;
            rbox.Left = c.Left + c.Width;
            rbox.Top = c.Top + c.Height;
          //  block[0] =false;
        }

        /// <summary>
        /// The key event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Cancel)
            {
                captionEditor.Visible = false;
                return;
            }
            if (e.KeyData == Keys.Enter)
            {
                label.ComponentName = captionEditor.Text;
                captionEditor.Visible = false;
            }
        }

        /// <summary>
        /// Saves label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="info">Serialization info</param>
        public static void Save(IObjectLabelUI label, SerializationInfo info)
        {
            info.AddValue("X", label.X, typeof(int));
            info.AddValue("Y", label.Y, typeof(int));
            Control c = label.Control as Control;
            info.AddValue("Width", c.Width, typeof(int));
            info.AddValue("Height", c.Height, typeof(int));
        }

        /// <summary>
        /// Loads label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="info">Serialization info</param>
        public static void Load(IObjectLabelUI label, SerializationInfo info)
        {
            label.X = (int)info.GetValue("X", typeof(int));
            label.Y = (int)info.GetValue("Y", typeof(int));
            Control c = label.Control as Control;
            c.Width = (int)info.GetValue("Width", typeof(int));
            c.Height = (int)info.GetValue("Height", typeof(int));
        }



        #endregion
    }
}
