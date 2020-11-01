using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataPerformer.Portable.DifferentialEquationProcessors;
using Diagram.UI;
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
            Internet.Meteo.StaticExtensionMeteo.Init();
            Http.Meteo.StaticExtensionMeteo.Init();
            StaticExtensionEventBasic.Init();
            BasicEngineeringInitializer initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            RungeProcessor.Processor,
                new Diagram.UI.Interfaces.IApplicationInitializer[]
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