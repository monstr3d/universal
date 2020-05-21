using Event.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    public string desktop;

    public string[] parameters;


    public Text[] texts;

    public string[] formats;


    public float[] scales;

    bool exists;

    public bool isEnabled = true;

    Action update = () => { };


    Action ev = () => { };

    IScadaInterface scada;

    MonoBehaviorTimerFactory factory;

    private void Awake()
    {
        exists = desktop.ScadaExists();
        if (!isEnabled)
        {
            update = () => { };
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop, out factory);
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
                parameters[i], format,  text, scale);
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
