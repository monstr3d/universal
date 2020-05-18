
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;


using Diagram.UI;

using Diagram.UI.Interfaces;


using BaseTypes.Attributes;

using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using DataPerformer.Portable.Interfaces;
using DataPerformer.Portable.Measurements;


using Event.Interfaces;
using Event.Portable;

using Scada.Interfaces;
using Scada.Desktop;

namespace Unity.Standard
{

 
    /// <summary>
    /// Static 
    /// </summary>
    public static class StaticExtensionUnity
    {

        #region Fields


        static private TimeMeasureProviderFactory factory = new TimeMeasureProviderFactory();

        static private ITimerEventFactory timerEventFactory;

        static private ITimerFactory timerFactory;

        static private ITimeMeasurementProviderFactory timeMeasureProviderFactory;

        static private ITimeMeasurementProvider timeMeasureProvider;

        static private Scada.Interfaces.IErrorHandler errorHandler = new ErrorHanller();

        static Dictionary<string, MonoBehaviorWrapper> wrappers =
            new Dictionary<string, MonoBehaviorWrapper>();


        static Dictionary<string, ConstructorInfo> updates = new Dictionary<string, ConstructorInfo>();


        static internal Scada.Interfaces.IErrorHandler ErrorHandler => errorHandler;


        #endregion

        #region Members

        /// <summary>
        /// Text update
        /// </summary>
        static public ITextUpdate TextUpdate
        { get; set; } 


        /// <summary>
        /// Gets unique scada
        /// </summary>
        /// <param name="desktop">Desktop name</param>
        /// <returns>Scada</returns>
        public static IScadaInterface ToUniqueScada(this string desktop,
                         ITimerEventFactory timerEventFactory,
                ITimerFactory timerEvent)
        {
            return desktop.ToScada("Consumer", timerEventFactory,
                 timerEvent,
                factory, TimeType.Second, false, null, true);
        }

        static void GetComponents(this Component go,

            Dictionary<string, List<GameObject>> objects, Dictionary<string, List<Component>> comp)
        {
            Component[] components = go.GetComponentsInChildren(typeof(Component), false);
            foreach (Component component in components)
            {
                string name = component.name;
                List<Component> lc;
                if (comp.ContainsKey(name))
                {
                    lc = comp[name];
                }
                else
                {
                    lc = new List<Component>();
                    comp[name] = lc;
                }
                if (lc.Contains(component))
                {
                    continue;
                }
                lc.Add(component);
                GameObject gobj = component.gameObject;
                if (gobj != null)
                {
                    name = gobj.name;
                    List<GameObject> lo;
                    if (objects.ContainsKey(name))
                    {
                        lo = objects[name];
                    }
                    else
                    {
                        lo = new List<GameObject>();
                        objects[name] = lo;
                    }
                    if (lo.Contains(gobj))
                    {
                        return;
                    }
                    lo.Add(gobj);
                    gobj.GetComponents(objects, comp);

                }
            }
        }
        static void GetComponents(this GameObject go, 
            
            Dictionary<string, List<GameObject>> objects, Dictionary<string, List<Component>> comp)
        {
            Component[] components = go.GetComponents(typeof(Component));
            foreach (Component component in components)
            {
                string name = component.name;
                List<Component> lc;
                if (comp.ContainsKey(name))
                {
                    lc = comp[name];
                }
                else
                {
                    lc = new List<Component>();
                    comp[name] = lc;
                }
                if (lc.Contains(component))
                {
                    continue;
                }
                lc.Add(component);
                component.GetComponents(objects, comp);
                GameObject gobj = component.gameObject;
                if (gobj != null)
                {
                    name = gobj.name;
                    List<GameObject> lo;
                    if (objects.ContainsKey(name))
                    {
                        lo = objects[name];
                    }
                    else
                    {
                        lo = new List<GameObject>();
                        objects[name] = lo;
                    }
                    if (lo.Contains(gobj))
                    {
                        continue;
                    }
                    lo.Add(gobj);
                    gobj.GetComponents(objects, comp);
                }
            }
        }

        static public void Calculate<T>(this Func<T>[] func, int i, T[] t)
        {
            for (int j = 0; j < t.Length; j++)
            {
                t[j] = func[i + j]();
            }
        }

        static public Quaternion ToQuaternion(this  double[] t)
        {
            float p = t[0] > 0 ? 1f : -1f;
            return new Quaternion(p * (float)t[1], p * (float)t[2], 
                p * (float)t[3], p * (float)t[0]);
        }

        static public Dictionary<string, List<T>> GetComponents<T>(this Dictionary<string, List<Component>> comp)
            where T : Component
        {
            Dictionary<string, List<T>> l = new Dictionary<string, List<T>>();
            foreach (string name in comp.Keys)
            {
                List<T> lt = null;
                List<Component> lc = comp[name];
                foreach (Component component in lc)
                {
                    if (component is T)
                    {
                        T t = component as T;
                        if (lt == null)
                        {
                            lt = new List<T>();
                            l[name] = lt;
                        }
                        else
                        {
                            lt = l[name];
                        }
                        if (!lt.Contains(t))
                        {
                            lt.Add(t);
                        }
                    }
                }
            }
            return l;
        }

