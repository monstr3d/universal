using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;



namespace ImageTransformations.Factory
{
    /// <summary>
    /// Factory for image transformation
    /// </summary>
    public class ImageTransformationFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ImageTransformationFactory Object = new ImageTransformationFactory();

        public static readonly ButtonWrapper[] ObjectButtons = new ButtonWrapper[]
        {
           new ButtonWrapper(typeof(ImageTransformations.SourceBitmap),
                    "", "Source bitmap", ResourceImage.SourceBitmap,
                    ImageTransformationFactory.Object, true, false),
    /*       new ButtonWrapper(typeof(BitmapMeasurements.BitmapWrapper),
                    "", "Source bitmap measurements", ResourceImage.SourceBitmapMeasurements,
                    ImageTransformationFactory.Object, true, false),*/
          new ButtonWrapper(typeof(ImageTransformations.SourceImage),
                    "", "Source image", ResourceImage.ImageSource,
                    ImageTransformationFactory.Object, true, false),
           new ButtonWrapper(typeof(ImageTransformations.ExternalImage),
                    "Web", "Web image", ResourceImage.BitmapWeb,
                    ImageTransformationFactory.Object, true, false),
         new ButtonWrapper(typeof(ImageTransformations.ExternalContextImage),
                    "Web", "Web context image", ResourceImage.BitmapWebCtx,
                    ImageTransformationFactory.Object, true, false),
          new ButtonWrapper(typeof(ImageTransformations.BitmapTransformer),
                    "", "Transformation of image", ResourceImage.BitmapTransformer, 
                    ImageTransformationFactory.Object, true, false),
          new ButtonWrapper(typeof(ImageTransformations.MapTransformation),
                    "", "Transformation of image", ResourceImage.MapTransform, 
                    ImageTransformationFactory.Object, true, false),
          new ButtonWrapper(typeof(ImageTransformations.ColorTransformer),
                    "", "Transformation of image", ResourceImage.BitmapTransformer, 
                    ImageTransformationFactory.Object, false, false),
           new ButtonWrapper(typeof(ImageTransformations.DataPicture),
                    "", "Data picture", ResourceImage.DataPicture, 
                    ImageTransformationFactory.Object, false, false),

 
        };

        public static readonly ButtonWrapper[] ArrowButtons = new ButtonWrapper[]
        {
           new ButtonWrapper(typeof(BitmapConsumer.BitmapConsumerLink),
                    "", "Link between bitmap and its consumer", ResourceImage.BitmapLink, 
                    ImageTransformationFactory.Object, true, true)
        };


 
        #endregion

        #region Ctor

        private ImageTransformationFactory()
        {
        }

        #endregion

        #region IUIFactory Members


        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is ImageTransformations.MapTransformation)
                {
                    return new ImageTransformations.FormMapTransform(lab);
                }
                if (obj is ImageTransformations.SourceBitmap)
                {
                    return new ImageTransformations.Forms.FormSourceBitmap(lab);
                }
                if (obj is ImageTransformations.BitmapTransformer)
                {
                    return new ImageTransformations.FormBitmapTransformer(lab);
                }
            }
            return null;
        }


        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            string kind = button.Kind;
            if (type == null)
            {
                return null;
            }
            Image image = type.ToImage();
            if (image != null)
            {
                return (new ImageTransformations.Labels.BitmapProviderLabel(image)).CreateLabelUI(image, false);
            }
            if (type.Equals(typeof(ImageTransformations.SourceImage)))
            {

                return (new Labels.ImageProviderLabel(type, kind, ResourceImage.ImageSource.ToBitmap())).CreateLabelUI(
                  ResourceImage.ImageSource.ToBitmap(), false);
            }
            if (type.Equals(typeof(ImageTransformations.ExternalImage)) | 
                type.Equals(typeof(ImageTransformations.ExternalContextImage)))
            {
                if (kind.Equals("Web"))
                {
                    System.Drawing.Image im = type.Equals(typeof(ImageTransformations.ExternalImage)) ?
                        ResourceImage.BitmapWeb.ToBitmap() : ResourceImage.BitmapWebCtx.ToBitmap();
                    return (new Labels.WebProviderLabel(type, kind, im)).CreateLabelUI( im, false);
                }
            }
            if (type.Equals(typeof(ImageTransformations.ExternalUIImage)))
            {
                ExternalUIImage im = new ExternalUIImage(kind);
                object[] ob = (im as IPropertiesEditor).Editor as object[];
                object o = ob[1];
                System.Drawing.Image img =
                    (o is System.Drawing.Image) ? o as System.Drawing.Image
                    : (o as System.Drawing.Icon).ToBitmap();
                return (new Labels.ImageProviderLabel(type, kind, img)).CreateLabelUI(img, false);
            } 
            return null;
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            if (obj is BitmapConsumer.IBitmapProvider)
            {
                return (new Labels.BitmapProviderLabel(
                        ResourceImage.SourceBitmap.ToBitmap())).CreateLabelUI(null, false);
            }
            return null;
        }

  
        #endregion
    }
}
