using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

using Diagram.UI;

namespace ImageTransformations
{
    [Serializable()]
    public class SourceImage : AbstractBitmap
    {
        #region Fields

        protected Image image;
   
        #endregion

        #region Constructors

        public SourceImage()
        {
        }

        public SourceImage(SerializationInfo info, StreamingContext context)
        {
            try
            {
                image = (Bitmap)info.GetValue("Image", typeof(Image));
                CreateBitmap();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            comments = (ArrayList)info.GetValue("Comments", typeof(ArrayList));
        }


        #endregion

        #region ISerializable Members

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Image", image, typeof(Image));
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
        }

        #endregion

        #region Own Members

        public override Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                CreateBitmap();
            }
        }

        protected virtual void CreateBitmap()
        {
            if (image == null)
            {
                return;
            }
            bitmap = new System.Drawing.Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(image, 0, 0, image.Width, image.Height);
            }
        }

        #endregion

    }
}
