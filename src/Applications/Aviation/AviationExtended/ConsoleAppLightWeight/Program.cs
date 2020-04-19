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

namespace ConsoleAppLightWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticExtensionDiagramUI.ErrorHandler = new ConsoleErrorHandler();
            BasicEngineeringInitializer initializer =
                 new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                  RungeProcessor.Processor,
                     DataPerformer.Runtime.DataRuntimeFactory.Object, new IApplicationInitializer[]
                    {
                         Event.Basic.ApplicationInitializer.Singleton

                    },
                    true);
            initializer.InitializeApplication();

            StaticExtensionScadaDesktop.ScadaFactory = StaticExtensionScadaDesktopSerializable.BaseFactory;
            IScadaInterface  scada  = Properties.Resources.EventCircle.ScadaFromBytes("Chart",
                BaseTypes.Attributes.TimeType.Second, false, null);

        }

    }
}
