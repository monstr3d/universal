
using DataPerformer.Portable.DifferentialEquationProcessors;
using EngineeringInitializer;
using Event.Basic;
using Scada.Interfaces;

namespace Scada.Temperature.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string s = Environment.GetEnvironmentVariable("SCADA_DESIGN");
            StaticExtensionEventBasic.Init();
            var sc = new EmptyScadaInterface(s);
            var initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
       RungeProcessor.Processor,
     [
                        Motion6D.ApplicationInitializer.Object],

       true);

            initializer.InitializeApplication(); 
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}