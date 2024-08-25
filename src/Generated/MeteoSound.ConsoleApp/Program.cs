// See https://aka.ms/new-console-template for more information


using DataPerformer.Interfaces;
using DataPerformer.Portable;
using GeneratedProject;


var obj = new Internet.Meteo.Wrapper.Serializable.Sensor("all");

if (obj is Internet.Meteo.Wrapper.Sensor sensor)
{
    sensor = null;
}
else
{
    int j = 0;
}

var d = MeteoSoundTest.Desktop;
var c = d.GetObject("Chart ATIS") as IDataConsumer;
c.PerformFixed(0, 0.01, 2600, null, null, "", 0, null, null, null);

/*PerformFixed(this IDataConsumer consumer, double start, double step, int count,
ITimeMeasurementProvider provider,
                  IDifferentialEquationProcessor processor, string reason,
int priority, Action action, string condition, Func<bool> stop, IAsynchronousCalculation asynchronousCalculation = null,
IErrorHandler errorHandler = null)
        {

    c = null;*/