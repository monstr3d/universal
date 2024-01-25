using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Library.Forms.Factory
{
    internal class UIFactory : EmptyUIFactory
    {
        public UIFactory() 
        {
            this.Add();
        }

        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            return CreateObjectLabel(button.ReflectionType, button.Kind, button.ButtonImage as Image);
        }

        IObjectLabelUI CreateObjectLabel(Type type, string kind, Image image)
        {
            if (type.Equals(typeof(Serializable.Objects.DataQuery)))
            {
                return (new Labels.TradingDataLabel()).CreateLabelUI(image, true);
            }
            if (type.Equals(typeof(Serializable.Objects.Order))) 
            {
                return (new Labels.OrderLabel()).CreateLabelUI(image, true);
            }
            return null;

        }



    }
}
