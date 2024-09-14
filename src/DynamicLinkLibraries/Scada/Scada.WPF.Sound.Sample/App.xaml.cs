using System.Windows;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Portable.DifferentialEquationProcessors;

using EngineeringInitializer;

using Event.Basic;
using Event.Interfaces;
using Event.WPF;

using Scada.Desktop;
using Scada.Desktop.Serializable;

namespace Scada.WPF.Sound.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Internet.Meteo.Wrapper.StaticExtensionInternetMeteo.Init();
            StaticExtensionEventBasic.Init();
            BasicEngineeringInitializer initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            RungeProcessor.Processor,
                new IApplicationInitializer[]
                {
              }, true);
            initializer.InitializeApplication();
            StaticExtensionEventInterfaces.TimerEventFactory = WpfTimerEventFactory.Singleton;
            StaticExtensionEventInterfaces.TimerFactory = WpfTimerFactory.Singleton;
            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            StaticExtensionDiagramUISerializable.Init();
            SoundService.StaticExtensionSoundService.SoundDirectory = 
                AppDomain.CurrentDomain.BaseDirectory + "sounds" + 
                System.IO.Path.DirectorySeparatorChar;
        }
    }
}