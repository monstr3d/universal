
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

using BaseTypes.Attributes;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Interfaces;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using Event.Portable;
using Scada.Desktop;
using Event.Portable.Runtime;
using Event.Portable.Interfaces;
using DataPerformer.Portable.Measurements;
using System.Reflection;
using Scada.Interfaces;
using CategoryTheory;

namespace StaticExtension
{

 
    static class StaticInit
    {

        #region Fields

   

        #endregion


        static internal void ShowError(this Exception exception)
        {
            Debug.LogError(exception.Message);
        }
        static private ITimerEventFactory timerEventFactory;

        static private ITimerFactory timerFactory;

        static private ITimeMeasurementProviderFactory timeMeasureProviderFactory;
        
        static private ITimeMeasurementProvider timeMeasureProvider;

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
                if (script is ITimerEventFactory)
                {
                    timerEventFactory = script as ITimerEventFactory;
                    StaticExtensionEventInterfaces.TimerEventFactory = timerEventFactory;
                }
            }
         /*   if (timeMeasureProvider == null)
            {
                if (script is ITimeMeasureProvider)
                {
                    timeMeasureProvider = script as ITimeMeasureProvider;
                    timeMeasureProviderFactory = new TimeMeasureProviderFactory();
                    StaticExtensionDataPerformerPortable.TimeMeasureProviderFactory 
                        = timeMeasureProviderFactory;
                }
            }*/
        }



        static StaticInit()
        {
            Assembly ass = typeof(StaticInit).Assembly;
            ass.SetScadaAssembly();
            ExtendedApplicationInitializer initializer =
       new ExtendedApplicationInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
        RungeProcessor.Processor,
           DataPerformer.Portable.Runtime.DataRuntimeFactory.Singleton, new IApplicationInitializer[]
          {

          },
          true);
            initializer.InitializeApplication();

            
        }
        class ErrorHanller : Scada.Interfaces.IErrorHandler
        {
            void Scada.Interfaces.IErrorHandler.ShowError(Exception exception, object obj)
            {
                exception.ShowError();
            }

            void Scada.Interfaces.IErrorHandler.ShowMessage(string message, object obj)
            {
                Debug.Log(message);
            }
        }

   

        class TimeMeasureProviderFactory : ITimeMeasurementProviderFactory, ITimeMeasurementProvider
        {
            ITimeMeasurementProvider ITimeMeasurementProviderFactory.Create(bool isAbsolute, TimeType timeUnit, string reason)
            {
                return this;
            }


            IMeasurement ITimeMeasurementProvider.TimeMeasurement => m;

            double ITimeMeasurementProvider.Time { get => Time.realtimeSinceStartup; set { } }
            double ITimeMeasurementProvider.Step { get; set; }

            IMeasurement m = new Measurement(() => Time.realtimeSinceStartup, "Time");

        }
    }
}