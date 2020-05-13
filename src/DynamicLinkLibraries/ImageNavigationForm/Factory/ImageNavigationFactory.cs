using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using CategoryTheory;
using Diagram.UI.Labels;
using Diagram.UI;
using ImageNavigation.Labels;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;


namespace ImageNavigation.Factory
{
    /// <summary>
    /// Factory of image navigation
    /// </summary>
    public class ImageNavigationFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static ImageNavigationFactory Object = new ImageNavigationFactory();

        public static readonly ButtonWrapper[] ObjectButtons =
               new ButtonWrapper[] 
                {
                            new ButtonWrapper(typeof(BitmapSelection),
                               "", "Image Selection", ResourceImage.Contour, ImageNavigationFactory.Object, true, false),
                            new ButtonWrapper(typeof(BitmapGraphSelection),
                               "", "Graph selection bitmap", ResourceImage.BitmapGraphSelection, ImageNavigationFactory.Object, true, false),
                            new ButtonWrapper(typeof(BitmapColorTable),
                               "", "Color table", ResourceImage.BitmapColorSelection, ImageNavigationFactory.Object, true, false),
                };

        public static readonly ButtonWrapper[] ArrowButtons =
               new ButtonWrapper[] 
                {
                            new ButtonWrapper(typeof(BitmapMeasurementsLink),
                               "", "Link between bitmap selection and camera", ResourceImage.ContourLink, ImageNavigationFactory.Object, true, true),
                };
 
 
        #endregion

        #region Ctor

        private ImageNavigationFactory()
        {
        }

        #endregion

        #region IUIFactory Members

        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                ICategoryObject obj = lab.Object;
                if (obj is BitmapGraphSelection)
                {
                    return new Forms.FormBitmapGraphSelection(lab);
                }
            }
            return null;
        }

        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            if (type.Equals(typeof(BitmapSelection)))
            {
                (new BitmapSelectionLabel()).CreateLabelUI(button.ButtonImage, false);
            }
            return Create(type);
         }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            Type type = obj.GetType();
            return Create(type);
        }

        #endregion

        #region Own Members

        IObjectLabelUI Create(Type type)
        {
            if (type == null)
            {
                return null;
            }
            if (type.Equals(typeof(BitmapColorTable)))
            {
                return typeof(BitmapTableLabel).CreateLabelUI(true);
            }
            if (type.Equals(typeof(BitmapGraphSelection)))
            {
                return typeof(BitmapGraphSelectionLabel).CreateLabelUI(false);
            }
            return null;
        }

        #endregion
    }
}
