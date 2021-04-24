using Diagram.UI.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI.Labels;
using CategoryTheory;

namespace Http.Meteo.UI.Factory
{
    class UIFactory : EmptyUIFactory
    {

        public override object CreateForm(INamedComponent component)
        {
            if (component is IArrowLabel)
            {
                IArrowLabel lab = component as IArrowLabel;
                ICategoryArrow arrow = lab.Arrow;
            }
            if (component is IObjectLabel)
            {
                IObjectLabel lab = component as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is Services.MeteoService)
                {
                    return new Forms.FormMeteo(obj);
                }
            }
            return null;
        }
    }
}
