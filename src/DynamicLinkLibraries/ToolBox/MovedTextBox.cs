using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;



namespace ToolBox
{
    /// <summary>
    /// Moved text box
    /// </summary>
    [Serializable()]
    public class MovedTextBox : TextBox, ISetBorders, ISerializable, ICloneable
    {
        #region Fields

        private ControlPanel[] panels;
        private bool moved;
        private int mouseX;
        private int mouseY;
        private PictureBox movePicture;
        private bool isActive;
        static private Image moveImage;

        #endregion

        #region Constructors & Destuctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MovedTextBox()
        {
            init();
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MovedTextBox(SerializationInfo info, StreamingContext context)
        {
            Left = (int)info.GetValue("Left", typeof(int));
            Top = (int)info.GetValue("Top", typeof(int));
            Width = (int)info.GetValue("Width", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            Text = (string)info.GetValue("Text", typeof(string));
            string fontFamilyName = (string)info.GetValue("FontFamilyName", typeof(string));
            bool bold = (bool)info.GetValue("FontBold", typeof(bool));
            bool italic = (bool)info.GetValue("FontItalic", typeof(bool));
            bool underline = (bool)info.GetValue("FontUnderline", typeof(bool));
            bool strikeout = (bool)info.GetValue("Strikeout", typeof(bool));
            FontStyle fs = 0;
            if (bold)
            {
                fs |= FontStyle.Bold;

            }
            else
            {
                fs |= FontStyle.Regular;
            }
            if (italic)
            {
                fs |= FontStyle.Italic;
            }
            if (underline)
            {
                fs |= FontStyle.Underline;
            }
            if (strikeout)
            {
                fs |= FontStyle.Strikeout;
            }
            float size = (float)info.GetValue("FontSize", typeof(float));
            this.Font = new Font(fontFamilyName, size, fs, GraphicsUnit.Point);
            BorderStyle = BorderStyle.None;
            init();
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~MovedTextBox()
        {
            if (!IsDisposed)
            {
                try
                {
                    Dispose();
                }
                catch (Exception)
                {
                }
            }
        }




        #endregion


        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Left", Left);
            info.AddValue("Top", Top);
            info.AddValue("Width", Width);
            info.AddValue("Height", Height);
            info.AddValue("Text", Text);
            Font font = this.Font;
            info.AddValue("FontFamilyName", font.Name);
            info.AddValue("FontSize", font.SizeInPoints);
            info.AddValue("FontBold", font.Bold);
            info.AddValue("FontItalic", font.Italic);
            info.AddValue("FontHeight", font.Height);
            info.AddValue("FontUnderline", font.Underline);
            info.AddValue("Strikeout", font.Strikeout);
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public object Clone()
        {
            MovedTextBox clone = new MovedTextBox();
            clone.Left = Left;
            clone.Top = Top;
            clone.Width = Width;
            clone.Height = Height;
            string s = "";
            foreach (char c in Text)
            {
                s += c;
            }
            clone.Text = s;
            Font font = this.Font;
            FontStyle fs = 0;
            if (font.Bold)
            {
                fs |= FontStyle.Bold;

            }
            else
            {
                fs |= FontStyle.Regular;
            }
            if (font.Italic)
            {
                fs |= FontStyle.Italic;
            }
            if (font.Underline)
            {
                fs |= FontStyle.Underline;
            }
            if (font.Strikeout)
            {
                fs |= FontStyle.Strikeout;
            }
            clone.Font = new Font(font.Name, font.SizeInPoints, fs, GraphicsUnit.Point);
            clone.BorderStyle = BorderStyle.None;
            return clone;
        }


        /// <summary>
        /// Moved image
        /// </summary>
        static public Image MoveImage
        {
            set
            {
                moveImage = value;
            }
        }

        /// <summary>
        /// Gets corner control
        /// </summary>
        /// <param name="i">Control number</param>
        /// <returns>Corner control</returns>
        public ControlPanel this[int i]
        {
            get
            {
                return panels[i];
            }
        }

        /// <summary>
        /// Deactivates itself
        /// </summary>
        public void Deactivate()
        {
            if (!isActive)
            {
                return;
            }
            ControlPanel.RemovePanels(this);
            if (Text.Length > 0)
            {
                BorderStyle = BorderStyle.None;
            }
            if (Parent != null)
            {
                if (Parent.Contains(movePicture))
                {
                    Parent.Controls.Remove(movePicture);
                }
            }
            isActive = false;
            moved = false;
        }


        /// <summary>
        /// The "is active" sign
        /// </summary>
        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        /// <summary>
        /// Moved pictute
        /// </summary>
        public Control MovePicture
        {
            get
            {
                return movePicture;
            }
        }

        /// <summary>
        /// The "is empty" sign
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Text.Length != 0;
            }
        }

        /// <summary>
        /// Shows font dialog
        /// </summary>
        /// <param name="control">Base control</param>
        static public void ShowFontDialog(Control control)
        {
            TextBox box = ControlPanel.GetActiveTextBox(control);
            if (box == null)
            {
                return;
            }
            FontDialog dlg = new FontDialog();
            Control c = control.Parent;
            while (true)
            {
                if (c.Parent == null)
                {
                    break;
                }
                c = c.Parent;
            }
            dlg.ShowDialog(c as Form);
            Font font = dlg.Font;
            box.Font = font;
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
            Control p = Parent;
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
            ControlPanel.Move(this, dx, dy);
            movePicture.Left += dx;
            movePicture.Top += dy;
        }



        private void keyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    foreach (Panel p in panels)
                    {
                        Parent.Controls.Remove(p);
                    }
                    Parent.Controls.Remove(movePicture);
                    Parent.Controls.Remove(this);
                }
                catch (Exception)
                {
                   // ex = ex;
                }
            }
        }

        private void enter(object sender, EventArgs e)
        {
            string text = Text.Clone() as string;
            Control p = Parent;
            movePicture.Left = Left;
            movePicture.Top = Top - movePicture.Height;
            p.Controls.Add(movePicture);
            ControlPanel.SetPanels(this, panels);
            ControlPanel.DeactivateOther(this);
            isActive = true;
        }




        private void exit(object sender, EventArgs e)
        {
            Deactivate();
        }

        private void init()
        {
            Multiline = true;
            panels = new ControlPanel[]{new ControlPanel(this, 0), new ControlPanel(this, 1), 
										   new ControlPanel(this, 2), new ControlPanel(this, 3)};
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Width = 4;
                panels[i].Height = 4;
                panels[i].BackColor = Color.Black;
            }
            if (moveImage == null)
            {
                moveImage = ResourceImage.Move;
            }
            movePicture = new PictureBox();
            movePicture.Width = moveImage.Width;
            movePicture.Height = moveImage.Height;
            movePicture.Image = moveImage;
            movePicture.Cursor = Cursors.SizeAll;
            Enter += new EventHandler(enter);
            Leave += new EventHandler(exit);
            movePicture.MouseDown += new MouseEventHandler(onMouseDownEventHandler);
            movePicture.MouseUp += new MouseEventHandler(onMouseUpEventHandler);
            movePicture.MouseMove += new MouseEventHandler(onMouseMoveEventHandler);
            KeyDown += new KeyEventHandler(keyDown);
           ToolStripMenuItem   itFont = new ToolStripMenuItem("Font");
            //	itFont.Text = "Font";
            itFont.Click += new EventHandler(selectFont);
            try
            {
                //ContextMenu..MenuItems..IsReadOnly = false;
                //ContextMenu = new ContextMenu(new MenuItem[]{itFont});
            }
            catch (Exception)
            {
                //ex = ex;
            }
        }




        private void selectFont(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            dlg.ShowDialog(Parent);
            Font = dlg.Font;
        }
    }
}
