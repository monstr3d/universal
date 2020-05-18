
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
            ev();
            update();
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
                double[] pos = referenceFrame.Position;
                double[] quater = referenceFrame.Quaternion;
                gameObject.transform.position = new Vector3((float)pos[0], 
                    (float)pos[1], (float)pos[2]);
                gameObject.transform.rotation =
                new Quaternion((float)quater[1], 
                (float)quater[2], (float)quater[3], (float)quater[0]);
            };
            AddAction(act);
        }
    }

    #endregion


}
