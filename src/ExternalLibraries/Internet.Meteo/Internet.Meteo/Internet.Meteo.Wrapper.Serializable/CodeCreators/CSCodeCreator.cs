using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;

namespace Internet.Meteo.Wrapper.Serializable.CodeCreators
{
    /// <summary>
    /// Code creator
    /// </summary>
    [Language("C#")]
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
           this.AddClassCodeCreator();
        }


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }


   
        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }


        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            if (!(obj is Internet.Meteo.Wrapper.Sensor sensor))
            {
                return null;
            }
            var l = new List<string>();
            l.Add("Internet.Meteo.Wrapper.Sensor");
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            l.Add("\tKey = \"" + sensor.Key + "\";");
            l.Add("\tPosition = \"" + sensor.Position + "\";");
            l.Add("\tSet(\"" + sensor.Kind + "\");");
            var fc = (sensor.FahrenheitCelsius == FahrenheitCelsius.Fahrenheit) ? "Fahrenheit" : "Celsius";
            l.Add("\tFahrenheitCelsius = Internet.Meteo.FahrenheitCelsius." + fc + ";");
            l.Add("\tCreate();");
            l.Add("}");
            l.Add("}");
            return l;
        }
    }
}
