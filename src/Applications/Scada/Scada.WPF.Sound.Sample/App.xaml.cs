using System.Windows;
using System.IO;

using Diagram.UI;

using DataPerformer.Portable.DifferentialEquationProcessors;

using Event.Basic;
using Event.Interfaces;
using Event.WPF;

using Scada.Desktop;
using Scada.Desktop.Serializable;

using SoundService;

using EngineeringInitializer;


namespace Scada.WPF.Sound.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StaticExtensionSoundService.SoundDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SOUNDS");
            AssemblyService.StaticExtensionAssemblyService.Init();
            Internet.Meteo.Wrapper.StaticExtensionInternetMeteo.Init();
            StaticExtensionEventBasic.Init();
            BasicEngineeringInitializer initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            RungeProcessor.Processor,[], true);
            initializer.InitializeApplication();
            StaticExtensionEventInterfaces.TimerEventFactory = WpfTimerEventFactory.Singleton;
            StaticExtensionEventInterfaces.TimerFactory = WpfTimerFactory.Singleton;
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            StaticExtensionDiagramUISerializable.Init();
         }
    }
}