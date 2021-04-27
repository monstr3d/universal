using CategoryTheory;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCamCapture.UI.Labels;

using Diagram.UI;

namespace WebCamCapture.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {

        #region Overriden members

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            if (obj is WebCamMeasurementsEvent)
            {
                WebCamMeasurementsEvent camera = obj as WebCamMeasurementsEvent;
                LabelWebCamCapture l = new LabelWebCamCapture(obj.GetType());
                l.Object = obj;
                return l.CreateLabelUI(
                         Properties.Resources.Culture, true);
            }
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            object im = button.ButtonImage;
            if (type.IsSubclassOf(typeof(WebCamMeasurements)))
            {
                return (new LabelWebCamCapture(type)).CreateLabelUI(im, false);
            }
            return base.CreateObjectLabel(button);
        }


        #endregion

    }
}
