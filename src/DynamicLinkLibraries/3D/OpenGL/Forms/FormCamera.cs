using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using WindowsExtensions;

namespace InterfaceOpenGL.Forms
{
    public partial class FormCamera : Form, IUpdatableForm, IRedraw, IStartStop
    {
        #region Fields
        
        private Panel pan = null;
        private OpenGLCamera camera;
        private bool first = true;
        private int w;
        private int h;

        #endregion

        private FormCamera()
        {
            InitializeComponent();
            w = Width;
            h = Height;
        }

        internal FormCamera(OpenGLCamera camera)
            : this()
        {
            this.camera = camera;
            ResourceService.Resources.LoadControlResources(this, InterfaceOpenGL.Utils.ControlUtilites.Resources);
            pan = panelDesktopCenter;
            camera.Graphics = Graphics.FromHwnd(pan.Handle);
            pan.BackColor = Color.FromArgb(0, 0, 255);
            UpdateFormUI();
            resize(camera.Width, camera.Height);
            textBoxWidth.Text = camera.Width + "";
            textBoxHeight.Text = camera.Height + "";
            textBoxAngle.Text = camera.ReferenceAngle + "";
        }

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            CategoryTheory.IAssociatedObject ao = camera;
            object o = ao.Object;
            if (o == null)
            {
                return;
            }
            if (!(o is INamedComponent))
            {
                return;
            }
            INamedComponent nc = o as INamedComponent;
            Text = nc.Name;
        }

        #endregion

        private void resize(int width, int height)
        {
            int dw = width - 600;
            int dh = height - 600;
            Width = w + dw;
            Height = h + dh;
            pan.Width = width;
            pan.Height = height;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (first)
            {
                camera.Prepare(camera.Graphics, 0);
                first = false;
            }
            camera.UpdateImage();
        }


        private void save(string filename)
        {
            BitmapConsumer.IBitmapProvider p = camera;
            Bitmap bmp = p.Bitmap;
            bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void saveAs()
        {
            if (saveFileDialogBmp.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            save(saveFileDialogBmp.FileName);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveAs();
        }


        #region IRedraw Members

        void IRedraw.Redraw()
        {
            camera.UpdateImage();
        }

        #endregion

        private void buttonStart_Click(object sender, EventArgs e)
        {
        }     

        private void buttonSize_Click(object sender, EventArgs e)
        {
            try
            {
                int w = Int32.Parse(textBoxWidth.Text);
                int h = Int32.Parse(textBoxHeight.Text);
                resize(h, w);
                camera.Set(h, w);
                pan.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRefAngle_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Double.Parse(textBoxAngle.Text);
                camera.ReferenceAngle = a;
                pan.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void toolStripStop_Click(object sender, EventArgs e)
        {
            IProcess p = Motion6D.StaticExtensionMotion6D.Animation;
            if (p != null)
            {
                p.Terminate();
            }
        }

        private void Act(object type, bool start)
        {
            if (IsDisposed)
            {
                return;
            }
            toolStripStart.Enabled = !start;
            toolStripStop.Enabled = false;
        }

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            //this.InvokeIfNeeded<object, bool>(Act, type, start);
        }

        #endregion
    }
}