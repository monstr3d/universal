using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI;
using Diagram.UI.Labels;

namespace Motion6D.Image.UI.Factory
{
    public class MotionImageFactory : WpfInterface.UI.Factory.WpfFactory
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly new MotionImageFactory Singleton =
            new MotionImageFactory();

        private MotionImageFactory()
        {
        }


        static MotionImageFactory()
        {
        }

        const string name = "3D Image Bitmap consumer";

        /// <summary>
        /// Additional buttons
        /// </summary>
        public static readonly ButtonWrapper[] Buttons = new ButtonWrapper[]
            {
                new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    name, "3D Object", ResourceImage.CubeImage, null, true, false)
            };

        public override object CreateObject(string type)
        {
            object o = base.CreateObject(type);
            if (o != null)
            {
                return o;
            }
            if (type.Equals(name))
            {
                return new MotionImageFigure();
            }
            return null;
        }

        public override Diagram.UI.Labels.IObjectLabel CreateLabel(object obj)
        {
            Diagram.UI.Labels.IObjectLabel l = base.CreateLabel(obj);
            if (l == null)
            {
                if (name.Equals(obj + ""))
                {
                    l = new Labels.FigureImageLabel("", ResourceImage.CubeImage.ToBitmap());
                    return l.CreateLabelUI(ResourceImage.CubeImage.ToBitmap(), false);
                }
            }
            return l;
        }
  
    }
}
