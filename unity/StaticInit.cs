
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
using Assets;
using System.Runtime.InteropServices;
using Diagram.UI;

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

        static Dictionary<string, MonoBehaviorWrapper> wrappers = 
            new Dictionary<string, MonoBehaviorWrapper>();

        static Dictionary<string, ConstructorInfo> updates = new Dictionary<string, ConstructorInfo>();


        static internal Scada.Interfaces.IErrorHandler ErrorHandler => errorHandler;
        internal static void Init()
        {

        }


        public static Action Create(this MonoBehaviour mono, MonoBehaviorWrapper wrapper, string[] upd)
        {
            Action action = null;
            foreach (string s in upd)
            {
                ConstructorInfo c = updates[s];
                IUpdate up = c.Invoke(new object[0]) as IUpdate;
                up.Set(wrapper, mono);
                if (action == null)
                {
                    action = up.Update;
                }
                else
                {
                    action += up.Update;
                }
            }
            return action;
        }

        public static MonoBehaviorWrapper   Create(MonoBehaviour monoBehaviour, bool unique, 
            string  desktop, 
            string[] inputs,
            string[] outputs, 
            out Action ev, out Action act, 
            out Dictionary<string, Action<double>> ins, 
            out Dictionary<string, Func<double>> outs)
        {
            Dictionary<string, Action<double>> insp = new Dictionary<string, Action<double>>();
            Dictionary<string, Func<double>> outp = new Dictionary<string, Func<double>>();
            bool exists = false;
            ev = null;
            act = null;
            if (unique)
            {
                if (wrappers.ContainsKey(desktop))
                {
                    exists = true;
                }
            }
            MonoBehaviorWrapper wr = null;
            if (exists)
            {
                wr = wrappers[desktop];
                act = () => { };
                ev = act;
            }
            else
            {
                wr = new MonoBehaviorWrapper(monoBehaviour, desktop, unique);
                ev = wr.Event;
                act = ev;
                wrappers[desktop] = wr;
             }
            IScadaInterface scada = wr.Scada;
            foreach (var key in inputs)
            {
                insp[key] = scada.GetDoubleInput(key);
            }
            foreach (var key in inputs)
            {
                outp[key] = scada.GetDoubleOutput(key);
            }
            ins = insp;
            outs = outp;
            return wr;
        }


        static Action<IDesktop> dAct = (IDesktop d) =>
        {

        };




        static StaticInit()
        {
            Assembly ass = typeof(StaticInit).Assembly;

            StaticExtensionDiagramUI.PostLoadDesktop += dAct;

            PureDesktop.DesktopPostLoad += dAct;

            ass.SetScadaAssembly((Type type) =>
            {
                if (type.GetInterfaces().Contains(typeof(IUpdate)))
                {
                    updates[type.Name] = type.GetConstructor(new Type[0]);
                }
            }

                );
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