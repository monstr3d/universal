using Diagram.UI.Factory;
using Diagram.UI.Labels;
using CategoryTheory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI;

namespace Http.Meteo.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            string kind = button.Kind;
            if (type.Equals(typeof(Serializable.MeteoService)))
            {
                return
                     (new Labels.MeteoLabel(type, kind,
                         button.ButtonImage as Image)).CreateLabelUI(Properties.Resources.Culture, true);
            }
            return null;
        }



        public override object CreateForm(INamedComponent component)
        {
            if (component is IObjectLabel)
            {
                IObjectLabel lab = component as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is MeteoService)
                {
                    return new Forms.FormMeteo(obj);
                }
            }
            return null;
        }
    }
}
