using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPerformer.Portable.DifferentialEquationProcessors;
using EngineeringInitializer;
using Event.Basic;
using Scada.Interfaces;

namespace Agriculture.ScadaSample.WindowsForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // IScadaInterface scada = new EmptyScadaInterface(@"c:\SCADA_DESIGN\scada.xml");
            //       scada.GetRealList(true);
            StaticExtensionEventBasic.Init();
            BasicEngineeringInitializer initializer =
            new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
       RungeProcessor.Processor,
       Motion6D.Runtime.DataRuntimeFactory.Object, new Diagram.UI.Interfaces.IApplicationInitializer[]
               {
                        ApplicationInitializer.Singleton,
                        Motion6D.ApplicationInitializer.Object

               },
      true);
            initializer.InitializeApplication();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
