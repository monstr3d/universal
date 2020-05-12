
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scada.Interfaces;

using Assets;
using Diagram.UI;

public class ScriptWithWrapper : MonoBehaviour
{
    private MonoBehaviorWrapper monoBehaviorWrapper;


    Action<double> a;

    Action<double> b;

    Func<double> f1;
    Func<double> f2;
    Func<double> f3;
    Func<double> f4;


    Action<double> fx;

    Action<double> fy;

    Action<double> fz;

    Action<double> mx;

    Action<double> my;

    Action<double> mz;


    Func<double> x;
    Func<double> y;
    Func<double> d;
    Func<double> ox;





    IScadaInterface scada;
    private void Awake()
    {
        CreateRigidBodyFirst();
    }
    // Start is called before the first frame update
    void Start()
    {
        scada.IsEnabled = true;
    }

    void CreateMotionFirst()
    {
        monoBehaviorWrapper = new MonoBehaviorWrapper(this, "MotionFirst", true);
        scada = monoBehaviorWrapper.Scada;
        a = scada.GetDoubleInput("Input.a");
        b = scada.GetDoubleInput("Input.b");
        f1 = scada.GetDoubleOutput("Motion.Formula_1");
        f2 = scada.GetDoubleOutput("Motion.Formula_1");
        f3 = scada.GetDoubleOutput("Motion.Formula_1");
        f4 = scada.GetDoubleOutput("Motion.Formula_1");
    }

    void CreateRigidBodyFirst()
    {
        monoBehaviorWrapper = new MonoBehaviorWrapper(this, "RigidBodyFirst", true);
        scada = monoBehaviorWrapper.Scada;
        var ou = scada.Outputs;
        var inp = scada.Inputs;
        fx = scada.GetDoubleInput("Force.Fx");
        fy = scada.GetDoubleInput("Force.Fy");
        fz = scada.GetDoubleInput("Force.Fz");
        mx = scada.GetDoubleInput("Force.Mx");
        my = scada.GetDoubleInput("Force.My");
        mz = scada.GetDoubleInput("Force.Mz");
        x = scada.GetDoubleOutput("Rigid Body.X");
        y = scada.GetDoubleOutput("Rigid Body.X");
        d = scada.GetDoubleOutput("Measurements.Distance");
        ox = scada.GetDoubleOutput("Rigid Body.OMGx");
    }


    // Update is called once per frame
    void Update()
    {
        try
        {
            monoBehaviorWrapper.Event();
            PrintRigid();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    void PrintRigid()
    {
        if (Input.GetKey(KeyCode.A))
        {
            fx(0.1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            fx(-0.1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mx(0.1);
        }
        if (Input.GetKey(KeyCode.F))
        {
            mx(-0.1);
        }
        print(x() + " " + ox());
    }

    void PrintFirst()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a(0.1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            a(-0.1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            b(0.1);
        }
        if (Input.GetKey(KeyCode.F))
        {
            b(-0.1);
        }
        print(x() + " " + ox());
    }
}