        static public Dictionary<string, List<GameObject>> GetComponents(this GameObject gob, 
            out Dictionary<string, List<Component>> comp)
        {
            Dictionary<string, List<GameObject>> dog = new Dictionary<string, List<GameObject>>();
            comp = new Dictionary<string, List<Component>>();
            gob.GetComponents(dog, comp);
            return dog;
        }

        static internal void ShowError(this Exception exception)
        {
            Debug.LogError(exception.StackTrace);
        }

        internal static void Init()
        {

        }


        public static Action Create(this ScriptWithWrapper mono, 
            MonoBehaviorWrapper wrapper, string[] upd, ref Action start)
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
                if (start == null)
                {
                    start = up.Start;
                }
                else
                {
                    start += up.Start;
                }
            }
            if (start == null)
            {
                start = () => { };
            }
            return action;
        }

        public static MonoBehaviorWrapper  Create(this ScriptWithWrapper monoBehaviour, 
            bool unique, 
            string  desktop, 
            string[] inputs,
            string[] outputs)
        {
            Dictionary<string, Action<double>> insp = monoBehaviour.inps;
            Dictionary<string, Func<double>> outp = monoBehaviour.outs;
            bool exists = false;
            Action ev = null;
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
                ev = () => { };
            }
            else
            {
                wr = new MonoBehaviorWrapper(monoBehaviour, desktop, unique);
                ev = wr.Event;
                wrappers[desktop] = wr;
            }
            monoBehaviour.ev = ev;
            IScadaInterface scada = wr.Scada;
            List<Action<double>> li = new List<Action<double>>();
            var inp = scada.Inputs;
            foreach (var key in inputs)
            {
                if (!inp.ContainsKey(key))
                {
                    Debug.LogError(key + "does not exist");
                }
                try
                {
                    Action<double> ad = scada.GetDoubleInput(key);
                    insp[key] = ad;
                    li.Add(ad);
                }
                catch (Exception ex)
                {
                    Debug.LogError(key);
                    Debug.LogError(ex.StackTrace);
                }
            }
            List<Func<double>> lo = new List<Func<double>>();
            var outs = scada.Outputs;
            foreach (var key in outputs)
            {
                if (!outs.ContainsKey(key))
                {
                    Debug.LogError(key + "does not exist");
                }
                Func<double> fd = scada.GetDoubleOutput(key);
                outp[key] = fd;
                lo.Add(fd);
            }
            monoBehaviour.dInp = li.ToArray();
            monoBehaviour.dOut = lo.ToArray();
            monoBehaviour.ev = ev;
            if (ev == null)
            {
                Debug.LogError("Event" + monoBehaviour.gameObject.name);
            }
            return wr;
        }


        static Action<IDesktop> dAct = (IDesktop d) =>
        {

        };

        /// <summary>
        /// Creates Text action
        /// </summary>
        /// <param name="scada">Scada</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="format">Format</param>
        /// <param name="text">Text</param>
        /// <param name="scale">Scale</param>
        /// <returns>The action</returns>
        static public Action CreateTextAction(this IScadaInterface scada,
                string parameter, string format,  Text text, float scale)
        {
            ITextUpdate up = TextUpdate;
            return up.Create(scada, parameter, format,  text,  scale);
        }


        #endregion

        #region Constructor

        static StaticExtensionUnity()
        {
            TextUpdate = new DefaultTextAction();

            Assembly ass = typeof(StaticExtensionUnity).Assembly;

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

        #endregion

        #region Classes

        class DefaultTextAction : ITextUpdate
        {

            Action ITextUpdate.Create(IScadaInterface scada, 
                string parameter, string format, Text text, float scale)
            {
                string s = text.text + "";
                float[] sc = new float[] { scale };
                if (sc[0] == 0)
                {
                    sc[0] = 1;
                }
                if (!scada.Outputs.ContainsKey(parameter))
                {
                    return null;
                }
                string form = format;
                if (form == null)
                {
                    form = "0";
                }
                object t = scada.Outputs[parameter];
                if (t.GetType() == typeof(double))
                {
                    Func<double> fd = scada.GetDoubleOutput(parameter);
                    if (form != null)
                    {
                        if (form.Length > 0)
                        {
                            return () =>
                                {
                                    float x = sc[0] * (float)fd();
                                    text.text = s + " " + x.ToString(form);
                                };
                        }
                    }
                    return () =>
                    {
                        double x = sc[0] * fd();
                        text.text = s + x.ToString();
                    };



                }

                Func<object> f = scada.GetOutput(parameter);

                return () =>
                {
                    text.text =
                    f() + "";
                };
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

            IMeasurement m = new Measurement(() => (double)Time.realtimeSinceStartup, "Time");
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


        #endregion
    }
}