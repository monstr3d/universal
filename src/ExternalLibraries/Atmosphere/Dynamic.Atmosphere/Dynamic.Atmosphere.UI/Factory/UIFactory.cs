using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;
using Diagram.UI;

using Dynamic.Atmosphere.UI.Forms;

namespace Dynamic.Atmosphere.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {


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

            if (type.Equals(typeof(Serializable.Atmosphere)))
            {
                return
                     (new Labels.AtmosphereLabel()).CreateLabelUI(
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
