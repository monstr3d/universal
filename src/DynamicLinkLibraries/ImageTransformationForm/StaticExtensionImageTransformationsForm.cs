using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Scada.Interfaces;

using DataPerformer.UI;
using System.Xml.Linq;

namespace ImageTransformations
{
    /// <summary>
    /// Static extension
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionImageTransformationsForm
    {
        /// <summary>
        /// Draws image on control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="image">Image</param>
        /// <param name="graphics">Graphics</param>
        public static void DrawImage(this Control control, Image image, Graphics graphics)
        {
            float bw = (float)image.Width;
            float bh = (float)image.Height;
            float cw = (float)control.Width;
            float ch = (float)control.Height;
            float rw = cw / bw;
            float rh = ch / bh;
            float delta = 0;

            RectangleF srcRect = new RectangleF(0, 0, image.Width, image.Height);
            if (rw > rh)
            {
                delta = rw - rh;
                float dx = (delta * cw / 2);
                RectangleF destRect = new RectangleF(dx, 0, control.Width - 2 * dx, control.Height);
                if ((destRect.Width > 0) & (destRect.Height > 0))
                {
                    graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                }
                return;
            }
            delta = rh - rw;
            float dy = (delta * cw / 2);
            RectangleF destRectY = new RectangleF(0, dy, control.Width, control.Height - 2 * dy);
            graphics.DrawImage(image, destRectY, srcRect, GraphicsUnit.Pixel);
        }


        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        internal static Image ToImage(this object obj)
        {
            Type t = obj.GetType();
            if (obj is Type)
            {
                t = obj as Type;
            }
            if (labelTypes.ContainsKey(t))
            {
                return labelTypes[t];
            }
            return null;
        }

        private static readonly Dictionary<Type, Image> labelTypes = new Dictionary<Type, Image>
        {
           { typeof(ImageTransformations.SourceBitmap), ResourceImage.SourceBitmap.ToBitmap()},
           { typeof(ImageTransformations.DataPicture), ResourceImage.DataPicture.ToBitmap()},
           { typeof(ImageTransformations.BitmapTransformer), ResourceImage.BitmapTransformer.ToBitmap()},
        };

        static StaticExtensionImageTransformationsForm()
        {
            Scada.Desktop.StaticExtensionScadaDesktop.ScadaFactory.OnCreateXml +=
                (Diagram.UI.Interfaces.IDesktop desktop, XElement document) =>
                {
                    List<string> ls = new List<string>();
                    desktop.ForEach<ExternalImage>((ExternalImage image) =>
                    {
                        if (image.GetType().Equals(typeof(ExternalImage)))
                        {
                            ls.Add(image.GetRootName());
                        }
                    });
                    document.AddItems("ExternalImage", ls);
                };

            (new Indicators.BitmapIndicator()).AddGraphIndicator();
        }
    }
}