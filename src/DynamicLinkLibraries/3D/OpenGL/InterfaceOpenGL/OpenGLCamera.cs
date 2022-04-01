using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

using CategoryTheory;

using Diagram.UI;


using Motion6D;
using Motion6D.Interfaces;

using BitmapConsumer;

namespace InterfaceOpenGL
{
    /// <summary>
    /// Open GL Camera
    /// </summary>
    [Serializable()]
    public class OpenGLCamera : Camera, ISerializable, IBitmapProvider, IUpdatableObject, 
        IRemovableObject
    {

        #region Fields

        /// <summary>
        /// Peer camera
        /// </summary>
        private OpenGL_Library.CameraGL camera = null;

        /// <summary>
        /// Width
        /// </summary>
        private int width;

        /// <summary>
        /// Heght
        /// </summary>
        private int height;

        /// <summary>
        /// Width of camera
        /// </summary>
        static private int cameraWidth = 600;

        /// <summary>
        /// Height of camera
        /// </summary>
        static private int cameraHeight = 600;

        /// <summary>
        /// Graphics of camera
        /// </summary>
        private Graphics graphics;

        /// <summary>
        /// Visualization angle
        /// </summary>
        private double angle = 40;

        /// <summary>
        /// Perspective matrix
        /// </summary>
        private double[,] matr4 = new double[4, 4];

        /// <summary>
        /// Helper frame
        /// </summary>
        private ReferenceFrame helperFrame = new ReferenceFrame();

        /// <summary>
        /// Vector
        /// </summary>
        private double[] vector16 = new double[16];

        /// <summary>
        /// Shift
        /// </summary>
        private double[] shift = new double[3];

        /// <summary>
        /// Bitmap source
        /// </summary>
        protected Bitmap bmp;

        /// <summary>
        /// The "update bitmap" sign
        /// </summary>
        protected bool updateBmp = true;


 
        /// <summary>
        /// Child
        /// </summary>
        private OpenGLCamera child;

        /// <summary>
        /// Update image
        /// </summary>
        private Action upd;


        #endregion

        #region Ctor

        internal OpenGLCamera()
        {
            width = cameraWidth;
            height = cameraHeight;
            init();
        }

        protected OpenGLCamera(SerializationInfo info, StreamingContext context)
        {
            try
            {
                width = (int)info.GetValue("Width", typeof(int));
                height = (int)info.GetValue("Height", typeof(int));
                angle = (double)info.GetValue("Angle", typeof(double));
                updateBmp = (bool)info.GetValue("UpdateBmp", typeof(bool));
            }
            catch (Exception)
            {
            }
            init();
        }

        ~OpenGLCamera()
        {
            try
            {
                IRemovableObject r = this;
                r.RemoveObject();
            }
            catch (Exception excepton)
            {
                excepton.ShowError();
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", width, typeof(int));
            info.AddValue("Height", height, typeof(int));
            info.AddValue("Angle", angle, typeof(double));
            info.AddValue("UpdateBmp", updateBmp, typeof(bool));
        }

        #endregion

        #region IBitmapProvider Members

        unsafe Bitmap IBitmapProvider.Bitmap
        {
            get
            {
                if (bmp == null)
                {
                }
                Graphics gr = Graphics.FromImage(bmp);
                draw(gr, true);
                return bmp;
            }
        }

        #endregion

        #region IUpdatableObject Members

        Action IUpdatableObject.Update
        {
            get { return upd; }
        }

        bool IUpdatableObject.ShouldUpdate
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (camera != null)
            {
                try
                {
                    camera.Dispose();
                    camera = null;
                    IRemovableObject rc = child;
                    if (rc != null)
                    {
                        rc.RemoveObject();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion
 
        #region Overriden Members

        public override void UpdateImage()
        {
            if (graphics == null)
            {
                return;
            }
            draw(graphics);
        }

        /// <summary>
        /// Dynamically adds visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public override void DynamicalAdd(SerializablePosition position)
        {
        }


        /// <summary>
        /// Dynamically removes visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public override void DynamicalRemove(SerializablePosition position)
        {
        }


        public override IReferenceFrame Parent
        {
            get
            {
                return base.Parent;
            }
            set
            {
                base.Parent = value;
                if (child != null)
                {
                    child.Parent = value;
                }
            }
        }

        public override void AddVisible(IPosition p)
        {
            base.AddVisible(p);
            if (child != null)
            {
                child.AddVisible(p);
            }
        }

        public override void RemoveVisible(IPosition p)
        {
            base.RemoveVisible(p);
            if (child != null)
            {
                child.AddVisible(p);
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Preparatoin
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="mode">Mode - 0 screen, 1 - bitmap</param>
        internal unsafe void Prepare(Graphics g, int mode)
        {
            IBitmapProvider p = this;
            Bitmap bmp = p.Bitmap;
            IntPtr hdc = g.GetHdc();
            camera.PrepareHDC(hdc.ToPointer(), mode);
            g.ReleaseHdc(hdc);
        }

        /// <summary>
        /// Drawing
        /// </summary>
        /// <param name="g">Graphics</param>
        unsafe private void draw(Graphics g)
        {
            try
            {
                float dpiX = g.DpiX;
            }
            catch (Exception)
            {
                return;
            }
            IntPtr hdc = graphics.GetHdc();
            camera.BeginPaint(hdc.ToPointer());
            ReferenceFrame b = BaseFrame;
            int n = Count;
            for (int i = 0; i < n; i++)
            {
                IPosition p = this[i];
                object obj = p.Parameters;
                if (!(obj is ShapeGL | obj is Reper))
                {
                    continue;
                }
                ReferenceFrame f = p.GetParentFrame();
                ReferenceFrame.GetRelative(b, f, helperFrame, shift, matr4, vector16);
                if (obj is ShapeGL)
                {
                    ShapeGL s = obj as ShapeGL;
                    camera.Draw(hdc.ToPointer(), s.Shape, vector16);
                    continue;
                }
                Reper r = obj as Reper;
                camera.Draw(hdc.ToPointer(), r.Peer, vector16);
            }
            camera.EndPaint(hdc.ToPointer());
            graphics.ReleaseHdc(hdc);
        }

        /// <summary>
        /// Drawing
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="invertY">The inversion flag</param>
        unsafe private void draw(Graphics g, bool invertY)
        {
            IntPtr hdc = g.GetHdc();
            camera.BeginPaint(hdc.ToPointer(), invertY);
            ReferenceFrame b = BaseFrame;
            int n = Count;
            for (int i = 0; i < n; i++)
            {
                IPosition p = this[i];
                object obj = p.Parameters;
                if (!(obj is ShapeGL))
                {
                    continue;
                }
                ShapeGL s = obj as ShapeGL;
                ReferenceFrame f = p.GetParentFrame();
                ReferenceFrame.GetRelative(b, f, helperFrame, shift, matr4, vector16);
                camera.Draw(hdc.ToPointer(), s.Shape, vector16);
            }
            camera.EndPaint(hdc.ToPointer());
            g.ReleaseHdc(hdc);
        }

        /// <summary>
        /// Width
        /// </summary>
        internal int Width
        {
            get
            {
                return width;
            }
        }

        /// <summary>
        /// Height
        /// </summary>
        internal int Height
        {
            get
            {
                return height;
            }
        }

  
        /// <summary>
        /// Graphics
        /// </summary>
        internal Graphics Graphics
        {
            get
            {
                return graphics;
            }
            set
            {
                graphics = value;
            }
        }

        /// <summary>
        /// Reference angle
        /// </summary>
        internal double ReferenceAngle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                camera.SetReferenceAngle(value);
                if (child != null)
                {
                    child.ReferenceAngle = value;
                }
            }
        }

 
         

        /// <summary>
        /// Sets size
        /// </summary>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        internal void Set(int width, int height)
        {
            this.width = width;
            this.height = height;
            init();
        }

        internal OpenGLCamera Child
        {
            set
            {
                child = value;
                foreach (IPosition v in visible)
                {
                    child.AddVisible(v);
                }
                init();
            }
            get
            {
                return child;
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private unsafe void init()
        {
            int width = this.width;
            int height = this.height;
            upd = UpdateImage;
            if (child != null)
            {
                ICategoryObject co = this;
                if (co.Object is Labels.CameraLabel)
                {
                    Labels.CameraLabel lo = co.Object as Labels.CameraLabel;
                    child.Graphics = lo.Graphics;
                }
                child.camera = new OpenGL_Library.CameraGL(child.width, child.height);
                child.camera.SetReferenceAngle(angle);
                Motion6D.Portable.Position p = this;
                Motion6D.Portable.Position pc = child;
                pc.Parent = p.Parent;
                //upd += child.UpdateImage;
            }
            camera = new OpenGL_Library.CameraGL(width, height);
            camera.SetReferenceAngle(angle);
            bmp = new Bitmap(this.width, this.height);
            Graphics g = Graphics.FromImage(bmp);
            camera.PrepareHDC(g.GetHdc().ToPointer(), 1);
            IBitmapProvider pr = this;
            Bitmap b = pr.Bitmap;
        }

        #endregion


    }


}