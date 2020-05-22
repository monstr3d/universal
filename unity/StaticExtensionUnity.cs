
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
using Vector3D;
using Motion6D.Interfaces;
using System.Runtime.CompilerServices;

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

  
        static private Dictionary<string, Tuple<object,

            List<IScadaUpdate>>> scadaUpdates
            = new Dictionary<string, Tuple<object,
            List<IScadaUpdate>>>();

        static Dictionary<string, ConstructorInfo> updates = 
            new Dictionary<string, ConstructorInfo>();

        static internal Dictionary<string, ConstructorInfo> updatesRectTransform =
     new Dictionary<string, ConstructorInfo>();



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
                ITimerFactory timerEvent, IScadaUpdate update)
        {
            bool exists = desktop.ScadaExists();
            IScadaInterface scada = desktop.ToScada("Consumer", timerEventFactory,
                 timerEvent,
                factory, TimeType.Second, false, null, true);
            scada.ErrorHandler = StaticExtensionUnity.ErrorHandler;
            if (exists)
            {
                var t = scadaUpdates[desktop];
                List<IScadaUpdate> l = t.Item2;
                l.Add(update);
            }
            else
            {
                List<IScadaUpdate> l = new List<IScadaUpdate>() { update };
                scadaUpdates[desktop] = new
                    Tuple<object, List<IScadaUpdate>>
                (new object(), l);   
            }
            return scada;
        }

      /*  static public Quaternion FromDouble(this double[] x)
        {
            float p = x[0] < 0 ? -1f : 1f;
            return new Quaternion(p * (float)x[1],  p * (float)x[2], p * (float)x[3], p * (float)x[0]);
        }
        */

        static public object GetLock(this string desktop)
        {
            return scadaUpdates[desktop].Item1;
        }

        static void GetComponents(this Component go,

            Dictionary<string, List<GameObject>> objects, Dictionary<string, List<Component>> comp)
        {
            Component[] components = go.GetComponentsInChildren(typeof(Component), false);
            foreach (Component component in components)
            {
                if (component == null)
                {
                    continue;
                }
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
                if (component == null)
                {
                    continue;
                }
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

   
        static private Quaternion ToQuaternion(this EulerAngles euler, double[] t)
        {
            euler.Set(t);
            return
               Quaternion.Euler(Mathf.Rad2Deg * (float)euler.pitch,
                Mathf.Rad2Deg * (float)euler.roll, Mathf.Rad2Deg * (float)euler.yaw);
        }


        static private UnityEngine.Quaternion ToQuaternion(this 
           ReferenceFrame frame, EulerAngles euler)
        {
            return euler.ToQuaternion(frame.Quaternion);
        }

        static public UnityEngine.Quaternion ToQuaternion(this
   ReferenceFrame frame)
        {
            double[] ori = frame.Quaternion;
            return new Quaternion((float)ori[1], (float)ori[2],
                (float)ori[3], (float)ori[0]);
        }


        static public Vector3 ToPosition(this double[] t)
        {
            return new Vector3((float)t[0], (float)t[1], (float)t[2]);
        }


        static public Dictionary<string, List<T>> GetComponents<T>(this 
            Dictionary<string, List<Component>> comp)
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


        public static Action Create(this ReferenceFrameBehavior mono, 
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

        public static float ToDegree(this double angle)
        {
            return Mathf.Rad2Deg * (float)angle;
        }

        static public Action ExecuteScadaUpdate(this string desktop)
        {
            var exe = scadaUpdates[desktop];
            var o = exe.Item1;
            var l = exe.Item2;
            Action a = null;
            foreach (var up in exe.Item2)
            {
                var act = up.Update;
                if (act != null)
                {
                    if (a == null)
                    {
                        a = act;
                        continue;
                    }
                    a += act;
                }
            }
            if (a == null)
            {
                return () => { };
            }
            return () =>
                {
                    lock (o)
                    {
                        a();
                    }
                };
        }


        public static MonoBehaviorWrapper Create(this ReferenceFrameBehavior monoBehaviour,
            bool unique, float step,
            string desktop,
            string[] inputs,
            string[] outputs)
        {
            Dictionary<string, Action<double>> insp = monoBehaviour.inps;
            Dictionary<string, Func<double>> outp = monoBehaviour.outs;
            MonoBehaviorWrapper wr = new MonoBehaviorWrapper(monoBehaviour, desktop);
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
            Quaternion q1 = new Quaternion(0.77f, 0.7f, 0, 0);
            Quaternion q2 = new Quaternion(0.75f, 0.7f, 0, 0);
            Quaternion.EulerRotation(0.77f, 0.7f, 0);
            Quaternion.Euler(1, 2, 3);
            Vector3 v1 = q1.eulerAngles;
            Vector3 v2 = q2.eulerAngles;
            v1 = v2;

            /*         Quaternion q1 = new Quaternion(0.77f, 0.7f, 0, 0);
                     Quaternion q2 = new Quaternion(0, 0, 1f, 0);
                     Quaternion q3 = Quaternion.Slerp(q1, q2, 0.3456f);
                     Quaternion q4 = new Quaternion(0, 0, 0.131f, -1f);
                     Quaternion q5 = Quaternion.EulerRotation(1.357f, 2.432f, 3.756f);
                     Quaternion q6 = Quaternion.EulerRotation(1.3671f, 2.432f, 3.756f);
                     Vector3 v1 = q5.eulerAngles;
                     Vector3 v2 = q6.eulerAngles;
                     q6 = Quaternion.EulerRotation(0.02f, 0.04f, 0.06f);
                     v2 = q6.eulerAngles;*/

            TextUpdate = new DefaultTextAction();

            Assembly ass = typeof(StaticExtensionUnity).Assembly;

            StaticExtensionDiagramUI.PostLoadDesktop += dAct;

            PureDesktop.DesktopPostLoad += dAct;

            ass.SetScadaAssembly((Type type) =>
            {
                ConstructorInfo ci = type.GetConstructor(new Type[0]);
                if (ci == null)
                {
                    return;
                }
                var types = type.GetInterfaces();
                string name = type.Name;
                if (types.Contains(typeof(IUpdate)))
                {

                    updates[name] = ci;
                }
                if (types.Contains(typeof(IUpdateRectTransform)))
                {
                    updatesRectTransform[name] = ci;

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
                            if (form == "+-")
                            {
                                return () =>
                                {
                                    double x = fd();
                                    if (x > 0)
                                    {
                                        text.text = s + "+";
                                        return;
                                    }
                                    if (x < 0)
                                    {
                                        text.text = s + "-";
                                        return;
                                    }
                                    text.text = "0";
                                };
                            }
                            if (form == "+--")
                            {
                                return () =>
                                {
                                    double x = fd();
                                    if (x > 0)
                                    {
                                        text.text = s + "-";
                                        return;
                                    }
                                    if (x < 0)
                                    {
                                        text.text = s + "+";
                                        return;
                                    }
                                    text.text = "0";
                                };
                            }

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