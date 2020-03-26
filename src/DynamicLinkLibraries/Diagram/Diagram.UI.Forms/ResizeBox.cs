using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;

namespace Diagram.UI
{
    /// <summary>
    /// Box for resizing
    /// </summary>
    public class ResizeBox : PictureBox
    {
        /// <summary>
        /// label
        /// </summary>
        private IObjectLabelUI label;

        private bool moved;

        private int mouseX;

        private int mouseY;




        private ResizeBox()
        {
            InitializeComponent();
            Image = new Bitmap(5, 5);
            Brush brush = new SolidBrush(Color.Black);
            Graphics g = Graphics.FromImage(Image);
            g.FillRectangle(brush, 0, 0, Image.Width, Image.Height);
            Width = Image.Width;
            Height = Image.Height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Associated label</param>
        public ResizeBox(IObjectLabelUI label)
            : this()
        {
            this.label = label;
        }


        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ResizeBox
            // 
            this.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizeBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizeBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeBox_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void ResizeBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            moved = true;

        }

        private void ResizeBox_MouseUp(object sender, MouseEventArgs e)
        {
            moved = false;
        }

        private void ResizeBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moved)
            {
                return;
            }
            int dx = e.X - mouseX;
            int dy = e.Y - mouseY;
            Left += dx;
            Top += dy;
            Control c = label as Control;
            c.Width += dx;
            c.Height += dy;
            PanelDesktop d = label.Desktop as PanelDesktop;
            d.Redraw();
        }
    }
}
