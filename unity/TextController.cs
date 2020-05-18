using Event.Interfaces;
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




    public bool isEnabled = true;

    Action update = () => { };


    Action[] ev;

    IScadaInterface scada;

    private void Awake()
    {
        if (!isEnabled)
        {
            update = () => { };
            ev = new Action[] { update };
            return;
        }
        scada = MonoBehaviorTimerFactory.Create(desktop, out ev);
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
    }

    

    // Start is called before the first frame update
    void Start()
    {
        if (!scada.IsEnabled)
        {
            scada.IsEnabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ev[0]();
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
