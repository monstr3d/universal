using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using BaseTypes;

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

using UnityEngine;
using UnityEngine.UI;
using Unity.Standard.Interfaces;
using Unity.Standard.Abstract;
using System.Globalization;

namespace Unity.Standard
{


    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionUnity
    {

        #region Fields

        /// <summary>
        /// Failure messages
        /// </summary>
        static public List<IFailureMessage> FailureMessages
        { get; } = new List<IFailureMessage>();

        /// <summary>
        /// UpdateTypes
        /// </summary>
        static public Dictionary<string, Type> StringUpates
        { get => stringUpates; }

        volatile static KeyCode current;

        static KeyCode lastCurrent;

        static private TimeMeasureProviderFactory factory = new TimeMeasureProviderFactory();

        static private Dictionary<KeyCode, Action<KeyCode>> keyListenres = new Dictionary<KeyCode, Action<KeyCode>>();

        static private ITimerEventFactory timerEventFactory;

        static private ITimerFactory timerFactory;

        static private ITimeMeasurementProviderFactory timeMeasureProviderFactory;

        static private ITimeMeasurementProvider timeMeasureProvider;

        static private Scada.Interfaces.IErrorHandler errorHandler = new ErrorHanller();

        static MonoBehaviour enabled;


        static private Dictionary<string, Type> stringUpates = 
            new Dictionary<string, Type>();

        static private Dictionary<string, Tuple<object,

            List<IScadaUpdate>>> scadaUpdates
            = new Dictionary<string, Tuple<object,
            List<IScadaUpdate>>>();

        static Dictionary<string, ConstructorInfo> updates =
            new Dictionary<string, ConstructorInfo>();

        static internal Dictionary<string, ConstructorInfo> updatesGameObject =
     new Dictionary<string, ConstructorInfo>();

        static internal Dictionary<string, ConstructorInfo> activations =
          new Dictionary<string, ConstructorInfo>();


        static internal Dictionary<string, ConstructorInfo> updatesTriggerAction =
     new Dictionary<string, ConstructorInfo>();

        static internal Dictionary<string, ConstructorInfo> updatesCollisionAction =
     new Dictionary<string, ConstructorInfo>();

        static internal Scada.Interfaces.IErrorHandler ErrorHandler => errorHandler;

        static private List<MonoBehaviour> monoBehaviours = new List<MonoBehaviour>();

        static double pauseTime;

        static List<IIndicatorFactory> indicatorFactories = new List<IIndicatorFactory>();


        static event Action<Tuple<GameObject, Component,
            IScadaInterface, ICollisionAction>> collision = (Tuple<GameObject, Component,
            IScadaInterface, ICollisionAction> t) =>
            { };

        static Action<string> global = (string s) => { };
        
        static public event Action<string> OnGlobal
        {
            add { global += value; }
            remove { global -= value; }
        }

        /// <summary>
        /// Adds global event
        /// </summary>
        /// <param name="act">Action</param>
        static public void AddGlobal(this Action<string> act)
        {
            OnGlobal += act;
        }


        /// <summary>
        /// Executes glbal event
        /// </summary>
        /// <param name="str"></param>
        static public void Global(this string str)
        {
            global(str);
        }

        /// <summary>
        /// Key down imitation
        /// </summary>
        /// <param name="code">Key code</param>
        /// <returns>True in succces</returns>
        static public bool KeyDown(this KeyCode code)
        {
            var unused = UnusedKey;
            current = code;
            if ((current == unused) | (current == default(KeyCode)))
            {
                return false;
            }
            UpdateCurrent();
            return true;
        }

        /// <summary>
        /// Processes key code
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>True in succces</returns>
        static public bool ProcessKeyCode(this KeyCode code)
        {
            var unused = UnusedKey;
            if (Input.GetKeyDown(code))
            {
                current = code;
            }
            if ((current == unused)  | (current == default(KeyCode)))
            {
                return false;
            }
            UpdateCurrent();
            return true;
        }


        /// <summary>
        /// Adds a key listener
        /// </summary>
        /// <param name="keyListener">The key listener for addinion</param>
        static public void AddKeyListener(this IKeyListener keyListener)
        {
            var l = keyListenres.Keys;
            var p = keyListener.Keys;
            foreach (var key in l)
            {
                if (p.Contains(key))
                {
                    throw new Exception();
                }
            }
            foreach (var key in p)
            {
                keyListenres[key] = keyListener.Action;
            }
        }


        /// <summary>
        /// Collosion event
        /// </summary>
        static public event Action<Tuple<GameObject, Component,
            IScadaInterface, ICollisionAction>> Collision
        {
            add { collision += value; }
            remove { collision -= value; }
        }

        /// <summary>
        /// Time of start
        /// </summary>
        static public double StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Activation
        /// </summary>
        static public Activation Activation
        {
            get;
            set;
        }

        /// <summary>
        /// Time
        /// </summary>
        static public double Time
        {
            get => UnityEngine.Time.realtimeSinceStartup - StartTime;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// String to single
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Single value</returns>
        static public float ToSingle(this string value)
        {
            return float.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// String to double
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>Double value</returns>
        static public double ToDouble(this string value)
        {
            return double.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        /// Level action
        /// </summary>
        public static Action LevelAction
        {
            get;
            set;
        } = () => { Level.GetConstructor(new Type[0]).Invoke(new object[0]); };

        /// <summary>
        /// Blinked coroutine
        /// </summary>
        /// <param name="blinked">Blinked object</param>
        /// <param name="intervals">Intervals</param>
        /// <returns>Blinks</returns>
        public static IEnumerator BlinkedCoroutine(this IBlinked blinked, float[] intervals)
        {
            blinked.IsStopped = false;
            while (true)
            {
                for (int i = 0; i < intervals.Length; i++)
                {
                    yield return new WaitForSeconds(intervals[i]);
                    if (blinked.IsStopped)
                    {
                        goto finish;
                    }
                    blinked.Blink(i);
                }
            }
        finish:
            yield return null;
        }

        /// <summary>
        /// Starts Blinked coroutine
        /// </summary>
        /// <param name="blinked">Blinked object</param>
        /// <param name="intervals">Intervals</param>
        /// <param name="monoBehaviour">Mono behavior</param>
        public static void Start(this IBlinked blinked, float[] intervals, MonoBehaviour monoBehaviour)
        {
            monoBehaviour.StartCoroutine(BlinkedCoroutine(blinked, intervals));
        }

        /// <summary>
        /// Starts Blinked coroutine
        /// </summary>
        /// <param name="blinked">Blinked object</param>
        /// <param name="intervals">Intervals</param>
        public static void Start(this IBlinked blinked, float[] intervals)
        {
            Start(blinked, intervals, Enabled);
        }


        /// <summary>
        /// Processes codes
        /// </summary>
        static public void ProcessKeyCodes()
        {
            foreach (var key in keyListenres.Keys)
            {
                if (key.ProcessKeyCode())
                {
                    return;
                }
                if (Input.GetKeyUp(key))
                {
                    current = default(KeyCode);
                }
            }
        }

        /// <summary>
        /// Checks whether indicators exceed
        /// </summary>
        /// <param name="limits"></param>
        /// <returns>True is excced</returns>
        static public bool Exceeds(this IEnumerable<ILimits> limits)
        {
            foreach (var l in limits)
            {
                if (l.Exceeds)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds action value
        /// </summary>
        /// <param name="action">The action</param>
        /// <param name="value">The value</param>
        public static void Add(this Action<object> action, object value)
        {
            Activation.Put(action, value);
        }

        /// <summary>
        /// Sets level
        /// </summary>
        public static void SetLevel()
        {
            LevelAction();
        }

        public static string ToZero(this string str)
        {
            int k = str.IndexOf("=");
            return str.Substring(0, k + 1) + "0";
        }

        /// <summary>
        /// Static Level
        /// </summary>
        public static int StaticLevel
        {
            get;
            set;
        }


        /// <summary>
        /// Level type
        /// </summary>
        public static Type Level
        {
            get
            {
                return Activation.LevelType;
            }
        }

        public static void SendLevelMessage(this string message)
        {
            string s = AbstractLevelStringUpdate.Level + ":" +
                 Activation.level + ":" + message;
            s.Global();
        }

        public static void EnableDisable(this string command, bool active)
        {
            var s = active ? "on:" : "off:";
            (s + command).Global();
        }


        /// <summary>
        /// Enables indicator
        /// </summary>
        /// <param name="indicator">The indicator</param>
        /// <param name="command">The command</param>
        /// <returns>Success</returns>
        static public bool EnableDisable(this IIndicator indicator, string command)
        {
            string[] ss = command.Split(":".ToCharArray());
            if (ss.Length != 2)
            {
                return false;
            }
            bool b;
            if (ss[0] == "on")
            {
                b = true;
            }
            else if (ss[0] == "off")
            {
                b = false;
            }
            else
            {
                return false;
            }
            if (ss[1] == indicator.Parameter)
            {
                indicator.IsActive = b;
            }
            return true;
        }
        /// <summary>
        /// Collision event
        /// </summary>
        /// <param name="action">Action</param>
        /// <param name="go">Game object</param>
        /// <param name="c">Component</param>
        /// <param name="scada">Scada</param>
        public static void CollisionEvent(this ICollisionAction action, GameObject go, Component c,
            IScadaInterface scada)
        {
            var t = new Tuple<GameObject, Component,
            IScadaInterface, ICollisionAction>(go, c, scada, action);
            collision(t);
        }

        /// <summary>
        /// Sets active state of indicator
        /// </summary>
        /// <param name="indicator">The indicator</param>
        /// <param name="active">The state</param>
        /// <returns>Change sign</returns>
        public static bool SetActive(this IIndicator indicator, bool active)
        {
            if (indicator.IsActive == active)
            {
                return false;
            }
            if (active)
            {
                indicator.Add();
            }
            else
            {
                indicator.Remove();
            }
            return true;
        }

        /// <summary>
        /// Adds indicator to tuple
        /// </summary>
        /// <param name="indicator">The indicator</param>
        /// <param name="ls">The tuple</param>
        public static void Add(this IIndicator indicator, 
            Dictionary<string, Tuple<Func<object>, List<IIndicator>>> ls)
        {
            string p = indicator.Parameter;
            List<IIndicator> l;
            if (ls.ContainsKey(p))
            {
                l = ls[p].Item2;
            }
            else
            {
                l = new List<IIndicator>();
                Func<object> f = null;
                if (indicator.Type.Equals(typeof(object[])))
                {
                    f = ArrayWrapper.FromString(p);
                }
                if (f == null)
                {
                    var s = p.ToScadaString();
                    if (s.Item1.Outputs.ContainsKey(s.Item2))
                    {
                        f = s.Item1.GetOutput(s.Item2);
                    }
                }
                if (f == null)
                {
                    f = () => null;
                }
                var tt = new Tuple<Func<object>, List<IIndicator>>(f, l);
                ls[p] = tt;
            }
            if (!l.Contains(indicator))
            {
                var j = indicator is IJumpedIndicator;
                if (!j)
                {
                    l.Add(indicator);
                }
            }
        }


        /// <summary>
        /// Adds indicator
        /// </summary>
        /// <param name="indicator"></param>
        static public void Add(this IIndicator indicator)
        {
            //indicator.Add(indicators);
        }

        

        /// <summary>
        /// Removes indicator
        /// </summary>
        /// <param name="indicator"></param>
        static public void Remove(this IIndicator indicator)
        {
            /*
            string p = indicator.Parameter;
            if (!indicators.ContainsKey(p))
            {
                return;
            }
            var l = indicators[p].Item2;
            if (!l.Contains(indicator))
            {
                return;
            }
            l.Remove(indicator);
            if (l.Count == 0)
            {
                indicators.Remove(p);
            }
            */
        }

        public static void UpdateInicators<T>(this
            Dictionary<T, Tuple<Func<object>, List<IIndicator>>> indicators)
        {
            foreach (var t in indicators.Values)
            {
                var o = t.Item1();
                var l = t.Item2;
                foreach (var i in l)
                {
                    i.Value = o;
                }
            }
        }         

 
        /// <summary>
        /// Key interval
        /// </summary>
        static public float KeyInterval
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// Unused key
        /// </summary>
        static public KeyCode UnusedKey
        {
            get;
            set;
        }

       

        /// <summary>
        /// Gets full list of indicators
        /// </summary>
        /// <param name="gameObject">The game object</param>
        /// <returns>Full list</returns>
        static public Dictionary<string, Tuple<Func<object>, List<IIndicator>>> GetIndicatorsFull(this GameObject gameObject)
        {
            var d = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();
            List<GameObject> go = new List<GameObject>();
            gameObject.GetIndicators(go, d);
            return d;
        }

        private static void GetIndicators(this GameObject gameObject,
            List<GameObject> lg, 
            Dictionary<string, Tuple<Func<object>, List<IIndicator>>> ls)
        {
            if (lg.Contains(gameObject))
            {
                return;
            }
            lg.Add(gameObject);
            RectTransform[] rt = gameObject.GetComponentsInChildren<RectTransform>();
            foreach (var r in rt)
            {
                r.gameObject.GetIndicators(lg, ls);
            }
            foreach (var factory in indicatorFactories)
            {
                var ind = factory.Get(gameObject);
                if (ind != null)
                {
                    if (ind is IJumpedIndicator)
                    {
                        IJumpedIndicator i = ind as IJumpedIndicator;
                        var pd = new Dictionary<string, Tuple<Func<object>, List<IIndicator>>>();
                        ind.Add(pd);
                        foreach (var iii in pd.Values)
                        {
                            var f = iii.Item1;
                            Action act = () =>
                            {
                                 ind.Value = f();
                            };
                            act.AddToScadaEvent(i.JumpEvents);
                            break;
                        }
                    }
                    else
                    {
                        ind.Add(ls);
                    }
                    ind.Global.AddGlobal();
                }
            }
        }


        /// <summary>
        /// Gets all indicators from Game object
        /// </summary>
        /// <param name="gameObject">The Game object</param>
        /// <returns>Indicators</returns>
        static public Dictionary<string, List<IIndicator>> GetIndicators(this GameObject gameObject)
        {
            var l = new Dictionary<string, List<IIndicator>>();
            List<GameObject> go = new List<GameObject>();
            gameObject.GetIndicators(go, l);
            return l;
        }


        /// <summary>
        /// Action from indicators
        /// </summary>
        /// <param name="indicators">Indicators</param>
        /// <returns>The action</returns>
        static public Action Update<T>(this Dictionary<T, List<IIndicator>> indicators)
        {
            Action update = null;
            foreach (var l in indicators.Values)
            foreach (var i in l)
            {
                var a = i.Update;
                update = update.Add(a);
            }
            return update;
        }


        /// <summary>
        /// Action from indicators
        /// </summary>
        /// <param name="indicators">Indicators</param>
        /// <returns>The action</returns>
        static public Action Update(this IEnumerable<IIndicator> indicators)
        {
            Action update = null;
            foreach (var i in indicators)
            {
                var a = i.Update;
                update = update.Add(a);
            }
            return update;
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        static  void Clear()
        {
           // indicators.Clear();
            StaticExtensionScadaDesktop.Clear();
            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
            {
                monoBehaviour.gameObject.SetActive(false);
                monoBehaviour.enabled = false;
            }
            monoBehaviours.Clear();
            Activation.Disable();
        }

        /// <summary>
        /// Stops itself
        /// </summary>
        static public void Stop()
        {
            Clear();
            "Stop".Global();
        }

        /// <summary>
        /// Starts Coroutine
        /// </summary>
        /// <param name="enumerator"></param>
        public static void StartCoroutine(this IEnumerator enumerator)
        {
            Enabled.StartCoroutine(enumerator);
        }


        /// <summary>
        /// Enabled script
        /// </summary>
        public static MonoBehaviour Enabled
        {
            get
            {
                foreach (MonoBehaviour monoBehaviour in monoBehaviours)
                {
                    if (monoBehaviour.gameObject.activeSelf)
                    {
                        return monoBehaviour;
                    }
                }
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        /// <summary>
        /// Pause
        /// </summary>
        static public void Pause()
        {
            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
            {
                monoBehaviour.enabled = false;
            }
            pauseTime = Time;
            "Escape:true".Global();
        }

        /// <summary>
        /// Restarts itself
        /// </summary>
        public static void Restart()
        {
            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
            {
                monoBehaviour.enabled = true;
            }
            StartTime =  UnityEngine.Time.realtimeSinceStartup - pauseTime;
            "Escape:false".Global();
        }

        static public void Add(this MonoBehaviour monoBehaviour)
        {
            if (!monoBehaviours.Contains(monoBehaviour))
            {
                monoBehaviours.Add(monoBehaviour);
            }
        }

        static public int SetConstants(this float[] input, int offset, float[] output)
        {
            if (offset < 0 | output.Length == 0)
            {
                return offset;
            }
            int l = output.Length;
            if (input.Length > offset + l)
            {
                return -1;
            }
            Array.Copy(input, offset, output, 0, l);
            int k = l + offset;
            return (k == input.Length) ? -1 : k;
        }

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

        static public object GetLock(this string desktop)
        {
            return scadaUpdates[desktop].Item1;
        }

        /// <summary>
        /// Starts blink
        /// </summary>
        /// <param name="limits">Limits</param>
        /// <param name="delay">Delay</param>
        /// <param name="start">Start actuin</param>
        /// <param name="st">Start sign</param>
        /// <param name="act">Action</param>
        public static void StartBlink(this IEnumerable<ILimits> limits,
            float delay, Func<bool> start, bool[] st, Action<bool> act)
        {
            if (st[0])
            {
                return;
            }
            bool s = start();
            if (st[0] == s)
            {
                return;
            }
            if (s)
            {
                foreach (var l in limits)
                {
                    if (l.Exceeds)
                    {
                        act(true);
                        st[0] = true;
                        limits.BlinkLimits(delay, start, st, act).StartCoroutine();
                        return;
                    }
                }
            }
        }

        #endregion

        #region Private


        static private Quaternion ToQuaternion(this EulerAngles euler, double[] t)
        {
            euler.Set(t);
            return
               Quaternion.Euler(Mathf.Rad2Deg * (float)euler.pitch,
                Mathf.Rad2Deg * (float)euler.roll, Mathf.Rad2Deg * (float)euler.yaw);
        }


        static void UpdateCurrent()
        {
            if (current == lastCurrent)
            {
                return;
            }
            if (keyListenres.ContainsKey(current))
            {
                Action<KeyCode> act = keyListenres[current];
                act(current);
                lastCurrent = current;
            }
            StartCoroutine(coroutine);
        }

        static IEnumerator coroutine
        {
            get
            {
                current = UnusedKey;
                yield return new WaitForSeconds(KeyInterval);
                current = default(KeyCode);
                lastCurrent = UnusedKey;
                yield return current;
            }
        }

        /// <summary>
        /// Blinks limit indicators
        /// </summary>
        /// <param name="limits">Limits</param>
        /// <param name="delay">Delay</param>
        /// <param name="start">Start func</param>
        /// <param name="st">Start sign</param>
        /// <param name="act">Action</param>
        /// <returns>Enumerable for coroutine</returns>
        static private IEnumerator BlinkLimits(this IEnumerable<ILimits> limits,
            float delay, Func<bool> start, bool[] st, Action<bool> act)
        {
            bool exceeds = true;
            while (exceeds)
            {
                exceeds = false;
                yield return new WaitForSeconds(delay);
                int i = 0;
                int k = 0;
                foreach (var l in limits)
                {
                    ++k;
                    if (l == null)
                    {
                        continue;
                    }
                    if (l.Exceeds)
                    {
                        exceeds = true;
                        if (l.Active)
                        {
                            l.Active = false;
                            ++i;
                        }
                    }
                }
                yield return new WaitForSeconds(delay);
                foreach (var l in limits)
                {
                    if (l == null)
                    {
                        continue;
                    }
                    if (!l.Active)
                    {
                        l.Active = true;
                    }
                    if (!exceeds)
                    {
                        if (l.Exceeds)
                        {
                            exceeds = true;
                        }
                    }
                    if (!start() | !exceeds)
                    {
                        st[0] = false;
                        act(false);
                        break;
                    }
                }
            }
        }

        private static void GetIndicators(this GameObject gameObject,
            List<GameObject> lg,
           Dictionary<string, List<IIndicator>> ls)
        {
            if (lg.Contains(gameObject))
            {
                return;
            }
            lg.Add(gameObject);
            RectTransform[] rt = gameObject.GetComponentsInChildren<RectTransform>();
            foreach (var r in rt)
            {
                r.gameObject.GetIndicators(lg, ls);
            }
            foreach (var factory in indicatorFactories)
            {
                var ind = factory.Get(gameObject);
                if (ind != null)
                {
                    ind.Add();
                }
            }
        }
        static void GetComponents(this Component go,

            Dictionary<string, List<GameObject>> objects, Dictionary<string, List<Component>> comp)
        {
            Component[] components = go.GetComponentsInChildren(typeof(Component), true);
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
            //Component[] components = go.GetComponents(typeof(Component));
            Component[] components = go.GetComponentsInChildren<Component>(true);
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

        /// <summary>
        /// T
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="euler"></param>
        /// <returns></returns>
        static private Quaternion ToQuaternion(this 
           ReferenceFrame frame, EulerAngles euler)
        {
            return euler.ToQuaternion(frame.Quaternion);
        }

        /// <summary>
        /// Frame to quaternion
        /// </summary>
        /// <param name="frame">The frame</param>
        /// <returns>The quaternion</returns>
        static public Quaternion ToQuaternion(this
            ReferenceFrame frame)
        {
            double[] ori = frame.Quaternion;
            return new Quaternion((float)ori[1], (float)ori[2],
                (float)ori[3], (float)ori[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static public Vector3 ToPosition(this double[] t)
        {
            return new Vector3((float)t[0], (float)t[1], (float)t[2]);
        }

        /// <summary>
        /// Gets Game Object Components
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="go">Game object</param>
        /// <returns>Dictonary</returns>
        static public Dictionary<string, List<T>> GetGameObjectComponents<T>(this
            GameObject go)
            where T : Component
        {
            Dictionary<string, List<Component>> comp;
            go.GetComponents(out comp);
            return comp.GetComponents<T>();
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
            MonoBehaviourWrapper wrapper, string[] upd, ref Action start)
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

        /// <summary>
        /// The transformation of angle to degree
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The degree</returns>
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


        public static MonoBehaviourWrapper Create(this ReferenceFrameBehavior monoBehaviour,
            bool unique, float step,
            string desktop,
            string[] inputs,
            string[] outputs)
        {
            Dictionary<string, Action<double>> insp = monoBehaviour.inps;
            Dictionary<string, Func<double>> outp = monoBehaviour.outs;
            MonoBehaviourWrapper wr = new MonoBehaviourWrapper(monoBehaviour, desktop);
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

        public static IReplaceActionFactory ReplaceActionFactory
        { get; set; } = new FrameReplaceActionFactory();


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
                if (types.Contains(typeof(IUpdateGameObject)))
                {
                    updatesGameObject[name] = ci;
                }
                if (types.Contains(typeof(ITriggerAction)))
                {
                    updatesTriggerAction[name] = ci;
                }
                if (types.Contains(typeof(ICollisionAction)))
                {
                    updatesCollisionAction[name] = ci;
                }
                if (types.Contains(typeof(IActivation)))
                {
                    activations[name] = ci;
                }
                if (types.Contains(typeof(IIndicatorFactory)))
                {
                    indicatorFactories.Add(ci.Invoke(new object[] { })
                        as IIndicatorFactory);
                }
                if (types.Contains(typeof(IStringUpdate)))
                {
                    stringUpates[name] = type; 
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
        class ArrayWrapper
        {
            object[] o;

            Func<object>[] f;

            internal ArrayWrapper(Func<object>[] f)
            {
                this.f = f;
                o = new object[f.Length];
            }

            internal object Get()
            {
                for (int i = 0; i < o.Length; i++)
                {
                    o[i] = f[i]();
                }
                return o;
            }

            static internal Func<object> FromString(string s)
            {
                string[] ss = s.Split(";".ToCharArray());
                var ff = new List<Func<object>>();
                foreach (var str in ss)
                {
                    int k = str.IndexOf(".");
                    if (k < 1)
                    {
                        continue;
                    }
                    string desktop = str.Substring(0, k);
                    var scada = desktop.ToExistedScada();
                    if (scada == null)
                    {
                        continue;
                    }
                    string par = str.Substring(k + 1);
                    if (scada.Outputs.ContainsKey(par))
                    {
                        ff.Add(scada.GetOutput(par));
                    }
                }
                ArrayWrapper arrayWrapper = new ArrayWrapper(ff.ToArray());
                return arrayWrapper.Get;
            }
        }

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

            double ITimeMeasurementProvider.Time { get => StaticExtensionUnity.Time; set { } }
            double ITimeMeasurementProvider.Step { get; set; }

            IMeasurement m = new Measurement(() => StaticExtensionUnity.Time, "Time");
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