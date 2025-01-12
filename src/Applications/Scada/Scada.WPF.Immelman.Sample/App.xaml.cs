using DataPerformer.Portable.DifferentialEquationProcessors;
using Diagram.UI;
using EngineeringInitializer;
using Event.Basic;
using Event.Interfaces;
using Scada.Desktop;
using AssemblyService;
using System.Windows;
using Event.WPF;
using Scada.Desktop.Serializable;

namespace Scada.WPF.Immelman.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StaticExtensionAssemblyService.Init(null);
            StaticExtensionEventBasic.Init();
            var initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            RungeProcessor.Processor, [], true);
            initializer.InitializeApplication();
            StaticExtensionEventInterfaces.TimerEventFactory = WpfTimerEventFactory.Singleton;
            StaticExtensionEventInterfaces.TimerFactory = WpfTimerFactory.Singleton;
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            StaticExtensionDiagramUISerializable.Init();
        }

    }

}
