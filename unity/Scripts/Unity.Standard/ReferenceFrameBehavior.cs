﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

using Motion6D.Interfaces;


using Scada.Interfaces;
using Scada.Desktop;

using Scada.Motion6D.Interfaces;

using Vector3D;

using Unity.Standard;

using Unity.Standard.Interfaces;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class ReferenceFrameBehavior : MonoBehaviour
{

    #region Fields

    

    protected Vector3DProcessor vp = new();


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

    public float jumpX = 1f;

    public float jumpY = 1f;

    public float jumpZ = 1f;

    public float jumpPause = 0.1f;



    public bool unique = true;

    private AudioSource audioSource;


    public AudioSource AudioSource
    {
        set => audioSource = value;
    }


    public float Scale
    {
        get => globalScale;
        set
        {
            globalScale = value;
        }
    }

    Motion6D.Portable.Camera Camera
    {
        get;
        set;
    } = null;

 
    private MonoBehaviourWrapper monoBehaviorWrapper;


    internal Dictionary<string, Action<double>>
        inps = new Dictionary<string, Action<double>>();

    internal Dictionary<string, Func<double?>> outs =
        new Dictionary<string, Func<double?>>();

    internal Action<double>[] dInp;

    internal Func<double?>[] dOut;

    Action update;

    Action lateUpdate;

    double[] quaternion = new double[4];


    public Scada.Motion6D.ScadaDesktop Scada
    {
        get;
        private set;
    }

    Scada.Motion6D.ScadaDesktop motion6D;

    Action<Collider> triggerEnter = (Collider c) => { };

    Action<Collision> collisionEnter = (Collision collision) => { };


    Action wrapperUpdate = null;

    ReferenceFrame referenceFrame;

    Action scadaUpdate;

    ICollisionAction collisionAction;

    bool exists = false;

    Quaternion jump;

    private static float globalScale = 1f;


    Camera owncamera;


    #endregion

    #region Standard Members

    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        
    }

   
    private void Awake()
    {
        globalScale = StaticExtensionUnity.GlobalScale;
        this.Add();
        MonoBehaviourTimerFactory.OnStart +=
            (string s) =>
            {
                if (desktop == s)
                {
                    SetConstants();
                    constants = new string[0];
                }
                var mirror = StaticExtensionUnity.Activation.mirror;
                Action act = mirror ? UpdateGlobalScalePositionMirror : UpdateGlobalScalePosition;// (globalScale == 1f) ? UpdatePosition : UpdateGlobalScalePosition;
                if (owncamera != null)
                {
                    lateUpdate = act;
                }
                else
                {
                    update = act;
                }
            };
        exists = desktop.ScadaExists();
        monoBehaviorWrapper =
           StaticExtensionUnity.Create(this, unique, step,
           desktop, inputs, outputs);
        Scada = monoBehaviorWrapper.Scada;
        motion6D = Scada as Scada.Motion6D.ScadaDesktop;
        (monoBehaviorWrapper as IScadaUpdate).Update = null;
        //ScadaUpdate;
        wrapperUpdate = monoBehaviorWrapper.Update;
        ICameraProvider p = motion6D;
        var cameras = p.Cameras;
        IReferenceFrame frame;
        if (cameras.ContainsKey(transformation))
        {
            Camera = cameras[transformation];
            frame = motion6D.GetFrame(Camera);
        }
        else if (motion6D.Frames.ContainsKey(transformation))
        {
            var frames = motion6D.Frames;
            frame = frames[transformation];
            Camera = motion6D.GetCamera(frame);
        }  
        else
        {
            IScadaInterface s = motion6D;
            var pos = s.GetObject<IPosition>(transformation);
            frame = pos.Parent;
        }
        referenceFrame = frame.Own;
        owncamera = gameObject.GetComponent<Camera>();
        SetCamera();
   
        if (onTriggerEnter.Length > 0)
        {
            ConstructorInfo c = StaticExtensionUnity.updatesTriggerAction[onTriggerEnter];
            ITriggerAction ta = c.Invoke(new Type[0]) as ITriggerAction;
            ta.Set(gameObject, Scada);
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
            collisionAction.Set(gameObject, collisionIndicator, Scada);
            collisionEnter = collisionAction.Action;
        }
    }


    // Start is called before the first frame update

    void Start()
    {
        if (collisionAction != null)
        {
            collisionAction.SetConstants(0, collisionConstants);
        }
        monoBehaviorWrapper.Start();
    }



    // Update is called once per frame

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
            if (audioSource != null)
            {
                audioSource.enabled = true; ;
                audioSource = null;
            }

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

    #region Public Members

    /// <summary>
    /// Jump
    /// </summary>
    public void Jump()
    {
        float[] f = new float[] { jumpX, jumpY, jumpZ };
        for (int i = 0; i < 3; i++)
        {
            float a = f[i];
            f[i] = UnityEngine.Random.Range(-a, a);
        }
        Quaternion j = Quaternion.Euler(f[0], f[1], f[2]);
        jump = gameObject.transform.rotation * j;
      //  Set(UpdateJump);
        StartCoroutine(jumpCoroutine);
    }


    #endregion

    #region  Private Members

    void SetCamera()
    {
        var c = Camera;
        if ((owncamera == null) | (c == null)) return;

        //        owncamera.aspect = (float)(c.Aspect);
        owncamera.farClipPlane = (float)c.FarPlaneDistance * globalScale;
        owncamera.nearClipPlane = (float)c.NearPlaneDistance * globalScale;
        owncamera.fieldOfView = (float)c.FieldOfView;
    }


    IEnumerator jumpCoroutine
    {
        get
        {
            yield return new WaitForSeconds(jumpPause);
            //Set(UpdateGlobalScalePosition);
            yield return 0;
        }
    }
    /*
        void Set(Action act)
        {
            if (owncamera == null)
            {
                update = act;
                return;
            }
            lateUpdate = act;
        }*/
    /*
        void UpdatePosition()
        {
            gameObject.transform.rotation = referenceFrame.ToQuaternion();
            gameObject.transform.position = referenceFrame.Position.ToPosition();
        }
    */



    void UpdateGlobalScalePositionMirror()
    {
        SetPositionMirror(referenceFrame);
        SetOrientationMirror(referenceFrame);
    }

    void UpdateGlobalScalePosition()
    {
        SetPosition(referenceFrame);
        var ori = referenceFrame.Quaternion;
        Quaternion q = new Quaternion((float)ori[1],
            (float)ori[2], (float)ori[3], (float)ori[0]);
        gameObject.transform.rotation = q;
    }


    void SetOrientationMirror(ReferenceFrame frame)
    {
        var ori = frame.Quaternion;
        Array.Copy(ori, quaternion, quaternion.Length);
        quaternion[1] = -ori[1];
        quaternion[2] = -ori[2];
        Quaternion q = new Quaternion((float)quaternion[1],
            (float)quaternion[2], (float)quaternion[3], (float)quaternion[0]);
        gameObject.transform.rotation = q;
    }
    
    void SetPosition(ReferenceFrame frame)
    {
        var vector = ToPosition(frame.Position);
        gameObject.transform.position = vector;
    }

    void SetPositionMirror(ReferenceFrame frame)
    {
        var vector = ToPositionMirror(frame.Position);
        gameObject.transform.position = vector;
    }


    Vector3 ToPositionMirror(double[] t)
    {
        return new Vector3((float)t[0], (float)t[1], -(float)t[2]);
    }


    Vector3 ToPosition(double[] t)
    {
        return new Vector3((float)t[0], (float)t[1], (float)t[2]);
    }







    void UpdateJump()
    {
        gameObject.transform.rotation = jump;
        gameObject.transform.position = referenceFrame.Position.ToPosition();
    }

    void SetConstants()
    {
        var consts = (Scada as IScadaInterface).Constants;
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
                    (Scada as IScadaInterface).SetConstant(ss[0], a);
                }

            }
        }
    }
 

    #endregion
}


