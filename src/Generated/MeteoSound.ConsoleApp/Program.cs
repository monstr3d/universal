// See https://aka.ms/new-console-template for more information


using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Helpers;
using Diagram.UI.Interfaces;
using Event.Portable;
using GeneratedProject;


var initializer =
new ExtendedApplicationInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
RungeProcessor.Processor,
DataPerformer.Portable.Runtime.DataRuntimeFactory.Singleton, [], true);
initializer.InitializeApplication();


var d = MeteoSoundTest.Desktop;
var c = d.GetObject("Chart ATIS") as IDataConsumer;
var time = new TimeMeasurementProvider(null);
try
{
    c.PerformFixed(0, 0.01, 2600, time, RungeProcessor.Processor, "Calculation", 0, null, null, null);
}
catch (Exception ex)
{

}

/*PerformFixed(this IDataConsumer consumer, double start, double step, int count,
ITimeMeasurementProvider provider,
                  IDifferentialEquationProcessor processor, string reason,
int priority, Action action, string condition, Func<bool> stop, IAsynchronousCalculation asynchronousCalculation = null,
IErrorHandler errorHandler = null)
        {

    c = null;*/