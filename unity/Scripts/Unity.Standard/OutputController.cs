using System;
using System.Collections.Generic;
using System.Reflection;


using UnityEngine;
using UnityEngine.UI;

using Scada.Desktop;
using Scada.Interfaces;


using Diagram.UI.Interfaces;
using Diagram.UI;

using Unity.Standard;
using BaseTypes;
using Unity.Standard.Interfaces;

public class OutputController : MonoBehaviour
{

    public string desktop;

    public string[] aliases;


    public string[] parameters;


    public Text[] texts;

    public string[] formats;


    public float[] scales;

    public string[] inputs;

    public float[] inputConstants;

    public Component[] inputComponents;

    public string[] generalizedParamerers;

    public string[] generalizedUpdates;

    public Component[] indicators;

    public bool isEnabled = true;

    public float[] constants;

    bool exists;


    Action ev = null;


    Action inpAct;

    IScadaInterface scada;

    IDesktop scadaDesktop;

    Action up = null;

    Action update;

    MonoBehaviourTimerFactory factory;

    private Dictionary<string, Tuple<object,
        Func<object>, List<Tuple<string, Component>>>> allparameters
        = new Dictionary<string, Tuple<object, Func<object>,
            List<Tuple<string, Component>>>>();

    private Dictionary<string, int> valuePairs = new Dictionary<string, int>();

    private Dictionary<int, IUpdateGameObject> keyValuePairs =

        new Dictionary<int, IUpdateGameObject>();

    #region Standard Members

    private void Awake()
    {
        this.Add();
        MonoBehaviourTimerFactory.OnStart +=
           (string s) =>
           {
               if (desktop == s)
               {
                   SetConstants();
                   aliases = new string[0];
               }
           };
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            return;
        }
        scada = MonoBehaviourTimerFactory.Create(desktop, out factory);
        for (int i = 0; i < generalizedUpdates.Length; i++)
        {
            valuePairs[generalizedUpdates[i]] = i;
        }
        FillAllParameters();
        scadaDesktop = scada.GetDesktop();
        if (!exists)
        {
            ev = factory.Update;
        }
        for (int i = 0; i < parameters.Length; i++)
        {
            if (i >= texts.Length)
            {
                break;
            }
            Text text = texts[i];
            if (text == null)
            {
                continue;
            }
            float scale = 1f;
            string format = null;
            if (i < scales.Length)
            {
                scale = scales[i];
            }
            if (i < formats.Length)
            {
                format = formats[i];
            }
            Action act = scada.CreateTextAction(
                parameters[i], format, text, scale);
            AddUpdate(act);
        }
        (factory as IScadaUpdate).Update = null;
    }


    // Start is called before the first frame update
    void Start()
    {
        factory.Start();
        UpdateInput();
        UpdateOutput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ev?.Invoke();
    }

    void Update()
    {
        update?.Invoke();
    }

    #endregion

    void FillAllParameters()
    {
        for (int i = 0; i < generalizedParamerers.Length; i++)
        {
            string key = generalizedParamerers[i];
            Component go = indicators[i];
            string up = generalizedUpdates[i];
            Tuple<object,
             Func<object>, List<Tuple<string, Component>>> t;
            List<Tuple<string, Component>> l;
            if (allparameters.ContainsKey(key))
            {
                t = allparameters[key];
                l = t.Item3;
            }
            else
            {
                Func<object> f = null;
                object type = null;
                var ou = scada.Outputs;
                if (ou.ContainsKey(key))
                {
                    f = scada.GetOutput(key);
                    type = ou[key];
                }
                l = new List<Tuple<string, Component>>();
                t = new Tuple<object, Func<object>, List<Tuple<string, Component>>>
                    (type, f, l);
                allparameters[key] = t;
            }
            Tuple<string, Component> tt = new Tuple<string, Component>(up, go);
            l.Add(tt);
        }
    }

    void SetConstants()
    {
        var consts = scada.Constants;
        char[] sep = "=".ToCharArray();
        foreach (string cc in aliases)
        {
            string[] ss = cc.Split(sep);
            if (consts.ContainsKey(ss[0]))
            {
                object o = consts[ss[0]];
                if (o.GetType() == typeof(double))
                {
                    double a = double.Parse(ss[1],
                        System.Globalization.CultureInfo.InvariantCulture);
                    scada.SetConstant(ss[0], a);
                }

            }
        }
    }

    private void UpdateOutput()
    {
        if (allparameters.Count == 0)
        {
            return;
        }
        var factory = StaticExtensionUnity.ReplaceActionFactory;
        Dictionary<string, ConstructorInfo> constructors =
            StaticExtensionUnity.updatesGameObject;
        foreach (var key in allparameters.Keys)
        {
            Action act = null;
            object[] o = null;
            var v = allparameters[key];
            if (factory != null)
            {
                o = factory.Create(scada, key, out act);
            }
            if (o == null)
            {
                o = new object[1];
                if (v.Item1 != null)
                {
                    Func<object> f = v.Item2;
                    act = () =>
                    {
                        o[0] = f();
                    };
                }
            }
            AddUpdate(act);
            var lt = v.Item3;
            List<object> lo = new List<object>(o);
            lo.Add(this);
            o = lo.ToArray();
            foreach (var actions in lt)
            {
                IUpdateGameObject ua = constructors[actions.Item1].Invoke(new Type[0])
                    as IUpdateGameObject;
                ua.Set(o, actions.Item2, scada);
                int k = valuePairs[actions.Item1];
                keyValuePairs[k] = ua;
                AddUpdate(ua.Update);
            }
        }
        List<int> l = new List<int>(keyValuePairs.Keys);
        l.Sort();
        int offset = 0;
        foreach (var ln in l)
        {
            var uas = keyValuePairs[ln];
            offset = uas.SetConstants(offset, constants);
            if (offset < 0)
            {
                break;
            }
        }
    }

    private void UpdateInput()
    {
        if (inputs.Length == 0)
        {
            return;
        }
        Dictionary<string, ConstructorInfo> constructors =
       StaticExtensionUnity.updatesGameObject;
        int offset = 0;
        int n = 0;
        foreach (var key in inputs)
        {
            IUpdateGameObject ua = constructors[key].Invoke(new Type[0])
                as IUpdateGameObject;
            Component component = gameObject.GetComponent<Component>();
            if (inputComponents.Length > n)
            {
                component = inputComponents[n];
            }
            ++n;
            ua.Set(new object[] { this }, component, scada);
            AddUpdate(ua.Update);
            offset = ua.SetConstants(offset, inputConstants);
        }
    }

    void AddUpdate(Action act)
    {
        update = update.Add(act);
    }

}
