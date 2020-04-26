using Diagram.UI.Interfaces;
using EngineeringInitializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Portable.DifferentialEquationProcessors;
using Scada.Desktop;
using Scada.Desktop.Serializable;
using Event.Interfaces;
using Diagram.UI;
using Scada.Interfaces;
using GeneratedProject;
using System.Threading;
using AssemblyService;

namespace ConsoleAppLightWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            
           //    var div =  typeof(StaticExtensionGeneratedProject1).Assembly.GetStaticFieldDictionary<IDesktop>("Desktop");

                        IDesktop d = StaticExtensionGeneratedProject.Desktop;
                        IScadaInterface scada = d.ScadaFromDesktop("Consumer",
                            BaseTypes.Attributes.TimeType.Second, false, null);
                        scada.ErrorHandler = new ConsoleErrorHandler();
                Action act = () =>
                 {
                     scada.IsEnabled = true;
                 };
                act.Invoke();
                Console.ReadKey();
             }
            catch (Exception ex)
            {

            }

        }
        static Program()
        {
            BasicEngineeringInitializer initializer =
                 new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                  RungeProcessor.Processor,
                     DataPerformer.Runtime.DataRuntimeFactory.Singleton, new IApplicationInitializer[]
                    {
                         Event.Portable.ApplicationInitializer.Singleton

                    },
                    true);
            initializer.InitializeApplication();


            StaticExtensionEventInterfaces.TimerEventFactory = Event.Windows.Forms.WindowsTimerFactory.Singleton;

            StaticExtensionScadaDesktop.ScadaFactory = Scada.Desktop.ScadaDesktop.Singleton;

                //Scada.Motion6D.Factory.ScadaDesktopMotion6D.Singleton;

            Event.Windows.Forms.WindowsTimerFactory f = Event.Windows.Forms.WindowsTimerFactory.Singleton;
            StaticExtensionEventInterfaces.TimerFactory = f;
            StaticExtensionEventInterfaces.TimerEventFactory = f;

        }
    }
}
