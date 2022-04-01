using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;

using DataPerformer;


using Motion6D;
using Motion6D.Interfaces;
using Motion6D.Portable;


using PhysicalField;


using InterfaceOpenGL.Forms;

namespace InterfaceOpenGL
{
    public class OpenGLFactory : PositionObjectFactory
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly OpenGLFactory Singleton = new OpenGLFactory();

        private static readonly List<string> types = new List<string>()
        {
                     "",
                     "Deformed figure",
                    "3D Field Consumer",
                    "Reper",
         };

        #endregion

        #region Ctor

        private OpenGLFactory()
        {
        }

        #endregion

        #region Overiden Members

        public override object CreateObject(string type)
        {
            if (type.Equals(""))
            {
                return new ShapeGL();
            }
            if (type.Equals("Deformed figure"))
            {
                return new DeformedShapeGL();
            }
            if (type.Equals("3D Field Consumer"))
            {
                return new Shape3DField();
            }
            if (type.Equals("Reper"))
            {
                return new Reper();
            }
            return null;
        }

        public override Motion6D.Portable.Camera NewCamera()
        {
            return new OpenGLCamera();
        }

        public override object CreateForm(Motion6D.Portable.Camera camera)
        {
            OpenGLCamera cam = camera as OpenGLCamera;
            FormCamera f = new FormCamera(cam);
            return f;
        }

        public override object CreateForm(IPosition position, IVisible visible)
        {
            if (visible is DeformedShapeGL)
            {
                return new FormDeformed(position, visible);
            }
            if (visible is Shape3DField)
            {
                Shape3DField sh = visible as Shape3DField;
                return new Motion6D.UI.Forms.FormFieldShape(visible as Shape3DField);
            }
            if (visible is Reper)
            {
                Motion6D.UI.FormLength f = new Motion6D.UI.FormLength(visible as Reper);
                f.Header = "Reper";
                return f;
            }
            return new FormShape(position, visible as ShapeGL);
        }

        public override Type CameraType
        {
            get { return typeof(InterfaceOpenGL.OpenGLCamera); }
        }

        public override IObjectLabel CreateLabel(object obj)
        {
            if (obj.Equals(CameraType))
            {
                return (new Labels.CameraLabel()).CreateLabelUI(ResourceImage.Camera, false);
            }
            if (obj.Equals(""))
            {
                IObjectLabel l = new Labels.UserControl3DShape(null, null);
                return l.CreateLabelUI(ResourceImage.Cube.ToBitmap(), false);
            }
            if (obj.Equals("3D Field Consumer"))
            {
                IObjectLabel l = new Labels.UserControl3DShape(null, null);
                return l.CreateLabelUI(ResourceImage.Field3D_Consumer.ToBitmap(), false);
            }
            if (obj is OpenGLCamera)
            {
                return (new Labels.CameraLabel()).CreateLabelUI(ResourceImage.Camera, false);
            }
            return null;
        }

        public override object CreateLabel(IPosition position, IVisible visible)
        {
            ShapeGL sh = visible.GetSimpleObject<ShapeGL>();
            if (sh is DeformedShapeGL)
            {
                return null;
            }
            if (sh != null)
            {
                IObjectLabel l = new Labels.UserControl3DShape(position, sh);
                return l.CreateLabelUI(ResourceImage.Camera, false);
            }
            return null;
        }

        /// <summary>
        /// Checks whether the factory supports a kind
        /// </summary>
        /// <param name="kind">Kind of object</param>
        /// <returns>True is supports and false otherwise</returns>
        public override bool SupportsKind(string kind)
        {
            return types.Contains(kind);
        }

        #endregion

    }
}
