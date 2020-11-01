using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;
using DinAtm.Forms.FormUI;

namespace DinAtm.Forms.Factory
{
    class UIFactory : EmptyUIFactory
    {
        internal UIFactory()
        {
            this.Add();
        }

        #region Overriden Members

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            string kind = button.Kind;
            if (type.Equals(typeof(DimAtm.Serializable.Atmosphere)))
            {
                return
                     (new Labels.LabelAtmosphere(type, kind,
                         button.ButtonImage as System.Drawing.Image)).CreateLabelUI(
                         Properties.Resources.Culture, true);
            }
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent component)
        {
            if (component is IObjectLabel)
            {
                IObjectLabel lab = component as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is Portable.Atmosphere)
                {
                    return new FormAtmosphere(obj as Portable.Atmosphere);
                }
            }
            return null;
        }

        #endregion

    }
}
