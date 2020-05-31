
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Scada.Interfaces;



using Motion6D;
using Unity.Standard;
using Scada.Desktop;

using Motion6D.Interfaces;

using V = Vector3D;
using Vector3D;
using System.Reflection;
using UnityEngine.Rendering;

public class ReferenceFrameBehavior : MonoBehaviour
{

    #region Fields

    public string desktop = "";

    public float step = 0;

    public string[] starts;

    public string[] inputs = new string[0];

    public string[] outputs = new string[0];

    public string[] updates = new string[0];

    public string[] constants = new string[0];

    public string onTriggerEnter = "";

    public string onCollisionEnter = "";

    public float[] collisionConstants = new float[0];

    public Component collisionIndicator = null;

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

    Action update = () => { };

    Action lateUpdate = () => { };

    IScadaInterface scada;

    Action<Collider> triggerEnter = (Collider c) => { };

    Action<Collision> collisionEnter = (Collision collision) => { };


    Quaternion currentOrientation;

    Quaternion startOrientation;

    Quaternion nextOrientation;

    Vector3 currentPosition;

    Vector3 startPosition;

    Vector3 nextPosition;


    IAngularVelocity angular;

    double[] startQ = new double[4];

    double[] auxQ = new double[4];

    double[] nextQ = new double[4];


    float lastTime;


    double[,] qd = new double[4, 4];


    double[] qder = new double[4];

    double[] auxQuaternion = new double[4];

    double[] pos;

    double[] quater;

    double[] newQuater = new double[4];

    Action updatePosition;

    bool exists;

    Action wrapperUpdate = null;

    ReferenceFrame referenceFrame;

    Action scadaUpdate;

    ICollisionAction collisionAction;

 
    #endregion

    #region Standard Members

    private void Awake()
    {
        this.Add();
        exists = desktop.ScadaExists();
         monoBehaviorWrapper =
            StaticExtensionUnity.Create(this, unique, step,
            desktop, inputs, outputs);
        scada = monoBehaviorWrapper.Scada;
        (monoBehaviorWrapper as IScadaUpdate).Update = null;
            //ScadaUpdate;
        wrapperUpdate = monoBehaviorWrapper.Update;
        Dictionary<string, IReferenceFrame> frames
     = monoBehaviorWrapper.Frames;

         if (frames.ContainsKey(transformation))
        {
            IReferenceFrame frame = frames[transformation];
            referenceFrame = frame.Own;
            
        }
        var cam = gameObject.GetComponent<Camera>();
        if (cam != null)
        {
            lateUpdate = UpdatePosition;
        }
        else
        {
            update = UpdatePosition;
        }
        if (onTriggerEnter.Length > 0)
        {
            ConstructorInfo c = StaticExtensionUnity.updatesTriggerAction[onTriggerEnter];
            ITriggerAction ta = c.Invoke(new Type[0]) as ITriggerAction;
            ta.Set(gameObject, scada);
            triggerEnter = ta.Action;
        }
        if (onCollisionEnter.Length > 0)
        {
            ConstructorInfo c = StaticExtensionUnity.updatesCollisionAction[onCollisionEnter];
            collisionAction = c.Invoke(new Type[0]) as ICollisionAction;
        }
        else if (collisionIndicator != null)
        {
            collisionAction = new StandardCollisionAction();
        }
        if (collisionAction != null)
        {
            collisionAction.Set(gameObject, collisionIndicator, scada);
            collisionEnter = collisionAction.Action;
        }
    }

    void Start()
    {
        SetConstants();
        if (collisionAction != null)
        {
            collisionAction.SetConstants(0, collisionConstants);
        }
        //start();
        monoBehaviorWrapper.Start();
    }



    void Update()
    {
        update?.Invoke();
    }

    private void LateUpdate()
    {
        lateUpdate?.Invoke();
    }


    void FixedUpdate()
    {
        try
        {
            wrapperUpdate?.Invoke();
        }
        catch (Exception exception)
        {
            exception.ShowError();
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        triggerEnter(other);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        collisionEnter(collision);
    }


    #endregion

    /*
       void ScadaUpdate()
       {
           gameObject.transform.rotation = referenceFrame.ToQuaternion();
           gameObject.transform.position = referenceFrame.Position.ToPosition();

       }
   */

    // Start is called before the first frame update


    // Update is called once per frame

    void UpdatePosition()
    {
        gameObject.transform.rotation = referenceFrame.ToQuaternion();
        gameObject.transform.position = referenceFrame.Position.ToPosition();
    }

    #region Standard Members

 
 

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
 

    #endregion
}


