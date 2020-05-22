using UnityEngine;
using UnityEngine.UI;

using Scada.Desktop;
using Scada.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Standard;
using Motion6D.Interfaces;
using Vector3D;
using System.Reflection;

public class RectTransformController : MonoBehaviour
{
    public string desktop;

    public string referenceFrame;



    string[] uptates;


    public RectTransform[] transforms;


    bool exists;

    public bool isEnabled = true;

    Action update = () => { };


    Action ev = () => { };

    IScadaInterface scada;

    MonoBehaviorTimerFactory factory;

    ReferenceFrame frame;

    EulerAngles angles = new EulerAngles();

    

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
        Dictionary<string, ConstructorInfo> constructors =
            StaticExtensionUnity.updatesRectTransform;
        for (int i = 0; i < uptates.Length; i++)
        {
            IUpdateRectTransform r = constructors[uptates[i]].Invoke(new Type[0]) 
                as IUpdateRectTransform;
            r.Set(frame, angles, transforms[i]);
            Action act = r.Update;
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

    void Update()
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
