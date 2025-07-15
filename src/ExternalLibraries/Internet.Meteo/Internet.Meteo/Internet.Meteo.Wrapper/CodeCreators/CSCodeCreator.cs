using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Internet.Meteo.Wrapper.CodeCreators
{
    /// <summary>
    /// Code creator
    /// </summary>
    [Language("C#")]
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCodeCreator();
        }

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            var tt = typeof(Internet.Meteo.Wrapper.Sensor);
            var t = obj.GetType();
            var s = t.IsSubclassOf(tt);
            t = t.BaseType;
            s = t.Equals(tt);
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
