using BaseTypes.Attributes;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Interfaces;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using Scada.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


namespace StaticExtension
{
    static class StaticInit
    {
 
        static private ITimerEventFactory timerEventFactory;

        static private ITimerFactory timerFactory;

        static private ITimeMeasureProvider timeProvider;

        static private Scada.Interfaces.IErrorHandler errorHandler = new ErrorHanller();




        static internal Scada.Interfaces.IErrorHandler ErrorHandler => errorHandler;
        internal static void Init()
        {
        }

        static internal void SetFactory(this MonoBehaviour script)
        {
            if (timerFactory == null)
            {
                if (script is ITimerFactory)
                {
                    timerFactory = script as ITimerFactory;
                    StaticExtensionEventInterfaces.TimerFactory = timerFactory;
                }
            }
            if (timerEventFactory == null)
            {
                if (script is ITimerFactory)
                {
                    timerEventFactory = script as ITimerEventFactory;
                    StaticExtensionEventInterfaces.TimerEventFactory = timerEventFactory;
                }
            }
            if (timeProvider == null)
            {
                if (script is ITimeMeasureProvider)
                {
                    timeProvider = script as ITimeMeasureProvider;
                    StaticExtensionEventInterfaces.TimerEventFactory = timerEventFactory;
                }
            }
        }



        static StaticInit()
        {
            StaticExtensionDataPerformerPortable.Factory = DataPerformer.Runtime.DataRuntimeFactory.Object; 
            StaticExtensionScadaDesktop.ScadaFactory = ScadaDesktop.Singleton;

            /*         BasicEngineeringInitializer initializer =
               new BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                RungeProcessor.Processor,
                   DataPerformer.Runtime.DataRuntimeFactory.Object, new IApplicationInitializer[]
                  {
                                  Event.Basic.ApplicationInitializer.Singleton

                  },
                  true);
                     initializer.InitializeApplication();
         */

            // StaticExtensionEventInterfaces.TimerEventFactory = Event.Windows.Forms.WindowsTimerFactory.Singleton;


            StaticExtensionScadaDesktop.ScadaFactory = ScadaDesktop.Singleton;

            //Scada.Motion6D.Factory.ScadaDesktopMotion6D.Singleton;

            //      Event.Windows.Forms.WindowsTimerFactory f = Event.Windows.Forms.WindowsTimerFactory.Singleton;
            //   StaticExtensionEventInterfaces.TimerFactory = f;
            //   StaticExtensionEventInterfaces.TimerEventFactory = f;

            Event.Portable.Factory.EmptyTimerEventFactory.Set();
            StaticExtensionScadaDesktop.ScadaFactory = ScadaDesktop.Singleton;

        }
        class ErrorHanller : Scada.Interfaces.IErrorHandler
        {
            void Scada.Interfaces.IErrorHandler.ShowError(Exception exception, object obj)
            {
                Debug.LogError(exception.Message);
            }

            void Scada.Interfaces.IErrorHandler.ShowMessage(string message, object obj)
            {
                Debug.Log(message);
            }
        }

        class TimeMeasureProviderFactory : ITimeMeasureProviderFactory
        {
            ITimeMeasureProvider ITimeMeasureProviderFactory.Create(bool isAbsolute, TimeType timeUnit, string reason)
            {
                return StaticInit.timeProvider;
            }
        }
    }
}