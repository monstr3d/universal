
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Motion6D.Interfaces;


using Scada.Interfaces;
using Scada.Desktop;

using Unity.Standard;

using System.Reflection;
using Unity.Standard.Interfaces;

public class ReferenceFrameBehavior : MonoBehaviour
{

    #region Fields

    public bool inheritCamera = true;

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

    Camera owncamera;

    public float Scale
    {
        get => globalScale;
        set
        {
            globalScale = value;
            SetCamera();
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

    IScadaInterface scada;

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
                Action act = UpdateGlobalScalePosition;// (globalScale == 1f) ? UpdatePosition : UpdateGlobalScalePosition;
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
        scada = monoBehaviorWrapper.Scada;
        motion6D = scada as Scada.Motion6D.ScadaDesktop;
        (monoBehaviorWrapper as IScadaUpdate).Update = null;
        //ScadaUpdate;
        wrapperUpdate = monoBehaviorWrapper.Update;
        var  frames  = monoBehaviorWrapper.Frames;
        if (frames.ContainsKey(transformation))
        {
            IReferenceFrame frame = frames[transformation];
            referenceFrame = frame.Own;
            Camera = motion6D.GetCamera(frame);
            SetCamera();
        }
        owncamera = gameObject.GetComponent<Camera>();
        SetCamera();
   
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
        Set(UpdateJump);
        StartCoroutine(jumpCoroutine);
    }


    #endregion

    #region  Private Members

    void SetCamera()
    {
        if (!inheritCamera)
        {
            return;
        }
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
            Set(UpdateGlobalScalePosition);
            yield return 0;
        }
    }

    void Set(Action act)
    {
        if (owncamera == null)
        {
            update = act;
            return;
        }
        lateUpdate = act;
    }
/*
    void UpdatePosition()
    {
        gameObject.transform.rotation = referenceFrame.ToQuaternion();
        gameObject.transform.position = referenceFrame.Position.ToPosition();
    }
*/

    void UpdateGlobalScalePosition()
    {
        gameObject.transform.rotation = referenceFrame.ToQuaternion();
        var p = referenceFrame.Position.ToPosition();
        gameObject.transform.position = p * globalScale;
    }


    void UpdateJump()
    {
        gameObject.transform.rotation = jump;
        gameObject.transform.position = referenceFrame.Position.ToPosition();
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
 

    #endregion
}


