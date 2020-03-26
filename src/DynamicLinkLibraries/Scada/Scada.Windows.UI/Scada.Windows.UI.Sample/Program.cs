using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using EngineeringInitializer;

namespace Scada.Windows.UI.Sample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
             BasicEngineeringInitializer initializer =
                 new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                  DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor,
                     DataPerformer.Runtime.DataRuntimeFactory.Object, new Diagram.UI.Interfaces.IApplicationInitializer[]
                    {
                         Event.Basic.ApplicationInitializer.Singleton

                    },
                    true);
            initializer.InitializeApplication();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
