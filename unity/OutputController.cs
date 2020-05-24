using System;
using System.Collections.Generic;
using System.Reflection;


using UnityEngine;
using UnityEngine.UI;

using Scada.Desktop;
using Scada.Interfaces;


using Motion6D.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI;
using Vector3D;

using Unity.Standard;


public class OutputController : MonoBehaviour
{

    public string desktop;

    public string[] parameters;


    public Text[] texts;

    public string[] formats;


    public float[] scales;



    public string[] generalizedParamerers;

    public string[] generalizedUpdates;

    public GameObject[] gameObjects;


 


    public bool isEnabled = true;

    bool exists;


    Action update = () => { };

    public float[] constants;

    Action ev = () => { };

    IScadaInterface scada;

    IDesktop scadaDesktop;

    MonoBehaviorTimerFactory factory;

    private Dictionary<string, Tuple<object,
        Func<object>, List<Tuple<string, GameObject>>>> allparameters
        = new Dictionary<string, Tuple<object, Func<object>, 
            List<Tuple<string, GameObject>>>>();

    private Dictionary<string, int> valuePairs = new Dictionary<string, int>();

    private Dictionary<int, IUpdateGameObject> keyValuePairs = 
        
        new Dictionary<int, IUpdateGameObject>();

    #region Standard Members

    private void Awake()
    {
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            update = () => { };
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop, out factory);
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
        if (update == null)
        {
            update = () => { };
        }
        (factory as IScadaUpdate).Update = null;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        factory.Start();
        UpdateOutput();
  //      UpdateTransforms();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ev();
    }

    void  Update()
    {
        update();
    }


    #endregion

    void FillAllParameters()
    {
        for (int i = 0; i < generalizedParamerers.Length; i++)
        {
            string key = generalizedParamerers[i];
            GameObject go = gameObjects[i];
            string up = generalizedUpdates[i];
            Tuple<object,
             Func<object>, List<Tuple<string, GameObject>>> t;
            List<Tuple<string, GameObject>> l;
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
                l = new List<Tuple<string, GameObject>>();
                t = new Tuple<object, Func<object>, List<Tuple<string, GameObject>>>
                    (type, f, l);
                allparameters[key] = t;
            }
            Tuple<string, GameObject> tt = new Tuple<string, GameObject>(up, go);
            l.Add(tt);
        }
    }

    Action up = null;

    void AddGenAct(Action act)
    {
        if (act == null)
        {
            return;
        }
        if (up == null)
        {
            up = act;
            return;
        }
        up += act;
    }



    private void UpdateOutput()
    {
        if (allparameters.Count == 0)
        {
            return;
        }
        var factory = StaticExtensionUnity.ReplaceActionFactory;
        Dictionary<string, ConstructorInfo> constructors = StaticExtensionUnity.updatesGameObject;
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
            AddGenAct(act);
            var lt = v.Item3;
            foreach (var actions in lt)
            {
                IUpdateGameObject ua = constructors[actions.Item1].Invoke(new Type[0]) 
                    as IUpdateGameObject;
                ua.Set(o, actions.Item2, scada);
                int k = valuePairs[actions.Item1];
                keyValuePairs[k] = ua;
                AddGenAct(ua.Update);
            }

        }
        if (up != null)
        {
            update += up;
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


    void AddUpdate(Action act)
    {
        if (act == null)
        {
            return;
        }
        if (update == null)
        {
            update = act;
            return;
        }
        update += act;
    }

}
