using Diagram.UI.Factory;
using Diagram.UI.Labels;
using CategoryTheory;

namespace Http.Meteo.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {

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
