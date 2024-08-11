using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;

using Internet.Meteo.UI.Labels;

namespace Internet.Meteo.UI
{
    internal class UIFactory : EmptyUIFactory
    {
        internal UIFactory() 
        {
            this.Add();
        }

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            var type = button.ReflectionType;
            if (type == typeof(Wrapper.Serializable.Sensor))
            {
                return new Wrapper.Serializable.Sensor(button.Kind);
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
            var type = button.ReflectionType;
            var kind = button.Kind;
            var image = button.ButtonImage;
            if (type == typeof(Wrapper.Serializable.Sensor))
            {
                if (kind == "thermometer")
                {
                    return (new SensorLabel()).CreateLabelUI(Properties.Resources.thermometerp, true);
                }
            }

            return null;
        }

    }
}
