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
    /// Moved box
    /// </summary>
    public class MovedBox : PictureBox
    {
        /// <summary>
        /// label
        /// </summary>
        private IObjectLabelUI label;

        private bool moved;

        private int mouseX;

        private int mouseY;




        private MovedBox()
        {
            InitializeComponent();
            Image = ResourceImage.Move;
            Width = Image.Width;
            Height = Image.Height;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Associated label</param>
        public MovedBox(IObjectLabelUI label)
            : this()
        {
            this.label = label;
        }


        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MovedBox
            // 
            this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovedBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovedBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovedBox_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void MovedBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            moved = true;
            desktop.SetBlocking(true);

        }

        private void MovedBox_MouseUp(object sender, MouseEventArgs e)
        {
            moved = false;
            desktop.SetBlocking(false);
        }

        private void MovedBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moved)
            {
                return;
            }
            int dx = e.X - mouseX;
            int dy = e.Y - mouseY;
            Left += dx;
            Top += dy;
            label.X += dx;
            label.Y += dy;
            PanelDesktop d = label.Desktop as PanelDesktop;
            d.Redraw();
        }

        private PanelDesktop desktop
        {
            get
            {
                return label.Desktop as PanelDesktop;
            }
        }
    }
}
