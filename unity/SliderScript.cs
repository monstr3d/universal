using System;
using System.Collections.Generic;
using UnityEngine;

using Unity.Standard;
using Scada.Interfaces;
using Scada.Desktop;
using UnityEngine.UI;
using UnityEditor.Experimental.UIElements;

public class SliderScript : MonoBehaviour
{

    #region Fields

    public float limit;

    public float scale;

    public bool positive  = true;

    public Color normal = new Vector4(0, 0, 1, 1);

    public Color exceed = new Vector4(1, 0, 0, 1);

    public string desktop = "";

    public string pararmeter = "";

    Dictionary<string, List<Component>> components;

    Func<double> output;

    IScadaInterface scada;

    bool exists = false;

    bool isEnabled = true;

    MonoBehaviorTimerFactory factory;

    Action ev;

    Action update;

    Slider left;

    Slider right;

    #endregion

    #region Standard Members

    private void Awake()
    {
        if (desktop.Length == 0)
        {
            enabled = false;
        }
        this.Add();
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop, out factory);
        components = gameObject.GetGameObjectComponents<Component>();
        if (!exists)
        {
            ev = factory.Update;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (desktop.Length == null)
        {
            enabled = false;
        }
        factory.Start();
        output = scada.GetDoubleOutput(pararmeter);
        CreateUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        update?.Invoke();
    }

    private void FixedUpdate()
    {
        ev?.Invoke();
    }

    #endregion

    float Get()
    {
        return scale * (float)output();
    }


    void CreateUpdate()
    {
        if (!isEnabled)
        {
            return;
        }
        var c = components;
        left = c["SliderLeft"][1] as Slider;
        right = c["SliderRight"][1] as Slider;

        update = SimpleUpdate;

    }


    void SimpleUpdate()
    {
        float x = Get() / limit;
        if (x < 1)
        {
            left.value = x;
            return;
        }
        left.value = 1;
        x -= 1;
        if (x > 1)
        {
            x = 1;
        }
        right.value = x;
    }
 
}
