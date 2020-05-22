
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


    Action fixedAct = null;

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

    Action wrapperUpdate;

    ReferenceFrame referenceFrame;


  //  private Action update = { }


    #endregion

    #region Standard Members

    private void Awake()
    {
        exists = desktop.ScadaExists();
         monoBehaviorWrapper =
            StaticExtensionUnity.Create(this, unique, step,
            desktop, inputs, outputs);
        scada = monoBehaviorWrapper.Scada;
        SetConstants();
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


    }

    Action scadaUpdate;

 
    void ScadaUpdate()
    {
        gameObject.transform.rotation = referenceFrame.ToQuaternion();
        gameObject.transform.position = referenceFrame.Position.ToPosition();

    }


    // Start is called before the first frame update
    void Start()
    {
        //start();
        monoBehaviorWrapper.Start();
    }

    // Update is called once per frame

    void UpdatePosition()
    {
        gameObject.transform.rotation = referenceFrame.ToQuaternion();
        gameObject.transform.position = referenceFrame.Position.ToPosition();
    }
    void Update()
    {
        update();
        var rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            var ang = rb.angularVelocity;
        }
    }

    private void LateUpdate()
    {
        lateUpdate();
    }




    void FixedUpdate()
    {
        try
        {

            wrapperUpdate();
            //       updatePosition();
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
    /*
    void AddAction(Action action)
    {
        if (update == null)
        {
            update = action;
            return;
        }
        update += action;
    }

    */

    #endregion
}

/*

 void ScadaUpdateFramesFirst()
 {
     pos = referenceFrame.Position;
     quater = referenceFrame.Quaternion;
     currentPosition = new Vector3((float)pos[0],
     (float)pos[1], (float)pos[2]);
     currentOrientation = quater.ToQuaternion();
     double[] om = angular.Omega;
     V.StaticExtensionVector3D.RotateOmega(om, 1, quater, nextQ, auxQ);
     nextOrientation = nextQ.ToQuaternion();
     nextPosition = currentPosition;
     startPosition = currentPosition;
     startOrientation = currentOrientation;
     lastTime = Time.realtimeSinceStartup;
     updatePosition = UpdateFrameSecond;
     scadaUpdate = ScadaUpdateFramesSecond;
 }

 void ScadaUpdateFramesSecond()
 {
     pos = referenceFrame.Position;
     quater = referenceFrame.Quaternion;
     currentPosition = new Vector3((float)pos[0],
     (float)pos[1], (float)pos[2]);
     currentOrientation = quater.ToQuaternion();
     double[] om = angular.Omega;
     V.StaticExtensionVector3D.RotateOmega(om, 1, quater, nextQ, auxQ);
     nextOrientation = nextQ.ToQuaternion();
     nextPosition = currentPosition;
     startPosition = currentPosition;
     startOrientation = currentOrientation;
     lastTime = Time.realtimeSinceStartup;
 }



 void UpdateFramesFirst()
 {
     gameObject.transform.position = currentPosition;
     gameObject.transform.rotation = currentOrientation;
 }

 void UpdateFrameSecond()
 {
     float dt = Time.realtimeSinceStartup - lastTime;
     if (dt > 0)
     {
         currentOrientation = Quaternion.Lerp(startOrientation, nextOrientation,
             dt);
     }
     gameObject.transform.position = currentPosition;
     gameObject.transform.rotation = currentOrientation;
 }

 */

