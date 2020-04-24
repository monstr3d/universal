using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using GeneratedProject;
using Scada.Desktop;
using Scada.Interfaces;
using StaticExtension;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, ITimerEventFactory, ITimerFactory, ITimer,
    ITimerEvent
{
    [SerializeField]
    private GameObject obj;

     IDesktop desktop;

    IMeasurement timeMeasurement;

    IScadaInterface scada;

    TimeSpan ts = new TimeSpan();

    Action ev = () => { };

    bool isEnabled = false;

    Func<double> outputX;
    Func<double> outputY;

    Action<double> inputA;

    Action<double> inputB;

    double a = 1;

    double b = 1;

    private void Awake()
    {
        this.SetFactory();
        try
        {
            desktop = StaticExtensionGeneratedProject.Desktop;
            scada = desktop.ScadaFromDesktop("Consumer", BaseTypes.Attributes.TimeType.Second, false, null);
            var ou = scada.Outputs;
            outputX = scada.GetDoubleOutput("Motion.Formula_1");
            outputY = scada.GetDoubleOutput("Motion.Formula_2");
            inputA = scada.GetDoubleInput("Input.a");
            inputB = scada.GetDoubleInput("Input.b");
            //          desktop.SetAliasValue("Motion.a", (double)2);
            //          desktop.SetAliasValue("Motion.b", (double)5);
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            scada.IsEnabled = true;
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    // Update is called once per frame
    void Update()
    {
        double dd = 0.01;
        if (scada.IsEnabled)
        {
            ev();
            if (Input.GetKey(KeyCode.A))
            {
                a += dd;
                if (a > 10)
                {
                    a = 10;
                }
                inputA(a);
            }
            if (Input.GetKey(KeyCode.S))
            {
                a -= dd;
                if (a < 0)
                {
                    a = 0;
                }
                inputA(a);
            }
            if (Input.GetKey(KeyCode.D))
            {
                b += dd;
                if (b > 10)
                {
                    b = 10;
                }
                inputB(b);
            }
            if (Input.GetKey(KeyCode.E))
            {
                b -= dd;
                if (b < 0)
                {
                   b = 0;
                }
                inputB(b);
            }
            if (obj != null)
            {
                obj.transform.position = new Vector3((float)outputX(), (float)outputY());
            }
        }
    }


    #region ITimerEventFactory Members

    ITimerEvent ITimerEventFactory.NewTimer => this;

    #endregion

    #region ITimer Members

    TimeSpan ITimer.TimeSpan =>  ts;

    bool ITimer.IsEnabled {  get => isEnabled; set => SetEnabled(value); }
    TimeSpan ITimerEvent.TimeSpan { get => ts; set => ts = value; }
    bool Event.Interfaces.IEvent.IsEnabled { get => isEnabled; set => SetEnabled(value); }

  
    #endregion



    #region ITimerFactory Members


    ITimer ITimerFactory.CreateTimer(TimeSpan timeSpan)
    {
        return this;
    }

    #endregion


    #region ITimer Members

    event Action ITimer.Event
    {
        add
        {
            ev += value;
        }

        remove
        {
            ev -= value;
        }
    }

    event Action Event.Interfaces.IEvent.Event
    {
        add
        {
            ev += value;
        }

        remove
        {
            ev -= value;
        }
    }

    #endregion

    void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
    }


    #region Private Members

    static NewBehaviourScript()
    {
        StaticExtension.StaticInit.Init();
    }

    #endregion
}
