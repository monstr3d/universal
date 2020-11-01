using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using ResourceService;

namespace ToolBox
{
    /// <summary>
    /// Moved picture box
    /// </summary>
    [Serializable()]
    public class MovedPictureBox : PictureBox, ISetBorders, ISerializable, ICloneable
    {
        #region Fields

        private ControlPanel[] panels;
        private bool moved;
        private int mouseX;
        private int mouseY;
        private Bitmap bmpTemp;
        private bool isActive = false;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MovedPictureBox()
        {
            init();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public MovedPictureBox(SerializationInfo info, StreamingContext context)
        {
            Left = (int)info.GetValue("Left", typeof(int));
            Top = (int)info.GetValue("Top", typeof(int));
            Width = (int)info.GetValue("Width", typeof(int));
            Height = (int)info.GetValue("Height", typeof(int));
            Image = (Image)info.GetValue("Bitmap", typeof(Bitmap));
            init();
        }

        #endregion

        #region Members

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
            bmpTemp = new Bitmap(Image);
            info.AddValue("Bitmap", bmpTemp);
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public object Clone()
        {
            MovedPictureBox clone = new MovedPictureBox();
            clone.Image = new Bitmap(Image);
            clone.Left = Left;
            clone.Top = Top;
            clone.Width = Width;
            clone.Height = Height;
            return clone;
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
            ControlPanel.RemovePanels(this);
            isActive = false;
        }

        /// <summary>
        /// Moved pictute
        /// </summary>
        public Control MovePicture
        {
            get
            {
                return null;
            }
        }


        /// <summary>
        /// The "is empty" sign
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return false;
            }
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
            ControlPanel.Move(this, dx, dy);

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
            ControlPanel.SetPanels(this, panels);
            Focus();
            ControlPanel.DeactivateOther(this);
            isActive = true;
        }


        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (Panel p in panels)
                {
                    p.Dispose();
                }
                Dispose();
            }
        }

        private void enter(object sender, EventArgs e)
        {
            ControlPanel.SetPanels(this, panels);
        }


        private void exit(object sender, EventArgs e)
        {
            Deactivate();
        }



        private void init()
        {
            AllowDrop = true;
            panels = new ControlPanel[]{new ControlPanel(this, 0), new ControlPanel(this, 1), 
										   new ControlPanel(this, 2), new ControlPanel(this, 3)};
            for (int i = 0; i < panels.Length; i++)
            {
                panels[i].Width = 4;
                panels[i].Height = 4;
                panels[i].BackColor = Color.Black;
            }
            Enter += new EventHandler(enter);
            Leave += new EventHandler(exit);
            MouseDown += new MouseEventHandler(onMouseDownEventHandler);
            MouseUp += new MouseEventHandler(onMouseUpEventHandler);
            MouseMove += new MouseEventHandler(onMouseMoveEventHandler);
            KeyDown += new KeyEventHandler(keyDown);
            MenuItem itCopy = new MenuItem(Resources.GetControlResource("Copy", new Dictionary<string, object>[]
                {
                ResourceService.Resources.ControlResources}));
            MenuItem itPaste = new MenuItem(Resources.GetControlResource("Paste", new Dictionary<string, object>[]
                {
                ResourceService.Resources.ControlResources}));
            itPaste.Click += new EventHandler(pasteClick);
            itCopy.Click += new EventHandler(copyClick);
            DragEnter += new DragEventHandler(dragEnter);
            DragDrop += new DragEventHandler(dragDrop);
            ContextMenu = new ContextMenu(new MenuItem[] { itCopy, itPaste });
        }

        private void pasteClick(object sender, EventArgs e)
        {
            IDataObject ob = System.Windows.Forms.Clipboard.GetDataObject();
            if (ob.GetDataPresent("System.Drawing.Bitmap"))
            {
                Image = ob.GetData("System.Drawing.Bitmap") as Image;
            }
        }

        private void copyClick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Image);
            System.Windows.Forms.Clipboard.SetDataObject(bmp, true);
        }


        private void dragEnter(object sender, DragEventArgs e)
        {
            /*		string[] str = e.Data.GetFormats();
                    foreach (string s in str)
                    {
                        object o = e.Data.GetData(s);
                        o = o;
                    }*/
            /*	string[] str = e.Data.GetFormats();
                foreach (string s in str)
                {
                    object o = e.Data.GetData(s);
                    o = o;
                }*/

            if (e.Data.GetDataPresent("FileNameW"))
            {
                Array a = e.Data.GetData("FileNameW") as Array;
                string s = a.GetValue(0) as string;
                string fin = s.Substring(s.Length - 4).ToLower();
                if (fin.Equals(".bmp") | fin.Equals(".gif") | fin.Equals(".jpg") | fin.Equals(".ico") | fin.Equals("jpeg"))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
        }
        private void dragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileNameW"))
            {
                Array a = e.Data.GetData("FileNameW") as Array;
                string s = a.GetValue(0) as string;
                string fin = s.Substring(s.Length - 4).ToLower();
                if (fin.Equals(".bmp") | fin.Equals(".gif") | fin.Equals(".jpg") | fin.Equals(".ico") | fin.Equals("jpeg"))
                {
                    Image = new Bitmap(s);
                    return;
                }
            }
        }

        #endregion

    }
}
