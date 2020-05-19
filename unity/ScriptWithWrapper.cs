
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scada.Interfaces;



using Motion6D;
using Unity.Standard;

public class ScriptWithWrapper : MonoBehaviour
{

    #region Fields

    public string desktop = "";

    public string[] starts;

    public string[] inputs = new string[0];
    
    public string[] outputs = new string[0];

    public string[] updates = new string[0];

    public string[] constants = new string[0];

    public bool isEnabled = true;

    public GameObject[] transformations = new GameObject[0];

    public string transformation = "";

    public string[] frames = new string[0];

    public bool unique = true;

    private MonoBehaviorWrapper monoBehaviorWrapper;

    internal Dictionary<string, Action<double>> 
        inps = new Dictionary<string, Action<double>>();

    internal Dictionary<string, Func<double>> outs = 
        new Dictionary<string, Func<double>>();

    internal Action<double>[] dInp;

    internal Func<double>[] dOut;

    Action update = null;

    Action start = null;

    internal Action ev;

    IScadaInterface scada;

    Action lateUpdate = () => { };

    Action fixedAct = null;


    Motion6D.Interfaces.IAngularVelocity angular;

  
    float prevtime = 0;

    float lastTime;


    double[,] qd = new double[4, 4];


    double[] qder = new double[4];

    double[] auxQuaternion = new double[4];

    double[] pos;

    double[] quater;

    double[] newQuater = new double[4];


    #endregion

    #region Standard Members

    private void Awake()
    {
        monoBehaviorWrapper = StaticExtensionUnity.Create(this, unique, desktop, inputs, outputs);
        scada = monoBehaviorWrapper.Scada;
        SetConstants();
        AddAction(StaticExtensionUnity.Create(this, monoBehaviorWrapper, updates, ref start));
        UpdateFrames();
        if ((update == null) | (!isEnabled))
        {
            update = () => { };
        }
      }

    // Start is called before the first frame update
    void Start()
    {
        start();
        if (!scada.IsEnabled)
        {
            scada.IsEnabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            prevtime = Time.realtimeSinceStartup;
            ev();
            update();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    private void FixedUpdate()
    {
        try
        {
            fixedAct();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    private void LateUpdate()
    {
        try
        {
          //  fixedAct();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }


    #endregion

    #region Public Members

    #endregion


    #region  Private Members

    void AddFixed(Action action)
    {
        if (fixedAct == null)
        {
            fixedAct = action;
            return;
        }
        fixedAct += action;
    }

    void SetAngularVelocity()
    {
        if (angular != null)
        {

        }
    }

    void SetConstants()
    {
        var consts = scada.Constants;
        char[] sep = "=".ToCharArray();
        foreach (string cc in constants)
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
                pos = referenceFrame.Position;
                quater = referenceFrame.Quaternion;
                gameObject.transform.position = new Vector3((float)pos[0], 
                    (float)pos[1], (float)pos[2]);
                gameObject.transform.rotation = quater.ToQuaternion();
                lastTime = Time.realtimeSinceStartup;
            };
            AddAction(act);

            var cam = gameObject.GetComponent<Camera>();
            if (referenceFrame is Motion6D.Interfaces.IAngularVelocity)
            {
                var av = referenceFrame as Motion6D.Interfaces.IAngularVelocity;

                act = () =>
                {
                    Vector3D.StaticExtensionVector3D.CalculateQuaternionDerivation(quater,
                        av.Omega, qder, auxQuaternion);
                };
                AddAction(act);
                act = () =>
                {
                    if (quater == null)
                    {
                        return;
                    }
                    double dt = Time.realtimeSinceStartup - lastTime;
                    for (int i = 0; i < 4; i++)
                    {
                        newQuater[i] = quater[i] + dt * qder[i];
                    }
                    Vector3D.StaticExtensionVector3D.Normalize(newQuater);
                    gameObject.transform.rotation = newQuater.ToQuaternion();
                };
                AddFixed(act);
                lateUpdate = act;
            }
            if (fixedAct == null)
            {
                fixedAct = () => { };
            }
             if (cam != null)
            {
                lateUpdate = act;
            }
            return;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (true)
                {
                    if (referenceFrame is Motion6D.Interfaces.IAngularVelocity)
                    {
                        var av = referenceFrame as Motion6D.Interfaces.IAngularVelocity;
                        act = () =>
                        {
                            var avv = av.Omega;
                            rb.angularVelocity = new Vector3((float)avv[0], (float)avv[1], (float)avv[2]);
                            int i = 0;
                        };
                        AddAction(act);
                    }
                }
            }
        }
    }

  

    #endregion


}
