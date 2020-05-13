
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scada.Interfaces;

using Assets;
using StaticExtension;
using Diagram.UI.Interfaces;
using Scada.Desktop;
using Diagram.UI.Labels;
using Motion6D;

public class ScriptWithWrapper : MonoBehaviour
{

    public string desktop = "";

    public string[] inputs = new string[0];
    
    public string[] outputs = new string[0];

    public string[] updates = new string[0];

    public GameObject[] transformations = new GameObject[0];

    public string transformation = "";

    public string[] frames = new string[0];

    public bool unique = true;

    private MonoBehaviorWrapper monoBehaviorWrapper;

    internal Dictionary<string, Action<double>> inps = new Dictionary<string, Action<double>>();

    internal Dictionary<string, Func<double>> outs = new Dictionary<string, Func<double>>();

    Action update = null;

    private Action act;

    private Action ev;

    Vector3 position = new Vector3();

    Quaternion rotation = new Quaternion();

 

    IScadaInterface scada;
 
    private void Awake()
    {
        monoBehaviorWrapper = StaticInit.Create(this, unique, desktop, inputs, outputs,
            out ev, out act, out inps, out outs);
        scada = monoBehaviorWrapper.Scada;
        AddAction(StaticInit.Create(this, monoBehaviorWrapper, updates));
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
        UpdateFrames();
        
    }

    void AddAction(Action action)
    {
        if (update == null)
        {
            update = action;
            return;
        }
        update += action;
    }

    void UpdateFrames()
    {
        Dictionary<string, Motion6D.Interfaces.IReferenceFrame> frames
             = monoBehaviorWrapper.Frames;
        if (frames.ContainsKey(transformation))
        {
            Motion6D.Interfaces.IReferenceFrame frame = frames[transformation];
            ReferenceFrame referenceFrame = frame.Own;
            Action act = () =>
            {
                double[] pos = referenceFrame.Position;
                double[] quater = referenceFrame.Quaternion;
                gameObject.transform.position = new Vector3((float)pos[0], (float)pos[1], (float)pos[2]);//.Translate((float)pos[0], (float)pos[1], (float)pos[2]);
                gameObject.transform.rotation =
                new Quaternion((float)quater[1], (float)quater[2], (float)quater[3], (float)quater[0]);
           //     new Vector3((float)pos[0], (float)pos[1], (float)pos[2]);
            };
            AddAction(act);
        }
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
   /*     a = scada.GetDoubleInput("Input.a");
        b = scada.GetDoubleInput("Input.b");
        f1 = scada.GetDoubleOutput("Motion.Formula_1");
        f2 = scada.GetDoubleOutput("Motion.Formula_1");
        f3 = scada.GetDoubleOutput("Motion.Formula_1");
        f4 = scada.GetDoubleOutput("Motion.Formula_1");
        */
    }

    void CreateRigidBodyFirst()
    {
 /*       var ou = scada.Outputs;
        var inp = scada.Inputs;
        fx = scada.GetDoubleInput("Force.Fx");
        fy = scada.GetDoubleInput("Force.Fy");
        fz = scada.GetDoubleInput("Force.Fz");
        mx = scada.GetDoubleInput("Force.Mx");
        my = scada.GetDoubleInput("Force.My");
        mz = scada.GetDoubleInput("Force.Mz");
        x = scada.GetDoubleOutput("Rigid Body.X");
        y = scada.GetDoubleOutput("Rigid Body.Y");
        d = scada.GetDoubleOutput("Measurements.Distance");
        ox = scada.GetDoubleOutput("Rigid Body.OMGx");
        */
    }


    // Update is called once per frame
    void Update()
    {
        try
        {
            ev();
            update();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    void PrintRigid()
    {
     /*   if (Input.GetKey(KeyCode.A))
        {
            inps["Force.Fx"](0.1);
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
        */
    }

    void PrintFirst()
    {
      /*  if (Input.GetKey(KeyCode.A))
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
        */
    }
}
